using adventofcode_2015.Task49;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task49;

public class SolutionTests
{
    [Fact]
    public void Task49_RealExample_Correct()
    {
        var row = 50;
        var column = 100;

        Assert.Equal(9019153L, Solution.Function(row, column));
    }
}