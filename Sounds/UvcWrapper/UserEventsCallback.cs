using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sounds.UvcWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    struct UserEventsCallback
    {
        public Action Play;
        public Action Pause;
        public Action Stop;
        public Action Next;
        public Action Previous;
        public Action FastForward;
        public Action Rewind;
    }
}
