using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task9
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/5/ task
        /// </summary>
        public static long Function(List<string> input)
        {
            var forb = new List<string>() { "ab", "cd", "pq", "xy" };
            var result = 0;

            foreach (string s in input)
            {
                if (s.Count(i => "aeiou".Contains(i)) >= 3
                    && s.Skip(1).Zip(s, (curr, prev) => curr == prev ? 1 : 0).Sum() > 0
                    && !forb.Any(i => s.Contains(i)))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
