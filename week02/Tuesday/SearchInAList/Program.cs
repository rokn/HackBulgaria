using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInAList
{
    class Program
    {
        static void Main(string[] args)
        {
            int res;
            List<string> list = new List<string>() { "abbbba", "caca", "gavra", "kaka", "kifla" };
            if(TryFindSubstring(list,"la", out res))
            {
                Console.WriteLine(res);
            }
        }

        static bool TryFindSubstring(List<string> list, string searched, out int foundIndex)
        {
            int index;
            foundIndex = -1;

            foreach (var str in list)
            {
                foundIndex++;
                index = GetSubstringIndex(str, searched);

                if(index != -1)
                {
                    return true;
                }
            }

            foundIndex = -1;
            return false;
        }

        static int GetSubstringIndex(string str, string searched)
        {
            int res = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == searched[0])
                {
                    bool isFound = true;
                    for (int b = 1; b < searched.Length; b++)
                    {
                        if(i+b < str.Length)
                        {
                            if(str[i+b] != searched[b])
                            {
                                isFound = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if(isFound)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
