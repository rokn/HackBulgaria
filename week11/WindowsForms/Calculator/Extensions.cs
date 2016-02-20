using System;

namespace Calculator
{
	public static class Extensions
	{
		public static char ToChar(this Operator op)
		{
			switch(op)
			{
				case Operator.Plus:
					return '+';
				case Operator.Minus:
					return '-';
				case Operator.Multiply:
					return '*';
				case Operator.Divide:
					return '/';
				default:
					throw new Exception("Don't use none as argument to char...");
			}
		}

		public static Operator ToOperator(this char op)
		{
			switch(op)
			{
				case '+':
					return Operator.Plus;
				case '-':
					return Operator.Minus;
				case '*':
					return Operator.Multiply;
				case '/':
					return Operator.Divide;
				default:
					throw new Exception("Unrecognized operator: " + op);
			}
		}
	}
}
