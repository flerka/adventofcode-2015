using adventofcode_2015.Task30;
using System.Collections.Generic;
using Xunit;

namespace adventofcode_2015.Tests.Task30;

public class SolutionTests
{
    [Fact]
    public void Task30_RealExample_Correct()
    {
        Assert.Equal(0, Solution.Function(new List<List<int>>{
            new List<int> { 3, 0, 0, -3, 2},
            new List<int> { -3, 3, 0, 0, 9},
            new List<int> { -1, 0, 4, 0, 1},
            new List<int> { 0, 0, -2, 2, 8} }));
    }
}