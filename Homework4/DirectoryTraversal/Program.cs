using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo("C:\\Users\\Antonio\\Documents\\visual studio 2015\\Projects\\Homework4");

            foreach (var item in IterateDirectory(dirInfo))
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<string> IterateDirectory(DirectoryInfo dir)
        {
            var files = dir.GetFiles();
            var dirs = dir.GetDirectories();

            foreach(var cDir in dirs)
            {
                foreach (var name in IterateDirectory(cDir))
                {
                    yield return name;
                }
            }

            foreach (var file in files)
            {
                yield return file.Name;
            }
        }
    }
}
0