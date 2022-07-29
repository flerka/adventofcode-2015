using adventofcode_2015.Task23;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task23
{
    public class SolutionTests
    {
        [Fact]
        public void Task23_RealExample_Correct()
        {
            Assert.Equal(0, Solution.Function(ReadFile(Path.Combine("Task23", "Data.txt"))));
        }

        private string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}