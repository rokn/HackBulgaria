using System;
using RPGEngine;

namespace XNARpg
{
	public class Weapon : DamageDealObject, IWeapon
	{
		private int _durability;

		public Weapon(float damage, string name, int durability) 
			: base(damage, name)
		{
			_durability = durability;
		}

		public int Durability
		{
			get { return _durability; }
			set { _durability = Math.Min(0, value); }
		}

		public bool Use(out float damage)
		{
			if (Durability > 0)
			{
				damage = this.Damage;
				Durability--;
				return true;
			}

			damage = 0;
			return false;
		}

	}
}
