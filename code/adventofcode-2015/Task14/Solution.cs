using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task14;

public class Command
{
    public Command(string op, string left, string right, string output)
    {
        Op = op;
        Output = output;
        Left = left;
        Right = right;
    }

    public virtual int PerformCommand(int? left, int? right)
    {
        throw new NotImplementedException();
    }

    public string Output { get; set; }
    public string Op { get; set; }
    public string? Left { get; set; }
    public string? Right { get; set; }
}

public class RShiftComamnd : Command
{
    public RShiftComamnd(string left, int shift, string output) : base(OperationType.RSHIFT, left, null, output)
    {
        ShiftVal = shift;
    }
    public int ShiftVal { get; set; }

    public override int PerformCommand(int? left, int? right)
    {
        return left.Value >> ShiftVal;
    }
}
public class LShiftComamnd : Command
{
    public LShiftComamnd(string left, int shift, string output) : base(OperationType.RSHIFT, left, null, output)
    {
        ShiftVal = shift;
    }
    public int ShiftVal { get; set; }

    public override int PerformCommand(int? left, int? right)
    {
        return left.Value << ShiftVal;
    }
}

public class NotCommand : Command
{
    public NotCommand(string left, string output) : base(OperationType.NOT, left, null, output)
    {
    }

    public override int PerformCommand(int? left, int? right)
    {
        return ~left.Value;
    }
}

public class InputCommand : Command
{
    public InputCommand(int input, string output) : base(OperationType.INPUT, null, null, output)
    {
        InputVal = input;
    }

    public InputCommand(string input, string output) : base(OperationType.INPUT, input, null, output)
    {
    }

    public int? InputVal { get; set; }

    public override int PerformCommand(int? left, int? right)
    {
        return left.Value;
    }
}

public class AndCommand : Command
{
    public AndCommand(int left, string right, string output) : base(OperationType.AND, null, right, output)
    {
        InputVal = left;
    }

    public AndCommand(string left, string right, string output) : base(OperationType.AND, left, right, output)
    {
    }

    public int? InputVal { get; set; }

    public override int PerformCommand(int? left, int? right)
    {
        return InputVal.HasValue ? InputVal.Value & right.Value : left.Value & right.Value;
    }
}

public class OrCommand : Command
{
    public OrCommand(string left, string right, string output) : base(OperationType.OR, left, right, output)
    {
    }

    public override int PerformCommand(int? left, int? right)
    {
        return left.Value | right.Value;
    }
}

public class OperationType
{
    public const string AND = "AND";
    public const string OR = "OR";
    public const string LSHIFT = "LSHIFT";
    public const string RSHIFT = "RSHIFT";
    public const string NOT = "NOT";
    public const string INPUT = "INPUT";
}

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/7/ task
    /// </summary>
    public static int Function(List<Command> inputData)
    {
        var input = inputData.Where(item => item is InputCommand && ((InputCommand)item).InputVal.HasValue).ToList();
        var operations = inputData.Where(item => !input.Contains(item)).ToList();

        var valuesDict = new Dictionary<string, int>();
        foreach (var item in input)
        {
            valuesDict.Add(item.Output, ((InputCommand)item).InputVal.Value);
        }

        var a = GetA(operations, valuesDict);
        valuesDict["b"] = a;
        return GetA(operations, valuesDict);
    }

    private static int GetA(List<Command> inputOp, Dictionary<string, int> inputD)
    {
        var operations = new List<Command>(inputOp);
        var valuesDict = new Dictionary<string, int>(inputD);
        while (operations.Count > 0)
        {
            var op = operations.First(item =>
                (string.IsNullOrEmpty(item.Left) || valuesDict.ContainsKey(item.Left))
                && (string.IsNullOrEmpty(item.Right) || valuesDict.ContainsKey(item.Right)));

            int? left = string.IsNullOrEmpty(op.Left) ? null : valuesDict[op.Left];
            int? right = string.IsNullOrEmpty(op.Right) ? null : valuesDict[op.Right];
            var result = op.PerformCommand(left, right);
            operations.Remove(op);
            valuesDict[op.Output] = result;
        }

        return valuesDict["a"];
    }
}