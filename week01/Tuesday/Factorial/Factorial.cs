using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }

            Console.WriteLine(fact);
            Console.WriteLine(Fact(n));
        }

        static int Fact(int n)
        {
            return (n <= 1) ? 1 : Fact(n - 1) * n;
        }
    }
}
