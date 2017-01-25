using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Sounds
{
    public partial class MainForm : Form
    {
        ToolStripTrackBar tb = new ToolStripTrackBar();
        MediaPlayer mp = new MediaPlayer();
        TagLib.File activeFile = null;
        // not if the MediaPlayer is, but if we should at all
        bool playing = false;

        bool repeat = false;

        string playlistFile = null;

        bool Paused
        {
            get
            {
                // HACK HACK
                try
                {
                    var mps = mp.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.Name == "_mediaPlayerState").First().GetValue(mp);
                    var paused = (bool)mps.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.Name == "_paused").First().GetValue(mps);
                    return paused;
                }
                catch (Exception)
                {
                    // god knows what could have gone wrong
                    return false;
                }
            }
        }

        double Volume
        {
            get
            {
                return mp.Volume;
            }
            set
            {
                mp.Volume = value;
                tb.Value = Convert.ToInt32(mp.Volume * 100);
                var simplePercent = new CultureInfo(CultureInfo.InvariantCulture.Name);
                simplePercent.NumberFormat.PercentDecimalDigits = 0;
                simplePercent.NumberFormat.PercentPositivePattern = 1;
                volumeButton.Text = string.Format(simplePercent, "{0:P}", mp.Volume);
                UpdateMenus();
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // construct volume widget
            tb.Maximum = 100;
            tb.TickFrequency = 10;
            tb.Scroll += (o, e) =>
            {
                Volume = tb.Value / 100d;
            };
            // a new dropdown w/ a system rendering looks more like a panel
            var dd = new ToolStripDropDown();
            dd.RenderMode = ToolStripRenderMode.System;
            dd.Items.Add(tb);
            volumeButton.DropDown = dd;

            // do initial init of menubar and such
            UpdateMenus();
            mp.MediaEnded += (o, e) =>
            {
                // avoid race coondition
                trackBarSyncTimer.Enabled = false;
                if (playing)
                    Next();
            };
            mp.MediaFailed += (o, e) =>
            {
                Stop();
                errorMessageLabel.Text = e.ErrorException.Message;
            };
            mp.MediaOpened += (o, e) =>
            {
                if (mp.NaturalDuration.HasTimeSpan)
                {
                    positionTrackBar.Maximum = Convert.ToInt32(mp.NaturalDuration.TimeSpan.TotalSeconds);
                    positionTrackBar.Enabled = true;
                    trackBarSyncTimer.Enabled = true;
                }
                else
                {
                    trackBarSyncTimer.Enabled = false;
                    positionTrackBar.Enabled = false;
                }
            };

            // mp's value is, but not the UI bits; do this to update them
            Volume = 0.50;
        }
        
        public void AddFile(string fileName)
        {
            try
            {
                var f = TagLib.File.Create(fileName);
                if (f.Properties?.MediaTypes != TagLib.MediaTypes.Audio)
                {
                    // we don't want it
                    return;
                }
                var lvi = new ListViewItem();
                // fall back to filename
                lvi.Text = f.Tag.Title ?? f.Name;
                lvi.SubItems.Add(f.Tag.Track.ToString());
                lvi.SubItems.Add(f.Tag.Album);
                lvi.SubItems.Add(f.Tag.Performers.Count() > 0 ? f.Tag.Performers?[0] : string.Empty);
                lvi.Tag = f;
                listView1.Items.Add(lvi);
            }
            catch (TagLib.UnsupportedFormatException)
            {
                // not needed
            }
            finally
            {
                UpdateMenus();
            }
        }

        public void AddDirectory(string name)
        {
            foreach (var f in Directory.EnumerateFiles(name))
            {
                AddFile(f);
            }
        }

        public void PlayAndSet(bool playSelected)
        {
            if (!playSelected && Paused)
            {
                mp.Play();
                UpdateMenus();
            }
            else
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    activeFile = (TagLib.File)listView1.SelectedItems[0].Tag;
                }
                else if (listView1.Items.Count > 0)
                {
                    activeFile = (TagLib.File)listView1.Items[0].Tag;
                }
                else return;

                playing = true;

                PlayActive();
            }
        }

        public void PlayActive()
        {
            mp.Open(new Uri(activeFile.Name));
            mp.Play();
            UpdateUI();
            UpdateMenus();
        }

        public void Pause()
        {
            mp.Pause();
            UpdateMenus();
        }

        public void PlayPauseToggle()
        {
            if (!playing || Paused)
                PlayAndSet(false);
            else if (playing)
                Pause();
            UpdateMenus();
        }

        // Metadata and such
        public void UpdateUI()
        {
            if (activeFile != null)
            {
                var title = activeFile.Tag.Title;
                var album = activeFile.Tag.Album;
                var artist = activeFile.Tag.Performers?[0];

                // fill out metadata
                Text = string.Format("{0} - {1}", title, artist);

                titleLabel.Text = title;
                albumLabel.Text = album;
                artistLabel.Text = artist;

                // generating an image can be complicated
                var pictureStream = activeFile.Tag.Pictures.Where(x => x.Type == TagLib.PictureType.FrontCover).FirstOrDefault()?.Data?.Data;
                using (var ms = new MemoryStream(pictureStream))
                {
                    var b = Image.FromStream(ms);
                    albumArtBox.Image = b;
                }

                // embolden the active song
                listView1.Items.Cast<ListViewItem>().First(x => x.Tag == activeFile).Font = new Font(listView1.Font, FontStyle.Bold);
            }
            else
            {
                // nop it out
                Text = "Sounds";
                titleLabel.Text = string.Empty;
                albumLabel.Text = string.Empty;
                artistLabel.Text = string.Empty;

                positionLabel.Text = string.Empty;

                albumArtBox.Image = null;
            }

            // we can run this regardless
            errorMessageLabel.Text = string.Empty;
            foreach (var lvi in listView1.Items.Cast<ListViewItem>().Where(x => x.Tag != activeFile))
            {
                lvi.Font = listView1.Font;
            }
        }

        public void UpdateMenus()
        {
            var selected = listView1.SelectedItems.Count > 0;
            var any = listView1.Items.Count > 0;

            removeSelectedToolStripMenuItem.Enabled = selected;
            propertiesToolStripMenuItem.Enabled = playing || any;
            shuffleToolStripMenuItem.Enabled = any;

            var canPlay = playing ? Paused : any;
            var canPause = playing ? !Paused : false;

            playToolStripMenuItem.Enabled = canPlay;
            pauseToolStripMenuItem.Enabled = canPause;
            stopToolStripMenuItem.Enabled = playing;
            playToolStripMenuItem.Checked = playing && !Paused;
            pauseToolStripMenuItem.Checked = playing && Paused;
            stopToolStripMenuItem.Checked = !playing;

            previousToolStripMenuItem.Enabled = playing;
            nextToolStripMenuItem.Enabled = playing;

            volumeUpToolStripMenuItem.Enabled = Volume + 0.1 <= 1;
            volumeDownToolStripMenuItem.Enabled = Volume - 0.1 >= 0;
            muteToolStripMenuItem.Enabled = Volume > 0;
        }

        public void Stop()
        {
            trackBarSyncTimer.Enabled = false;
            mp.Stop();
            mp.Close();
            playing = false;
            activeFile = null;

            UpdateUI();
            UpdateMenus();
        }

        public void Previous()
        {
            activeFile = (TagLib.File)listView1.Items.Cast<ListViewItem>().TakeWhile(x => x.Tag != activeFile).LastOrDefault()?.Tag;
            if (activeFile != null && playing)
            {
                PlayActive();
            }
            else
            {
                Stop();
            }
        }

        public void Next()
        {
            activeFile = (TagLib.File)listView1.Items.Cast<ListViewItem>().SkipWhile(x => x.Tag != activeFile).Skip(1).FirstOrDefault()?.Tag;
            if (activeFile != null && playing)
            {
                PlayActive();
            }
            else if (playing && repeat)
            {
                activeFile = (TagLib.File)listView1.Items.Cast<ListViewItem>().FirstOrDefault().Tag;
                if (activeFile != null)
                {
                    PlayActive();
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                Stop();
            }
        }

        public void Shuffle()
        {
            var r = new Random();
            for (int n = listView1.Items.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                var temp = (ListViewItem)listView1.Items[n].Clone();
                listView1.Items[n] = (ListViewItem)listView1.Items[k].Clone();
                listView1.Items[k] = temp;
            }
        }

        public void NewPlaylist()
        {
            Stop();
            playlistFile = null;
            listView1.Items.Clear();
        }

        public void SavePlaylist(bool forceDialog)
        {
            if (forceDialog || string.IsNullOrEmpty(playlistFile))
            {
                if (savePlaylistDialog.ShowDialog(this) == DialogResult.OK)
                {
                    playlistFile = savePlaylistDialog.FileName;
                }
                else return;
            }

            var lines = listView1.Items.Cast<ListViewItem>().Select(x => ((TagLib.File)x.Tag).Name);
            File.WriteAllLines(playlistFile, lines.ToArray());
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addFilesDialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var f in addFilesDialog.FileNames)
                {
                    AddFile(f);
                }
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayAndSet(false);
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void trackBarSyncTimer_Tick(object sender, EventArgs e)
        {
            var value = Convert.ToInt32(mp.Position.TotalSeconds);
            // only update the trackbar if value =< max, to avoid races
            if (positionTrackBar.Maximum >= value)
            {
                positionTrackBar.Value = value;
            }

            if (mp.NaturalDuration.HasTimeSpan)
            {
                positionLabel.Text = string.Format("{0} / {1}",
                    mp.Position, mp.NaturalDuration.TimeSpan);
            }
            else
            {
                positionLabel.Text = string.Format("{0}",
                    mp.Position);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // this is only invoked when the user scrolls
            mp.Position = new TimeSpan(0, 0, 0, positionTrackBar.Value);
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Cast<ListViewItem>().Any(x => x.Tag == activeFile))
                Stop();

            foreach (ListViewItem lvi in listView1.SelectedItems)
                listView1.Items.Remove(lvi);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPlaylist();
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPlaylist();
            if (openPlaylistDialog.ShowDialog(this) == DialogResult.OK)
            {
                var text = File.ReadAllText(openPlaylistDialog.FileName);
                var splitText = Regex.Split(text, @"\r?\n");
                foreach (var f in M3UParser.Parse(splitText))
                {
                    AddFile(f);
                }
                playlistFile = openPlaylistDialog.FileName;
            }
        }

        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePlaylist(false);
        }

        private void savePlaylistAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePlaylist(true);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagLib.File item = activeFile;

            if (listView1.SelectedItems.Count > 0)
                item = (TagLib.File)listView1.SelectedItems[0].Tag;

            new PropertiesForm(item).Show(this);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMenus();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            PlayAndSet(true);
        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                AddDirectory(folderBrowserDialog1.SelectedPath);
            }
        }

        private void repeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repeat = repeatToolStripMenuItem.Checked;
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.AllowedEffect == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var data = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (var f in data)
                    {
                        if (Directory.Exists(f))
                        {
                            AddDirectory(f);
                        }
                        else if(File.Exists(f))
                        {
                            AddFile(f);
                        }
                    }
                }
            }
            else if (e.Effect == DragDropEffects.Move)
            {
                var cp = listView1.PointToClient(new Point(e.X, e.Y));
                ListViewItem dragToItem = listView1.GetItemAt(cp.X, cp.Y);
                if (!listView1.SelectedItems.Contains(dragToItem))
                {
                    var selectedItems = listView1.SelectedItems.Cast<ListViewItem>().ToList();

                    var dropIndex = dragToItem?.Index ?? listView1.Items.Count;

                    foreach (var i in selectedItems)
                        listView1.Items.Insert(dropIndex++, (ListViewItem)i.Clone());

                    foreach (var i in selectedItems)
                        i.Remove();
                }

            }
        }

        private void volumeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volume += 0.1;
        }

        private void volumeDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volume -= 0.1;
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volume = 0;
        }

        private void togglePlaybackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayPauseToggle();
        }
    }
}
