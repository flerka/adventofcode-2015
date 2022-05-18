using adventofcode_2015.Task19;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task19
{
    public class SolutionTests
    {
        [Fact]
        public void Task19_RealExample_Correct()
        {
            Assert.Equal("312211", Solution.Function("111221", 1));
        }
    }
}