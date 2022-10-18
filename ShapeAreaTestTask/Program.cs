/*
	Пример использования библиотеки
 */
using ShapeLib.Shapes;

namespace ShapeAreaTestTask
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var shapes = new List<IShape>
			{
				new Circle(3),
				new Square(2),
				new Triangle(4, 5, 3)
			};
			var sumArea = 0f;
			for(var i = 0; i < shapes.Count; i++)
			{
				var area = shapes[i].GetArea();
				sumArea += area;
				Console.WriteLine("Площадь фигуры {0} = {1:0.##}", i+1, area);
			}

			Console.WriteLine("Общая площадь всех фигур = {0:0.##}", sumArea);
		}
	}

	public class Square : IShape
	{
		public Square(float side)
		{
			if (side <= 0)
			{
				throw new ArgumentException("Side must be greater than zero!");
			}

			Side = side;
		}

		public float Side { get; }

		public float GetArea()
		{
			return Side * Side;
		}
	}
}