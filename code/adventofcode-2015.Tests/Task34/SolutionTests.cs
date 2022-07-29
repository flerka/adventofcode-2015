using adventofcode_2015.Task34;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task34
{
    public class SolutionTests
    {
        [Fact]
        public void Task34_RealExample_Correct()
        {
            var data = ReadFile(Path.Combine("Task34", "Data.txt"));
            var storageSize = 25;
            Assert.Equal(3, Solution.Function(data, storageSize));
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