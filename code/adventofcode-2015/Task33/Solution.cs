using System;
using System.Collections.Generic;

namespace adventofcode_2015.Task33;

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/17/ task
    /// </summary>
    public static int Function(List<int> input, int size)
    {
        var result = 0;

        var count = Math.Pow(2, input.Count);
        for (var i = 1; i <= count - 1; i++)
        {
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
                    temp += input[j];
                }
            }

            if (temp == size)
            {
                result++;
            }
        }

        return result;
    }
}