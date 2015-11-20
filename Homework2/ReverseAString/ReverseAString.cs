using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAString
{
    class ReverseAString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(CopyEveryChar(input, 3));
        }

        static string ReverseMe(string original)
        {
            StringBuilder reversed = new StringBuilder();

            for (int i = original.Length - 1; i >= 0; i--)
            {
                reversed.Append(original[i]);
            }

            return reversed.ToString();
        }

        static string ReverseEachWord(string text)
        {
            string[] splitted = text.Split(' ');

            for (int i = 0; i < splitted.Length; i++)
            {
                splitted[i] = ReverseMe(splitted[i]);
            }

            return String.Join(" ", splitted);
        }

        static string CopyEveryChar(string original, int n)
        {
            StringBuilder copyChar = new StringBuilder();

            foreach(char ch in original)
            {
                copyChar.Append(ch, n);
            }

            return copyChar.ToString();
        }
    }
}
