using System;

namespace GeometryFigures
{
    public class Point
    {
        private readonly double x;
        private readonly double y;

        public Point()
        {
            this.x = CoordinateSystemOrigin.x;
            this.y = CoordinateSystemOrigin.y;
            DateTime date = DateTime.Now;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        public static Point CoordinateSystemOrigin
        {
            get { return new Point(0, 0); }
        }

        public override bool Equals(object obj)
        {
            return X == (obj as Point).X && Y == (obj as Point).Y;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        public static LineSegment operator +(Point p1, Point p2)
        {
            return new LineSegment(p1,p2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("Point({0},{1})", x,y);
        }

    }
}
