using adventofcode_2015.Task20;
using Xunit;

namespace adventofcode_2015.Tests.Task20
{
    public class SolutionTests
    {
        [Fact]
        public void Task20_RealExample_Correct()
        {
            Assert.Equal("abcdffaa", Solution.Function("abcdefgh"));
        }
    }
}