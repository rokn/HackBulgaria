using System;

namespace Shapes
{
	public class Triangle : IShape
	{
		private Point _vertexA;
		private Point _vertexB;
		private Point _vertexC;

		public Triangle(Point vertexA, Point vertexB, Point vertexC)
		{
			_vertexA = vertexA;
			_vertexB = vertexB;
			_vertexC = vertexC;
		}

		public Point VertexA
		{
			get { return _vertexA; }
			set
			{
				if(value == VertexB || value == VertexC)
				{
					throw new ArgumentException("Triangle vertecies");
				}

				_vertexA = VertexA;
			}
		}

		public Point VertexB
		{
			get { return _vertexB; }
			set
			{
				if(value == VertexA || value == VertexC)
				{
					throw new ArgumentException("Triangle vertecies");
				}

				_vertexB = value;
			}
		}

		public Point VertexC
		{
			get { return _vertexC; }
			set
			{
				if(value == VertexB || value == VertexA)
				{
					throw new ArgumentException("Triangle vertecies");
				}

				_vertexC = value;
			}
		}

		public LineSegment SideA => new LineSegment(VertexB, VertexC);

		public LineSegment SideB => new LineSegment(VertexA, VertexC);

		public LineSegment SideC => new LineSegment(VertexA, VertexB);


		public double GetPerimeter()
		{
			return SideA.GetLength() + SideB.GetLength() + SideC.GetLength();
		}

		public double GetArea()
		{
			return (VertexA.X * (VertexB.Y - VertexC.Y) + VertexB.X * (VertexA.Y - VertexC.Y) + VertexC.X * (VertexA.Y - VertexB.Y)) / 2;
		}

		public void Move(double x, double y)
		{
			VertexA.Move(x, y);
			VertexB.Move(x, y);
			VertexC.Move(x, y);
		}
	}
}
