using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task16
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/8/ task
        /// </summary>
        public static int Function(List<string> input)
        {
            var len = 0;
            var actualtLen = 0;
            foreach (var line in input)
            {
                actualtLen += line.Length;
                var count = line.Count(x => x == '\\' || x == '"');
                len += line.Length + count + 2;
            }

            return len - actualtLen;
        }
    }
}
