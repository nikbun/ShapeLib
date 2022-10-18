using System;

namespace ShapeLib.Shapes
{
	public class Triangle : IShape
	{
		public Triangle(float a, float b, float c)
		{
			ShapeMath.ValidateSidesOfTriangle(a, b, c);
			A = a;
			B = b;
			C = c;
		}

		public float A { get; }
		public float B { get; }
		public float C { get; }

		public bool IsRightTriangle()
		{
			return ShapeMath.IsRightTriangle(A, B, C);
		}

		public float GetArea()
		{
			return ShapeMath.GetTriangleArea(A, B, C);
		}
	}
}
