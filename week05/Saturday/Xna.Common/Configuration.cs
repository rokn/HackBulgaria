using System.IO;
using INIFiles;

namespace Xna.Common
{
	public static class Configuration
	{
		//MapsLegend
		public static char SpawnPointSymbol;
		public static char HeroSymbol;
		public static char PathSymbol;
		public static char WallSymbol;
		public static char EnemySymbol;
		public static char TreasureSymbol;
		public static char ExitSymbol;

		//Paths
		public static string LevelsPath;
		public static string MapsSubPath;
		public static string EnemiesSubPath;
		public static string TreasuresSubPath;
		public static string TexturesSubPath;
		public static string LogFile;

		//Hero
		public static int MaxHealthPotions;
		public static int MaxManaPotions;
		public static float HealthPotionPercent;
		public static float ManaPotionPercent;


		public static void Load(string filename)
		{
			var file = new IniFile(Directory.GetCurrentDirectory() + "\\" + filename);

			//MapLegend
			SpawnPointSymbol = file.IniReadValue("MapLegend", "SpawnPoint", "S").ToCharArray()[0];
			HeroSymbol = file.IniReadValue("MapLegend", "Hero", "H").ToCharArray()[0];
			PathSymbol = file.IniReadValue("MapLegend", "Path", ".").ToCharArray()[0];
			WallSymbol = file.IniReadValue("MapLegend", "Wall", "#").ToCharArray()[0];
			EnemySymbol = file.IniReadValue("MapLegend", "Enemy", "E").ToCharArray()[0];
			TreasureSymbol = file.IniReadValue("MapLegend", "Treasure", "T").ToCharArray()[0];
			ExitSymbol = file.IniReadValue("MapLegend", "Exit", "G").ToCharArray()[0];

			//Paths
			LevelsPath = file.IniReadValue("Paths", "Levels", @"\Levels\");
			MapsSubPath = file.IniReadValue("Paths", "Maps", @"Maps\");
			EnemiesSubPath = file.IniReadValue("Paths", "Enemies", @"Enemies\");
			TexturesSubPath = file.IniReadValue("Paths", "Textures", @"Textures\");
			TreasuresSubPath = file.IniReadValue("Paths", "Treasures", @"Treasures\");
			LogFile = file.IniReadValue("Paths", "LogFile", "\\log.txt");

			//Hero
			MaxHealthPotions = int.Parse(file.IniReadValue("Hero", "MaxHealthPotions", "3"));
			MaxManaPotions = int.Parse(file.IniReadValue("Hero", "MaxManaPotions", "3"));
			HealthPotionPercent = float.Parse(file.IniReadValue("Hero", "HealthPotionPercent", "30"));
			ManaPotionPercent = float.Parse(file.IniReadValue("Hero", "ManaPotionPercent", "30"));
		}
	}
}
