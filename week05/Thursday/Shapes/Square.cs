using System;
using Shapes;

namespace Shapes
{
	public class Square : Rectangle
	{
		public Square(Point corner1, Point corner2) : base(corner1, corner2)
		{
			if (Math.Abs(Width - Height) > 0.0001)
			{
				throw new ArgumentException("Square width and height must be the same");
			}
		}

		public Square(Rectangle rect) : base(rect)
		{
			if (Math.Abs(rect.Width - rect.Height) > 0.00001)
			{
				throw new ArgumentException("Square width and height must be the same");
			}
		}
	}
}
