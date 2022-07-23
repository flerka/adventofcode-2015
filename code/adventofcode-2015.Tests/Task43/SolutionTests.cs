﻿using adventofcode_2015.Task43;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2015.Tests.Task43
{
    public class SolutionTests
    {
        [Fact]
        public void Task43_RealExample_Correct()
        {
            Assert.Equal(169, Solution.Function(ReadFileAsync(Path.Combine("Task43", "Data.txt"))));
        }

        private List<Command> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines.Select(line =>
            {
                var commandName = string.Concat(line.Take(3));
                char? register = null;
                int? offset = null;

                var commandText = string.Concat(line.Skip(4));
                if (commandName == "jie" || commandName == "jio")
                {
                    var temp = commandText.Split(", ");
                    offset = int.Parse(temp[1]);
                    register = temp[0][0];
                }

                if (commandName == "jmp")
                {
                    offset = int.Parse(commandText);
                }

                if (commandName == "hlf" || commandName == "tpl" || commandName == "inc")
                {
                    register = commandText[0];
                }
                 return  new Command { Name = commandName, Offset = offset, Register = register};
            }).ToList();
        }
    }
}