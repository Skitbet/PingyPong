using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingyPong.Screen
{
    public abstract class Screen {
        public abstract void LoadContent();
        public abstract void Update(GameTime time);
        public abstract void Draw(SpriteBatch batch);
    }
}
