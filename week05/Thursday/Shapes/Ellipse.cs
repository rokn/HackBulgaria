using System;

namespace Shapes
{
	public class Ellipse : IShape
	{
		public Ellipse(double radiusX, double radiusY, Point center)
		{
			RadiusX = radiusX;
			RadiusY = radiusY;
			Center = center;
		}

		public virtual double RadiusX { get; set; }
		public virtual double RadiusY { get; set; }
		public Point Center { get; private set; }

		public double GetPerimeter()
		{
			var a = RadiusX;
			var b = RadiusY;
			return Math.PI*(3*(a + b) - Math.Sqrt((3*a + b)*(a + 3*b)));
		}

		public double GetArea()
		{
			return Math.PI * RadiusX * RadiusY;
		}

		public void Move(double x, double y)
		{
			Center.Move(x, y);
		}
	}
}
