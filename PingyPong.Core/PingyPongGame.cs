using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PingyPong.Entity;
using PingyPong.Screen;
using System;

namespace PingyPong
{
    public class PingyPongGame : Game
    {
        public static PingyPongGame instance;

        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public GameStateManager gameStateManager;
        public ScreenManager screenManager;


        public PingyPongGame()
        {
            instance = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            int w = GraphicsDevice.Viewport.Width;
            int h = GraphicsDevice.Viewport.Height;

            gameStateManager = new GameStateManager();
            screenManager = new ScreenManager();

            gameStateManager.ChangeState(GameState.MainMenu);
            screenManager.SetScreen(new MainMenuScreen());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            screenManager.UpdateScreen(gameTime);

            // Handle exiting
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            screenManager.DrawScreen(_spriteBatch);

            base.Draw(gameTime);
        }

        public void OnGameOver()
        {
            // TODO: Game end
            gameStateManager.ChangeState(GameState.MainMenu);
            screenManager.SetScreen(new MainMenuScreen());

        }
    }
}
