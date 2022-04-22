using adventofcode_2015.Task9;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task9
{
    public class SolutionTests
    {
        [Fact]
        public void Task9_RealExample_Correct()
        {
            Assert.Equal(2, Solution.Function(ReadFile(Path.Combine("Task9", "Data.txt"))));
        }

        private List<string> ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }
    }
}