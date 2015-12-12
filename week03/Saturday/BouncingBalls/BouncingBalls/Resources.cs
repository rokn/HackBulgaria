using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BouncingBalls
{
    public static class Resources
    {
        private static Dictionary<string, Texture2D> textureCache;


        public static void Initialize()
        {
            textureCache = new Dictionary<string, Texture2D>();
        }

        public static Texture2D GetTexture(string filename)
        {
            if(textureCache.ContainsKey(filename))
            {
                return textureCache[filename];
            }
            else
            {
                Texture2D newTexture = LoadTexture(filename);
                textureCache.Add(filename, newTexture);
                return newTexture;
            }
        }

        private static Texture2D LoadTexture(string filename)
        {
            return Main.ContentManger.Load<Texture2D>(filename) as Texture2D;
        }
    }
}
