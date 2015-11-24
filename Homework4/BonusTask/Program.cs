using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 5, 4, 2, 4, 5};
            //int x = 0;
            //foreach (var item in list)
            //{
            //    x ^= item;
            //}
            //Console.WriteLine(x);

            foreach (var item in FindOddNumbers(list))
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<int> FindOddNumbers(List<int> numbers)
        {
            List<int> clone = new List<int>();
            int currNumb;

            while(clone.Count > 1)
            {
                currNumb = clone[0];
                clone.Remove(currNumb);

                if(!clone.Remove(currNumb))
                {
                    Console.WriteLine(currNumb);
                    yield return currNumb;
                }
            }

            if(clone.Count > 0)
            {
                Console.WriteLine(clone[0]);

                yield return clone[0];
            }
            else
            {
                Console.WriteLine(-1);
                yield return -1;
            }
        }
    }
}
