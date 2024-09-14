using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using PingyPong.Entity;
using PingyPong.Map;

namespace PingyPong.Screen
{
    public class GameScreen : Screen
    {

        private MapManager mapManager;

        public Paddle leftPaddle { get; private set; }
        public Paddle rightPaddle;
        public Ball ball;

        Texture2D paddleTexture;
        Texture2D ballTexture;

        public GameScreen()
        {
            mapManager = new MapManager();
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
            game.IsMouseVisible = false;
            paddleTexture = game.Content.Load<Texture2D>("paddle");
            ballTexture = game.Content.Load<Texture2D>("ball");

            mapManager.LoadMap("testMap.json");
        }

        public override void Update(GameTime time)
        {
            mapManager.Update(this);

            leftPaddle.Update(time);
            rightPaddle.Update(time);
            ball.Update(time);

            ball.HandlePaddleCollision(leftPaddle, rightPaddle);

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            mapManager.DrawBackground(batch);
            batch.Draw(paddleTexture, leftPaddle.Rectangle, Color.White);
            batch.Draw(paddleTexture, rightPaddle.Rectangle, Color.White);
            batch.Draw(ballTexture, ball.Rectangle, Color.White);
            batch.End();
        }
    }
}