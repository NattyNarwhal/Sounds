using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sounds
{
    public class ToolStripTrackBar : ToolStripControlHost
    {
        public TrackBar TrackBar
        {
            get
            {
                return (TrackBar)Control;
            }
        }

        public ToolStripTrackBar() : base (new TrackBar())
        {
            TrackBar.Scroll += (o, e) =>
            {
                OnScroll(e);
            };
        }

        public int TickFrequency
        {
            get
            {
                return TrackBar.TickFrequency;
            }
            set
            {
                TrackBar.TickFrequency = value;
            }
        }

        public int Value
        {
            get
            {
                return TrackBar.Value;
            }
            set
            {
                TrackBar.Value = value;
            }
        }

        public int Minimum
        {
            get
            {
                return TrackBar.Minimum;
            }
            set
            {
                TrackBar.Minimum = value;
            }
        }

        public int Maximum
        {
            get
            {
                return TrackBar.Maximum;
            }
            set
            {
                TrackBar.Maximum = value;
            }
        }

        public int LargeChange
        {
            get
            {
                return TrackBar.LargeChange;
            }
            set
            {
                TrackBar.LargeChange = value;
            }
        }

        protected virtual void OnScroll(EventArgs e)
        {
            Scroll?.Invoke(this, e);
        }

        public event EventHandler Scroll;
    }
}
