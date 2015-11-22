using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumber
{
    class FibonacciNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(FibNumber(n));
        }

        static string FibNumber(int n)
        {
            string str = "";

            int prev2 = 1, prev = 1, curr;

            if (n > 2)
            {
                str += "1";
                if (n > 1)
                {
                    str += "1";
                }
            }

            for (int i = 2; i < n; i++)
            {
                curr = prev + prev2;
                prev2 = prev;
                prev = curr;
                str += curr.ToString();
            }

            return str;
        }
    }
}
