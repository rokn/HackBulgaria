namespace Animals
{
	public abstract class Animal
	{
		public int Hunger
		{
			get { return _hunger; }
			set
			{
				_hunger = value;
				if (_hunger < 0)
				{
					_hunger = 0;
				}
			}
		}

		private int _hunger;

		protected Animal()
		{
			Hunger = 100;
		}

		public abstract void Move();

		public virtual void Eat()
		{
			Hunger -= 10;
		}
		public abstract Animal GiveBirth();
	}
}
