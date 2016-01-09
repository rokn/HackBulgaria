namespace Animals
{
	public abstract class Mammal : Animal
	{
		public virtual void NurseChild(Mammal child)
		{
			child.Eat();
		}
	}
}
