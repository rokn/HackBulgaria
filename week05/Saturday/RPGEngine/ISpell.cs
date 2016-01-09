namespace RPGEngine
{
	public interface ISpell
	{
		/// <summary>
		/// Mana cost of the spell
		/// </summary>
		float ManaCost { get; }

		/// <summary>
		/// Cast range of the spell
		/// </summary>
		int CastRange { get; }
	}
}
