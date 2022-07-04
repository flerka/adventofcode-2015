using adventofcode_2015.Task13;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task13
{
    public class SolutionTests
    {
        [Fact]
        public void Task13_RealExample_Correct()
        {
            Assert.Equal(-457, Solution.Function(ReadFile(Path.Combine("Task13", "Data.txt"))));
        }

        private List<Command> ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName).Select<string, Command>(item =>
            {
                int n;

                var data = item.Split(" -> ").ToList();
                string output = data[1];

                if (item.Contains($" {OperationType.AND} "))
                {
                    var temp = data[0].Split($" {OperationType.AND} ").ToList();
                    if (int.TryParse(temp[0], out n))
                    {
                        return new AndCommand(n, temp[1], output);
                    }
                    return new AndCommand(temp[0], temp[1], output);
                }

                if (item.Contains($" {OperationType.OR} "))
                {
                    var temp = data[0].Split($" {OperationType.OR} ").ToList();
                    return new OrCommand(temp[0], temp[1], output);
                }

                if (item.Contains($" {OperationType.LSHIFT} "))
                {
                    var temp = data[0].Split($" {OperationType.LSHIFT} ").ToList();
                    return new LShiftComamnd(temp[0], int.Parse(temp[1]), output);
                }

                if (item.Contains($" {OperationType.RSHIFT} "))
                {
                    var temp = data[0].Split($" {OperationType.RSHIFT} ").ToList();
                    return new RShiftComamnd(temp[0], int.Parse(temp[1]), output);
                }

                if (item.Contains($"{OperationType.NOT}"))
                {
                    return new NotCommand(data[0].Split($"{OperationType.NOT} ")[1], output);
                }

                if (int.TryParse(data[0], out n))
                {
                    return new InputCommand(int.Parse(data[0]), output);
                }

                return new InputCommand(data[0], output);
            }).ToList();
        }
    }
}