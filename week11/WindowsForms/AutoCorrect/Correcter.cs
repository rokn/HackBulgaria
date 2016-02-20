using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AutoCorrect
{
	public partial class Correcter : Form
	{
		private List<string> _correctWords;

		public Correcter()
		{
			InitializeComponent();
			LoadWords(@"F:\Google Drive\Programming\HackBulgaria\EnglishWords.txt");
		}

		private void mainTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == ' ' || e.KeyChar == 13)
			{
				CorrectLastWord();
			}
		}

		private string FindClosest(string word)
		{
			var minDiff = word.Length;
			var minDiffWord = word;

			foreach(var currWord in _correctWords)
			{
//				var primary = (currWord.Length >= word.Length) ? currWord : word;
//				var secondary = (primary == currWord) ? word : currWord;
//				var currDiff = primary.Except(secondary).Count();

				int currDiff = Math.Abs(word.Length - currWord.Length);

				for (int i = 0; i < Math.Min(word.Length, currWord.Length); i++)
				{
					if (word[i] != currWord[i])
						currDiff++;
				}

				if(currDiff < minDiff)
				{
					minDiff = currDiff;
					minDiffWord = currWord;

					if (minDiff == 0)
						break;
				}
			}

			return minDiffWord;
		}

		private void LoadWords(string filename)
		{
			_correctWords = new List<string>();

			using(var reader = new StreamReader(filename))
			{
				string line;

				while((line = reader.ReadLine()) != null)
				{
					_correctWords.Add(line);
				}
			}
		}

		private void CorrectLastWord()
		{
			var lastWord = mainTextBox.Text.Split(' ').LastOrDefault();
			var corrected = FindClosest(lastWord);

			if (lastWord == null || lastWord.Equals(corrected)) return;

			mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - (lastWord.Length));
			mainTextBox.Text += corrected;
			mainTextBox.Select(mainTextBox.Text.Length, 0);
		}
	}
}
