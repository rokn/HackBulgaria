using System;

namespace Shapes
{
	public class Rectangle : IShape
	{
		private readonly Point _corner1;
		private readonly Point _corner2;

		public Rectangle(Point corner1, Point corner2)
		{
			if (Math.Abs(corner1.X - corner2.X) < 0.0001 || Math.Abs(corner1.Y - corner2.Y) < 0.0001)
			{
				throw new ArgumentException("Points of rectangle cannot be on the same axis");
			}

			_corner1 = corner1;
			_corner2 = corner2;
		}

		public Rectangle(Rectangle rect)
		{
			_corner1 = new Point(rect._corner1);
			_corner2 = new Point(rect._corner2);
		}

		public Point UpLeft => new Point(Math.Min(_corner1.X, _corner2.X), Math.Max(_corner1.Y, _corner2.Y));

		public Point UpRight => new Point(Math.Max(_corner1.X, _corner2.X), Math.Max(_corner1.Y, _corner2.Y));

		public Point DownLeft => new Point(Math.Min(_corner1.X, _corner2.X), Math.Min(_corner1.Y, _corner2.Y));

		public Point DownRight => new Point(Math.Max(_corner1.X, _corner2.X), Math.Min(_corner1.Y, _corner2.Y));

		public LineSegment Left => new LineSegment(UpLeft, DownLeft);

		public LineSegment Top => new LineSegment(UpLeft, UpRight);

		public LineSegment Right => new LineSegment(UpRight, DownRight);

		public LineSegment Bottom => new LineSegment(DownRight, DownLeft);

		public double Width => UpRight.X - UpLeft.X;

		public double Height => UpLeft.Y - DownLeft.Y;

		public Point Center => new Point(DownLeft.X + Width/2, DownLeft.Y + Height/2);

		public double GetPerimeter()
		{
			return Width*2 + Height*2;
		}

		public double GetArea()
		{
			return Width*Height;
		}

		public override string ToString()
		{
			return String.Format("Rectangle[({0},{1}), ({2},{3})]", UpLeft.X, UpLeft.Y, Width, Height);
		}

		public override bool Equals(object obj)
		{
			var rectangle = obj as Rectangle;
			return rectangle != null && (_corner1.Equals(rectangle._corner1) && _corner2.Equals(rectangle._corner2));
		}

		public static bool operator ==(Rectangle rect1, Rectangle rect2)
		{
			return rect1 != null && rect1.Equals(rect2);
		}

		public static bool operator !=(Rectangle rect1, Rectangle rect2)
		{
			return rect1 != null && !rect1.Equals(rect2);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash = hash*23 + _corner1.GetHashCode();
				hash = hash*23 + _corner2.GetHashCode();
				return hash;
			}
		}

		public void Move(double x, double y)
		{
			_corner1.Move(x, y);
			_corner2.Move(x, y);
		}
	}
}