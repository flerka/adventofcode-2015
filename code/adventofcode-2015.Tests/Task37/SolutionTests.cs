using adventofcode_2015.Task37;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task37
{
    public class SolutionTests
    {
        [Fact]
        public void Task37_RealExample_Correct()
        {
            long data = ReadFile(Path.Combine("Task37", "Data.txt"));
            Assert.Equal(18, Solution.Function(data));
        }

        private long ReadFile(string fileName)
        {
            return long.Parse(File.ReadAllText(fileName));
        }
    }
}