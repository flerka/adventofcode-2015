using adventofcode_2015.Task33;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task33
{
    public class SolutionTests
    {
        [Fact]
        public void Task33_RealExample_Correct()
        {
            var data = ReadFile(Path.Combine("Task33", "Data.txt"));
            var stepsCount = 100;
            Assert.Equal(4, Solution.Function(data, stepsCount));
        }

        private List<List<bool>> ReadFile(string fileName)
        {
            var result = new List<List<bool>>();
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                result.Add(line.ToCharArray().Select(i => i == '#').ToList());
            }

            return result;
        }
    }
}