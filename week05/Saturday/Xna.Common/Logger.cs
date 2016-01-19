using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Xna.Common
{
	public static class Logger
	{
		private static bool _showError = true;

		public static void ClearLogFile()
		{
			try
			{
				File.Delete(Directory.GetCurrentDirectory() + Configuration.LogFile);
			}
			catch(Exception)
			{
				ShowError();
			}
		}

		public static void WriteLine(string line)
		{
			var builder = new StringBuilder();
			builder.Append(DateTime.Now.ToString("g"));
			builder.Append(" : ");
			builder.Append(line);

			try
			{
				using(var writer = File.AppendText(Directory.GetCurrentDirectory() + Configuration.LogFile))
				{
					writer.WriteLine(builder.ToString());
				}
			}
			catch(Exception)
			{
				ShowError();
			}
		}

		public static void WriteLine(string format, object arg0)
		{
			WriteLine(string.Format(format, arg0));
		}

		public static void WriteLine(string format, object arg0, object arg1)
		{
			WriteLine(string.Format(format, arg0, arg1));
		}

		public static void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			WriteLine(string.Format(format, arg0, arg1, arg2));
		}

		private static void ShowError()
		{
			if (!_showError) return;

			var result = MessageBox.Show("Can't open log file: " + Directory.GetCurrentDirectory() + Configuration.LogFile,
				"Log file error",
				buttons: MessageBoxButtons.AbortRetryIgnore);

			if(result == DialogResult.Abort)
				Environment.Exit(-1);
			if (result == DialogResult.Ignore)
				_showError = false;
		}
	}
}
