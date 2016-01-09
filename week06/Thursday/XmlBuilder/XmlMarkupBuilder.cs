using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace XmlBuilder
{
    public class XmlMarkupBuilder
    {
		private class XmlTag
		{
			public string Text { get; set; }
			private readonly List<string> _attributeList;
			private readonly string _name;
			public bool StartAppended { get; private set; }

			public XmlTag(string name)
			{
				_name = name;
				_attributeList = new List<string>();
				Text = "";
				StartAppended = false;
			}

			public void AddAttribute(string attrName, string attrValue)
			{
				_attributeList.Add(attrName + "=" + attrValue);
			}

			public string GetOpenTag()
			{
				var str = new StringBuilder();
				str.Append("<").Append(_name);

				foreach (var attribute in _attributeList)
				{
					str.Append(" ").Append(attribute);
				}

				str.Append(">");

				StartAppended = true;

				return str.ToString();
			}

			public string GetClosingTag()
			{
				var str = new StringBuilder();
				str.Append("</").Append(_name).Append(">");
				return str.ToString();
			}
		}

	    private readonly Stack<XmlTag> _openTags;
	    private bool _rootOpened;
	    private readonly StringBuilder _xmlString;
		private bool _isFinalized;


		public XmlMarkupBuilder()
	    {
		    _openTags = new Stack<XmlTag>();
			_isFinalized = false;
			_xmlString = new StringBuilder();
	    }

	    public XmlMarkupBuilder OpenTag(string tagName)
	    {
			CheckFinalized();

		    if (_openTags.Count <= 0)
		    {
			    if (!_rootOpened)
				    _rootOpened = true;
			    else
				    throw new XmlSyntaxException("You can't have more than one root tags");
		    }
		    else
		    {
				AppendCurrentTag();
			}

			_openTags.Push(new XmlTag(tagName));

		    return this;
	    }

	    public XmlMarkupBuilder AddAttr(string attrName, string attrValue)
	    {
			CheckFinalized();

			if(_openTags.Count <= 0)
			{
				throw new XmlSyntaxException("You need at least one open tag to add attributes");
			}

			_openTags.Peek().AddAttribute(attrName, attrValue);
			return this;
		}

	    public XmlMarkupBuilder AddText(string text)
	    {
			CheckFinalized();
			if(_openTags.Count <= 0)
			{
				throw new XmlSyntaxException("You need at least one open tag to add text");
			}

			_openTags.Peek().Text = text;
			return this;
		}

	    public XmlMarkupBuilder CloseTag()
	    {
			CheckFinalized();
			if(_openTags.Count <= 0)
			{
				throw new XmlSyntaxException("There aren't any open tags to close");
			}

		    if (!_openTags.Peek().StartAppended)
		    {
			    AppendCurrentTag();
		    }

			CloseCurrentTag();
		    return this;
	    }

	    public XmlMarkupBuilder Finalize()
	    {
		    CheckFinalized();

		    while (_openTags.Count > 0)
		    {
			    CloseTag();
		    }

		    _isFinalized = true;
		    return this;
	    }

	    public string GetResult()
	    {
		    if (!_isFinalized)
		    {
			    throw new XmlSyntaxException("Xml not finalized");
		    }

		    return _xmlString.ToString();
	    }

	    private void CheckFinalized()
	    {
		    if (_isFinalized)
		    {
			    throw new XmlSyntaxException("The object is already finalized");
		    }
	    }

	    private void AppendCurrentTag()
	    {
		    AppendTabs(_openTags.Count - 1);
			var currTag = _openTags.Peek();
			_xmlString.Append(currTag.GetOpenTag());
			_xmlString.Append('\n');
			AppendTabs(_openTags.Count);
			_xmlString.Append(currTag.Text);
			_xmlString.Append('\n');
		}

	    private void CloseCurrentTag()
	    {
			AppendTabs(_openTags.Count - 1);
			var currTag = _openTags.Pop();
			_xmlString.Append(currTag.GetClosingTag());
			_xmlString.Append('\n');
		}

	    private void AppendTabs(int count)
	    {
		    for (var i = 0; i < count; i++)
		    {
			    _xmlString.Append("    ");
		    }
	    }
	}
}
