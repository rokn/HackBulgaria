using Microsoft.Xna.Framework;

namespace BouncingBalls
{
    public class Laser : GameObject
    {
        private float height;
        private int startY;

        public Laser(Vector2 startPos, float movementSpeed, Color color)
            : base(startPos, movementSpeed)
        {
            texture = Resources.GetTexture("Sprites/Laser");
            drawRect.Width = texture.Width;
            drawRect.Height = 1;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            height = 0;
            startY = (int)startPos.Y;
            Color = color;
            UpdateDrawRect();
        }

        public int Height
        {
            get { return drawRect.Height; }
        }

        public Rectangle CollisionRect
        {
            get { return drawRect; }
        }

        public void Update(double deltaTime)
        {
            height += movementSpeed * (float)deltaTime;
            drawRect.Height = (int)height;
            drawRect.Y = startY - Height;
        }
    }
}
