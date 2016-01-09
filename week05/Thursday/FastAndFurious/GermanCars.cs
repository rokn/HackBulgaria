namespace FastAndFurious
{
	public class Audi : GermanCar
	{
	}

	// ReSharper disable once InconsistentNaming
	public class BMW : GermanCar
	{
	}

	public class Volkswagen : GermanCar
	{
		public override bool IsEcoFriendly(bool testing)
		{
			return testing;
		}
	}
}
