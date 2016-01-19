using System;
using System.IO;
using System.Linq;

namespace FileEditor
{
    public class Editor : IDisposable
    {
	    private const string ExitCommand = "exit";

	    private StreamWriter _writer;
	    private readonly FileInfo _fileInfo;

	    public Editor(FileInfo fileInfo)
	    {
		    this._fileInfo = fileInfo;
	    }

	    public void Run()
	    {
		    OpenFile();
		    var command = "" ;

		    while (command != ExitCommand)
		    {
			    var readLine = Console.ReadLine();
			    string[] splitted;

			    if (readLine != null)
			    {
				    splitted = readLine.Split();
			    }
			    else
			    {
				    throw new IOException("Can't read console line");
			    }

			    command = splitted[0];

			    switch(command)
				{
					case "list":
						ShowFile();
						break;
					case "clear":
						ClearFile();
						break;
					case "appendline":
						AppendLine(splitted[1]);
						break;
					case "append":
						AppendText(splitted[1]);
						break;
					case "linecount":
						Console.WriteLine(CountLines());
						break;
					case ExitCommand:
						break;
					default:
						Console.WriteLine("Unknown command");
						break;
				}
		    }
	    }

	    public void Dispose()
	    {
		    _writer?.Dispose();
	    }

	    private void OpenFile()
	    {
			if(_fileInfo.Exists)
				_writer = new StreamWriter(_fileInfo.FullName, true);
			else
				throw new FileNotFoundException(_fileInfo.FullName);
	    }

	    private void ClearFile()
	    {
		    CloseFile();
			File.WriteAllText(_fileInfo.FullName, string.Empty);
			OpenFile();
		}

	    private void CloseFile()
	    {
		    _writer?.Close();
	    }

	    private int CountLines()
	    {
			return File.ReadLines(_fileInfo.FullName).Count();
		}

		private void AppendLine(string line)
		{
			_writer?.WriteLine(line);
			_writer?.Flush();
		}

		private void AppendText(string text)
		{
			_writer?.Write(text);
			_writer?.Flush();
		}

		private void ShowFile()
	    {
			if(!_fileInfo.Exists) throw new FileNotFoundException(_fileInfo.FullName);

			CloseFile();

		    using (var sr = new StreamReader(_fileInfo.FullName))
		    {
			    string line;

				while((line = sr.ReadLine()) != null)
					Console.WriteLine(line);
		    }

			OpenFile();
	    }
    }
}
