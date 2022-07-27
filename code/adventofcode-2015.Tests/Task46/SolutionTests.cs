using adventofcode_2015.Task46;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task46
{
    public class SolutionTests
    {
        [Fact]
        public void Task46_RealExample_Correct()
        {
            Assert.Equal(24104369L, Solution.Function(ReadFileAsync(Path.Combine("Task46", "Data.txt"))));
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