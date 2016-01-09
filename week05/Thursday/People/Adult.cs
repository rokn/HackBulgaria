using System.Collections.Generic;

namespace People
{
	public class Adult : Person
	{
		public Adult(Gender gender) : base(gender)
		{
			_children = new List<Child>();
		}

		private readonly List<Child> _children;

		public override void DailyStuff()
		{
			//Do work....
		}

		public override string ToString()
		{
			return string.Format("An adult {0} with {1} children", Gender, _children.Count);
		}
	}
}
