using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingyPong.Screen
{
    public class MainMenuScreen : Screen
    {

        private SpriteFont font;
        private Button playButton;
        
        public override void LoadContent()
        {
            font = PingyPongGame.instance.Content.Load<SpriteFont>("DefaultFont");
            
            Texture2D buttonTex = PingyPongGame.instance.Content.Load<Texture2D>("button");
            playButton = new Button(buttonTex, font, "Play", new Vector2(width / 2, height / 2));
            playButton.OnClick += PlayButton_Click;
        }

        private void PlayButton_Click(object sender, EventArgs e) {
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