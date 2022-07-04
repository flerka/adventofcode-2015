using adventofcode_2015.Task3;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task3
{
    public class SolutionTests
    {
        [Fact]
        public void Task3_RealExample_Correct()
        {
            Assert.Equal(58, Solution.Function(ReadFileAsync(Path.Combine("Task3", "Data.txt"))));
        }

        private List<(int, int, int)> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines.Select(line =>
            {
                var dimensions = line.Split("x").ToList();
                var l = int.Parse(dimensions[0]);
                var w = int.Parse(dimensions[1]);
                var h = int.Parse(dimensions[2]);
                return (l, w, h);
            }).ToList();
        }
    }
}
