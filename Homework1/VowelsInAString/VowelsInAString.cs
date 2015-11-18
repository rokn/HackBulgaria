using System;
using System.Linq;

namespace VowelsInAString
{
    class VowelsInAString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine("Vowels: {0}", CountVowels(input));
            Console.WriteLine("Consonants: {0}", CountConsonants(input));
        }

        static int CountVowels(string str)
        {
            string vowels = "aeiouyAEIOUY";
            return str.Count(ch => vowels.Contains(ch));
        }

        static int CountConsonants(string str)
        {
            string consonants = "bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ";
            return str.Count(ch => consonants.Contains(ch));
        }
    }
}
