using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task48;

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/24/ task
    /// </summary>
    public static long Function(List<long> weights)
    {
        var totalWeight = weights.Sum();
        var gWeight = totalWeight / 4;
        var lenght = 1;
        var allSums = new Dictionary<long, List<List<long>>>();

        while (!allSums.ContainsKey(gWeight))
        {
            var combs = Subsets(weights, lenght).Where(i => i.Count == lenght).ToList();
            foreach (var combination in combs)
            {
                if (!allSums.ContainsKey(combination.Sum()))
                {
                    allSums[combination.Sum()] = new();
                }
                allSums[combination.Sum()].Add(combination);
            }
            lenght++;
        }
        return allSums[gWeight].Select(item => item.Aggregate(1L, (current, item) => current * item)).Min();
    }

    // Code is from https://stackoverflow.com/a/36329628/3653606 this answer
    static IEnumerable<List<T>> Subsets<T>(List<T> objects, int maxLength)
    {
        if (objects == null || maxLength <= 0)
            yield break;
        var stack = new Stack<int>(maxLength);
        int i = 0;
        while (stack.Count > 0 || i < objects.Count)
        {
            if (i < objects.Count)
            {
                if (stack.Count == maxLength)
                    i = stack.Pop() + 1;
                stack.Push(i++);
                yield return (from index in stack.Reverse()
                    select objects[index]).ToList();
            }
            else
            {
                i = stack.Pop() + 1;
                if (stack.Count > 0)
                    i = stack.Pop() + 1;
            }
        }
    }
}