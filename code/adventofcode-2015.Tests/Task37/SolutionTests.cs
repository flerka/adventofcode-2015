using adventofcode_2015.Task37;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventtofcode_2015.Tests.Task37;

public class SolutionTests
{
    [Fact]
    public void Task37_RealExample_Correct()
    {
        // To make my solution work I manually changed corner values in input data to true.
        var data = ReadFile(Path.Combine("Task37", "Data.txt"));
        Assert.Equal(410, Solution.Function(data));
    }

    private (string, List<(string, string)>) ReadFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        var stringInput = lines.Last();
        var data = new List<(string, string)>();
        var filterLines = lines.Where(item => item != stringInput).ToList();
        foreach (var line in filterLines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                var temp = line.Split(" => ");
                data.Add((temp[0], temp[1]));
            }
        }

        return (stringInput, data);
    }
}