using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketEngine.Core.Utils
{
    public static class Randomizer
    {
        public static string GetString(int length = 8)
        {
            var result = new StringBuilder();
            foreach (var i in Enumerable.Repeat(1, length))
            {
                var c = (char)new Random().Next();
                result.Append(c);
            }

            return result.ToString();
        }
    }
}
