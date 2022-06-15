using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task29
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/16/ task
        /// </summary>
        public static int Function(Dictionary<string, int> userData,
                Dictionary<int, Dictionary<string, int>> data)
        {
            return data.Keys.FirstOrDefault(key => data[key].Keys.All(subkey =>
                data[key][subkey] == userData[subkey]));
        }
    }
}