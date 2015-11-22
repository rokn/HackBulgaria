using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace DepedenciesResolving
{
    public struct Project
    {
        public string projectName;
        public List<string> dependencies;
    }        

    public class Program
    {
        static void Main(string[] args)
        {
            const string installedModulesPath = ".\\installed_modules";
            Project project;
            Dictionary<string, List<string>> packages = new Dictionary<string, List<string>>();
            List<string> installedModules = new List<string>();

            using (var reader = new StreamReader("all_packages.json"))
            {
                string file = reader.ReadToEnd();
                packages = ParseJson(file);
            }

            using (var reader = new StreamReader("dependencies.json"))
            {
                string file = reader.ReadToEnd();
                project = ParseProjectFile(file);
            }

            if(Directory.Exists(installedModulesPath))
            {
                foreach(var dir in Directory.GetDirectories(installedModulesPath))
                {
                    installedModules.Add(dir.Remove(0, installedModulesPath.Length + 1));
                }
            }
            else
            {
                Directory.CreateDirectory(installedModulesPath);
            }


            // Work the magic
            foreach(string dependency in project.dependencies)
            {
                InstallPackage(dependency, installedModules, packages, installedModulesPath);
            }

            Console.WriteLine("All done :)");
            Console.WriteLine();
        }

        private static void InstallPackage(string package, List<string> installedModules, Dictionary<string, List<string>> packages, string installedModulesPath)
        {
            Console.WriteLine();
            Console.WriteLine("Installing " + package + ".");

            if(installedModules.Contains(package))
            {
                Console.WriteLine(package + " is already installed.");
            }
            else
            {
                if (packages[package].Count > 0)
                {
                    Console.WriteLine("In order to isntall " + package + ", the following will be installed :");
                    int i = 1;
                    foreach (string dependency in packages[package])
                    {
                        Console.WriteLine((i++) + ". " + dependency);
                    }

                    foreach (string dependency in packages[package])
                    {
                        InstallPackage(dependency, installedModules, packages, installedModulesPath);
                    }
                }

                installedModules.Add(package);
                Directory.CreateDirectory(installedModulesPath + "\\" + package);                
            }            
        }

        private static Project ParseProjectFile(string json)
        {
            Project project = new Project();

            Dictionary<string, List<string>> parsed = ParseJson(json);

            if (parsed.ContainsKey("projectName") && parsed.ContainsKey("dependencies"))
            {
                project.projectName = parsed["projectName"][0];
                project.dependencies = parsed["dependencies"];
            }
            else
            {
                throw new Exception("Error in parsing project file");
            }

            return project;
        }



        //I like challenges so let's write a reaaaaly simple Json parser
        private static Dictionary<string, List<string>> ParseJson(string json)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            json = Regex.Replace(json, @"\s+", "");

            int position = 1;
            bool readingKey = true;                        
            int sepIndex;
            string currentKey = "";            

            while(position < json.Length - 2)
            {                
                if(readingKey)
                {
                    sepIndex = json.IndexOf(':', position);
                    currentKey = json.Substring(position, sepIndex - position).Trim('"');
                    readingKey = false;
                    position = sepIndex + 1;
                }
                else
                {
                    List<string> currentValue = new List<string>();

                    if(json[position] == '[')
                    {
                        sepIndex = json.IndexOf(']', position+1);
                        string sub = json.Substring(position, sepIndex - position).Trim('[', ']');

                        string[] arr = sub.Split(new Char[] { ',' });

                        foreach (string element in arr)
                        {
                            if (element.Trim('"') != "")
                            {
                                currentValue.Add(element.Trim('"'));
                            }
                        }

                        sepIndex++;
                    }
                    else
                    {
                        sepIndex = json.IndexOf(',');
                        
                        if (sepIndex == -1)
                        {
                            currentValue.Add(json.Substring(position).Trim('"'));
                            sepIndex = json.Length - 1;
                        }
                        else
                        {
                            currentValue.Add(json.Substring(position, sepIndex - position).Trim('"'));                            
                        }
                    }

                    readingKey = true;
                    position = sepIndex + 1;                    
                    result.Add(currentKey, currentValue);                    
                    currentKey = "";
                }
            }

            return result;
        }

    }
}
