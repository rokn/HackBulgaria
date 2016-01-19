using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Xna.Common
{
	public static class HelperMethods
	{
		public static Random Rand;

		public static Texture2D WhitePixelTexture;

		public static void Initialize(GraphicsDevice device)
		{
			Rand = new Random();
			WhitePixelTexture = new Texture2D(device,1,1);
			WhitePixelTexture.SetData(new[] {Color.White});
		}

		public static string GetRandomFile(string directory, string extension)
		{
			try
			{
				var files = Directory.GetFiles(directory, "*." + extension);
				return files[Rand.Next(files.Length)];
			}
			catch (DirectoryNotFoundException e)
			{
				Logger.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Logger.WriteLine(e.Message);
			}

			return "";
		}
	}
}
