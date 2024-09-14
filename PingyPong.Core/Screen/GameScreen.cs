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

        private RhythmMap testMap;
        private float testTime;
    

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
            game.IsMouseVisible = false;
            paddleTexture = game.Content.Load<Texture2D>("paddle");
            ballTexture = game.Content.Load<Texture2D>("ball");

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string gameFolderPath = Path.Combine(appDataPath, "PingyPong");
            string mapFilePath = Path.Combine(gameFolderPath, "testMap.json");
            testMap = LoadMap(mapFilePath);
            string songFilePath = Path.Combine(gameFolderPath + "/songs", testMap.Song);

            MediaPlayer.Play(Song.FromUri(songFilePath, new Uri(songFilePath, UriKind.Absolute)));

        }

        public override void Update(GameTime time)
        {
            testTime = (float)MediaPlayer.PlayPosition.TotalMilliseconds;

            for (int i = testMap.Events.Count - 1; i >= 0; i--) {
                var mapEvent = testMap.Events[i];
                
                if (testTime >= mapEvent.Time) {
                    ProcessEvent(mapEvent);
                    Debug.WriteLine("Fired Event: " + mapEvent.Action);
                    testMap.Events.RemoveAt(i);
                }
            }

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

        public RhythmMap LoadMap(string filePath) {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<RhythmMap>(json);
        }

        private void ProcessEvent(MapEvent mapEvent) {
            switch (mapEvent.Action) {
                case "ball_speed":
                    ball.UpdateSpeed(mapEvent.Speed);
                    break;
                case "ball_direction":
                    var currentVelocity = ball.velocity;

                    if (mapEvent.Direction == "left") {
                        ball.velocity = new Vector2(-Math.Abs(currentVelocity.X), currentVelocity.Y);
                    } else if (mapEvent.Direction == "right") {
                        ball.velocity = new Vector2(Math.Abs(currentVelocity.X), currentVelocity.Y);
                    }       
                    break;
                case "paddle_auth_move":
                    if (mapEvent.Paddle == "left") {
                        leftPaddle.Move(new Vector2(0, mapEvent.Position));
                        break;    
                    }
                    if (mapEvent.Paddle == "right") {
                        rightPaddle.Move(new Vector2(0, mapEvent.Position));
                        break;    
                    }
                    break;
                    
            }
        }
    }
}