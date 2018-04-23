using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sounds.UvcWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    struct TrackInfo
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Title;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Artist;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string AlbumArtist;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string AlbumTitle;

        public IntPtr ImageData;
        // this is intptr because size_t
        public IntPtr ImageSize;

        public ulong TrackNumber, TrackCount;
    }
}
