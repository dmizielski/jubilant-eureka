using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.common.wyjątki
{
    public static class Wyjątki
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var rnd = new Random();

            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rnd.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
