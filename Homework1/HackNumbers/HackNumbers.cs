using System;
namespace HackNumbers
{
    public static class HackNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Is hack number : {0}", IsHack(n));
            Console.WriteLine("NextHack : {0}", NextHack(n));
        }

        static bool IsHack(int n)
        {
            string binary = GetBinary(n);
            int ones = binary.Count('1');
            return ones % 2 == 1 && IsPalindrome(binary);
        }

        static int NextHack(int n)
        {
            while(true)
            {
                if(IsHack(++n))
                {
                    return n;
                }
            }
        }

        static string GetBinary(int n)
        {
            string str = "";
            while(n > 0)
            {
                if(n % 2 == 0)
                    str += "0";
                else
                    str += "1";

                n /= 2;
            }

            return str.Reverse();
        }

        static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length/2; i++)
            {
                if(str[i] != str[(str.Length-1) - i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int Count(this string s, char ch)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ch) count++;                    
            }

            return count;
        }
    }
}
