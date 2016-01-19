using RPGEngine;

namespace XNARpg
{
	public class Spell : DamageDealObject, ISpell
	{
		public float ManaCost { get; }

		public int CastRange { get; }

		public Spell(float damage, string name, float manaCost, int castRange) 
			: base(damage, name)
		{
			ManaCost = manaCost;
			CastRange = castRange;
		}
	}
}
