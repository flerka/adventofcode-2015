using adventofcode_2015.Task39;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task39;

public class SolutionTests
{
    [Fact]
    public void Task39_RealExample_Correct()
    {
        long data = ReadFile(Path.Combine("Task39", "Data.txt"));
        Assert.Equal(18, Solution.Function(data));
    }

    private long ReadFile(string fileName)
    {
        return long.Parse(File.ReadAllText(fileName));
    }
}