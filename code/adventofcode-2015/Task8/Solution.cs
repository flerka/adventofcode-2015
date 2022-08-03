using System;
using System.Security.Cryptography;
using System.Text;

namespace adventofcode_2015.Task8;

public class Solution
{
    /// <summary>
    /// Solution for the second https://adventofcode.com/2015/day/4/ task
    /// </summary>
    public static long Function(string input)
    {
        for (long i = 0; ; i++)
        {
            var hash = MD5.HashData(Encoding.ASCII.GetBytes($"{input}{i.ToString()}"));
            var result = BitConverter.ToString(hash).Replace("-", "");
            if (result.StartsWith("000000"))
            {
                return i;
            }
        }
    }
}