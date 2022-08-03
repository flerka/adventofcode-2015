using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task45;

public class Command
{
    public string Name { get; set; }
    public char? Register { get; set; } = null;
    public int? Offset { get; set; } = null;
}

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/23/ task
    /// </summary>
    public static int Function(List<Command> commands)
    {
        var values = new Dictionary<char, int>();
        values['a'] = 0;
        values['b'] = 0;

        var theEnd = false;
        var position = 0;

        while (position >= 0 && position < commands.Count)
        {
            var command = commands[position];
            if (command.Name == "hlf")
            {
                values[command.Register.Value] /= 2;
            }

            if (command.Name == "tpl")
            {
                values[command.Register.Value] *= 3;
            }

            if (command.Name == "inc")
            {
                values[command.Register.Value]++;
            }

            if (command.Name == "jmp")
            {
                position += command.Offset.Value;
                continue;
            }

            if (command.Name == "jie" && values[command.Register.Value] % 2 == 0)
            {
                position += command.Offset.Value;
                continue;
            }

            if (command.Name == "jio" && values[command.Register.Value] == 1)
            {
                position += command.Offset.Value;
                continue;
            }

            position++;
        }
        return values['b'];
    }
}