namespace Animals
{
	public class Crocodile : Reptile
	{
		public string Greet()
		{
			return "I'M A F****** CROCODILE";
		}

		public override void Move()
		{
			//Crocodile move
		}

		public override Animal GiveBirth()
		{
			return new Crocodile();
		}
	}
}
