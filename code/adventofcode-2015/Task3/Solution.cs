using System;
using System.Collections.Generic;

namespace adventofcode_2015.Task3;

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/2/ task
    /// </summary>
    public static int Function(List<(int l, int w, int h)> input)
    {
        // surface area = 2 * l * w + 2 * w * h + 2 * h * l
        var result = 0;

        foreach (var item in input)
        {
            var lw = item.l * item.w;
            var wh = item.w * item.h;
            var hl = item.h * item.l;

            result += (lw + wh + hl) * 2 + Math.Min(Math.Min(lw, wh), hl);
        }

        return result;
    }
}