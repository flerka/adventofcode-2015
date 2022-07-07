using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task4
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/2/ task
        /// </summary>
        public static int Function(List<(int l, int w, int h)> input)
        {
            var result = 0;

            foreach (var item in input)
            {
                var sorted = new List<int> { item.l, item.w, item.h }
                .OrderBy(x => x).Take(2).ToList();
                result += 2 * sorted[0] + 2 * sorted[1] + item.l * item.w * item.h;
            }

            return result;
        }
    }
}
