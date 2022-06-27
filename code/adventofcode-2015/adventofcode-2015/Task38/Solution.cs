using System.Collections.Generic;

namespace adventofcode_2015.Task38
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/20/ task
        /// </summary>
        public static int Function(long presentsNumber)
        {
            var n = presentsNumber / 10;
            Dictionary<int, int> elfes = new();
            for(var j = 1; j < n; j++)
            {
                elfes[j] = 0;
                var sum = 0;

                for (var i = 1; (i <= j); i++)
                {
                    if (elfes[i] < 51 && j % i == 0)
                    {
                        elfes[i]++;
                        sum += i * 11;
                    }
                }

                if (sum >= presentsNumber)
                {
                    return j;
                }
            }

            return -1;
        }
    }
}