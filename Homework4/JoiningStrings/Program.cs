using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoiningStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string res = JoinStrings("|", "cmon", "That", "is", "working");
            Console.WriteLine(res);
        }

        static string JoinStrings(string separator, params string[] strings)
        {
            StringBuilder result = new StringBuilder();

            foreach(string str in strings)
            {
                result.Append(str);
                result.Append(separator);
            }

            return result.ToString();
        }
    }
}
