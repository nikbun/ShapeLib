using System;

namespace ShapeLib.Shapes
{
	public class Circle : IShape
	{
		public Circle(float r)
		{
			ShapeMath.ValidateRadius(r);
			R = r;
		}

		public float R { get; }

		public float GetArea()
		{
			return ShapeMath.GetCircleArea(R);
		}
	}
}
