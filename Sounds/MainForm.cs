using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        TabbedThumbnail preview;
        ThumbnailToolBarButton playPauseTaskbarButton;
        ThumbnailToolBarButton prevTaskbarButton;
        ThumbnailToolBarButton nextTaskbarButton;

        // some take Icons, not Bitmaps
        Icon stopIcon = Icon.FromHandle(Properties.Resources.Stop.GetHicon());
        Icon playIcon = Icon.FromHandle(Properties.Resources.Play.GetHicon());
        Icon prevIcon = Icon.FromHandle(Properties.Resources.Previous.GetHicon());
        Icon nextIcon = Icon.FromHandle(Properties.Resources.Next.GetHicon());
        Icon pauseIcon = Icon.FromHandle(Properties.Resources.Pause.GetHicon());

        bool showInfoPane = true;
        bool showToolBar = true;
        bool showStatusBar = true;

        ToolStripTrackBar tb = new ToolStripTrackBar();
        MediaPlayer mp = new MediaPlayer();
        TagLib.File activeFile = null;
        // not if the MediaPlayer is, but if we should at all
        bool playing = false;
        double vol; // we need to keep this ourselves; mp.Stop resets mp.Volume

        // setings
        int volIncrement = 5; // for trackbar/keyboard
        int timeIncrement = 15;
        bool repeat = false;
        bool deleteOnNext = false;
        bool recursive = false;
        bool showDialogs;

        string playlistFile = null;
        bool dirty = false;

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
                return vol;
            }
            set
            {
                // clamp value
                vol = Math.Min(Math.Max(value, 0), 1);
                mp.Volume = vol;
                tb.Value = Convert.ToInt32(mp.Volume * 100);
                var simplePercent = new CultureInfo(CultureInfo.InvariantCulture.Name);
                simplePercent.NumberFormat.PercentDecimalDigits = 0;
                simplePercent.NumberFormat.PercentPositivePattern = 1;
                volumeButton.Text = string.Format(simplePercent, "{0:P}", mp.Volume);
                volumeStatusButton.Text = string.Format(simplePercent, "{0:P}", mp.Volume);
                UpdateMenus();
            }
        }

        int VolumeIncrement
        {
            get { return volIncrement; }
            set
            {
                volIncrement = value;
                tb.LargeChange = VolumeIncrement;
            }
        }

        int TimeIncrement
        {
            get { return timeIncrement; }
            set
            {
                timeIncrement = value;
                positionTrackBar.LargeChange = TimeIncrement;
            }
        }

        public MainForm()
        {
#if ForceJA
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
#endif
            InitializeComponent();
            // native ToolStrips
            if (Properties.Settings.Default.NativeToolStripRendering)
                ToolStripManager.Renderer = new ToolStripAeroRenderer(ToolbarTheme.Toolbar);
            // the designer doesn't want to use icons from resource files
            Icon = Properties.Resources.AppIcon;
            // load settings
            showToolBar = Properties.Settings.Default.ShowToolBar;
            showStatusBar = Properties.Settings.Default.ShowStatusBar;
            showInfoPane = Properties.Settings.Default.ShowInfoPane;
            deleteOnNext = Properties.Settings.Default.DeleteOnNext;
            repeat = Properties.Settings.Default.Repeat;
            VolumeIncrement = Properties.Settings.Default.VolumeShortcutIncrement;
            TimeIncrement = Properties.Settings.Default.TimeShortcutSeconds;
            recursive = Properties.Settings.Default.AddFolderRecursive;
            showDialogs = Properties.Settings.Default.ShowConfirmationDialogs;

            if (TaskbarManager.IsPlatformSupported)
            {
                preview = new TabbedThumbnail(Handle, toolStripContainer1.Handle);
                preview.SetWindowIcon(Properties.Resources.AppIcon);
                preview.DisplayFrameAroundBitmap = true;
                preview.Title = Text;
                TaskbarManager.Instance.TabbedThumbnail.AddThumbnailPreview(preview);
                preview.TabbedThumbnailBitmapRequested += (o, ev) =>
                {
                    // TODO: This seems to be a bit slow on the uptake
                    if (playing)
                    {
                        preview.SetImage(AlbumArt);
                    }
                    else
                    {
                        // HACK: the preview code is horribly broken with
                        // minimized forms, try to contain it?
                        if (WindowState == FormWindowState.Minimized)
                        {
                            // desperate measures to stop an NRE
                            using (var empty = new Bitmap(RestoreBounds.Width, RestoreBounds.Height))
                            {
                                preview.SetImage(empty);
                            }
                        }
                        else
                            preview.InvalidatePreview();
                    }
                    ev.Handled = true;
                };
                // Because we're using a thumbnail preview, we need to handle these
                preview.TabbedThumbnailMinimized += (o, ev) => WindowState = FormWindowState.Minimized;
                preview.TabbedThumbnailClosed += (o, ev) => Close();
                preview.TabbedThumbnailActivated += (o, ev) =>
                {
                    if (WindowState == FormWindowState.Minimized)
                        WindowState = FormWindowState.Normal;
                    Activate();
                };
                preview.TabbedThumbnailMaximized += (o, ev) => WindowState = FormWindowState.Maximized;

                // finally, wire up the buttons
                playPauseTaskbarButton = new ThumbnailToolBarButton(playIcon, playToolStripButton.Text);
                playPauseTaskbarButton.Click += (o, ev) => PlayPauseToggle();
                prevTaskbarButton = new ThumbnailToolBarButton(prevIcon, previousToolStripButton.Text);
                prevTaskbarButton.Click += (o, ev) => Previous();
                nextTaskbarButton = new ThumbnailToolBarButton(nextIcon, nextToolStripButton.Text);
                nextTaskbarButton.Click += (o, ev) => Next();

                TaskbarManager.Instance.ThumbnailToolBars.AddButtons(toolStripContainer1.Handle,
                    prevTaskbarButton, playPauseTaskbarButton, nextTaskbarButton);
            }

            // construct volume widget
            tb.Maximum = 100;
            tb.TickFrequency = 10;
            //tb.LargeChange = volIncrement;
            tb.Scroll += (o, e) =>
            {
                Volume = tb.Value / 100d;
            };
            // a new dropdown w/ a system rendering looks more like a panel
            var dd = new ToolStripDropDown();
            dd.RenderMode = ToolStripRenderMode.System;
            dd.Items.Add(tb);
            volumeButton.DropDown = dd;
            volumeStatusButton.DropDown = dd;

            mp.MediaEnded += (o, e) =>
            {
                // avoid race coondition
                if (!repeat)
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
                    positionTrackBar.Visible = true;
                    trackBarSyncTimer.Enabled = true;
                }
                else
                {
                    trackBarSyncTimer.Enabled = false;
                    positionTrackBar.Enabled = false;
                    positionTrackBar.Visible = false;
                }
            };

            // finally init UI by creating PL (args will override it)
            NewPlaylist();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // we need to do it when the form is visible so taskbar updates work
            // do initial init of menubar and such
            UpdateMenus();
            UpdateUI();
            UpdateTitle();
            // mp's value is, but not the UI bits; do this to update them
            Volume = 0.50;
        }

        public void DeleteSelected()
        {
            if (listView1.SelectedItems.Cast<ListViewItem>().Any(x => x.Tag == activeFile))
                Stop();

            foreach (ListViewItem lvi in listView1.SelectedItems)
                listView1.Items.Remove(lvi);

            Dirty = true;
            UpdatePlaylistTotal();
        }

        public void AddFile(string fileName, bool update = true)
        {
            // HACK: ignore Mac droppings that confuse TagLib when we get
            // aggressive with adding directories. (consider making a pref?)
            if (Path.GetFileName(fileName).StartsWith("._"))
                return;

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
                var trackNumber = f.Tag.TrackCount > 0 ?
                    string.Format("{0}/{1}", f.Tag.Track, f.Tag.TrackCount)
                    : f.Tag.Track.ToString();
                if (f.Tag.Disc > 0)
                    trackNumber += f.Tag.DiscCount > 0 ?
                        string.Format(" ({0}/{1})", f.Tag.Disc, f.Tag.DiscCount)
                        : string.Format(" ({0})" ,f.Tag.Disc.ToString());
                lvi.SubItems.Add(trackNumber);
                lvi.SubItems.Add(f.Tag.Album);
                lvi.SubItems.Add(f.Tag.Performers.Count() > 0 ? f.Tag.Performers?[0] : string.Empty);
                lvi.UseItemStyleForSubItems = false;
                lvi.ToolTipText = f.Name;
                lvi.Tag = f;
                listView1.Items.Add(lvi);
            }
            catch (TagLib.UnsupportedFormatException)
            {
                // not needed
            }
            catch (TagLib.CorruptFileException)
            {
                // should warn the user
            }
            finally
            {
                Dirty = true; // will get unset by Open if so
                if (update)
                {
                    UpdateMenus();
                    UpdatePlaylistTotal();
                }
            }
        }

        public void AddDirectory(string name)
        {
            if (recursive)
            {
                foreach (var f in Directory.EnumerateFiles(name).OrderBy(x => x)
                    .Concat(Directory.EnumerateDirectories(name).OrderBy(x => x)))
                {
                    AddItem(f, false);
                }
            }
            else
            {
                foreach (var f in Directory.EnumerateFiles(name).OrderBy(x => x))
                {
                    AddFile(f, false);
                }
            }
            UpdateMenus();
            UpdatePlaylistTotal();
        }

        public void AddItem(string name, bool update = false)
        {
            if (Directory.Exists(name))
            {
                AddDirectory(name);
            }
            else if (File.Exists(name))
            {
                AddFile(name, update);
            }
        }

        void DeleteOnChange(TagLib.File old)
        {
            if (deleteOnNext && old != null)
            {
                listView1.Items.Cast<ListViewItem>().Where(x => x.Tag == old).First().Remove();
                Dirty = listView1.Items.Count > 0 && playlistFile != null;
                UpdatePlaylistTotal();
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
                var oldActiveFile = activeFile;
                DeleteOnChange(oldActiveFile);

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

        /// <summary>
        /// Plays the song set as the active track.
        /// </summary>
        /// <remarks>
        /// It's the caller's responsibility to set the active track.
        /// </remarks>
        public void PlayActive()
        {
#pragma warning disable CS0618
            // HACK: It's deprecated, but MediaPlayer doesn't like escaped URIs
            var u = new Uri(activeFile.Name, true);
#pragma warning restore CS0618
            mp.Open(u);
            mp.Volume = vol; // as Stop might have reset it
            mp.Play();
            UpdateTitle();
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

        public void UpdateTitle()
        {
            var fileNameTitle = string.IsNullOrEmpty(playlistFile) ?
                MiscStrings.untitledPlaylist : Path.GetFileName(playlistFile);
            // Recommended if dirty if turned into a property?
            var fileNameFinalTitle = string.Format("{0}{1}",
                fileNameTitle, Dirty ? "*" : "");
            if (activeFile != null)
            {
                var title = activeFile.Tag.Title;
                var album = activeFile.Tag.Album;
                var artist = activeFile.Tag.Performers.Count() > 0 ?
                    activeFile.Tag.Performers[0] : string.Empty;
                
                if (title != null && album != null)
                    Text = string.Format("{0} - {1} [{2}]",
                        title, artist, fileNameFinalTitle);
                else
                    Text = string.Format("{0} [{1}]",
                        activeFile.Name, fileNameFinalTitle);

                // fill out metadata
                if (TaskbarManager.IsPlatformSupported)
                {
                    preview.Title = Text;
                    preview.Tooltip = Text;
                    preview.SetImage(AlbumArt);
                }
            }
            else
            {
                // nop it out
                Text = fileNameFinalTitle;

                if (TaskbarManager.IsPlatformSupported)
                {
                    preview.InvalidatePreview();
                    preview.Title = Text;
                    preview.Tooltip = Text;
                }
            }
        }

        // Metadata and such
        // TODO: needs optimization. profiler says we're churning, but
        // album art is fine. My guess is emboldening. [album art change
        // moved to Title.]
        public void UpdateUI()
        {
            if (activeFile != null)
            {
                var title = activeFile.Tag.Title;
                var album = activeFile.Tag.Album;
                var artist = activeFile.Tag.Performers.Count() > 0 ?
                    activeFile.Tag.Performers[0] : string.Empty;

                titleLabel.Text = title ?? activeFile.Name;
                albumLabel.Text = album;
                artistLabel.Text = artist;

                albumArtBox.Image = AlbumArt;

                panel1.Visible = showInfoPane;

                // embolden the active song
                var newBoldItem = listView1.Items.Cast<ListViewItem>().FirstOrDefault(x => x.Tag == activeFile);
#if DEBUG
                if (newBoldItem == null)
                    System.Diagnostics.Debugger.Break();
#endif
                if (newBoldItem != null)
                    newBoldItem.Font = new Font(listView1.Font, FontStyle.Bold);
            }
            else
            {
                // nop it out
                titleLabel.Text = string.Empty;
                albumLabel.Text = string.Empty;
                artistLabel.Text = string.Empty;

                positionLabel.Text = string.Empty;
                positionTrackBar.Enabled = false;
                positionTrackBar.Visible = false;

                albumArtBox.Image = null;

                panel1.Visible = false;

                if (TaskbarManager.IsPlatformSupported)
                {
                    preview.InvalidatePreview();
                    preview.Title = Text;
                    preview.Tooltip = Text;
                }
            }

            // we can run this regardless
            statusStrip1.Visible = showStatusBar;
            toolStrip1.Visible = showToolBar;
            volumeStatusButton.Enabled = !showToolBar;
            volumeStatusButton.Visible = !showToolBar;
            errorMessageLabel.Text = string.Empty;
            foreach (var lvi in listView1.Items.Cast<ListViewItem>().Where(x => x.Tag != activeFile))
            {
                lvi.Font = listView1.Font;
            }
        }

        public Bitmap AlbumArt
        {
            get
            {
                // generating an image can be complicated
                var pictureStream = activeFile.Tag.Pictures.Where(x => x.Type == TagLib.PictureType.FrontCover).FirstOrDefault()?.Data?.Data;
                if (pictureStream != null)
                {
                    using (var ms = new MemoryStream(pictureStream))
                    {
                        var b = new Bitmap(Image.FromStream(ms));
                        return b;
                    }
                }
                else
                {
                    // reasonable fallback
                    if (activeFile != null)
                    {
                        var containing = Path.GetDirectoryName(activeFile.Name);
                        // TODO, add more of these, and make them more scalable
                        // also figure out how to integrate this into the properties dialog
                        if (File.Exists(Path.Combine(containing, "cover.jpg")))
                        {
                            return new Bitmap(Path.Combine(containing, "cover.jpg"));
                        }
                        else if (File.Exists(Path.Combine(containing, "front.jpg")))
                        {
                            return new Bitmap(Path.Combine(containing, "front.jpg"));
                        }
                        else if (File.Exists(Path.Combine(containing, "folder.jpg")))
                        {
                            return new Bitmap(Path.Combine(containing, "folder.jpg"));
                        }
                    }
                    return new Bitmap(100, 100);
                }
            }
        }

        public bool Dirty
        {
            get
            {
                return dirty;
            }

            set
            {
                dirty = value;
                UpdateTitle();
                UpdateMenus();
            }
        }

        public void UpdateMenus()
        {
            var selected = listView1.SelectedItems.Count > 0;
            var any = listView1.Items.Count > 0;
            var atLeastTwo = listView1.Items.Count > 1;

            savePlaylistToolStripMenuItem.Enabled = Dirty;

            removeSelectedToolStripMenuItem.Enabled = selected;
            propertiesToolStripMenuItem.Enabled = playing || selected;
            shuffleToolStripMenuItem.Enabled = atLeastTwo;

            var canPlay = playing ? Paused : any;
            var canPause = playing ? !Paused : false;
            // localizable!
            var toggleDesc = TypeDescriptor.GetConverter(typeof(Keys))
                .ConvertToString(Keys.Control | Keys.Space);
            
            playToolStripMenuItem.Enabled = canPlay;
            playToolStripMenuItem.ShortcutKeyDisplayString =
                canPlay ? toggleDesc : string.Empty;
            pauseToolStripMenuItem.Enabled = canPause;
            pauseToolStripMenuItem.ShortcutKeyDisplayString =
                canPause ? toggleDesc : string.Empty;
            stopToolStripMenuItem.Enabled = playing;
            stopToolStripButton.Enabled = playing;
            playToolStripMenuItem.Checked = playing && !Paused;
            pauseToolStripMenuItem.Checked = playing && Paused;
            stopToolStripMenuItem.Checked = !playing;

            previousToolStripMenuItem.Enabled = playing;
            nextToolStripMenuItem.Enabled = playing;
            rewindToolStripMenuItem.Enabled = playing;
            skipAheadToolStripMenuItem.Enabled = playing;

            playToolStripButton.Enabled = canPlay;
            // ensure visibility in all cases
            playToolStripButton.Visible = canPlay || !playing;
            pauseToolStripButton.Enabled = canPause;
            pauseToolStripButton.Visible = canPause;
            previousToolStripButton.Enabled = playing;
            nextToolStripButton.Enabled = playing;

            volumeUpToolStripMenuItem.Enabled = Volume != 1;
            volumeDownToolStripMenuItem.Enabled = Volume != 0;
            muteToolStripMenuItem.Enabled = Volume > 0;

            playContextToolStripMenuItem.Enabled = selected;
            propertiesContextToolStripMenuItem.Enabled = selected;
            removeContextToolStripMenuItem.Enabled = selected;
            removeSelectedToolStripButton.Enabled = selected;

            repeatToolStripMenuItem.Checked = repeat;

            // TODO: make these translatable messages
            if (TaskbarManager.IsPlatformSupported)
            {
                prevTaskbarButton.Enabled = playing;
                nextTaskbarButton.Enabled = playing;
                if (playing && canPause)
                {
                    playPauseTaskbarButton.Icon = pauseIcon;
                    playPauseTaskbarButton.Tooltip = pauseToolStripButton.Text;
                    playPauseTaskbarButton.Enabled = true;
                }
                else if (playing && canPlay)
                {
                    playPauseTaskbarButton.Icon = playIcon;
                    playPauseTaskbarButton.Tooltip = playToolStripButton.Text;
                    playPauseTaskbarButton.Enabled = true;
                }
                else
                {
                    playPauseTaskbarButton.Enabled = false;
                }
            }

            // status bar/task bar icon image
            if (!playing)
            {
                positionLabel.Image = Properties.Resources.Stop;
                if (TaskbarManager.IsPlatformSupported && Visible)
                {
                    TaskbarManager.Instance.SetOverlayIcon(stopIcon, MiscStrings.stopped);
                }
            }
            else if (playing && Paused)
            {
                positionLabel.Image = Properties.Resources.Pause;
                if (TaskbarManager.IsPlatformSupported && Visible)
                {
                    TaskbarManager.Instance.SetOverlayIcon(pauseIcon, MiscStrings.paused);
                }
            }
            else if (playing && !Paused)
            {
                positionLabel.Image = Properties.Resources.Play;
                if (TaskbarManager.IsPlatformSupported && Visible)
                {
                    TaskbarManager.Instance.SetOverlayIcon(playIcon, MiscStrings.playing);
                }
            }
        }

        public void UpdatePlaylistTotal()
        {
            var plTotal = listView1.Items.Cast<ListViewItem>().Sum(x => ((TagLib.File)x.Tag).Properties.Duration.TotalSeconds);
            var plTotalSpan = new TimeSpan(0, 0, Convert.ToInt32(plTotal));
            playlistTotalLabel.Text = plTotalSpan.ToString();
        }

        public void Stop()
        {
            trackBarSyncTimer.Enabled = false;
            mp.Stop();
            mp.Close();
            playing = false;
            activeFile = null;

            UpdateTitle();
            UpdateUI();
            UpdateMenus();
        }

        public void Previous()
        {
            var oldActiveFile = activeFile;
            activeFile = (TagLib.File)listView1.Items.Cast<ListViewItem>().TakeWhile(x => x.Tag != activeFile).LastOrDefault()?.Tag;
            DeleteOnChange(oldActiveFile);

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
            var oldActiveFile = activeFile;
            activeFile = (TagLib.File)listView1.Items.Cast<ListViewItem>().SkipWhile(x => x.Tag != activeFile).Skip(1).FirstOrDefault()?.Tag;
            DeleteOnChange(oldActiveFile);

            if (activeFile != null && playing)
            {
                PlayActive();
            }
            else if (playing && repeat)
            {
                activeFile = (TagLib.File)listView1.Items.Cast<ListViewItem>().FirstOrDefault()?.Tag;
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

        public void ShowPropertiesDialog(bool forcePlayingSong)
        {
            if (!forcePlayingSong && listView1.SelectedItems.Count > 0)
            {
                new PropertiesForm(listView1.SelectedItems.Cast<ListViewItem>().Select(x => (TagLib.File)x.Tag).ToArray()).Show(this);
            }
            else if (playing)
            {
                new PropertiesForm(activeFile).Show(this);
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
            Dirty = true;
        }

        public void NewPlaylist()
        {
            Stop();
            playlistFile = null;
            Dirty = false;
            listView1.Items.Clear();
            UpdateTitle();
            UpdatePlaylistTotal();
        }

        public void OpenPlaylist(string fileName, bool append = false)
        {
            if (!append)
            {
                NewPlaylist();
                playlistFile = fileName;
            }

            var text = File.ReadAllText(fileName);
            var splitText = Regex.Split(text, @"\r?\n");
            foreach (var f in M3UParser.Parse(splitText, Path.GetDirectoryName(fileName)))
            {
                AddItem(f);
            }
            Dirty = append; // appending always dirty, opening is not
            UpdateTitle();
            UpdateMenus(); // as we set dirty bit
            UpdatePlaylistTotal();
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

            var files = listView1.Items.Cast<ListViewItem>().Select(x => (TagLib.File)x.Tag);
            // TODO: this should resolve the lowest common denominator root
            // instead of only tolerating a single shared root
            var hasSharedRoot = files.ToLookup(x => Path.GetDirectoryName(x.Name)).Count() == 1 &&
                Path.GetDirectoryName(files.FirstOrDefault()?.Name) == Path.GetDirectoryName(playlistFile);

            var toWrite = new StringBuilder();
            toWrite.AppendLine("#EXTM3U");
            foreach (var f in files)
            {
                // write an EXT tag if we have the metadata for it
                if (f.Tag.Title != null && f.Tag.AlbumArtists.Length > 0)
                {
                    toWrite.AppendLine(string.Format("#EXTINF:{0},{1} - {2}",
                        Math.Round(f.Properties.Duration.TotalSeconds),
                        f.Tag.AlbumArtists.FirstOrDefault(), f.Tag.Title));
                }
                if (hasSharedRoot)
                {
                    toWrite.AppendLine(Path.GetFileName(f.Name));
                }
                else
                {
                    toWrite.AppendLine(f.Name);
                }
            }
            File.WriteAllText(playlistFile, toWrite.ToString(), Encoding.UTF8);
            Dirty = false;
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
            // the Stop function is called by Next and such which will call
            // delete themselves. if the user manually stops, do deletion here.
            DeleteOnChange(activeFile);
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
            DeleteSelected();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool ChangePlaylistAskStop(string msg)
        {
            if (!showDialogs) return true; // stop it

            // should count even when paused?
            if (playing)
                return MessageBox.Show(this,
                    msg, "Sounds", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes;
            else return true;
        }

        // use result because tri-state
        // also, must be done beforehand and inline, as logic is more complex
        public DialogResult ChangePlaylistAskDirty()
        {
            if (!showDialogs) return DialogResult.No; // don't save

            var msg = MiscStrings.changeFileWhileDirty;
            if (Dirty)
                return MessageBox.Show(this,
                    msg, "Sounds", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
            else return DialogResult.No;
        }

        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ChangePlaylistAskDirty())
            {
                case DialogResult.Yes:
                    SavePlaylist(false);
                    break;
                case DialogResult.No: break;
                default: return;
            }
            if (ChangePlaylistAskStop(MiscStrings.newFileWhilePlaying))
                NewPlaylist();
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ChangePlaylistAskDirty())
            {
                case DialogResult.Yes:
                    SavePlaylist(false);
                    break;
                case DialogResult.No: break;
                default: return;
            }
            if (ChangePlaylistAskStop(MiscStrings.changeFileWhilePlaying) && 
                openPlaylistDialog.ShowDialog(this) == DialogResult.OK)
            {
                OpenPlaylist(openPlaylistDialog.FileName);
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
            ShowPropertiesDialog(false);
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
                    foreach (var f in data.OrderBy(x => x))
                    {
                        if (Directory.Exists(f))
                        {
                            AddDirectory(f);
                        }
                        else if(File.Exists(f))
                        {
                            if (Path.GetExtension(f).Contains("m3u"))
                                OpenPlaylist(f, Properties.Settings.Default.FileDragAppendPlaylist);
                            else
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

                    Dirty = true;
                }
            }
        }

        private void volumeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volume += (VolumeIncrement * 0.01);
        }

        private void volumeDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volume -= (VolumeIncrement * 0.01);
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volume = 0;
        }

        private void togglePlaybackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayPauseToggle();
        }

        private void skipAheadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mp.Position = mp.Position.Add(new TimeSpan(0, 0, TimeIncrement));
        }

        private void rewindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mp.Position = mp.Position.Subtract(new TimeSpan(0, 0, TimeIncrement));
        }

        private void albumArtBox_Click(object sender, EventArgs e)
        {
            ShowPropertiesDialog(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // for ephemereal playlists, if it's not a saved playlist and no
            // files, don't bother asking
            switch (ChangePlaylistAskDirty())
            {
                case DialogResult.Yes:
                    SavePlaylist(false);
                    break;
                case DialogResult.No: break;
                default:
                    e.Cancel = true;
                    return;
            }
            if (!ChangePlaylistAskStop(MiscStrings.quitWhilePlaying))
            {
                e.Cancel = true;
                return;
            }
            // save settings at end
            Properties.Settings.Default.ShowToolBar = showToolBar;
            Properties.Settings.Default.ShowStatusBar = showStatusBar;
            Properties.Settings.Default.ShowInfoPane = showInfoPane;
            Properties.Settings.Default.DeleteOnNext = deleteOnNext;
            Properties.Settings.Default.Repeat = repeat;
            Properties.Settings.Default.VolumeShortcutIncrement = volIncrement;
            Properties.Settings.Default.TimeShortcutSeconds = timeIncrement;
            Properties.Settings.Default.Save();
        }

        private void playContextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // the menu/toolbar item will play the same track when paused; this
            // forcibly plays the selected track
            PlayAndSet(true);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pd = new PrefsDialog()
            {
                ShowToolbar = showToolBar,
                ShowStatusbar = showStatusBar,
                ShowInfoPane = showInfoPane,
                DeleteOnTrackChange = deleteOnNext,
                ShowConfirmationDialogs = showDialogs,
                VolumeIncrement = volIncrement,
                TimeIncrement = timeIncrement,
            };
            if (pd.ShowDialog(this) == DialogResult.OK)
            {
                showToolBar = pd.ShowToolbar;
                showStatusBar = pd.ShowStatusbar;
                showInfoPane = pd.ShowInfoPane;
                deleteOnNext = pd.DeleteOnTrackChange;
                showDialogs = pd.ShowConfirmationDialogs;
                VolumeIncrement = pd.VolumeIncrement;
                TimeIncrement = pd.TimeIncrement;
                UpdateUI();
            }
        }

        private void appendPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openPlaylistDialog.ShowDialog(this) == DialogResult.OK)
            {
                OpenPlaylist(openPlaylistDialog.FileName, true);
            }
        }

        private void aboutSoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }
    }
}
