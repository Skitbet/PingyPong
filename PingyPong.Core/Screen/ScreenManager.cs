using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace PingyPong.Screen
{
    public class ScreenManager
    {

        public Screen currentScreen { get; private set; }

        /// <summary>
        /// Sets current screen and loads the new screen.
        /// </summary>
        /// <param name="screenToSet"></param> 
        public void SetScreen(Screen screenToSet)
        {
            MediaPlayer.Stop();

            currentScreen = screenToSet;
            LoadScreen();
        }

        /// <summary>
        /// Runs the update function in the current screen
        /// </summary>
        /// <param name="time"></param>
        public void UpdateScreen(GameTime time)
        {
            currentScreen.UpdateScreen(time);
        }

        /// <summary>
        /// Runs the current screen draw method
        /// </summary>
        /// <param name="batch"></param>
        public void DrawScreen(SpriteBatch batch)
        {
            currentScreen.Draw(batch);
        }


        private void LoadScreen()
        {
            currentScreen.LoadContent();
        }



    }
}