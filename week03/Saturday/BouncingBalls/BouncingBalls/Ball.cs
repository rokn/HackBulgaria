using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBalls
{
    public class Ball : GameObject
    {
        private Vector2 direction;

        public Ball(Vector2 position, Vector2 direction, float radius, float movementSpeed, Color color)
            :base(position, movementSpeed)
        {
            Radius = radius;
            Direction = direction;
            Color = color;
            texture = Resources.GetTexture("Sprites/Ball");
            UpdateDrawRect();
        }

        public float Radius
        {
            get
            {
                return origin.X;
            }

            set
            {
                origin.X = value;
                origin.Y = value;
                drawRect.Width = (int)origin.X * 2;
                drawRect.Height = (int)origin.Y * 2;
            }
        }

        public Vector2 Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
                direction.Normalize();
            }
        }

        public void Move(double deltaTime)
        {
            Position += Direction * MovementSpeed * (float)deltaTime;
        }
    }
}
