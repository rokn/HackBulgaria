using System;
using System.Security;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlBuilder;

namespace XmlBuilder.Tests
{
	[TestClass()]
	public class XmlMarkupBuilderTests
	{
		private XmlMarkupBuilder _builder;


		[TestInitialize()]
		public void InitBuilder()
		{
			_builder = new XmlMarkupBuilder();
		}

		[TestMethod()]
		public void OpenTwoRootTagsTest()
		{
			try
			{
				_builder.OpenTag("tag1").CloseTag().OpenTag("tag2");
			}
			catch (XmlSyntaxException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod()]
		public void AddAttrTest()
		{
			try
			{
				_builder.AddAttr("attr","10");
			}
			catch (XmlSyntaxException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod()]
		public void AddTextTest()
		{
			try
			{
				_builder.AddText("text");
			}
			catch(XmlSyntaxException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod()]
		public void CloseTagTest()
		{
			try
			{
				_builder.CloseTag();
			}
			catch(XmlSyntaxException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod()]
		public void FinalizeTest()
		{
			try
			{
				_builder.OpenTag("tag").Finalize().OpenTag("tag2");

			}
			catch (XmlSyntaxException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod()]
		public void GetResultTest()
		{
			var xmlString = _builder.OpenTag("tag").AddAttr("attr", "value").AddText("text").Finalize().GetResult();

			xmlString = Regex.Replace(xmlString, @"\s+", "");
			Assert.AreEqual(xmlString, "<tagattr=value>text</tag>");
		}
	}
}