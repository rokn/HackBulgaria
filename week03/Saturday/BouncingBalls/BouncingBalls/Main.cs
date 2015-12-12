using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingBalls
{
    public class Main : Game
    {
        private readonly Color ClearColor;


        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private static KeysInput keyboard;
        private static ContentManager content;
        private GameField field;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;

            keyboard = new KeysInput(this);
            Components.Add(keyboard);

            ClearColor = Color.CornflowerBlue;
        }

        public static KeysInput Keyboard
        {
            get { return keyboard; }
        }

        public static ContentManager ContentManger
        {
            get { return content; }
        }

        protected override void Initialize()
        {
            Resources.Initialize();
            int windowWidth = graphics.PreferredBackBufferWidth;
            int windowHeight = graphics.PreferredBackBufferHeight;
            field = new GameField(windowWidth, windowHeight);
            Ball startBall = new Ball(new Vector2(windowWidth/2,windowHeight/2),new Vector2(0.3f,0.3f), 30,300, Color.Red);
            field.Balls.Add(startBall);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            double deltaTime = gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.JustPressed(Keys.Escape))
                Exit();

            field.Update(deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);
            spriteBatch.Begin();
            field.DrawAll(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
