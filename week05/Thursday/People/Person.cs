namespace People
{
	public enum Gender
	{
		Female,
		Male
	}

	public abstract class Person
	{
		public Gender Gender { get; protected set; }

		protected Person(Gender gender)
		{
			Gender = gender;
		}

		public abstract void DailyStuff();
	}
}
