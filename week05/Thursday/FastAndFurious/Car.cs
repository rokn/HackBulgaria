namespace FastAndFurious
{
	public abstract class Car
	{
		protected float Mileage;

		public virtual bool IsEcoFriendly(bool testing)
		{
			return true;
		}
	}

	public class Honda : Car
	{
	}

	public class Skoda : Car
	{
	}
}
