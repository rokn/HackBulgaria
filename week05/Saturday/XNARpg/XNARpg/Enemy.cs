using RPGEngine;

namespace XNARpg
{
	public class Enemy : Character, IEnemy
	{
		public float BaseDamage { get; }

		public Enemy(string name, float maxHp, float maxMana, float baseDamage) 
			: base(name, maxHp, maxMana)
		{
			BaseDamage = baseDamage;
		}
	}
}
