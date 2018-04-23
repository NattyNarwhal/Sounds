using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sounds.UvcWrapper
{
    delegate void NewTrackFunction(ref TrackInfo trackInfo);
    delegate void PausedFunction(bool paused);

    [StructLayout(LayoutKind.Sequential)]
    struct Api
    {
        public Action Stopped;
        public NewTrackFunction NewTrack;
        public PausedFunction Paused;
    }
}
