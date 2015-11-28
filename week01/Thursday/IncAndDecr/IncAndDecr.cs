using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncAndDecr
{
    class IncAndDecr
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] {5,4,3,2,1 };
            Console.WriteLine(IsDecreasing(numbers));
        }

        static bool IsIncreasing(int[] sequence)
        {
            for (int i = 0; i < sequence.Length - 2; i++)
            {
                if (sequence[i] >= sequence[i + 1])
                    return false;
            }

            return true;
        }

        static bool IsDecreasing(int[] sequence)
        {
            for (int i = 0; i < sequence.Length - 2; i++)
            {
                if (sequence[i] <= sequence[i + 1])
                    return false;
            }

            return true;
        }
    }
}
