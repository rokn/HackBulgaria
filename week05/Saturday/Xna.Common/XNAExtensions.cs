using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Xna.Common
{
	public static class XnaExtensions
	{
		//		public static ContentManager Content { get; set; }
		//
		//		public static Texture2D Load(string filename, out bool status)
		//		{
		//			if(Content == null)
		//			{
		//				Logger.WriteLine("Content uninitializied; Can't load texture : '{0}'", filename);
		//				status = false;
		//				return null;
		//			}
		//
		//			try
		//			{
		//				var texture = Content.Load<Texture2D>(filename);
		//				status = true;
		//				return texture;
		//			}
		//			catch
		//			{
		//				Logger.WriteLine("Can't load texture : '{0}'", filename);
		//				status = false;
		//				return null;
		//			}
		//		}
		//
		//		public static bool Load(string filename,ref Texture2D texture)
		//		{
		//			bool result = true;
		//
		//			if (Content == null)
		//			{
		//
		//				Logger.WriteLine("Content uninitializied; Can't load texture : '{0}'", filename);
		//				result = false;
		//			}
		//			else
		//			{
		//
		//				try
		//				{
		//					texture = Content.Load<Texture2D>(filename);
		//				}
		//				catch
		//				{
		//					Logger.WriteLine("Can't load texture : '{0}'", filename);
		//					result = false;
		//				}
		//			}
		//
		//			return result;
		//
		//		}

		public static Rectangle UpdateViaVector(this Rectangle rect, Vector2 vector)
		{
			rect.X = (int)vector.X;
			rect.Y = (int)vector.Y;

			return rect;
		}

		public static bool Contains(this Rectangle rect, Vector2 vector)
		{
			return rect.Left < vector.X && rect.Right > vector.X && rect.Top < vector.Y && rect.Bottom > vector.Y;
		}
	}
}
