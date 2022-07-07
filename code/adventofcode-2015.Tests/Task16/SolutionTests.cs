using adventofcode_2015.Task16;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task16
{
    public class SolutionTests
    {
        [Fact]
        public void Task16_RealExample_Correct()
        {
            Assert.Equal(19, Solution.Function(ReadFile(Path.Combine("Task16", "Data.txt"))));
        }

        private List<string> ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }
    }
}