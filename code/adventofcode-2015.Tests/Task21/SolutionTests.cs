using adventofcode_2015.Task21;
using Xunit;

namespace adventofcode_2015.Tests.Task21;

public class SolutionTests
{
    [Fact]
    public void Task21_RealExample_Correct()
    {
        Assert.Equal("abcdffaa", Solution.Function("abcdefgh"));
    }
}