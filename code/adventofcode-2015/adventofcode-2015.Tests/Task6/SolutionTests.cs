using adventofcode_2015.Task6;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task6
{
    public class SolutionTests
    {
        [Fact]
        public void Task6_RealExample_Correct()
        {
            Assert.Equal(11, Solution.Function(ReadFile(Path.Combine("Task6", "Data.txt"))));
        }

        private string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
