using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace PingyPong.Screen
{
    public class ScreenManager {

        public Screen currentScreen { get; private set; }


        public void SetScreen(Screen screenToSet) {
            MediaPlayer.Stop();
            
            currentScreen = screenToSet;
            LoadScreen();
        }

        public void UpdateScreen(GameTime time) {
            currentScreen.UpdateScreen(time);
        }

        public void DrawScreen(SpriteBatch batch) {
            currentScreen.Draw(batch);
        }
    

        public void LoadScreen() {
            currentScreen.LoadContent();
        }
        
        

    }
}