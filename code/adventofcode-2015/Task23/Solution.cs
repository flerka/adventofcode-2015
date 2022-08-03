using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode_2015.Task23;

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/12/ task
    /// </summary>
    public static int Function(string input)
    {
        return Regex.Matches(input, @"-?\d+")
            .Select(i => int.Parse(i.Value))
            .Sum();
    }
}