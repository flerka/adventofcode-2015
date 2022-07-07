using adventofcode_2015.Task31;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task31
{
    public class SolutionTests
    {
        [Fact]
        public void Task31_RealExample_Correct()
        {
            var data = ReadFile(Path.Combine("Task31", "Data.txt"));
            var storageSize = 25;
            Assert.Equal(4, Solution.Function(data, storageSize));
        }

        private List<int> ReadFile(string fileName)
        {
            return File.ReadAllText(fileName)
                .Split(" ")
                .Select(int.Parse)
                .ToList();
        }
    }
}