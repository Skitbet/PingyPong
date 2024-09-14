using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingyPong.Screen
{
    public class ScreenManager {

        public Screen currentScreen { get; private set; }


        public void UpdateScreen(GameTime time) {
            currentScreen.Update(time);
        }

        public void DrawScreen(SpriteBatch batch) {
            currentScreen.Draw(batch);
        }
    

        public void LoadScreen() {
            currentScreen.LoadContent();
        }
        
        public void SetScreen(Screen screenToSet) {
            currentScreen = screenToSet;
            LoadScreen();
        }

    }
}