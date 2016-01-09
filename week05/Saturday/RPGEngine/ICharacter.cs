namespace RPGEngine
{
	public interface ICharacter
	{
		IWeapon EquippedWeapon { get; }
		ISpell EqippedSpell { get; }
		string Name { get; }

		/// <summary>
		/// Check if a character is alive
		/// </summary>
		/// <returns>Returns true if it is alive</returns>
		bool IsAlive();

		/// <summary>
		/// Checks if the character can cast eqipped spell
		/// </summary>
		bool CanCast(ISpell spell);

		/// <summary>
		/// Gets the health of the character
		/// </summary>
		float GetHealth();

		/// <summary>
		/// Gets the mana of the character
		/// </summary>
		float GetMana();

		/// <summary>
		/// Heals the character
		/// </summary>
		/// <param name="healing">How much to be healed</param>
		/// <returns>True if the character has been healed</returns>
		bool TakeHealing(float healing);

		/// <summary>
		/// Gives mana to the character
		/// </summary>
		/// <param name="mana">How much manato be given</param>
		/// <returns>True if the character has taken mana</returns>
		bool TakeMana(float mana);

		/// <summary>
		/// Attack the given character
		/// </summary>
		/// <param name="character">The character to be attacked</param>
		/// <returns>The damage dealt</returns>
		float Attack(ICharacter character);

		/// <summary>
		/// Deals damage to the character
		/// </summary>
		/// <param name="damage">Damage to be dealt</param>
		/// <returns>Returns Damage dealt</returns>
		float TakeDamage(float damage);

		/// <summary>
		/// Equips a weapon
		/// </summary>
		/// <param name="weapon">Weapon to be equipped</param>
		/// <returns>Returns true if equip is successful</returns>
		bool Equip(IWeapon weapon);

		/// <summary>
		/// Learns a spell
		/// </summary>
		/// <param name="spell">Spell to be learned</param>
		/// <returns>Returns true if learning is successful</returns>
		bool Learn(ISpell spell);
	}
}
