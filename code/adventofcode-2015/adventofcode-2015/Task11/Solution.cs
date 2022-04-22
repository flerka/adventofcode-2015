using System.Collections.Generic;

namespace adventofcode_2015.Task11
{
    public record InputCmd(string cmd, (int, int) start, (int, int) end);

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/6/ task
        /// </summary>
        public static int Function(List<InputCmd> input)
        {
            var data = new bool[1000, 1000];
            foreach(var cmd in input)
            {
                for (var y = cmd.start.Item2; y <= cmd.end.Item2; y++)
                {
                    for (var x = cmd.start.Item1; x <= cmd.end.Item1; x++)
                    {
                        if (cmd.cmd == "on")
                        {
                            data[x, y] = true;
                        }

                        if (cmd.cmd == "off")
                        {
                            data[x, y] = false;
                        }

                        if (cmd.cmd == "toggle")
                        {
                            data[x, y] = !data[x, y];
                        }
                    }
                }
            }

            var result = 0;
            for (var y = 0; y < 1000; y++)
            {
                for(var x = 0; x< 1000; x++)
                {
                    if (data[x, y])
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
