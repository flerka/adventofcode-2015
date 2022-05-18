using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task17
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/9/ task
        /// </summary>
        public static double Function(List<(string start, string end, double distance)> input)
        {
            var results = new List<double>();
            var cities = input.Select(i => i.start).Concat(input.Select(i => i.end)).Distinct().ToHashSet();

            foreach(var route in input)
            {
                var path = new HashSet<string>() { route.start, route.end };
                results.Add(route.distance + Solve(cities, path, route.end, input));
            }

            foreach (var route in input)
            {
                var path = new HashSet<string>() {route.end, route.start };
                results.Add(route.distance + Solve(cities, path, route.start, input));
            }

            return results.Min();
        }

        private static double Solve(HashSet<string> cities, HashSet<string> path, string last, List<(string start, string end, double distance)>  input)
        {
            var destinations = input.Where(i => 
                (i.start == last && !path.Contains(i.end))
                || (i.end == last && !path.Contains(i.start))).ToList();
            var results = new List<double>();

            foreach(var dest in destinations)
            {
                var newPath = new HashSet<string>(path);
                var d = dest.start == last ? dest.end : dest.start;
                newPath.Add(d);

                results.Add(dest.distance + Solve(cities, newPath, d, input));
            }

            if (destinations.Count == 0 && cities.Count != path.Count)
            {
                return double.PositiveInfinity;
            }

            return results.Count > 0 ? results.Min() : 0;
        }
    }
}
