using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sounds
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
            fileSelector.DisplayMember = "Name";
        }

        public PropertiesForm(params TagLib.File[] files) : this()
        {
            fileSelector.Items.AddRange(files);
            fileSelector.SelectedIndex = 0;

            int largestWidth = 0;
            foreach(var i in files)
            {
                var width = TextRenderer.MeasureText(i.Name, fileSelector.Font).Width;
                largestWidth = Math.Max(width, largestWidth);
            }
            fileSelector.DropDownWidth = largestWidth;
        }

        public void SwitchFile(TagLib.File f)
        {
            fileNameBox.Text = f.Name;
            durationBox.Text = f.Properties.Duration.ToString();
            bitrateBox.Text = f.Properties.AudioBitrate.ToString();
            channelsBox.Text = f.Properties.AudioChannels.ToString();
            sampleRateBox.Text = f.Properties.AudioSampleRate.ToString();

            titleBox.Text = f.Tag.Title;
            albumBox.Text = f.Tag.Album;
            yearBox.Text = f.Tag.Year.ToString();
            trackBox.Text = f.Tag.TrackCount > 0 ?
                string.Format("{0}/{1}", f.Tag.Track, f.Tag.TrackCount)
                : f.Tag.Track.ToString();
            discBox.Text = f.Tag.DiscCount > 0 ?
                string.Format("{0}/{1}", f.Tag.Disc, f.Tag.DiscCount)
                : f.Tag.Disc.ToString();
            copyrightBox.Text = f.Tag.Copyright;
            commentsBox.Text = f.Tag.Comment;
            lyricsBox.Text = f.Tag.Lyrics;

            artistsBox.Items.Clear();
            composersBox.Items.Clear();
            genresBox.Items.Clear();
            artistsBox.Items.AddRange(f.Tag.Performers
                .Select(x => f.Tag.AlbumArtists.Contains(x) ? string.Format(MiscStrings.albumArtistPrintf, x, MiscStrings.albumArtist) : x)
                .ToArray());
            artistsBox.Items.AddRange(f.Tag.AlbumArtists
                .Where(x => !f.Tag.Performers.Contains(x))
                .Select(x => string.Format(MiscStrings.albumArtistPrintf, x, MiscStrings.albumArtist))
                .ToArray());
            composersBox.Items.AddRange(f.Tag.Composers);
            genresBox.Items.AddRange(f.Tag.Genres);

            albumArtSelector.DisplayMember = "Type";
            albumArtSelector.Items.Clear();
            if (f.Tag.Pictures.Count() > 0)
            {
                albumArtSelector.Enabled = true;
                copyImageButton.Enabled = true;
                albumArtSelector.Items.AddRange(f.Tag.Pictures);
                if (albumArtSelector.Items.Count > 0)
                    albumArtSelector.SelectedIndex = 0;
            }
            else
            {
                albumArtSelector.Enabled = false;
                copyImageButton.Enabled = false;
                albumArtInfo.Text = string.Empty;
                albumArtBox.Image = null;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void albumArtSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picture = (TagLib.IPicture)albumArtSelector.SelectedItem;

            albumArtInfo.Text = string.Format("[{0}] {1}",
                picture.MimeType, picture.Description);

            var pictureStream = picture?.Data?.Data;
            if (pictureStream != null)
            {
                using (var ms = new MemoryStream(pictureStream))
                {
                    var b = Image.FromStream(ms);
                    albumArtBox.Image = b;
                }
            }
        }

        private void fileSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchFile((TagLib.File)fileSelector.SelectedItem);
        }

        private void copyImageButton_Click(object sender, EventArgs e)
        {
            if (albumArtBox.Image != null)
            {
                var dataObject = new DataObject();
                dataObject.SetImage(albumArtBox.Image);
                dataObject.SetText(albumArtInfo.Text);
                Clipboard.SetDataObject(dataObject);
            }
        }
    }
}
