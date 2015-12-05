using System;

namespace GeometryFigures
{
    public class LineSegment
    {
        private readonly Point start;
        private readonly Point end;

        public Point Start
        {
            get { return start; }
        }

        public Point End
        {
            get { return end; }
        }

        public LineSegment(Point start, Point end)
        {
            if(start.Equals(end))
            {
                throw new ArgumentException("Cannot create a line segment with zero length");
            }

            this.start = start;
            this.end = end;
        }

        public LineSegment(LineSegment line)
        {
            start = line.Start;
            end = line.End;
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        }

        public override string ToString()
        {
            return string.Format("Line[({0},{1}), ({2},{3})]", start.X, start.Y, end.X, end.Y);
        }

        public override bool Equals(object obj)
        {
            return start.Equals((obj as LineSegment).start) && end.Equals((obj as LineSegment).end);
        }

        public static bool operator ==(LineSegment line1, LineSegment line2)
        {
            return line1.Equals(line2);
        }

        public static bool operator !=(LineSegment line1, LineSegment line2)
        {
            return !line1.Equals(line2);
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
                int hash = 17;
                hash = hash * 23 + start.GetHashCode();
                hash = hash * 23 + end.GetHashCode();
                return hash;
            }
        }
    }
}
