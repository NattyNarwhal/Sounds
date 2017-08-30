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
    public partial class PrefsDialog : Form
    {
        public bool ShowToolbar
        {
            get
            {
                return showToolbarBox.Checked;
            }
            set
            {
                showToolbarBox.Checked = value;
            }
        }

        public bool ShowStatusbar
        {
            get
            {
                return showStatusbarBox.Checked;
            }
            set
            {
                showStatusbarBox.Checked = value;
            }
        }

        public bool ShowInfoPane
        {
            get
            {
                return showInfoPaneBox.Checked;
            }
            set
            {
                showInfoPaneBox.Checked = value;
            }
        }

        public bool DeleteOnTrackChange
        {
            get
            {
                return deleteOnTrackChangeBox.Checked;
            }
            set
            {
                deleteOnTrackChangeBox.Checked = value;
            }
        }

        public bool ShowConfirmationDialogs
        {
            get
            {
                return showDialogsBox.Checked;
            }
            set
            {
                showDialogsBox.Checked = value;
            }
        }

        public int VolumeIncrement
        {
            get
            {
                return Convert.ToInt32(volIncrementBox.Value);
            }
            set
            {
                volIncrementBox.Value = value;
            }
        }

        public int TimeIncrement
        {
            get
            {
                return Convert.ToInt32(timeIncrementBox.Value);
            }
            set
            {
                timeIncrementBox.Value = value;
            }
        }

        public PrefsDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
