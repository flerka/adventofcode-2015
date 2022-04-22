using System.Collections.Generic;

namespace adventofcode_2015.Task6
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/3/ task
        /// </summary>
        public static int Function(string input)
        {
            (int x, int y) santaPos = (0, 0);
            (int x, int y) robosantaPos = (0, 0);

            Dictionary<(int x, int y), int> houses = new() { { (0, 0), 2 } };

            for(var i = 0; i < input.Length; i++)
            {
                var item = input[i];
                var currentPos = i % 2 == 0 ? santaPos : robosantaPos;

                currentPos = item switch
                {
                    '>' => (currentPos.x + 1, currentPos.y),
                    '<' => (currentPos.x - 1, currentPos.y),
                    '^' => (currentPos.x, currentPos.y + 1),
                    'v' => (currentPos.x, currentPos.y - 1)
                };

                houses[currentPos] = houses.ContainsKey(currentPos) ? 
                    (houses[currentPos] + 1) : 1;

                if (i % 2 == 0)
                {
                    santaPos = currentPos;
                }
                else
                {
                    robosantaPos = currentPos;
                }
            }

            return houses.Keys.Count;
        }
    }
}
