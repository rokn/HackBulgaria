using System;
using RPGEngine;

namespace XNARpg
{
	public abstract class Character : ICharacter
	{
		private float _health;
		private float _mana;
		protected float MaxHealth;
		protected float MaxMana;

		protected Character(string name, float maxHp, float maxMana)
		{
			MaxHealth = maxHp;
			MaxMana = maxMana;
			_health = MaxHealth;
			_mana = MaxMana;
			Name = name;
		}

		public IWeapon EquippedWeapon { get; protected set; }

		public ISpell EquippedSpell { get; protected set; }

		public string Name { get; protected set; }

		public float Health
		{
			get { return _health; }
			protected set
			{
				_health = value;
				if (_health >= MaxHealth)
					_health = MaxHealth;
				if (_health < 0)
					_health = 0;
			}
		}

		public float Mana
		{
			get { return _mana; }
			protected set {
				_mana = value;
				if(_mana >= MaxMana)
					_mana = MaxMana;
				if(_mana < 0)
					_mana = 0;
			}
		}

		public bool IsAlive()
		{
			return _health > 0;
		}

		public bool CanCast(ISpell spell)
		{
			return _mana >= spell.ManaCost;
		}

		public bool TakeHealing(float healing)
		{
			if(Math.Abs(_health - MaxHealth) < 0.001 || !IsAlive())
				return false;

			_health = Math.Min(_health + healing, MaxHealth);
			return true;
		}

		public bool TakeMana(float mana)
		{
			if(Math.Abs(_mana - MaxMana) < 0.001 || !IsAlive())
				return false;

			_mana = Math.Min(_mana + mana, MaxMana);
			return true;
		}

		public float Attack(AttackType attackType)
		{
			float damage = 0;

			switch(attackType)
			{
				case AttackType.Weapon:
					EquippedWeapon.Use(out damage);
					break;

				case AttackType.Spell:
					if (CanCast(EquippedSpell))
					{
						damage = EquippedSpell.Damage;
						_mana = Math.Max(0, _mana - EquippedSpell.ManaCost);
					}
					break;
			}

			return damage;
		}

		public float TakeDamage(float damage)
		{
			var oldHp = _health;
			_health = Math.Max(0, _health - damage);

			return oldHp - _health;
		}

		public bool Equip(IWeapon weapon)
		{
			EquippedWeapon = weapon;
			return true;
		}

		public bool Learn(ISpell spell)
		{
			EquippedSpell = spell;
			return true;
		}
	}
}
