namespace RPGEngine
{
	public interface IWeapon : IDamageDealObject
	{
		/// <summary>
		///     Durability of the weapon
		/// </summary>
		int Durability { get; }

		/// <summary>
		///     Uses the weapon
		/// </summary>
		/// <param name="damage">Damage from weapon</param>
		/// <returns>Returns true if the weapon can be used</returns>
		bool Use(out float damage);
	}
}