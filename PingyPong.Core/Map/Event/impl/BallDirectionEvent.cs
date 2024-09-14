using System;
using System.IO;
using Microsoft.Xna.Framework;
using PingyPong.Entity;
using PingyPong.Screen;

namespace PingyPong.Map
{
    public class BallDirectionEvent : MapEvent
    {
        public string Direction { get; set; }

        public override void Process(GameScreen gameScreen)
        {
            Ball ball = gameScreen.ball;
            var currentVelocity = ball.velocity;

            switch (Direction)
            {
                case "left":
                    ball.velocity = new Vector2(-Math.Abs(currentVelocity.X), currentVelocity.Y);
                    break;
                case "right":
                    ball.velocity = new Vector2(Math.Abs(currentVelocity.X), currentVelocity.Y);
                    break;
            }
        }
    }

}