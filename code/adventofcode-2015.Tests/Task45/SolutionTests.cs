using adventofcode_2015.Task45;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task45
{
    public class SolutionTests
    {
        [Fact]
        public void Task45_RealExample_Correct()
        {
            Assert.Equal(25360703L, Solution.Function(ReadFileAsync(Path.Combine("Task45", "Data.txt"))));
        }

        private List<long> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines.Select(line =>
            {
                return long.Parse(line);
            }).ToList();
        }
    }
}