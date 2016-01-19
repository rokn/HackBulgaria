using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPGEngine;
using Xna.Common;


namespace XNARpg
{
	public class Main : Game
	{
		public GraphicsDeviceManager Graphics { get; }
		public SpriteBatch SpriteBatch { get; private set; }
		private Dungeon _dungeon;

		public Main()
		{
			Graphics = new GraphicsDeviceManager(this);
			GoFullscreenBorderless();
			Content.RootDirectory = "Content";
		}

		public static int WindowWidth { get; private set; }
		public static int WindowHeight { get; private set; }

		protected override void Initialize()
		{
			Resources.Initialize(Content);
			Resources.MapTexture = "MapTextures\\Grass";
			Resources.PlayerSprite = "Characters\\Player";
			Resources.DoorTexture = "Misc\\Door";
			Resources.TreasureTexture = "Misc\\Chest";
			Configuration.Load("Config.ini");
			Logger.ClearLogFile();
			HelperMethods.Initialize(GraphicsDevice);
			Input.Initialize(WindowWidth,WindowHeight,150);

			InitDungeon();
			base.Initialize();
		}

		private void InitDungeon()
		{
			var width = WindowWidth;
			var height = WindowHeight;
			_dungeon = new Dungeon(1, new Rectangle((WindowWidth - width) / 2, 0, width, height));
			_dungeon.Load();
			_dungeon.Spawn(new Player("Rokner", "Slayer", 100, 200, 15));
			_dungeon.Exit += d => InitDungeon();
		}

		protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			Input.Update(gameTime);
			HandleInput();
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			SpriteBatch.Begin();
			_dungeon.Draw(SpriteBatch);
			SpriteBatch.End();
			base.Draw(gameTime);
		}

		private void GoFullscreenBorderless()
		{
			IntPtr hWnd = this.Window.Handle;
			var control = System.Windows.Forms.Control.FromHandle(hWnd);
			var form = control.FindForm();
			if (form != null)
			{
				form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			}
			WindowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			WindowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
		}

		private void HandleInput()
		{
			if(Input.KeyJustPressed(Keys.Left))
			{
				_dungeon.MovePlayer(Direction.Left);
			}
			else if(Input.KeyJustPressed(Keys.Right))
			{
				_dungeon.MovePlayer(Direction.Right);
			}
			else if(Input.KeyJustPressed(Keys.Down))
			{
				_dungeon.MovePlayer(Direction.Down);
			}
			else if(Input.KeyJustPressed(Keys.Up))
			{
				_dungeon.MovePlayer(Direction.Up);
			}
		}
	}
}