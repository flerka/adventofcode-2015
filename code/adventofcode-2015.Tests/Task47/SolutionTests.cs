using adventofcode_2015.Task47;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task47;

public class SolutionTests
{
    [Fact]
    public void Task47_RealExample_Correct()
    {
        Assert.Equal(25360703L, Solution.Function(ReadFileAsync(Path.Combine("Task47", "Data.txt"))));
    }

    private List<long> ReadFileAsync(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        return lines.Select(line =>
        {
            return long.Parse(line);
        }).ToList();
    }
}