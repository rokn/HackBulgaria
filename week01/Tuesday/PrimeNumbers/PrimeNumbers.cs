using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = ListFirstPrimes(n);
            foreach (var numb in list)
            {
                Console.WriteLine(numb);
            }

        }

        static bool IsPrime(ulong n)
        {
            for (ulong i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        static List<ulong> ListFirstPrimes(int n)
        {
            List<ulong> list = new List<ulong>();
            ulong i = 2;

            while(n > 0)
            {
                if(IsPrime(i))
                {
                    list.Add(i);
                    n--;
                }
                i++;
            }

            return list;
        }
    }
}
