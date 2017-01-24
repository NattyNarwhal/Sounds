using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Sounds
{
    public partial class MainForm : Form
    {
        MediaPlayer mp = new MediaPlayer();
        TagLib.File activeFile = null;
        // not if the MediaPlayer is, but if we should at all
        bool playing = false;

        string playlistFile = null;

        public MainForm()
        {
            InitializeComponent();
            UpdateMenus();
            mp.MediaEnded += (o, e) =>
            {
                if (playing)
                    Next();
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
        }
        
        public void AddFile(string fileName)
        {
            var f = TagLib.File.Create(fileName);
            if (f.Properties.MediaTypes != TagLib.MediaTypes.Audio)
            {
                // we don't want it
                return;
            }
            var lvi = new ListViewItem();
            lvi.Text = f.Tag.Title;
            lvi.SubItems.Add(f.Tag.Track.ToString());
            lvi.SubItems.Add(f.Tag.Album);
            lvi.SubItems.Add(f.Tag.Performers?[0]);
            lvi.Tag = f;
            listView1.Items.Add(lvi);
        }

        public void PlayAndSet()
        {
            if (playing)
            {
                mp.Play();
            }
            else
            {
                playing = true;

                if (listView1.SelectedItems.Count > 0)
                {
                    activeFile = (TagLib.File)listView1.SelectedItems[0].Tag;
                }
                else if (listView1.Items.Count > 0)
                {
                    activeFile = (TagLib.File)listView1.Items[0].Tag;
                }
                else return;

                PlayActive();
            }
        }

        public void PlayActive()
        {
            mp.Open(new Uri(activeFile.Name));
            mp.Play();
            UpdateUI();
        }

        public void Pause()
        {
            mp.Pause();
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
            foreach (var lvi in listView1.Items.Cast<ListViewItem>().Where(x => x.Tag != activeFile))
            {
                lvi.Font = listView1.Font;
            }
        }

        public void UpdateMenus()
        {
            var selected = listView1.SelectedItems.Count > 0;
            removeSelectedToolStripMenuItem.Enabled = selected;
            propertiesToolStripMenuItem.Enabled = selected;
            playToolStripMenuItem.Enabled = !playing && selected;
        }

        public void Stop()
        {
            trackBarSyncTimer.Enabled = false;
            mp.Stop();
            mp.Close();
            playing = false;
            activeFile = null;

            UpdateUI();
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
            else
            {
                Stop();
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
            PlayAndSet();
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
            positionTrackBar.Value = Convert.ToInt32(mp.Position.TotalSeconds);
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
            if (listView1.SelectedItems.Count > 0)
                new PropertiesForm((TagLib.File)listView1.SelectedItems[0].Tag).Show(this);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMenus();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            PlayAndSet();
        }
    }
}
