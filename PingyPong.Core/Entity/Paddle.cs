using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingyPong.Entity
{
    public class Paddle : Entity
    {

        private Keys upKey;
        private Keys downKey;

        public Paddle(int x, int y, int width, int height, float speed, Keys upKey, Keys downKey)
            : base(x, y, width, height, speed)
        {
            this.upKey = upKey;
            this.downKey = downKey;
        }

        public override void Update(GameTime time)
        {
            var keyboardState = Keyboard.GetState();
            var deltaTime = (float)time.ElapsedGameTime.TotalSeconds;
            var delta = Vector2.Zero;
            int h = PingyPongGame.instance.GraphicsDevice.Viewport.Height;

            if (keyboardState.IsKeyDown(upKey) && Rectangle.Y > 0)
            {
                delta.Y -= (int)(Speed * deltaTime);
            }
            if (keyboardState.IsKeyDown(downKey) && Rectangle.Y < h - Rectangle.Height)
            {
                delta.Y += (int)(Speed * deltaTime);
            }

            Move(delta);
        }

    }
}
