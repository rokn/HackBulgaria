namespace Animals
{
	public class Shark : Fish
	{
		public override void BreathWater()
		{
			//blurpblurp
		}

		public override void Move()
		{
			//swimswim
		}

		public override Animal GiveBirth()
		{
			return new Shark(); // aren't shark laying eggs or something?? 
		}
	}
}
