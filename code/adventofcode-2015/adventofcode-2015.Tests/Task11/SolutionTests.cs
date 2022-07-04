using adventofcode_2015.Task11;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task11
{
    public class SolutionTests
    {
        [Fact]
        public void Task11_RealExample_Correct()
        {
            Assert.Equal(998996, Solution.Function(ReadFile(Path.Combine("Task11", "Data.txt"))));
        }

        private List<InputCmd> ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName).Select(item =>
            {
                List<string> data = new();
                var command = "";

                if (item.StartsWith("turn on "))
                {
                    data = item.Split("turn on ")[1].Split(" through ").ToList();
                    command = "on";
                }

                if (item.StartsWith("turn off "))
                {
                    data = item.Split("turn off ")[1].Split(" through ").ToList();
                    command = "off";
                }

                if (item.StartsWith("toggle "))
                {
                    data = item.Split("toggle ")[1].Split(" through ").ToList();
                    command = "toggle";
                }

                var startUnparsed = data[0].Split(',').Select(int.Parse).ToList();
                var endUnparsed = data[1].Split(',').Select(int.Parse).ToList();

                return new InputCmd(
                    command,
                    (startUnparsed[0], startUnparsed[1]),
                    (endUnparsed[0], endUnparsed[1]));
            }).ToList();
        }
    }
}