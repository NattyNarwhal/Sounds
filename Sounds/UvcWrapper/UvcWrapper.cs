using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sounds.UvcWrapper
{
    public static class UvcWrapper
    {
        const string DllName = "PP-UWP-Interop.dll";

        static IntPtr api;

        public static bool Initialized { get; private set; } = false;

        // not a static ctor so we can catch it
        public static void Init()
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT
                || Environment.OSVersion.Version < new Version(6, 2))
                throw new PlatformNotSupportedException();

            UserEventsCallback ue;
            var nullArgs = new EventArgs();
            ue.Play = () => Play?.Invoke(null, nullArgs);
            ue.Pause = () => Pause?.Invoke(null, nullArgs);
            ue.Stop = () => Stop?.Invoke(null, nullArgs);
            ue.Next = () => Next?.Invoke(null, nullArgs);
            ue.Previous = () => Previous?.Invoke(null, nullArgs);
            ue.FastForward = () => FastForward?.Invoke(null, nullArgs);
            ue.Rewind = () => Rewind?.Invoke(null, nullArgs);

            var res = PP_UVC_Init(ref ue);
            api = res;
            Initialized = api != null;
        }

        static void CheckInitialized()
        {
            if (!Initialized)
                throw new Exception("Not initialized.");
            if (api == IntPtr.Zero)
                throw new ArgumentNullException();
        }

        public static void Stopped()
        {
            CheckInitialized();

            UVC_C_Stopped(api);
        }

        public static void Paused(bool paused)
        {
            CheckInitialized();

            UVC_C_Paused(api, paused);
        }

        // TODO: wire up everything else
        // per the headers, some stuff isn't worth using and won't work on 8.1
        public static void NewTrack(string title,
            string artist,
            string albumArtist = null,
            string albumTitle = null,
            uint trackNumber = 0,
            uint trackCount = 0)
        {
            CheckInitialized();

            TrackInfo ti;
            ti.Title = title;
            ti.Artist = artist;
            ti.AlbumArtist = albumArtist;
            ti.AlbumTitle = albumTitle;
            ti.TrackNumber = trackNumber;
            ti.TrackCount = trackCount;
            ti.ImageData = IntPtr.Zero;
            ti.ImageSize = IntPtr.Zero;

            UVC_C_NewTrack(api, ref ti);
        }

        public static event EventHandler Play, Pause, Stop, Next, Previous, FastForward, Rewind;

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr PP_UVC_Init(ref UserEventsCallback callbacks);

        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        static extern void UVC_C_Stopped(IntPtr api);

        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        static extern void UVC_C_NewTrack(IntPtr api, ref TrackInfo ti);

        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        static extern void UVC_C_Paused(IntPtr api, bool paused);
    }
}
