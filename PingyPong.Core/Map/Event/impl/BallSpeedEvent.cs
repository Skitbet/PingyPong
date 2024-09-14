using System;
using System.IO;
using Microsoft.Xna.Framework;
using PingyPong.Entity;
using PingyPong.Screen;

namespace PingyPong.Map
{
    public class BallSpeedEvent : MapEvent
    {
        public float Speed { get; set; }

        public override void Process(GameScreen gameScreen)
        {
            Ball ball = gameScreen.ball;
            ball.Speed = Speed;
        }
    }

}