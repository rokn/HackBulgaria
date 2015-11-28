using System;
using System.Collections.Generic;

namespace ReverseAList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            ReverseList(list);
            list.ForEach(n => Console.WriteLine(n));
        }

        static void ReverseList(List<int> list)
        {
            List<int> reverse = new List<int>(list);

            list.Clear();

            for (int i = reverse.Count - 1; i >= 0; i--)
            {
                list.Add(reverse[i]);
            }
        }
    }
}
