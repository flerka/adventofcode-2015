using adventofcode_2015.Task48;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task48
{
    public class SolutionTests
    {
        [Fact]
        public void Task48_RealExample_Correct()
        {
            Assert.Equal(24104369L, Solution.Function(ReadFileAsync(Path.Combine("Task48", "Data.txt"))));
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