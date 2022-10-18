using NUnit.Framework;
using ShapeLib.Shapes;

namespace ShapeLib.Test
{
	[TestFixture]
	public class CircleTest
	{
		private const float Delta = 0.0001f;

		[TestCase(-4f)]
		[TestCase(0f)]
		public void Constructor_InvalidParameters(float r)
		{
			Assert.Throws<ArgumentException>(() => new Circle(r));
		}

		[TestCase(13f, 530.9292f)]
		[TestCase(3.55f, 39.5919f)]
		[TestCase(6f, 113.0973f)]
		[TestCase(2.55f, 20.4282f)]
		public void GetArea(float r, float expected)
		{
			var circle = new Circle(r);
			var area = circle.GetArea();
			Assert.That(area, Is.EqualTo(expected).Within(Delta));
		}
	}
}
