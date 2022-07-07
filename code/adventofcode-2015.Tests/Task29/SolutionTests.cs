using adventofcode_2015.Task29;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task29
{
    public class SolutionTests
    {
        [Fact]
        public void Task29_RealExample_Correct()
        {
            var data = ReadFile(Path.Combine("Task29", "Data.txt"));
            var userData = new Dictionary<string, int>
            {
                { "children", 3 },
                {"cats", 7 },
                {"samoyeds", 2 },
                {"pomeranians", 3 },
                {"akitas", 0 },
                {"vizslas", 0 },
                {"goldfish", 5 },
                {"trees", 3 },
                {"cars", 2 },
                {"perfumes", 1 }
            };
            Assert.Equal(103, Solution.Function(userData, data));
        }

        private Dictionary<int, Dictionary<string, int>> ReadFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            var result = new Dictionary<int, Dictionary<string, int>>();
            for (var i = 0; i < lines.Length; i++)
            {
                result[i + 1] = new();
                var line = lines[i];
                var data = line.Split($"Sue {i + 1}: ")[1].Split(", ");
                foreach (var item in data)
                {
                    var temp = item.Split(": ");
                    result[i + 1][temp[0]] = int.Parse(temp[1]);
                }
            }

            return result;
        }
    }
}