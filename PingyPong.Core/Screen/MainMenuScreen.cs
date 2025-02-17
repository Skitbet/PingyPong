using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PingyPong.Screen
{
    public class MainMenuScreen : Screen
    {

        private SpriteFont font;
        private Button playButton;

        public override void LoadContent()
        {
            // set mouse visible as we in main menu
            game.IsMouseVisible = true;

            font = PingyPongGame.instance.Content.Load<SpriteFont>("DefaultFont");

            // Load menu buttons
            Texture2D buttonTex = PingyPongGame.instance.Content.Load<Texture2D>("button");
            playButton = new Button(buttonTex, font, "Play", new Vector2((width / 2) - (buttonTex.Width / 2), (height / 2) - (buttonTex.Height / 2)));
            playButton.OnClick += PlayButton_Click;

        }

        /// <summary>
        /// Runs when the play button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            // Change game state and show game screen
            PingyPongGame.instance.gameStateManager.ChangeState(GameState.Playing);
            PingyPongGame.instance.screenManager.SetScreen(new GameScreen());
        }

        public override void Update(GameTime time)
        {
            playButton.Update(time);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            playButton.Draw(batch);
            batch.End();
        }
    }
}