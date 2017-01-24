using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounds
{
    public static class M3UParser
    {
        public static IEnumerable<string> Parse(IEnumerable<string> decomposed)
        {
            foreach (var u in decomposed)
            {
                // we don't need Extended attributes, or comments
                if (u.StartsWith("#") || string.IsNullOrWhiteSpace(u))
                    continue;

                yield return u;
            }
        }
    }
}
