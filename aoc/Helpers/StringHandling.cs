using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Helpers
{
    public static class StringHandling
    {
        private static string ReplaceAtIndex(string source, int index, string orgString, string newString)
        {
            var indexOStart = index;
            var indexOfEnd = index + orgString.Length;
            var lengthToEnd = source.Length - indexOfEnd;

            if (indexOStart == -1)
                return source;

            var firstPart = source.Substring(0, indexOStart);
            var lastPart = source.Substring(indexOfEnd, lengthToEnd);

            return firstPart + newString + lastPart;
        }
    }
}
