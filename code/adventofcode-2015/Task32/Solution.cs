using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task32
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/17/ task
        /// </summary>
        public static int Function(List<int> input, int size)
        {
            var result = 0;
            var resultCount = new List<int>();

            var count = Math.Pow(2, input.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                var containerCount = 0;
                var temp = 0;

                var str = Convert.ToString(i, 2).PadLeft(input.Count, '0');
                for (var j = 0; j < str.Length; j++)
                {
                    if (temp > size)
                    {
                        break;
                    }

                    if (str[j] == '1')
                    {
                        containerCount++;
                        temp += input[j];
                    }
                }

                if (temp == size)
                {
                    result++;
                    resultCount.Add(containerCount);
                }
            }

            var min = resultCount.Min();
            return resultCount.Count(i => i == min);
        }
    }
}