using System;

namespace Shapes
{
	public class LineSegment
	{
		public LineSegment(Point start, Point end)
		{
			if (start.Equals(end))
			{
				throw new ArgumentException("Cannot create a line segment with zero length");
			}

			Start = start;
			End = end;
		}

		public LineSegment(LineSegment line)
		{
			Start = line.Start;
			End = line.End;
		}

		public Point Start { get; }
		public Point End { get; }

		public double GetLength()
		{
			return Math.Sqrt(Math.Pow(Start.X - End.X, 2) + Math.Pow(Start.Y - End.Y, 2));
		}

		public override string ToString()
		{
			return string.Format("Line[({0},{1}), ({2},{3})]", Start.X, Start.Y, End.X, End.Y);
		}

		public override bool Equals(object obj)
		{
			var lineSegment = obj as LineSegment;
			return lineSegment != null && (Start.Equals(lineSegment.Start) && End.Equals(lineSegment.End));
		}

		public static bool operator ==(LineSegment line1, LineSegment line2)
		{
			return line1 != null && line1.Equals(line2);
		}

		public static bool operator !=(LineSegment line1, LineSegment line2)
		{
			return line1 != null && !line1.Equals(line2);
		}

		public static bool operator >(LineSegment line1, LineSegment line2)
		{
			return line1.GetLength() > line2.GetLength();
		}

		public static bool operator <(LineSegment line1, LineSegment line2)
		{
			return line1.GetLength() < line2.GetLength();
		}

		public static bool operator >=(LineSegment line1, LineSegment line2)
		{
			return line1.GetLength() >= line2.GetLength();
		}

		public static bool operator <=(LineSegment line1, LineSegment line2)
		{
			return line1.GetLength() <= line2.GetLength();
		}

		public static bool operator >(LineSegment line1, double length)
		{
			return line1.GetLength() > length;
		}

		public static bool operator <(LineSegment line1, double length)
		{
			return line1.GetLength() < length;
		}

		public static bool operator >=(LineSegment line1, double length)
		{
			return line1.GetLength() >= length;
		}

		public static bool operator <=(LineSegment line1, double length)
		{
			return line1.GetLength() <= length;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash = hash*23 + Start.GetHashCode();
				hash = hash*23 + End.GetHashCode();
				return hash;
			}
		}
	}
}