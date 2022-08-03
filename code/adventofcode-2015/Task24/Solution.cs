using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode_2015.Task24;

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/12/ task
    /// </summary>
    public static int Function(string input)
    {
        var objectDepth = 0;
        var remove = new List<(int start, int end)>();
        var stack = new Stack<int>();

        for (var i = 0; i < input.Length; i++)
        {
            var ch = input[i];
            if (ch == '{')
            {
                stack.Push(i);
                if (objectDepth > 0)
                {
                    objectDepth++;
                }
            }

            if (ch == '}')
            {
                var depth = stack.Pop();
                if (objectDepth > 0)
                {
                    objectDepth--;
                    if (objectDepth == 0)
                    {
                        remove.Add((depth, i));
                    }
                }
            }

            if (ch == 'r' && IsRed(i) && objectDepth == 0)
            {
                objectDepth++;
            }
        }

        var data = input.ToCharArray();
        foreach (var rem in remove)
        {
            for (int i = rem.start; i <= rem.end; i++)
            {
                data[i] = 'a';
            }
        }

        var result = string.Join(string.Empty, data);
        return Regex.Matches(result, @"-?\d+")
            .Select(i => int.Parse(i.Value))
            .Sum();

        bool IsRed(int i) =>
            input[i + 1] == 'e' &&
            input[i + 2] == 'd' &&
            input[i - 2] == ':';
    }
}