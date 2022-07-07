using adventofcode_2015.Task5;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task5
{
    public class SolutionTests
    {
        [Fact]
        public void Task5_RealExample_Correct()
        {
            Assert.Equal(2, Solution.Function(ReadFile(Path.Combine("Task5", "Data.txt"))));
        }

        private string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
