using adventofcode_2015.Task36;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task36
{
    public class SolutionTests
    {
        [Fact]
        public void Task36_RealExample_Correct()
        {
            // To make my solution work I manually changed corner values in input data to true.
            var data = ReadFile(Path.Combine("Task36", "Data.txt"));
            var stepsCount = 100;
            Assert.Equal(7, Solution.Function(data, stepsCount));
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