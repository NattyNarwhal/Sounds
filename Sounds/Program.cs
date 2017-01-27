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
                if (Directory.Exists(f))
                {
                    mf.AddDirectory(f);
                }
                else if (File.Exists(f) && (f.EndsWith(".m3u") || f.EndsWith(".m3u8")))
                {
                    mf.OpenPlaylist(f, true);
                }
                else if (File.Exists(f))
                {
                    mf.AddFile(f);
                }
            }
            Application.Run(mf);
        }
    }
}
