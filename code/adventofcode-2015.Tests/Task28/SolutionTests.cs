using adventofcode_2015.Task28;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task28
{
    public class SolutionTests
    {
        [Fact]
        public void Task28_RealExample_Correct()
        {
            var data = ReadFile(Path.Combine("Task28", "Data.txt"));
            Assert.Equal(689, Solution.Function(data, 1000));
        }

        private List<HorseStats> ReadFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            var result = new List<HorseStats>();

            foreach (var line in lines)
            {
                var words = line.TrimEnd('.').Split(" ");
                var name = words[0];
                var speed = int.Parse(words[3]);
                var runDur = int.Parse(words[6]);
                var restDur = int.Parse(words[words.Length - 2]);

                result.Add(new HorseStats(name, speed, runDur, restDur));
            }

            return result;
        }
    }
}