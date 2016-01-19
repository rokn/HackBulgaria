using RPGEngine;

namespace XNARpg
{
	public abstract class DamageDealObject : IDamageDealObject
	{
		public float Damage { get; }

		public string Name { get; }

		protected DamageDealObject(float damage, string name)
		{
			Damage = damage;
			Name = name;
		}
	}
}
