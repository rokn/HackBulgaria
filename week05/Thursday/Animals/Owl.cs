namespace Animals
{
	public class Owl : Bird, ILandAnimal
	{
		public override void MakeNest()
		{
			// Do owl's make nests ???
		}

		public string Greet()
		{
			return "HOOOOO-HOOOOOOOOO";
		}

		public override void Move()
		{
			//FLY ON THE WINGS OF ...
		}

		public override Animal GiveBirth()
		{
			return new Owl();
		}
	}
}
