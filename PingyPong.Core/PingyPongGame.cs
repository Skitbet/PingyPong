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


        private float _startDelay = 3.0f;
        private float _timer;
        private bool _gameStarted;

        public PingyPongGame()
        {
            instance = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            _timer = _startDelay;
            _gameStarted = false;

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
            // Handle start delay
            if (!_gameStarted)
            {
                _timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (_timer <= 0)
                {
                    _gameStarted = true;
                    _timer = 0;
                }
                base.Update(gameTime);
                return;
            }

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
            gameStateManager.ChangeState(GameState.GameOver);
        }
    }
}
