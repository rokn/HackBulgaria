using System;

namespace GeometryFigures
{
    public class Rectangle
    {
        private readonly Point corner1;
        private readonly Point corner2;

        public Rectangle(Point corner1, Point corner2)
        {
            if(corner1.X == corner2.X || corner1.Y == corner2.Y)
            {
                throw new ArgumentException("Points of rectangle cannot be on the same axis");
            }

            this.corner1 = corner1;
            this.corner2 = corner2;
        }

        public Rectangle(Rectangle rect)
        {
            corner1 = new Point(rect.corner1);
            corner2 = new Point(rect.corner2);
        }

        public Point UpLeft
        {
            get
            {
                return new Point(Math.Min(corner1.X, corner2.X), Math.Max(corner1.Y, corner2.Y));
            }
        }

        public Point UpRight
        {
            get
            {
                return new Point(Math.Max(corner1.X, corner2.X), Math.Max(corner1.Y, corner2.Y));
            }
        }

        public Point DownLeft
        {
            get
            {
                return new Point(Math.Min(corner1.X, corner2.X), Math.Min(corner1.Y, corner2.Y));
            }
        }

        public Point DownRight
        {
            get
            {
                return new Point(Math.Max(corner1.X, corner2.X), Math.Min(corner1.Y, corner2.Y));
            }
        }

        public LineSegment Left
        {
            get { return new LineSegment(UpLeft, DownLeft); }
        }

        public LineSegment Top
        {
            get { return new LineSegment(UpLeft, UpRight); }
        }

        public LineSegment Right
        {
            get { return new LineSegment(UpRight, DownRight); }
        }

        public LineSegment Bottom
        {
            get { return new LineSegment(DownRight, DownLeft); }
        }

        public double Width
        {
            get { return UpRight.X - UpLeft.X; }
        }

        public double Height
        {
            get { return UpLeft.Y - DownLeft.Y; }
        }

        public Point Center
        {
            get { return new Point(DownLeft.X + Width/2, DownLeft.Y + Height/2); }
        }

        public double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return String.Format("Rectangle[({0},{1}), ({2},{3})]", UpLeft.X, UpLeft.Y, Width, Height);
        }

        public override bool Equals(object obj)
        {
            return corner1.Equals((obj as Rectangle).corner1) && corner2.Equals((obj as Rectangle).corner2);
        }

        public static bool operator ==(Rectangle rect1, Rectangle rec2)
        {
            return rect1.Equals(rect1);
        }

        public static bool operator !=(Rectangle rect1, Rectangle rec2)
        {
            return !rect1.Equals(rect1);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + corner1.GetHashCode();
                hash = hash * 23 + corner2.GetHashCode();
                return hash;
            }
        }
    }
}
