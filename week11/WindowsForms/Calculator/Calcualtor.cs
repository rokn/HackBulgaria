using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Calculator.Properties;

namespace Calculator
{
	public enum Operator
	{
		None,
		Plus,
		Minus,
		Multiply,
		Divide,
	}

	public partial class Calculator : Form
	{
		private Operator _currOperator;
		private double _lhsNumber;
		private bool _resetResult;
		private double _memory;

		public Calculator()
		{

			InitializeComponent();

			_resetResult = true;
			_lhsNumber = 0;
			_currOperator = Operator.None;
			_memory = 0;

			mainPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

			foreach (var button in basicOpsPanel.Controls.Cast<Control>().Concat(advancedOpsPanel.Controls.Cast<Control>()).Concat(memoryPanel.Controls.Cast<Control>()).Cast<Button>())
			{
				button.FlatAppearance.BorderSize = 0;
				button.FlatStyle = FlatStyle.Flat;
				button.Margin = new Padding(0);
			}

			foreach(Button button in basicOpsPanel.Controls)
			{
				button.BackColor = Settings.Default.LightBackColor;
				button.ForeColor = Settings.Default.LightForeColor;
			}

			foreach(Button button in advancedOpsPanel.Controls)
			{
				button.BackColor = Settings.Default.DarkBackColor;
				button.ForeColor = Settings.Default.DarkForeColor;
			}

			foreach(Button button in memoryPanel.Controls)
			{
				button.BackColor = Settings.Default.DarkBackColor;
				button.ForeColor = Settings.Default.DarkForeColor;
			}
			mainPanel.BackColor = Settings.Default.DarkBackColor;

			resultTextBox.AutoSize = false;
			resultTextBox.BorderStyle = BorderStyle.None;
			resultTextBox.BackColor = Settings.Default.DarkBackColor;
			resultTextBox.ForeColor = Settings.Default.DarkForeColor;

			operationTextBox.AutoSize = false;
			operationTextBox.BorderStyle = BorderStyle.None;
			operationTextBox.BackColor = Settings.Default.DarkBackColor;
			operationTextBox.ForeColor = Settings.Default.DarkForeColor;

			OnResize(EventArgs.Empty);
		}

		protected override sealed void OnResize(EventArgs e)
		{
			base.OnResize(e);
		}	

		private void Calculator_Resize(object sender, EventArgs e)
		{
			var oldFont = resultTextBox.Font;
			resultTextBox.Font = new Font(oldFont.FontFamily, resultTextBox.Height - resultTextBox.Height/3, oldFont.Style, GraphicsUnit.Pixel);
		}

		private void DigitPressed(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null) AddToResult(button.Text);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if(keyData >= Keys.NumPad0 && keyData <= Keys.NumPad9)
			{
				AddToResult((keyData - Keys.NumPad0).ToString());
			}

			if(keyData >= Keys.D0 && keyData <= Keys.D9)
			{
				AddToResult((keyData - Keys.D0).ToString());
			}

			if (keyData == Keys.Back)
			{
				RemoveLastFromRes();
			}

			if(keyData == Keys.Enter)
			{
				Calculate();
			}

			if(keyData == Keys.OemPeriod || keyData == Keys.Decimal)
			{
				dotKeyButton.Focus();
				dotKeyButton.PerformClick();
			}

			if(keyData == Keys.Add)
			{
				plusButton.Focus();
				plusButton.PerformClick();
			}

			if(keyData == Keys.Subtract)
			{
				minusButton.Focus();
				minusButton.PerformClick();
			}

			if(keyData == Keys.Multiply)
			{
				multiplyButton.Focus();
				multiplyButton.PerformClick();
			}

			if(keyData == Keys.Divide)
			{
				divideButton.Focus();
				divideButton.PerformClick();
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void RemoveLastFromRes()
		{
			if (_resetResult)
				return;

			if(resultTextBox.Text.Length > 0)
				resultTextBox.Text = resultTextBox.Text.Remove(resultTextBox.Text.Length - 1);
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			RemoveLastFromRes();
		}

		private void resultTextBox_TextChanged(object sender, EventArgs e)
		{
			if (resultTextBox.Text.Length > resultTextBox.MaxLength)
				resultTextBox.Text = resultTextBox.Text.Remove(resultTextBox.MaxLength);

			resultTextBox.Select(resultTextBox.Text.Length, 0);
		}

		private void Calculate()
		{
			double rhs;
			double res = 0;

			if (!double.TryParse(resultTextBox.Text, out rhs)) return;

			switch (_currOperator)
			{
				case Operator.None:
					return;
				case Operator.Plus:
					res = _lhsNumber + rhs;
					break;
				case Operator.Minus:
					res = _lhsNumber - rhs;
					break;
				case Operator.Multiply:
					res = _lhsNumber * rhs;
					break;
				case Operator.Divide:
					if (Math.Abs(rhs) < 0.0000001)
					{
						MessageBox.Show(Resources.DivideByZeroText);
						break;
					}

					res = _lhsNumber / rhs;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			operationTextBox.Clear();
			_lhsNumber = 0;
			_currOperator = Operator.None;
			resultTextBox.Text = res.ToString(CultureInfo.CurrentCulture);
		}

		private void dotKeyButton_Click(object sender, EventArgs e)
		{
			AddDot();
		}

		private void AddDot()
		{
			if (resultTextBox.Text.Contains(".") && !_resetResult)
				return;

			if(_resetResult)
				resultTextBox.Clear();

			if(resultTextBox.Text.Length <= 0)
				resultTextBox.Text += 0;

			resultTextBox.Text += '.';
		}

		private void negateKeyButton_Click(object sender, EventArgs e)
		{
			resultTextBox.Text = !resultTextBox.Text.Contains("-") ? resultTextBox.Text.Insert(0, "-") : resultTextBox.Text.Remove(0, 1);
		}

		private void AppendOperator(char op)
		{
			double res;

			if(!_resetResult)
				Calculate();

			if (!double.TryParse(resultTextBox.Text, out res)) return;

			_currOperator = op.ToOperator();
			_lhsNumber = res;
			operationTextBox.Text = _lhsNumber + " " + op.ToString();

			_resetResult = true;
		}

		private void BasicOperatorClick(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null) AppendOperator(button.Text[0]);
		}

		private void AddToResult(string numb)
		{
			if(resultTextBox.Text == "0")
				resultTextBox.Clear();

			if (_resetResult)
			{
				resultTextBox.Clear();
				_resetResult = false;
			}

			resultTextBox.AppendText(numb);
		}

		private void AdvancedOpsClick(object sender, EventArgs e)
		{
			double rhs;
			double res = 0;
			if(!double.TryParse(resultTextBox.Text, out rhs))
				return;

			if (sender.Equals(percentButton))
				res = _lhsNumber*rhs/100;
			else if(sender.Equals(sqrtButton))
				res = Math.Sqrt(rhs);
			else if(sender.Equals(sqrButton))
				res = rhs * rhs;
			else if (sender.Equals(reciprocalButton))
			{
				if (Math.Abs(rhs) < 0.000001)
				{
					MessageBox.Show(Resources.DivideByZeroText);
					return;
				}
				res = 1/rhs;
			}

			resultTextBox.Text = res.ToString(CultureInfo.CurrentCulture);

			Calculate();
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void clearEverythingButton_Click(object sender, EventArgs e)
		{
			ClearAll();
		}

		private void Clear()
		{
			_lhsNumber = 0;
			_currOperator = Operator.None;
			resultTextBox.Text = "0";
			operationTextBox.Clear();
		}

		private void ClearAll()
		{
			Clear();
			_memory = 0;
		}

		private void memSubtractButton_Click(object sender, EventArgs e)
		{
			double rhs;

			if (!double.TryParse(resultTextBox.Text, out rhs)) return;

			_memory -= rhs;
		}

		private void memAddButton_Click(object sender, EventArgs e)
		{
			double rhs;

			if(!double.TryParse(resultTextBox.Text, out rhs))
				return;

			_memory += rhs;
		}

		private void memReadButton_Click(object sender, EventArgs e)
		{
			resultTextBox.Text = _memory.ToString(CultureInfo.CurrentCulture);
		}

		private void memClearButton_Click(object sender, EventArgs e)
		{
			_memory = 0;
		}

		private void equalButton_Click(object sender, EventArgs e)
		{
			Calculate();
		}
	}
}
