using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndStreams
{
    public static class Directories
    {
	    private const int FileShowReadCount = 100;
	    private static Dictionary<string,int> _files;

		public static void ListFiles(DirectoryInfo dir)
		{
			_files = new Dictionary<string, int>();
			Console.WriteLine("Reading ...");
			int i = 0;

			foreach (var fileName in IterateDirectory(dir))
			{
				if (i%FileShowReadCount == 0)
				{
					Console.WriteLine("{0} files read.", i);
				}

				if (!_files.ContainsKey(fileName))
				{
					_files.Add(fileName,1);
				}
				else
				{
					_files[fileName]++;
				}
				i++;
			}

			foreach (var kvp in _files)
			{
				Console.WriteLine("{0} - {1}", kvp.Key,kvp.Value);
			}

			_files.Clear();
		}

	    private static IEnumerable<string> IterateDirectory(DirectoryInfo dir)
	    {
			var files = dir.GetFiles();
			var dirs = dir.GetDirectories();

			foreach (var name in dirs.SelectMany(IterateDirectory))
			{
				yield return name;
			}

			foreach(var file in files)
			{
				yield return file.Name;
			}
		}

	    public static void DirectoryCopy(DirectoryInfo src, DirectoryInfo dest, bool recursively)
	    {
		    var newDirPath = Path.Combine(dest.FullName, src.Name);
		    DirectoryInfo newFolder = null;
			try
		    {
			    newFolder = Directory.CreateDirectory(newDirPath);
		    }
		    catch (Exception)
		    {
			    Console.WriteLine("Can't create directory: {0}", newDirPath);
			    return;
		    }

			FileInfo currFile = null;

			try
			{
			    var files = src.GetFiles();

			    foreach (var fileInfo in files)
			    {
				    currFile = fileInfo;
				    File.Copy(fileInfo.FullName, Path.Combine(newFolder.FullName, fileInfo.Name));
			    }
		    }
		    catch (Exception)
		    {
			    if (currFile != null)
			    {
				    Console.WriteLine("Can't copy file {0}", currFile.FullName);
			    }
			    else
			    {
				    Console.WriteLine("Error in copying files");
			    }
			    return;
		    }

		    if (!recursively) return;

		    var folders = src.GetDirectories();

		    foreach (var directoryInfo in folders)
		    {
			    DirectoryCopy(directoryInfo,newFolder,true);
		    }
	    }

	    public static void FileToUpper(FileInfo file, string newFileName)
	    {

		    var upperFileName = Path.Combine(file.DirectoryName, newFileName);

			using (var sr = new StreamReader(file.FullName))
			{
				string line;

			    while ((line = sr.ReadLine()) != null)
			    {
				    using (var sw = new StreamWriter(upperFileName))
				    {
					    sw.WriteLine(line.ToUpper());
				    }
			    }
		    }
	    }
    }
}
