using adventofcode_2015.Task24;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task24;

public class SolutionTests
{
    [Fact]
    public void Task24_RealExample_Correct()
    {
        Assert.Equal(-1, Solution.Function(ReadFile(Path.Combine("Task24", "Data.txt"))));
    }

    private string ReadFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}