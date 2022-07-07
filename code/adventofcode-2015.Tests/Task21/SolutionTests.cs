using adventofcode_2015.Task21;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task21
{
    public class SolutionTests
    {
        [Fact]
        public void Task21_RealExample_Correct()
        {
            Assert.Equal(0, Solution.Function(ReadFile(Path.Combine("Task21", "Data.txt"))));
        }

        private string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}