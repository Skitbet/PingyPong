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


        Paddle leftPaddle;
        Paddle rightPaddle;
        Ball ball;

        Texture2D paddleTexture;
        Texture2D ballTexture;

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
            leftPaddle = new Paddle(30, h / 2 - 50, 10, 100, 300f, Keys.W, Keys.S);
            rightPaddle = new Paddle(w - 40, h / 2 - 50, 10, 100, 300f, Keys.Up, Keys.Down);
            
            ball = new Ball(w / 2, h / 2, 10, 10, 200f,
                gameOverCallback: () =>
                {
                    OnGameOver();
                }
            );

            gameStateManager.ChangeState(GameState.MainMenu);
            screenManager.SetScreen(new MainMenuScreen());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleTexture = Content.Load<Texture2D>("paddle");
            ballTexture = Content.Load<Texture2D>("ball");
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


            // Handle game playing logic
            if (gameStateManager.CurrentState == GameState.Playing)
            {
                leftPaddle.Update(gameTime);
                rightPaddle.Update(gameTime);
                ball.Update(gameTime);

                ball.HandlePaddleCollission(leftPaddle, rightPaddle);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(paddleTexture, leftPaddle.Rectangle, Color.White);
            _spriteBatch.Draw(paddleTexture, rightPaddle.Rectangle, Color.White);
            _spriteBatch.Draw(ballTexture, ball.Rectangle, Color.White);
            _spriteBatch.End();

            screenManager.DrawScreen(_spriteBatch);

            base.Draw(gameTime);
        }

        public void OnGameOver()
        {
            gameStateManager.ChangeState(GameState.GameOver);
        }
    }
}
