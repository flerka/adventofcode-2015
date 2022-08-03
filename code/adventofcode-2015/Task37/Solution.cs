using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task37;

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/19/ task
    /// </summary>
    public static int Function((string str, List<(string left, string right)> data) input)
    {
        var str = input.str;
        var results = new List<string>();
        for (int i = 0; i < str.Length; i++)
        {
            if (input.data.Any(item => str[i].ToString() == item.left))
            {
                var subs = input.data.Where(item => str[i].ToString() == item.left).ToList();
                foreach (var sub in subs)
                {
                    var res = new List<char>();
                    res.AddRange(str.Take(i));
                    res.AddRange(sub.right);
                    res.AddRange(str.Skip(i + 1));
                    results.Add(string.Concat(res));
                }
            }
            else if (i != 0 && input.data.Any(item => $"{str[i - 1]}{str[i]}" == item.left))
            {
                var subs = input.data.Where(item => $"{str[i - 1]}{str[i]}" == item.left).ToList();
                foreach (var sub in subs)
                {
                    var res = new List<char>();
                    res.AddRange(str.Take(i - 1));
                    res.AddRange(sub.right);
                    res.AddRange(str.Skip(i + 1));
                        
                    results.Add(string.Concat(res));
                }
            }
        }

        return results.Distinct().Count();
    }
}