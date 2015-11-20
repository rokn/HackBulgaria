using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToListToNumber
{
    class NumberToListToNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var list = NumberToList(n);

            foreach(var numb in list)
            {
                Console.WriteLine(numb);
            }

            Console.WriteLine(ListToNumber(list));
        }

        static List<int> NumberToList(int n)
        {
            List<int> result = new List<int>();

            while(n>0)
            {
                result.Add(n % 10);
                n /= 10;
            }

            result.Reverse();

            return result;
        }

        static int ListToNumber(List<int> list)
        {
            int result = 0;

            foreach(var numb in list)
            {
                result *= 10;
                result += numb;
            }

            return result;
        }
    }
}
