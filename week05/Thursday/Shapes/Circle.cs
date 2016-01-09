using System;

namespace Shapes
{
	public class Circle : Ellipse
	{
		public Circle(double radius, Point center) : base(radius, radius, center)
		{}

		public double Radius
		{
			get { return RadiusX; }
			set { RadiusX = RadiusY = value; }
		}

		public override double RadiusX
		{
			set { Radius = value; }
		}

		public override double RadiusY
		{
			set { Radius = value; }
		}


	}
}
