using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        public PropertiesForm(TagLib.File f) : this()
        {
            fileNameBox.Text = f.Name;
            durationBox.Text = f.Properties.Duration.ToString();
            bitrateBox.Text = f.Properties.AudioBitrate.ToString();
            channelsBox.Text = f.Properties.AudioChannels.ToString();
            sampleRateBox.Text = f.Properties.AudioSampleRate.ToString();
        }
    }
}
