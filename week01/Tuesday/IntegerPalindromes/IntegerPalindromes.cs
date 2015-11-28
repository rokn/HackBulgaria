using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerPalindromes
{
    class IntegerPalindromes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("IsPalindrome: {0}", IsPalindrome(n));
            Console.WriteLine("LargestPalindrome: {0}", GetLargestPalindrome(n));
        }

        static int GetLargestPalindrome(int n)
        {
            while(n > 1)
            {
                if(IsPalindrome(n))
                {
                    return n;
                }

                n--;
            }

            return 1;
        }

        static bool IsPalindrome(int n)
        {
            string str = n.ToString();

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[(str.Length - 1) - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
