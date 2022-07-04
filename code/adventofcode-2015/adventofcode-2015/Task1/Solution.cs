namespace adventofcode_2015.Task1
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/1/ task
        /// </summary>
        public static int Function(string input)
        {
            var result = 0;
            var arr = input.ToCharArray();

            foreach (var ch in arr)
            {
                if (ch == '(')
                {
                    result++;
                }
                else
                {
                    result--;
                }
            }

            return result;
        }
    }
}
