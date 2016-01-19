using System.IO;
using FileEditor;
using FilesAndStreams;

namespace TestApp
{
	class Program
	{
		static void Main()
		{
			//Directories.ListFiles(new DirectoryInfo(@"F:\Dropbox\Programming"));
			//			Directories.DirectoryCopy(new DirectoryInfo(@"F:\Dropbox\Programming\HackBulgaria\HackBulgaria\week08\FilesAndStreams"), new DirectoryInfo(@"F:\Dropbox\Test"), false);
			//			Directories.FileToUpper(new FileInfo(@"F:\Dropbox\Test\test.txt"), "upper.txt");
			using (var editor = new Editor(new FileInfo(@"F:\Dropbox\Test\test.txt")))
			{
				editor.Run();
			}

			
		}
	}
}
