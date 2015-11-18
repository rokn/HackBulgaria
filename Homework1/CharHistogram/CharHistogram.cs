using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharHistogram
{
    class CharHistogram
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dict = CharHistogr(input);

            foreach (var kvp in dict)
            {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
            }
        }

        static Dictionary<char,int> CharHistogr(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                    dict[str[i]]++;
                else
                    dict.Add(str[i], 1);
            }

            return dict;
        }
    }
}
