using System.Numerics;

namespace adventofcode_2015.Task49;

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/25/ task
    /// </summary>
    public static long Function(int row, int column)
    {
        var firstCode = 20151125L;
        var baseVal = 252533;
        var modVal = 33554393L;
            
        long exponent = (row + column - 2) * (row + column - 1) / 2 + column - 1;
        return (long)(BigInteger.ModPow(baseVal, exponent, modVal) * firstCode) % modVal;
    }
}