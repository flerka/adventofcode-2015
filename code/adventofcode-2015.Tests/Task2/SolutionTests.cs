using adventofcode_2015.Task2;
using System.IO;
using Xunit;

namespace adventofcode_2015.Tests.Task2;

public class SolutionTests
{
    [Fact]
    public void Task2_RealExample_Correct()
    {
        Assert.Equal(5, Solution.Function(ReadFileAsync(Path.Combine("Task2", "Data.txt"))));
    }

    private string ReadFileAsync(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}