using adventofcode_2015.Task29;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2015.Tests.Task29;

public class SolutionTests
{
    public SolutionTests(ITestOutputHelper output)
    {
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    public void Task29_RealExample_Correct()
    {
        Assert.Equal(0, Solution.Function(new List<List<int>>{
            new List<int> { -1, -2, 6, 3},
            new List<int> { 2, 3, -2, -1},
            new List<int> { -1, 0, 4, 0},
            new List<int> { 0, 0, -2, 2} }));
    }

    private class Converter : TextWriter
    {
        ITestOutputHelper _output;
        public Converter(ITestOutputHelper output)
        {
            _output = output;
        }
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        public override void WriteLine(string message)
        {
            _output.WriteLine(message);
        }
        public override void WriteLine(string format, params object[] args)
        {
            _output.WriteLine(format, args);
        }

        public override void Write(char value)
        {
            throw new NotSupportedException("This text writer only supports WriteLine(string) and WriteLine(string, params object[]).");
        }
    }
}