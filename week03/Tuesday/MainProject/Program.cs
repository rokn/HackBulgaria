using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestVector();
        }

        static void TestTime()
        {
            Time time = Time.Now;
            Console.WriteLine(time);
        }

        static void TestPairs()
        {
            Pair<string, int> pair = new Pair<string, int>("string4e", 42);
            Pair<string, int> pair2 = new Pair<string, int>("drugoStringche", 42);
            Pair<string, int> pair3 = new Pair<string, int>("string4e", 42);
            Console.WriteLine(pair);
            Console.WriteLine(pair2);
            Console.WriteLine(pair3);
            Console.WriteLine(pair == pair3);
            Console.WriteLine(pair.Equals(pair2));
        }

        static void TestFractions()
        {
            Fraction fr = new Fraction(2, 5);
            Fraction fr2 = new Fraction(5, 4);

            Console.WriteLine(fr*fr2);
        }

        static void TestVector()
        {
            Vector v = new Vector(0, 1, 2, 3, 4, 5);
            Vector v2 = new Vector(0, 1, 2, 3, 4, 5);

            Console.WriteLine(v);
            Console.WriteLine(v2);
            Console.WriteLine("Sum: {0}", v + v2);
            Console.WriteLine("Sub: {0}", v - v2);
            Console.WriteLine("Dot: {0}", v * v2);
            Console.WriteLine("SCAdd: {0}", v + 5);
            Console.WriteLine("SCSub: {0}", v - 5);
            Console.WriteLine("SCMul: {0}", v * 5);
            Console.WriteLine("SCDiv: {0}", v / 5);
            Console.WriteLine("Equal: {0}", v == v2);
        }
    }
}