namespace RPGEngine
{
	public interface ISpell : IDamageDealObject
	{
		/// <summary>
		///     Mana cost of the spell
		/// </summary>
		float ManaCost { get; }

		/// <summary>
		///     Cast range of the spell
		/// </summary>
		int CastRange { get; }
	}
}