using System;
using System.Collections.Generic;
using System.Drawing;

namespace People
{
	public class Child : Person
	{
		public Child(Gender gender) : base(gender)
		{
			_toys = new List<Toy>() { new Toy(Color.Indigo, new Size(5, 5)) , new Toy(Color.Gold, new Size(15, 5)) , new Toy(Color.Green, new Size(5, 15)) };
		}

		private readonly List<Toy> _toys;

		public override void DailyStuff()
		{
			foreach (var toy in _toys)
			{
				Console.WriteLine("Toy: Color: {0}, Size: {1}", toy.Color.ToString(),toy.Size.ToString());
			}
		}

		public override string ToString()
		{
			return string.Format("A child {0} with {1} toys", Gender, _toys.Count);
		}
	}

	public class Toy
	{
		public Color Color { get; private set; }
		public Size Size { get; private set; }

		public Toy(Color color, Size size)
		{
			Color = color;
			Size = size;
		}
	}
}
