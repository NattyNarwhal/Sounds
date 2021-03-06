﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounds
{
    public static class M3UParser
    {
        public static IEnumerable<string> Parse(IEnumerable<string> decomposed, string relativePathBase)
        {
            foreach (var u in decomposed)
            {
                // we don't need Extended attributes, or comments
                if (u.StartsWith("#") || string.IsNullOrWhiteSpace(u))
                    continue;

                yield return Path.IsPathRooted(u) ? u : Path.Combine(relativePathBase, u);
            }
        }

        public static bool FileIsM3U(string f) => File.Exists(f) && (f.EndsWith(".m3u") || f.EndsWith(".m3u8"));
    }
}
