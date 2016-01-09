namespace Animals
{
	public class Cat : Mammal, ILandAnimal
	{
		public string Greet()
		{
			return "Meow";
		}

		public override void Move()
		{
			//Cat walking
		}

		public override Animal GiveBirth()
		{
			return new Cat();
		}
	}
}
