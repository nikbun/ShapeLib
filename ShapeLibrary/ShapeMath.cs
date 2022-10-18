using ShapeLib.Shapes;
using System;

namespace ShapeLib
{
    public static class ShapeMath
    {
        public static float GetArea(IShape shape)
        {
            return shape.GetArea();
        }

        public static float GetArea(dynamic shape)
        {
			if (shape is IShape s)
            {
                return s.GetArea();
            }
            else
            {
                throw new InvalidCastException("Variable \"shape\" not has type \"IShape\"!");
            }
		}

        public static float GetCircleArea(float r)
		{
            ValidateRadius(r);
			return (float)Math.PI * r * r;
		}

        public static float GetTriangleArea(float a, float b, float c)
		{
			ValidateSidesOfTriangle(a, b, c);

			var hP = (a + b + c) / 2f;
            return (float)Math.Sqrt(hP * (hP - a) * (hP - b) * (hP - c));
        }

        public static bool IsRightTriangle(float a, float b, float c)
        {
            ValidateSidesOfTriangle(a, b, c);

            var a2 = a * a;
            var b2 = b * b;
            var c2 = c * c;
			
            return Math.Abs(b2 + a2 - c2) <= float.Epsilon 
                || Math.Abs(b2 + c2 - a2) <= float.Epsilon 
                || Math.Abs(a2 + c2 - b2) <= float.Epsilon;
        }

        public static bool IsRightTriangle(Triangle triangle) 
        {
            return triangle.IsRightTriangle();
        }

        internal static void ValidateSidesOfTriangle(float a, float b, float c)
        {
			if (a <= 0 || b <= 0 || c <= 0)
			{
				throw new ArgumentException("Sides of triangle must be greater than zero!");
			}
            if (a + b <= c || b + c <= a || c + a <= b)
			{
				throw new ArgumentException($"A triangle with such sides cannot exist! Sides {a}, {b}, {c}");
			}
		}

        internal static void ValidateRadius(float r)
        {
			if (r <= 0)
			{
				throw new ArgumentException("Radius must be greater than zero!");
			}
		}
    }
}
