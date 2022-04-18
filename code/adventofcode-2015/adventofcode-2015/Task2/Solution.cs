using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2015.Task2
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/1/ task
        /// </summary>
        public static int Function(string input)
        {
            var result = 0;
            for (var i = 0; i < input.Count(); i++)
            {
                result += input[i] == '(' ? 1 : -1;
                if (result == -1)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
