using System;
using RPGEngine;
using Xna.Common;

namespace XNARpg
{
	public class Player : Character, IPlayer
	{
		private int _healthPotions;
		private int _manaPotions;

		public Player(string name, string title, float maxHp, float maxMana, float manaRegen)
			:base(name, maxHp, maxMana)
		{
			Title = title;
			ManaRegenRate = manaRegen;
			_healthPotions = 0;
			_manaPotions = 0;
		}

		public float ManaRegenRate { get; protected set; }

		public string Title { get; protected set; }

		public int HealthPotions
		{
			get { return _healthPotions; }
			set
			{
				_healthPotions = value;
				if(_healthPotions > Configuration.MaxHealthPotions)
					_healthPotions = Configuration.MaxHealthPotions;
			}
		}

		public int ManaPotions
		{
			get { return _manaPotions; }
			set
			{
				_manaPotions = value;
				if(_manaPotions > Configuration.MaxManaPotions)
					_manaPotions = Configuration.MaxManaPotions;
			}
		}

		public string KnownAs()
		{
			return string.Format("{0} the {1}", Name,Title);
		}

		public bool DrinkHealthPotion()
		{
			return HealthPotions > 0 && TakeHealing(MaxHealth*Configuration.HealthPotionPercent);
		}

		public bool DrinkManaPotion()
		{
			return ManaPotions > 0 && TakeMana(MaxMana * Configuration.ManaPotionPercent);
		}
	}
}
