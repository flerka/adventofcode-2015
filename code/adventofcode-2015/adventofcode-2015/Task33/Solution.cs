using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task33
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/18/ task
        /// </summary>
        public static int Function(List<List<bool>> input, int steps)
        {
            var size = (input.Count, input.Count);
            List<List<bool>> oldData = input.Select(x => x.Select(item => item).ToList()).ToList();
            List<List<bool>> newData = input.Select(x => x.Select(item => item).ToList()).ToList();

            for (var i = 0; i < steps; i++)
            {
                oldData = newData.Select(x => x.Select(item => item).ToList()).ToList();

                for (var y = 0; y < input.Count; y++)
                {
                    for (var x = 0; x < input.Count; x++)
                    {
                        var point = (x, y);
                        var neighbors = GetNeighbors(point, size);
                        var neighCount = neighbors
                            .Count(item => oldData[item.Item2][item.Item1]);

                        newData[y][x] = (oldData[y][x], neighCount) switch
                        {
                            (false, 3) or (true, 2) or (true, 3) => true,
                            _ => false
                        };
                    }
                }
            }

            return newData.Sum(item => item.Count(item2 => item2));
        }

        private static List<(int, int)> GetNeighbors((int i, int j) point, (int x, int y) size) =>
            new List<(int i, int j)>
            {
                (point.i - 1, point.j),
                (point.i + 1, point.j),
                (point.i, point.j + 1),
                (point.i, point.j - 1),
                (point.i - 1, point.j - 1),
                (point.i - 1, point.j + 1),
                (point.i + 1, point.j - 1),
                (point.i + 1, point.j + 1),
            }
            .Where(item => item.i >= 0 && item.i < size.x && item.j >= 0 && item.j < size.y)
            .ToList();
    }
}