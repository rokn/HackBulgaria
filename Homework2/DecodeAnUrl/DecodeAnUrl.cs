using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAnUrl
{
    class DecodeAnUrl
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DecodeUrl("kitten%20%3Apic.jpg"));
        }

        static string DecodeUrl(string input)
        {
            StringBuilder newUrl = new StringBuilder(input);
            Dictionary<string, string> rules = new Dictionary<string, string>();

            rules.Add("%20", " ");
            rules.Add("%3A", ":");
            rules.Add("%3D", "?");
            rules.Add("%2F", "/");

            foreach(var kvp in rules)
            {
                newUrl.Replace(kvp.Key, kvp.Value);
            }

            return newUrl.ToString();
        }
    }
}
