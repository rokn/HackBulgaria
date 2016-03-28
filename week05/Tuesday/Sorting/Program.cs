using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{

	class MyIntComparer : IComparer<int>
	{
		public int Compare(int x, int y)
		{
			return x.CompareTo(y);
		}
	}

	class LastDigitComparer : IComparer<int>
	{
		public int Compare(int x, int y)
		{
			int xLast = x % 10;
			int yLast = y % 10;

			return xLast.CompareTo(yLast);
		}
	}

	class StringLengthComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			return x.Length.CompareTo(y.Length);
		}
	}

	class OddEvenComparer : IComparer<int?>
	{
		public int Compare(int? x, int? y)
		{
			if (x == y) return 0;

			if (x == null)
			{
				return -1;
			}

			if (y == null)
			{
				return 1;
			}

			bool xEven = x.Value%2 == 0;
			bool yEven = y.Value%2 == 0;

			if (xEven == yEven)
			{
				if (xEven)
				{
					return x.Value.CompareTo(y.Value)*(-1);
				}

				return x.Value.CompareTo(y.Value);
			}

			if (xEven) return -1;

			return 1;
		}
	}
	
	class ReverseComparer<T> : IComparer<T>
		where T : IComparable
	{
		public int Compare(T x, T y)
		{
			return x.CompareTo(y) * (-1);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var array = new[] { 2, 4, 1, 6, 10 };
			var sortedArray = (int[])array.SelectionSort();

			foreach (var i in sortedArray)
			{
				Console.WriteLine(i);
			}
		}
	}
}
