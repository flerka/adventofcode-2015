using adventofcode_2015.Task22;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task22
{
    public class SolutionTests
    {
        [Fact]
        public void Task22_RealExample_Correct()
        {
            Assert.Equal(-1, Solution.Function(ReadFile(Path.Combine("Task22", "Data.txt"))));
        }

        private string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}