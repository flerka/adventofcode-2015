using System.Collections.Generic;

namespace adventofcode_2015.Task5
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/3/ task
        /// </summary>
        public static int Function(string input)
        {
            (int x, int y) currentPos = (0, 0);
            Dictionary<(int x, int y), int> houses = new();

            foreach (var item in input)
            {
                currentPos = item switch
                {
                    '>' => (currentPos.x + 1, currentPos.y),
                    '<' => (currentPos.x - 1, currentPos.y),
                    '^' => (currentPos.x, currentPos.y + 1),
                    'v' => (currentPos.x, currentPos.y - 1)
                };

                houses[currentPos] = houses.ContainsKey(currentPos) ?
                    (houses[currentPos] + 1) : 1;
            }

            return houses.Keys.Count;
        }
    }
}
