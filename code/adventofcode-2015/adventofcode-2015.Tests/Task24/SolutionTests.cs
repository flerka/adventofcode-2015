using adventofcode_2015.Task24;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task24
{
    public class SolutionTests
    {
        [Fact]
        public void Task24_RealExample_Correct()
        {
            Assert.Equal(286, Solution.Function(ReadFile(Path.Combine("Task24", "Data.txt"))));
        }

        private List<(string, string, int)> ReadFile(string fileName)
        {
            var size = 3;
            var lines = File.ReadAllLines(fileName);
            var skip = 0;

            var result = new List<(string, string, int)>();
            while (skip < lines.Length)
            {
                var namedLines = lines.Skip(skip).Take(size).ToList();
                foreach(var line in namedLines)
                {
                    var words = line.TrimEnd('.').Split(" ");
                    var name = words[0];
                    var neighbor = words.Last();

                    var number = int.Parse(words[3]);
                    number *= words[2] == "gain" ? 1 : -1;

                    result.Add((name, neighbor, number));
                }
                result.Add((result.Last().Item1, "Me", 0));
                result.Add(("Me", result.Last().Item1, 0));
                skip += size;
            }

            return result;
        }
    }
}