using System;
using XmlBuilder;

namespace Tester
{
	class Program
	{
		static void Main()
		{
			var markupBuilder = new XmlMarkupBuilder();
			var validMarkup = markupBuilder.OpenTag("body").AddAttr("background", "0xFF0000").AddText("Helo HTML!").OpenTag("h1").AddText("HEADER").Finalize().GetResult();

			Console.WriteLine(validMarkup);
		}
	}
}
