using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task10;

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/5/ task
    /// </summary>
    public static long Function(List<string> input)
    {
        var result = 0;

        foreach (var s in input)
        {
            var pairs = s.Skip(1).Zip(s, (curr, prev) => $"{prev}{curr}").Distinct().ToList();
            if (s.Skip(2).Zip(s, (curr, prev) => curr == prev ? 1 : 0).Sum() > 0
                && pairs.Any(pair => s.Split(pair).Length - 1 > 1))
            {
                result++;
            }
        }

        return result;
    }
}