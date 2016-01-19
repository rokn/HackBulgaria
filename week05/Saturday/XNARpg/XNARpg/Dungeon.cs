using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using INIFiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine;
using Xna.Common;

namespace XNARpg
{
	public delegate void DungeonExit(Dungeon dungeon);

	public class Dungeon : IDungeon
	{
		private delegate void MapIterator(int x, int y);
		private delegate void MapSquareIterator(char square);

		public List<string> Map { get; set; }

		public Rectangle DungeonRect { get; set; }

		public event DungeonExit Exit;

		private readonly int _difficultyLevel;
		private Point _playerPos;
		private Point _spawnPoint;
		private IPlayer _player;
		private bool _isSpawned;
		private bool _isLoaded;
		private string _treasuresFileName;
		private string _enemiesFilename;
		private string _mapFilename;
		private Texture2D _mapTexture;
		private Texture2D _playerTexture;
		private Texture2D _treasureTexture;
		private Texture2D _doorTexture;

		public Dungeon(int difficultyLevel, Rectangle dungeonRect)
		{
			_difficultyLevel = difficultyLevel;
			DungeonRect = dungeonRect;
			GetRandomFileNames();
			Map = new List<string>();
			_isSpawned = false;
			_isLoaded = false;
		}

		public int Width => Map[0].Length;
		public int Height => Map.Count;

		public bool Load()
		{
			var status = true;

			status = ReadMap(_mapFilename);
			status = status && FindSpawnPoint();
			_mapTexture = Resources.GetTexture(Resources.MapTexture); // TODO: make status in get textures in resources
			_playerTexture = Resources.GetTexture(Resources.PlayerSprite);
			_treasureTexture = Resources.GetTexture(Resources.TreasureTexture);
			_doorTexture = Resources.GetTexture(Resources.DoorTexture);
			_isLoaded = status;
			return status;
		}

		public void Spawn(IPlayer player)
		{
			if(!_isSpawned)
			{
				_playerPos = _spawnPoint;
				_player = player;
				_isSpawned = true;
			}
			else
			{
				throw new Exception("You can't spawn more than one player.");
			}
		}

		public bool MovePlayer(Direction direction)
		{
			var newPos = _playerPos;

			switch(direction)
			{
				case Direction.Down:
					newPos.Y++;
					break;
				case Direction.Up:
					newPos.Y--;
					break;
				case Direction.Right:
					newPos.X++;
					break;
				case Direction.Left:
					newPos.X--;
					break;
			}

			if(Map[newPos.Y][newPos.X] == Configuration.WallSymbol)
				return false;

			if (Map[newPos.Y][newPos.X] == Configuration.ExitSymbol)
			{
				Exit?.Invoke(this);
			}

			_playerPos = newPos;
			return true;
		}

		public void PrintMap()
		{
			IterateMap((x, y) =>
			{
				if(_playerPos.X == x && _playerPos.Y == y && _isSpawned)
				{
					Console.Write(Configuration.HeroSymbol);
				}
				else
				{
					Console.Write(Map[y][x]);
				}

				if(x == Map[0].Length - 1)
					Console.WriteLine();
			});
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if(!_isLoaded)
				return;

			var squareRect = new Rectangle(0, 0, DungeonRect.Width / Width, DungeonRect.Height / Height);

			for(var i = 0; i < Height; i++)
			{
				for(var j = 0; j < Width; j++)
				{
					squareRect.X = j * squareRect.Width + DungeonRect.X;
					squareRect.Y = i * squareRect.Height + DungeonRect.Y;

					if (Map[i][j] != Configuration.WallSymbol)
					{
						spriteBatch.Draw(_mapTexture, squareRect, Color.White);

						if(Map[i][j] == Configuration.TreasureSymbol)
						{
							spriteBatch.Draw(_treasureTexture, squareRect, Color.White);
						}

						if(Map[i][j] == Configuration.ExitSymbol)
						{
							spriteBatch.Draw(_doorTexture, squareRect, Color.White);
						}
					}
					else
					{
						spriteBatch.Draw(HelperMethods.WhitePixelTexture, squareRect, Color.Black);
					}

					if(_playerPos.X == j && _playerPos.Y == i && _isSpawned)
					{
						spriteBatch.Draw(_playerTexture, squareRect, Color.White);
					}
				}
			}
		}

		private bool FindSpawnPoint()
		{
			var found = false;

			IterateMap((x, y) =>
			{
				if(Map[y][x] != Configuration.SpawnPointSymbol)
					return;

				found = true;
				_spawnPoint = new Point(x, y);
			});

			return found;
		}

		private bool ReadMap(string filename)
		{
			var lineLength = -1;

			try
			{
				using(var reader = new StreamReader(filename))
				{
					string line;
					while((line = reader.ReadLine()) != null)
					{
						if(lineLength == -1)
						{
							lineLength = line.Length;
						}
						else
						{
							if(line.Length != lineLength)
								throw new FormatException("The lines in the level file must be the same");
						}

						Map.Add(line);
					}
				}
			}
			catch(IOException io)
			{
				Logger.WriteLine(io.ToString());
				return false;
			}
			catch(FormatException e)
			{
				Logger.WriteLine(e.ToString());
				return false;
			}

			return true;
		}

		private void IterateMap(MapIterator iterator)
		{
			for(var i = 0; i < Height; i++)
			{
				for(var j = 0; j < Width; j++)
				{
					iterator(j, i);
				}
			}
		}

		private void IterateMap(MapSquareIterator iterator)
		{
			foreach(var square in Map.SelectMany(line => line))
			{
				iterator(square);
			}
		}

		private void GetRandomFileNames()
		{
			var levelDir = Directory.GetCurrentDirectory() + Configuration.LevelsPath + "Level" + _difficultyLevel + @"\";
//			var contentLevelFolder = Directory.GetCurrentDirectory() + @"\Content" + Configuration.LevelsPath + "Level" + _difficultyLevel + @"\";

			_mapFilename = HelperMethods.GetRandomFile(levelDir + Configuration.MapsSubPath, "txt");
			_enemiesFilename = HelperMethods.GetRandomFile(levelDir + Configuration.EnemiesSubPath, "ini");
			_treasuresFileName = HelperMethods.GetRandomFile(levelDir + Configuration.TreasuresSubPath, "txt");
//			_textureFileName = HelperMethods.GetRandomFile(contentLevelFolder + Configuration.TexturesSubPath, "*");
		}

		private void PickUpTreasure()
		{
			try
			{
				var treasures = File.ReadAllLines(_treasuresFileName);
				var chosenTreasure = treasures[HelperMethods.Rand.Next(treasures.Length)].Split(',');
				if(chosenTreasure.Length <= 0)
				{
					Logger.WriteLine("Empty treasure file: '{0}'", _treasuresFileName);
					return;
				}

				switch(chosenTreasure[0].ToLower())
				{
					case "w":
						try
						{
							IWeapon weapon = new Weapon(
								name: chosenTreasure[1],
								damage: float.Parse(chosenTreasure[2]),
								durability: int.Parse(chosenTreasure[3]));
							Logger.WriteLine("Created weapon {0} from file: '{1}'", weapon.ToString(), _treasuresFileName);
						}
						catch(ArgumentOutOfRangeException)
						{
							Logger.WriteLine("Not enough arguments to create weapon in file: '{0}'", _treasuresFileName);
						}
						break;
					case "s":
						try
						{
							ISpell spell = new Spell(
								name: chosenTreasure[1],
								damage: float.Parse(chosenTreasure[2]),
								manaCost: float.Parse(chosenTreasure[3]),
								castRange: int.Parse(chosenTreasure[4]));
							Logger.WriteLine("Created spell {0} from file: '{1}'", spell.ToString(), _treasuresFileName);
						}
						catch(ArgumentOutOfRangeException)
						{
							Logger.WriteLine("Not enough arguments to create spell in file: '{0}'", _treasuresFileName);
						}
						break;
					case "p":
						if(chosenTreasure.Length <= 1)
						{
							Logger.WriteLine("Not enough arguments to create potion in file: '{0}'", _treasuresFileName);
							break;
						}

						switch(chosenTreasure[1].ToLower())
						{
							case "mana":
								_player.ManaPotions++;
								Logger.WriteLine("Player got mana potion");
								break;
							case "health":
								_player.HealthPotions++;
								Logger.WriteLine("Player got health potion");
								break;
							default:
								Logger.WriteLine("Unknown potion: '{0}'", chosenTreasure[1]);
								break;
						}
						break;
					default:
						Logger.WriteLine("Unknown item: '{0}'", chosenTreasure[0]);
						break;
				}
			}
			catch(Exception e)
			{
				Logger.WriteLine(e.Message);
			}
		}

		private IEnemy GetRandomEnemy()
		{
			try
			{
				var enemiesFile = new IniFile(_enemiesFilename);

				var name = enemiesFile.IniReadValue("Enemy", "Name", "Unknown");
				var health = float.Parse(enemiesFile.IniReadValue("Enemy", "Health", "1"));
				var mana = float.Parse(enemiesFile.IniReadValue("Enemy", "Mana", "0"));
				var baseDamage = float.Parse(enemiesFile.IniReadValue("Enemy", "BaseDamage", "1"));

				var enemy = new Enemy(name: name, maxHp: health, maxMana: mana, baseDamage: baseDamage);

				Logger.WriteLine("Created enemy '{0}' from file: '{1}'", enemy.ToString(), _enemiesFilename);

				return enemy;
			}
			catch(Exception e)
			{
				Logger.WriteLine(e.Message);
				return null;
			}
		}
	}
}
