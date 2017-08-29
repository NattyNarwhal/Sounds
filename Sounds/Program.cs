using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sounds
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mf = new MainForm();
            foreach (var f in args)
            {
                if (File.Exists(f) && (f.EndsWith(".m3u") || f.EndsWith(".m3u8")))
                {
                    // this is a bit odd; it'll take the filename of the last
                    // playlist. is that desirable?
                    mf.OpenPlaylist(f, true);
                }
                else
                {
                    mf.AddItem(f);
                }
            }
            Application.Run(mf);
        }
    }
}
