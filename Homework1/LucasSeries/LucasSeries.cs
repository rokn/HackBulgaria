using System;
using System.Collections.Generic;

namespace LucasSeries
{
    class LucasSeries
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(NthLucas(n-1));
            Console.WriteLine();

            List<int> l = FirstNLucas(n);

            l.ForEach(numb => Console.WriteLine(numb));
        }

        static int NthLucas(int n)
        {
            return (n < 2) ? ((n == 0) ? 2 : 1) : (NthLucas(n - 1) + NthLucas(n - 2));  
        }

        static List<int> FirstNLucas(int n)
        {
            List<int> list = new List<int>();

            int prev2 = 2, prev = 1, curr;

            if(n > 2)
            {
                list.Add(prev2);
                if(n > 1)
                {
                    list.Add(prev);
                }
            }

            for (int i = 2; i < n; i++)
            {
                curr = prev + prev2;
                prev2 = prev;
                prev = curr;     
                list.Add(curr);
            }

            return list;
        }
    }
}
