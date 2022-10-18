/*
 * Тесты до этого не доводилось писать
 */
using NUnit.Framework;
using ShapeLib.Shapes;
using System;

namespace ShapeLib.Test
{
	[TestFixture]
	public class ShapeMathTest
	{
		private const float Delta = 0.0001f;

		[TestCase(3f, 7f, 6f, 8.9442f)]
		public void GetArea_Triangle(float a, float b, float c, float expected)
		{
			var triangle = new Triangle(a, b, c);
			var area = ShapeMath.GetArea(triangle);
			Assert.That(area, Is.EqualTo(expected).Within(Delta));
		}

		[TestCase(4f, 50.2655f)]
		public void GetArea_Circle(float r, float expected)
		{
			var circle = new Circle(r);
			var area = ShapeMath.GetArea(circle);
			Assert.That(area, Is.EqualTo(expected).Within(Delta));
		}

		[Test]
		public void GetArea_Dynamic()
		{
			object shape = new Circle(4);
			float area = ShapeMath.GetArea(shape);
			Assert.That(area, Is.EqualTo(50.2655f).Within(Delta));
		}

		[Test]
		public void GetArea_Dynamic_WrongType()
		{
			Assert.Throws<InvalidCastException>(() => ShapeMath.GetArea(1));
		}

		[TestCase(13f, 530.9292f)]
		[TestCase(3.55f, 39.5919f)]
		public void GetCircleArea(float r, float expected)
		{
			var area = ShapeMath.GetCircleArea(r);
			Assert.That(area, Is.EqualTo(expected).Within(Delta));
		}

		[TestCase(0f)]
		[TestCase(-3)]
		public void GetCircleArea_InvalidParameters(float r)
		{
			Assert.Throws<ArgumentException>(() => ShapeMath.GetCircleArea(r));
		}

		[TestCase(5f, 12f, 13f, 30f)]
		[TestCase(14.34f, 12.5f, 5.95f, 37.0228f)]
		public void GetTriangleArea(float a, float b, float c, float expected)
		{
			var area = ShapeMath.GetTriangleArea(a, b, c);
			Assert.That(area, Is.EqualTo(expected).Within(Delta));
		}

		[TestCase(0f, 1f, 1f)]
		[TestCase(1f, 0f, 1f)]
		[TestCase(1f, 1f, 0f)]
		[TestCase(-1f, 1f, 1f)]
		[TestCase(1f, -1f, 1f)]
		[TestCase(1f, 1f, -1f)]
		[TestCase(20f, 1f, 1f)]
		[TestCase(20f, 10f, 10f)]
		public void GetTriangleArea_InvalidParameters(float a, float b, float c)
		{
			Assert.Throws<ArgumentException>(() => ShapeMath.GetTriangleArea(a, b, c));
		}

		[TestCase(5.87f, 12.56f, 13.864f, ExpectedResult = true)]
		[TestCase(7f, 12f, 13f, ExpectedResult = false)]
		[TestCase(5f, 12f, 13f, ExpectedResult = true)]
		[TestCase(12f, 13f, 5f, ExpectedResult = true)]
		[TestCase(13f, 5f, 12f, ExpectedResult = true)]
		public bool IsRightTriangle(float a, float b, float c)
		{
			return ShapeMath.IsRightTriangle(a, b, c);
		}

		[TestCase(5.87f, 12.56f, 13.864f, ExpectedResult = true)]
		[TestCase(7f, 12f, 13f, ExpectedResult = false)]
		[TestCase(5f, 12f, 13f, ExpectedResult = true)]
		[TestCase(12f, 13f, 5f, ExpectedResult = true)]
		[TestCase(13f, 5f, 12f, ExpectedResult = true)]
		public bool IsRightTriangle_Triangle(float a, float b, float c)
		{
			return ShapeMath.IsRightTriangle(new Triangle(a, b, c));
		}

		[TestCase(0f, 1f, 1f)]
		[TestCase(1f, 0f, 1f)]
		[TestCase(1f, 1f, 0f)]
		[TestCase(-1f, 1f, 1f)]
		[TestCase(1f, -1f, 1f)]
		[TestCase(1f, 1f, -1f)]
		[TestCase(20f, 1f, 1f)]
		[TestCase(20f, 10f, 10f)]
		public void IsRightTriangle_InvalidParameters(float a, float b, float c)
		{
			Assert.Throws<ArgumentException>(() => ShapeMath.IsRightTriangle(a, b, c));
		}
	}
}
