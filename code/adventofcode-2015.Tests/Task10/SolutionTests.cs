using adventofcode_2015.Task10;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task10
{
    public class SolutionTests
    {
        [Fact]
        public void Task10_RealExample_Correct()
        {
            Assert.Equal(2, Solution.Function(ReadFile(Path.Combine("Task10", "Data.txt"))));
        }

        private List<string> ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }
    }
}