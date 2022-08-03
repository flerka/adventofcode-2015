using System;
using System.Collections.Generic;

namespace adventofcode_2015.Task30;

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/15/ task
    /// </summary>
    public static int Function(List<List<int>> inp)
    {
        var max = 0;
        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; j <= 100 - i; j++)
            {
                for (int k = 0; k <= 100 - i - j; k++)
                {
                    var h = 100 - i - k - j;
                    var a = inp[0][0] * i + inp[1][0] * j + inp[2][0] * k + inp[3][0] * h;
                    var b = inp[0][1] * i + inp[1][1] * j + inp[2][1] * k + inp[3][1] * h;
                    var c = inp[0][2] * i + inp[1][2] * j + inp[2][2] * k + inp[3][2] * h;
                    var d = inp[0][3] * i + inp[1][3] * j + inp[2][3] * k + inp[3][3] * h;
                    var e = inp[0][4] * i + inp[1][4] * j + inp[2][4] * k + inp[3][4] * h;

                    if (e == 500)
                    {
                        max = Math.Max(max, Math.Max(0, a) *
                                            Math.Max(0, b) * Math.Max(0, c) *
                                            Math.Max(0, d));
                    }

                }
            }

        }

        return max;
    }
}