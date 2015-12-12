using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;

namespace BouncingBalls
{
    public class GameField
    {
        public const float PlayerSpeed = 200.0f;
        public const float ShootSpeed = 2000.0f;
        private const float MinRadius = 10.0f;


        private enum OutOfBounds { None = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 };

        private List<Ball> balls;
        private List<Laser> lasers;
        private Rectangle fieldRect;
        private Player player;

        public GameField(int width, int height)
            :this(0,0,width,height){}

        public GameField(int x, int y, int width, int height)
        {
            fieldRect = new Rectangle(x, y, width, height);
            balls = new List<Ball>();
            player = new Player(new Vector2(width/2, height - Player.PlayerHeight/2), PlayerSpeed, ShootSpeed);
            lasers = new List<Laser>();
        }

        public List<Ball> Balls
        {
            get { return balls; }
        }

        public Rectangle FieldRectangle
        {
            get { return fieldRect; }
        }

        public void Update(double deltaTime)
        {
            MoveBalls(deltaTime);
            HandleInput(deltaTime);
            UpdateLasers(deltaTime);
        }

        private void UpdateLasers(double deltaTime)
        {
            List<Laser> removeList = new List<Laser>();

            foreach(Laser laser in lasers)
            {
                laser.Update(deltaTime);

                if (laser.Height > FieldRectangle.Height - Player.PlayerHeight)
                {
                    removeList.Add(laser);
                }
                else
                {
                    List<Ball> hits = GetHitsWithBalls(laser);

                    if(hits.Count > 0)
                    {
                        removeList.Add(laser);
                    }

                    foreach (var ball in hits)
                    {
                        balls.Remove(ball);

                        if (ball.Radius > MinRadius)
                        {
                            float originalAngle = MathAid.VectorToAngle(ball.Direction);
                            balls.Add(new Ball(ball.Position, MathAid.AngleToVector(originalAngle + (float)Math.PI / 2), ball.Radius / 2, ball.MovementSpeed, ball.Color));

                            balls.Add(new Ball(ball.Position, MathAid.AngleToVector(originalAngle - (float)Math.PI / 2), ball.Radius / 2, ball.MovementSpeed, ball.Color));
                        }
                    }
                }
            }

            foreach (var laser in removeList)
            {
                lasers.Remove(laser);
            }
        }

        private List<Ball> GetHitsWithBalls(Laser laser)
        {
            List<Ball> hits = new List<Ball>();

            foreach (var ball in balls)
            {
                if(CheckCollision(ball, laser))
                {
                    hits.Add(ball);
                }
            }

            return hits;
        }

        private bool CheckCollision(Ball ball, Laser laser)
        {
            bool horizontal = IsBetween((int)ball.Position.X, laser.CollisionRect.Left - (int)ball.Radius, laser.CollisionRect.Right + (int)ball.Radius);
            bool vertical = IsBetween((int)ball.Position.Y, laser.CollisionRect.Top - (int)ball.Radius, laser.CollisionRect.Bottom + (int)ball.Radius);

            return horizontal && vertical;
        }

        private bool IsBetween(int x, int a, int b)
        {
            return x > a && x < b;
        }

        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (Ball ball in balls)
            {
                ball.Draw(spriteBatch);
            }

            foreach (Laser laser in lasers)
            {
                laser.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
        }

        private void HandleInput(double deltaTime)
        {
            bool moved = false;
            if (Main.Keyboard.IsHeld(Keys.A))
            {
                player.Move(deltaTime, MoveDirection.Left);
                moved = true;
            }
            else if (Main.Keyboard.IsHeld(Keys.D))
            {
                player.Move(deltaTime, MoveDirection.Right);
                moved = true;
            }

            if (Main.Keyboard.JustPressed(Keys.Space))
            {
                lasers.Add(new Laser(player.ShootPosition, ShootSpeed, Color.Blue));
                moved = true;
            }

            if (moved)
            {
                int outOfBounds = GetOutOfBounds(player);

                if (outOfBounds != (int)OutOfBounds.None)
                {
                    GetInBounds(player, outOfBounds);
                }
            }
        }

        private void MoveBalls(double deltaTime)
        {
            foreach (Ball ball in balls)
            {
                ball.Move(deltaTime);

                int outOfBounds = GetOutOfBounds(ball);

                if (outOfBounds != (int)OutOfBounds.None)
                {
                    GetInBounds(ball, outOfBounds);
                    ChangeBallDirection(ball, outOfBounds);
                }
            }
        }

        private int GetOutOfBounds(GameObject obj)
        {
            int result = (int)OutOfBounds.None;

            if (obj.Position.X - obj.Origin.X < fieldRect.Left)
            {
                result |= (int)OutOfBounds.Left;
            }
            if (obj.Position.X + obj.Origin.X> fieldRect.Right)
            {
                result |= (int)OutOfBounds.Right;
            }
            if (obj.Position.Y - obj.Origin.Y< fieldRect.Top)
            {
                result |= (int)OutOfBounds.Top;
            }
            if (obj.Position.Y + obj.Origin.Y> fieldRect.Bottom)
            {
                result |= (int)OutOfBounds.Bottom;
            }

            return result;
        }

        private void GetInBounds(GameObject obj, int outOfBounds)
        {
            if ((outOfBounds & (int)OutOfBounds.Left) == (int)OutOfBounds.Left)
            {
                obj.Position = new Vector2(fieldRect.Left + obj.Origin.X, obj.Position.Y);
            }
            else if ((outOfBounds & (int)OutOfBounds.Right) == (int)OutOfBounds.Right)
            {
                obj.Position = new Vector2(fieldRect.Right - obj.Origin.X, obj.Position.Y);
            }

            if ((outOfBounds & (int)OutOfBounds.Top) == (int)OutOfBounds.Top)
            {
                obj.Position = new Vector2(obj.Position.X, fieldRect.Top + obj.Origin.Y);
            }
            else if ((outOfBounds & (int)OutOfBounds.Bottom) == (int)OutOfBounds.Bottom)
            {
                obj.Position = new Vector2(obj.Position.X, fieldRect.Bottom - obj.Origin.Y);
            }
        }

        private void ChangeBallDirection(Ball ball, int outOfBounds)
        {
            if ((outOfBounds & ((int)OutOfBounds.Left | (int)OutOfBounds.Right)) != 0)
            {
                ball.Direction = new Vector2(-ball.Direction.X, ball.Direction.Y);
            }

            if ((outOfBounds & ((int)OutOfBounds.Top | (int)OutOfBounds.Bottom)) != 0)
            {
                ball.Direction = new Vector2(ball.Direction.X, -ball.Direction.Y);
            }
        }
    }
}
