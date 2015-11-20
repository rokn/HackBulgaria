using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeElements
{
    class ExtremeElements
    {
        static void Main(string[] args)
        {
            int[] numbs = new int[] { 1, 5, 4, 7, 4, 8, 4, 9, 0, 3 };
            Console.WriteLine(MinNth(numbs, 2));
            Console.WriteLine(Max(numbs));

        }

        static int[] MySort(int[] items)
        {
            int[] copy = new int[items.Length];
            items.CopyTo(copy, 0);
            Array.Sort(copy);
            return copy;
        }

        static int Min(int[] items)
        {
            return MinNth(items, 0);
        }

        static int Max(int[] items)
        {
            return MaxNth(items, 0);
        }

        static int MinNth(int[] items, int n)
        {
            return MySort(items)[n];
        }

        static int MaxNth(int[] items, int n)
        {
            return MySort(items)[items.Length - (n+1)];
        }
    }
}
