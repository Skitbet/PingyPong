using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace PingyPong.Entity
{
    public abstract class Entity
    {
        public Rectangle Rectangle { get; private set; }
        public Vector2 Position { get; private set; }
        public float Speed { get; set; }

        public Entity(int x, int y, int width, int height, float speed)
        {
            Position = new Vector2(x, y);
            Rectangle = new Rectangle(x, y, width, height);
            Speed = speed;
        }

        public abstract void Update(GameTime time);

        public void Move(Vector2 delta)
        {
            Position += delta;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Rectangle.Width, Rectangle.Height);
        }
    }
}
