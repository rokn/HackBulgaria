namespace RPGEngine
{
	public interface IPlayer : ICharacter
	{
		float ManaRegenRate { get; }

		string Title { get; }
		string KnownAs();
	}
}
