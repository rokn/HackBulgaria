using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDigits
{
    class WorkingWithDigits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Digit count : {0}", CountDigits(n));
            Console.WriteLine("Sum digits: {0}", SumDigits(n));
            Console.WriteLine("Factorial digits : {0}", FactorialDigits(n));
        }

        static int CountDigits(int n)
        {
            return n.ToString().Length;
        }

        static int SumDigits(int n)
        {
            List<int> digits = GetDigits(n);
            int sum = 0;

            digits.ForEach(digit => sum += digit);

            return sum;
        }
        static int Fact(int n)
        {
            return (n <= 1) ? 1 : Fact(n - 1) * n;
        }

        static int FactorialDigits(int n)
        {
            List<int> digits = GetDigits(n);
            int sum = 0;

            digits.ForEach(digit => sum += Fact(digit));

            return sum;
        }

        static List<int> GetDigits(int n)
        {
            List<int> digits = new List<int>();
            string str = n.ToString();

            for (int i = 0; i < str.Length; i++)
            {
                digits.Add((int)str[i] - 48);
            }

            return digits;
        }
    }
}
