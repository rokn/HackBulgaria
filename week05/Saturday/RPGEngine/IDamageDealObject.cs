namespace RPGEngine
{
	public interface IDamageDealObject
	{
		/// <summary>
		/// Damage of the object
		/// </summary>
		float Damage { get; }

		/// <summary>
		/// Name of the object
		/// </summary>
		string Name { get; }
	}
}
