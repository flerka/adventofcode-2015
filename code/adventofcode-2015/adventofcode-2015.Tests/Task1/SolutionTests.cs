using adventofcode_2015.Task1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace adventofcode_2015.Tests.Task1
{
    public class SolutionTests
    {
        [Fact]
        public void Task1_RealExample_Correct()
        {
            Assert.Equal(3, Solution.Function(ReadFileAsync(Path.Combine("Task1", "Data.txt"))));
        }

        private string ReadFileAsync(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
