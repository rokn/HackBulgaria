using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var n in GenerateFactorials(10))
            {
                Console.WriteLine(n);
            }
        }

        static IEnumerable<int> GenerateFactorials(int n)
        {
            int fact = 1;

            for (int i = 1; i <= n; i++)
            {
                fact *= i;
                yield return fact;
            }
        }
    }
}
