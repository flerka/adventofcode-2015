using adventofcode_2015.Task38;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task38
{
    public class SolutionTests
    {
        [Fact]
        public void Task38_RealExample_Correct()
        {
            long data = ReadFile(Path.Combine("Task38", "Data.txt"));
            Assert.Equal(16, Solution.Function(data));
        }

        private long ReadFile(string fileName)
        {
            return long.Parse(File.ReadAllText(fileName));
        }
    }
}