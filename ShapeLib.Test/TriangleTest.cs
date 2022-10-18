using NUnit.Framework;
using ShapeLib.Shapes;
using System;

namespace ShapeLib.Test
{
	[TestFixture]
	public class TriangleTest
	{
		private const float Delta = 0.0001f;

		[TestCase(0f, 1f, 1f)]
		[TestCase(1f, 0f, 1f)]
		[TestCase(1f, 1f, 0f)]
		[TestCase(-1f, 1f, 1f)]
		[TestCase(1f, -1f, 1f)]
		[TestCase(1f, 1f, -1f)]
		[TestCase(20f, 1f, 1f)]
		[TestCase(20f, 10f, 10f)]
		public void Conctructor_InvalidParameters(float a, float b, float c)
		{
			Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
		}

		[TestCase(4.6f, 5.34f, 6.23f, 11.9780f)]
		[TestCase(5f, 12f, 13f, 30f)]
		[TestCase(14.34f, 12.5f, 5.95f, 37.0228f)]
		public void GetArea(float a, float b, float c, float expected)
		{
			var triangle = new Triangle(a, b, c);
			var area = triangle.GetArea();
			Assert.That(area, Is.EqualTo(expected).Within(Delta));
		}

		[TestCase(5.87f, 12.56f, 13.864f, ExpectedResult = true)]
		[TestCase(7f, 12f, 13f, ExpectedResult = false)]
		[TestCase(5f, 12f, 13f, ExpectedResult = true)]
		[TestCase(12f, 13f, 5f, ExpectedResult = true)]
		[TestCase(13f, 5f, 12f, ExpectedResult = true)]
		public bool IsRightTriangle(float a, float b, float c)
		{
			var triangle = new Triangle(a, b, c);
			return triangle.IsRightTriangle();
		}
	}
}
