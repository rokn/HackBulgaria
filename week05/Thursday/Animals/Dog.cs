namespace Animals
{
	public class Dog : Mammal, ILandAnimal
	{
		public string Greet()
		{
			return "Djaf";
		}

		public override void Move()
		{
			//move dog
		}

		public override Animal GiveBirth()
		{
			return new Dog();
		}
	}
}
