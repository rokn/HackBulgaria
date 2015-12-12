using System;

namespace MyGenerics
{
    public class Program
    {
        static void Main()
        {
            Stack<int> myStack = new Stack<int>(1, 2, 3, 4);


            Console.WriteLine(myStack.Peek());
            Console.WriteLine(myStack.Count);

            myStack.Push(5);
            Console.WriteLine(myStack.Pop());

            Console.WriteLine(myStack.Contains(3));
        }
    }
}
