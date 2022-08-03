namespace adventofcode_2015.Task39;

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/20/ task
    /// </summary>
    public static int Function(long presentsNumber)
    {
        var n = presentsNumber / 10;
        for (var j = 1; j < n; j++)
        {
            var sum = 0;

            for (var i = 1; i <= j; i++)
            {
                if (j % i == 0)
                {
                    sum += i * 10;
                }
            }

            if (sum >= presentsNumber)
            {
                return j;
            }
        }

        return -1;
    }
}