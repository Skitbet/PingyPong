using Microsoft.Xna.Framework;
using PingyPong;
using System;
using System.Diagnostics;

namespace PingyPong.Entity
{
    public class Ball : Entity
    {
        public Vector2 velocity;
        private Action onGameOver;

        public Ball(int x, int y, int width, int height, float speed, Action gameOverCallback)
            : base(x, y, width, height, speed)
        {
            velocity = new Vector2(speed, speed);
            onGameOver = gameOverCallback;
        }

        public override void Update(GameTime time)
        {
            Debug.WriteLine(Position);
            var deltaTime = (float)time.ElapsedGameTime.TotalSeconds;

            Move(velocity * deltaTime);

            // Handle falling out of map on bottom or top
            if (Position.Y <= 0 || Position.Y >= PingyPongGame.instance.GraphicsDevice.Viewport.Height - Rectangle.Height)
            {
                velocity.Y = -velocity.Y;
            }

            // Handle missing the paddle
            if (Position.X <= 0 || Position.X >= PingyPongGame.instance.GraphicsDevice.Viewport.Width - Rectangle.Width)
            {
                onGameOver?.Invoke();
            }
        }

        public void HandlePaddleCollision(Paddle leftPaddle, Paddle rightPaddle)
        {
            if (Rectangle.Intersects(leftPaddle.Rectangle) || Rectangle.Intersects(rightPaddle.Rectangle))
            {
                velocity.X = -velocity.X;
            }
        }

    }
}
