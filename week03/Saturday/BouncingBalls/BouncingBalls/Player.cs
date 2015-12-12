using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBalls
{
    public enum MoveDirection { Left = -1, Right = 1 };
    public class Player : GameObject
    {
        public const int PlayerHeight = 64;

        private float shootSpeed;

        public Player(Vector2 startPos, float movementSpeed, float shootSpeed)
            : base(startPos, movementSpeed)
        {
            texture = Resources.GetTexture("Sprites/Player");
            drawRect.Width = texture.Width;
            drawRect.Height = texture.Height;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            ShootSpeed = shootSpeed;
            UpdateDrawRect();
        }

        public Vector2 ShootPosition
        {
            get { return new Vector2(Position.X, Position.Y - PlayerHeight / 2); }
        }

        public float ShootSpeed
        {
            get
            {
                return shootSpeed;
            }

            private set
            {
                shootSpeed = value;
            }
        }

        public void Move(double deltaTime, MoveDirection direction)
        {
            Position += new Vector2(movementSpeed * (int)direction * (float)deltaTime, 0);
        }
    }
}