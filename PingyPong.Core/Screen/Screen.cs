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

        /// <summary>
        /// The screen initialize function, use to load content and init classes
        /// </summary>
        public abstract void LoadContent();

        /// <summary>
        /// Screen update function
        /// </summary>
        /// <param name="time"></param>
        public abstract void Update(GameTime time);

        /// <summary>
        /// Screen draw function
        /// </summary>
        /// <param name="batch"></param>
        public abstract void Draw(SpriteBatch batch);
    }
}
