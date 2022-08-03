using adventofcode_2015.Task15;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task15;

public class SolutionTests
{
    [Fact]
    public void Task15_RealExample_Correct()
    {
        Assert.Equal(12, Solution.Function(ReadFile(Path.Combine("Task15", "Data.txt"))));
    }

    private List<string> ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName).ToList();
    }
}