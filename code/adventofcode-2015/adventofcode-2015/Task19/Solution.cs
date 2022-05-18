using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2015.Task19
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first and the https://adventofcode.com/2015/day/10/ task
        /// </summary>
        public static string Function(string input, int repeat)
        {
            var word = input;
            for (int i = 0; i < repeat; i++)
            {
                var newWord = new StringBuilder(10000000);
                char tempN = word[0];
                int tempC = 1;

                for (int k = 1; k < word.Length; k++)
                {
                    if (word[k] == tempN)
                    {
                        tempC++;
                    }
                    else 
                    {
                        newWord.Append($"{tempC}{tempN}");
                        tempC = 1;
                        tempN = word[k];
                    }
                }
                newWord.Append($"{tempC}{tempN}");
                word = newWord.ToString();
            }

            return word;
        }
    }
}
