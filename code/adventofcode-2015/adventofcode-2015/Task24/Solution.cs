using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task24
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/13/ task
        /// </summary>
        public static int Function(List<(string name, string neigh, int sat)> input)
        {
            var names = input.GroupBy(i => i.name).Select(i => i.Key).ToList();
            var pairs = input.ToDictionary(i => (i.name, i.neigh), k => k.sat);
            var mutations = GetAllNamesPermutations(names, 5);

            return mutations.Select(mut =>
            {
                var mutationsList = mut.ToList();
                var res = 0;
                for (int i = 1; i < mutationsList.Count - 1; i++)
                {
                    res += pairs[(mutationsList[i], mutationsList[i - 1])];
                    res += pairs[(mutationsList[i], mutationsList[i + 1])];
                }
                res += pairs[(mutationsList[0], mutationsList[mutationsList.Count - 1])];
                res += pairs[(mutationsList[0], mutationsList[1])];

                res += pairs[(mutationsList[mutationsList.Count - 1], mutationsList[mutationsList.Count - 2])];
                res += pairs[(mutationsList[mutationsList.Count - 1], mutationsList[0])];
                return res;
            }).Max();
        }

        // based on this answer https://stackoverflow.com/a/10629938
        static IEnumerable<IEnumerable<string>> GetAllNamesPermutations(IEnumerable<string> list, int length)
        {
            if (length == 1) return list.Select(t => new string[] { t });

            return GetAllNamesPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new string[] { t2 }));
        }
    }
}