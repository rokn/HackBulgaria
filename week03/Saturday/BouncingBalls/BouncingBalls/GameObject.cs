using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBalls
{
    public class GameObject
    {
        protected Vector2 position;
        protected Vector2 origin;
        protected Rectangle drawRect;
        protected float movementSpeed;
        protected Texture2D texture;
        protected Color color;

        public GameObject(Vector2 startPos, float movementSpeed)
        {
            drawRect = new Rectangle();
            Position = startPos;
            MovementSpeed = movementSpeed;
            color = Color.White;
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                UpdateDrawRect();
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public float MovementSpeed
        {
            get
            {
                return movementSpeed;
            }

            set
            {
                movementSpeed = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return origin;
            }

            private set
            {
                origin = value;
            }
        }

        protected void UpdateDrawRect()
        {
            drawRect.X = (int)(position.X - origin.X);
            drawRect.Y = (int)(position.Y - origin.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, drawRect, color);
        }
    }
}
