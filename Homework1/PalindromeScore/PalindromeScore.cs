using System;

namespace PalindromeScore
{
    public static class PalindromeScore
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(PScore(n));
        }

        static int PScore(int n)
        {
            return (IsPalindrome(n)) ? 1 : 1 + PScore(n + n.Reverse());
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

        public static int Reverse(this int n)
        {
            string s = n.ToString();
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return int.Parse(new string(charArray));
        }
    }
}
