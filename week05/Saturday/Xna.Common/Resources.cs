using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Xna.Common
{
	public static class Resources
	{
		public static string PlayerSprite { get; set; }
		public static string MapTexture { get; set; }
		public static string DoorTexture { get; set; }
		public static string TreasureTexture { get; set; }

		private static ContentManager _content;
		private static Dictionary<string, Texture2D> _textureCache;
		private static Dictionary<string, SpriteFont> _fontCache;


		public static void Initialize(ContentManager content)
		{
			_content = content;
			_textureCache = new Dictionary<string, Texture2D>();
			_fontCache = new Dictionary<string, SpriteFont>();
		}

		public static Texture2D GetTexture(string filename)
		{
			return GetResource(filename, _textureCache);
		}

		public static SpriteFont GetFont(string filename)
		{
			return GetResource(filename, _fontCache);
		}

		private static T LoadResource<T>(string filename)
		{
			return _content.Load<T>(filename);
		}

		public static T GetResource<T>(string filename, Dictionary<string, T> cache)
		{
			if(cache.ContainsKey(filename))
			{
				return cache[filename];
			}


			var newResource = LoadResource<T>(filename);
			cache.Add(filename, newResource);
			return newResource;
		}
	}
}
