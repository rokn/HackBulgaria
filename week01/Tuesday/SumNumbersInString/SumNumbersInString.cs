using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SumNumbersInString
{
    class SumNumbersInString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(SumofNumbersInString(input));
        }

        static float SumofNumbersInString(string str)
        {
            str = Regex.Replace(str, "[^0-9.]", " ");
            var splitted = str.Split(' ');
            float sum = 0;
            float currNumb;

            foreach (var numb in splitted)
            {
                if (float.TryParse(numb, out currNumb))
                {
                    sum += currNumb;
                }
            }

            return sum;
        }
    }
}
