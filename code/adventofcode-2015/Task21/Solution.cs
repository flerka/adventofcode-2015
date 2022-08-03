using System.Linq;

namespace adventofcode_2015.Task21;

public class Solution
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// Solution for the first and the second https://adventofcode.com/2015/day/11/ task
    /// </summary>
    public static string Function(string input)
    {
        var password = input;

        while (!IsValid(password))
        {
            password = Inc(password, password.Length - 1);
        }

        return password;
    }

    private static string Inc(string input, int bit)
    {
        if (input[bit] == 'z')
        {
            var str = string.Join(
                string.Empty,
                input.Take(bit).Append('a').Concat(input.Skip(bit + 1)));
            return Inc(str, bit - 1);
        }
        else
        {
            return string.Join(
                string.Empty,
                input.
                    Take(bit).
                    Append(Alphabet[Alphabet.IndexOf(input[bit]) + 1])
                    .Concat(input.Skip(bit + 1)));
        }
    }

    private static bool IsValid(string input)
    {
        // input may not contain the letters i, o, or l
        if (input.Contains('i') || input.Contains('o') || input.Contains('l'))
        {
            return false;
        }

        // input must contain at least two different, non-overlapping pairs of letters,
        // like aa, bb, or zz
        var temp = input[0];
        var pairTemp = 0;
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] == temp)
            {
                pairTemp++;
                temp = ' ';
            }
            else
            {
                temp = input[i];
            }
        }

        if (pairTemp < 2)
        {
            return false;
        }

        // inpuy must include one increasing straight of at least three letters,
        // like abc, bcd
        for (var i = 0; i < input.Length; i++)
        {
            if (i + 3 >= input.Length)
            {
                return false;
            }

            if (Alphabet.Contains(string.Join(string.Empty, input.Skip(i).Take(3))))
            {
                return true;
            }
        }

        return false;
    }
}