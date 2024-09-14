using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PingyPong.Entity;

namespace PingyPong.Screen
{
    public class GameScreen : Screen
    {
        Paddle leftPaddle;
        Paddle rightPaddle;
        Ball ball;

        Texture2D paddleTexture;
        Texture2D ballTexture;

        public GameScreen() {
            leftPaddle = new Paddle(30, height / 2 - 50, 10, 100, 300f, Keys.W, Keys.S);
            rightPaddle = new Paddle(width - 40, height / 2 - 50, 10, 100, 300f, Keys.Up, Keys.Down);
            
            ball = new Ball(width / 2, height / 2, 10, 10, 200f,
                gameOverCallback: () =>
                {
                    game.OnGameOver();
                }
            );
        }

        public override void LoadContent()
        {
            paddleTexture = game.Content.Load<Texture2D>("paddle");
            ballTexture = game.Content.Load<Texture2D>("ball");
        }

        public override void Update(GameTime time)
        {
            leftPaddle.Update(time);
            rightPaddle.Update(time);
            ball.Update(time);

            ball.HandlePaddleCollission(leftPaddle, rightPaddle);

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(paddleTexture, leftPaddle.Rectangle, Color.White);
            batch.Draw(paddleTexture, rightPaddle.Rectangle, Color.White);
            batch.Draw(ballTexture, ball.Rectangle, Color.White);
            batch.End();
        }
    }
}