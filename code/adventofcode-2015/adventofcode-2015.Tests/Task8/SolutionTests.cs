using adventofcode_2015.Task8;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task8
{
    public class SolutionTests
    {
        [Fact]
        public void Task8_RealExample_Correct()
        {
            Assert.Equal(609043L, Solution.Function(ReadFile(Path.Combine("Task8", "Data.txt"))));
        }

        private string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
