using System;
using System.IO;
using Microsoft.Xna.Framework;
using PingyPong.Entity;
using PingyPong.Screen;

namespace PingyPong.Map
{
    public class PaddleMoveEvent : MapEvent
    {
        public string Paddle { get; set; }
        public int Position { get; set; }

        public override void Process(GameScreen gameScreen)
        {
            if (Paddle == "left")
            {
                gameScreen.leftPaddle.Move(new Vector2(0, Position));
            }
            else
            {
                gameScreen.rightPaddle.Move(new Vector2(0, Position));
            }
        }
    }

}