using System;
using System.Collections.Generic;

namespace adventofcode_2015.Task12;

public record InputCmd(string cmd, (int, int) start, (int, int) end);

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/6/ task
    /// </summary>
    public static long Function(List<InputCmd> input)
    {
        var data = new int[1000, 1000];
        foreach (var cmd in input)
        {
            for (var y = cmd.start.Item2; y <= cmd.end.Item2; y++)
            {
                for (var x = cmd.start.Item1; x <= cmd.end.Item1; x++)
                {
                    if (cmd.cmd == "on")
                    {
                        data[x, y]++;
                    }

                    if (cmd.cmd == "off")
                    {
                        data[x, y] = Math.Max(data[x, y] - 1, 0);
                    }

                    if (cmd.cmd == "toggle")
                    {
                        data[x, y] += 2;
                    }
                }
            }
        }

        long result = 0;
        for (var y = 0; y < 1000; y++)
        {
            for (var x = 0; x < 1000; x++)
            {
                result += data[x, y];
            }
        }

        return result;
    }
}