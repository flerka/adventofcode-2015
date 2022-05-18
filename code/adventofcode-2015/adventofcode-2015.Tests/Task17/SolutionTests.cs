using adventofcode_2015.Task17;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task17
{
    public class SolutionTests
    {
        [Fact]
        public void Task17_RealExample_Correct()
        {
            Assert.Equal(605, Solution.Function(ReadFile(Path.Combine("Task17", "Data.txt"))));
        }

        private List<(string, string, double)> ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName).Select(item =>
            {
                var temp = item.Split(" = ");
                var distance = double.Parse(temp[1]);

                var cities = temp[0].Split(" to ");
                return (cities[0], cities[1], distance);
            }).ToList();
        }
    }
}