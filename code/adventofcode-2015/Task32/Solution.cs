using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task32;

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/16/ task
    /// </summary>
    public static int Function(Dictionary<string, int> userData,
        Dictionary<int, Dictionary<string, int>> data)
    {
        return data.Keys.FirstOrDefault(key => data[key].Keys.All(subkey =>
        {
            return subkey switch
            {
                "cats" or "trees" => data[key][subkey] > userData[subkey],
                "pomeranians" or "goldfish" => data[key][subkey] < userData[subkey],
                _ => data[key][subkey] == userData[subkey]
            };
        }));
    }
}