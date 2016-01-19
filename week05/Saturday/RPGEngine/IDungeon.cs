using System.Collections.Generic;

namespace RPGEngine
{
	public interface IDungeon
	{
		List<string> Map { get; }
		void Spawn(IPlayer player);
		bool MovePlayer(Direction direction);
		void PrintMap();
	}
}