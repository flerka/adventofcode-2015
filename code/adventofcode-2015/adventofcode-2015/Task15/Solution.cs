using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task15
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/8/ task
        /// </summary>
        public static int Function(List<string> input)
        {
            var len = 0;
            var actualtLen = 0;
            foreach (var line in input)
            {
                var cleanedLine = string.Concat(line.Skip(1).SkipLast(1));

                var slashCount = cleanedLine.Split(@"\\").Length - 1;

                var noDSlashesLine = string.Concat(cleanedLine.Split(@"\\"));
                var quotesCount = noDSlashesLine.Split("\\\"").Length - 1;
                var specialCount = noDSlashesLine.Split(@"\x").Length - 1;

                len += line.Length;
                actualtLen += line.Length - 2 - slashCount - quotesCount - specialCount * 3;
            }

            return len - actualtLen;
        }
    }
}
