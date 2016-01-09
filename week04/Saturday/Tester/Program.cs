using LinkedList;
using System;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("x");
            list.Add("g");
            list.Add("s");

            Console.WriteLine(list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.InsertAfter("g", "a");

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            //list.InsertAt(10, "z");

            Console.WriteLine();
            Console.WriteLine();

            list.InsertAt(2, "z");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();
            Console.WriteLine();

            list.RemoveAt(2);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            //Console.WriteLine(list[2]);
        }
    }
}
