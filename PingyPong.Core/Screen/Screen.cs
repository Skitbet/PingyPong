using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingyPong.Screen
{
    public abstract class Screen
    {

        protected int height;
        protected int width;

        protected PingyPongGame game;

        protected Screen()
        {
            this.game = PingyPongGame.instance;

            height = game.GraphicsDevice.Viewport.Height;
            width = game.GraphicsDevice.Viewport.Width;
        }

        public void UpdateScreen(GameTime time)
        {
            height = game.GraphicsDevice.Viewport.Height;
            width = game.GraphicsDevice.Viewport.Width;

            Update(time);
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime time);
        public abstract void Draw(SpriteBatch batch);
    }
}
