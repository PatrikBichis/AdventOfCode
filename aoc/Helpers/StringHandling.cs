using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Helpers
{
    public static class StringHandling
    {
        public static string ReplaceAtIndex(this string source, int index, string orgString, string newString)
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

        public static string After(this string source, char separator)
        {
            return source.Split(separator)[1].Trim();
        }

        public static string Before(this string source, char separator)
        {
            return source.Split(separator)[0].Trim();
        }

        public static int AfterWithSpace(this string source)
        {
            var numberStart = source.LastIndexOf(" ");

            return int.Parse(source.Substring(numberStart, source.Length - numberStart));
        }

        public static List<int>ValuesSeparatedBy(this string source, char separator)
        {
            var values = new List<int>();

            foreach (var n in source.Trim().Split(separator))
            {
                if (n != "")
                    values.Add(int.Parse(n.Trim()));
            }

            return values;
        }
    }
}
