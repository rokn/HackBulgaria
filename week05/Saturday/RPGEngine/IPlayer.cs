namespace RPGEngine
{
	public interface IPlayer : ICharacter
	{
		int HealthPotions { get; set; }
		int ManaPotions { get; set; }
		float ManaRegenRate { get; }
		string Title { get; }
		string KnownAs();
		bool DrinkHealthPotion();
		bool DrinkManaPotion();
	}
}