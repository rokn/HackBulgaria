using System;
using System.Linq;

namespace Anagrams
{
    class Anagrams
    {
        static void Main(string[] args)
        {
            string inA = Console.ReadLine();
            string inB = Console.ReadLine();
            Console.WriteLine("IsAnagram: {0}", IsAnagram(inA, inB));
            Console.WriteLine("HasAnagram: {0}", HasAnagramOf(inA, inB));
        }

        static bool IsAnagram(string A, string B)
        {
            if (A.Length != B.Length) 
                return false;

            return HasAnagramOf(A,B);
        }

        static bool HasAnagramOf(string A, string B)
        {
            if (A.Length > B.Length)
                return false;

            for (int i = 0; i < A.Length; i++)
            {
                if (B.Contains(A[i]))
                {
                    B = B.Remove(B.IndexOf(A[i]), 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
