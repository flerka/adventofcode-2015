using adventofcode_2015.Task40;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task40;

public class SolutionTests
{
    [Fact]
    public void Task40_RealExample_Correct()
    {
        long data = ReadFile(Path.Combine("Task40", "Data.txt"));
        Assert.Equal(16, Solution.Function(data));
    }

    private long ReadFile(string fileName)
    {
        return long.Parse(File.ReadAllText(fileName));
    }
}