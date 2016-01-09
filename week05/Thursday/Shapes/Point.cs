using System;

namespace Shapes
{
	public class Point : IMoveable
	{
		public Point()
		{
			X = CoordinateSystemOrigin.X;
			Y = CoordinateSystemOrigin.Y;
		}

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Point(Point p)
		{
			X = p.X;
			Y = p.Y;
		}

		public double X { get; private set; }
		public double Y { get; private set; }

		public static Point CoordinateSystemOrigin => new Point(0, 0);

		public override bool Equals(object obj)
		{
			var point = obj as Point;
			return point != null && (Math.Abs(X - point.X) < 0.0001 && Math.Abs(Y - point.Y) < 0.0001);
		}

		public static bool operator ==(Point p1, Point p2)
		{
			return p1 != null && p1.Equals(p2);
		}

		public static bool operator !=(Point p1, Point p2)
		{
			return p1 != null && !p1.Equals(p2);
		}

		public static LineSegment operator +(Point p1, Point p2)
		{
			return new LineSegment(p1, p2);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash = hash*23 + X.GetHashCode();
				hash = hash*23 + Y.GetHashCode();
				return hash;
			}
		}

		public override string ToString()
		{
			return string.Format("Point({0},{1})", X, Y);
		}

		public void Move(double x, double y)
		{
			X += x;
			Y += y;
		}
	}
}