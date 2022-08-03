using adventofcode_2015.Task7;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task7;

public class SolutionTests
{
    [Fact]
    public void Task7_RealExample_Correct()
    {
        Assert.Equal(609043L, Solution.Function(ReadFile(Path.Combine("Task7", "Data.txt"))));
    }

    private string ReadFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}