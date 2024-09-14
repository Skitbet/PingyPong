using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using PingyPong.Screen;

namespace PingyPong.Map
{
    public class MapManager
    {

        private List<MapEvent> events;
        private EventProcessor eventProcessor;

        private RhythmMap currentMap;
        private float currentTime;

        string appDataPath;
        string gameFolderPath;
        string songFolder;
        string backgroundFolder;

        Texture2D backgroundTexture;

        public MapManager()
        {
            events = new List<MapEvent>();

            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            gameFolderPath = Path.Combine(appDataPath, "PingyPong");
            songFolder = Path.Combine(gameFolderPath, "Songs");
            backgroundFolder = Path.Combine(gameFolderPath, "Images");
        }

        public void LoadMap(string fileName)
        {
            string json = File.ReadAllText(Path.Combine(gameFolderPath, fileName));
            currentMap = JsonConvert.DeserializeObject<RhythmMap>(json);

            events = currentMap.CreateEventList();

            using (var stream = new FileStream(Path.Combine(backgroundFolder, currentMap.Background), FileMode.Open)) {
                backgroundTexture = Texture2D.FromStream(PingyPongGame.instance.GraphicsDevice, stream);
                stream.Close();
            }

            eventProcessor = new EventProcessor(events);
            PlaySong();
        }

        public void Update(GameScreen screen)
        {
            float elapsedTime = (float)MediaPlayer.PlayPosition.TotalMilliseconds;
            eventProcessor.Update(elapsedTime, screen);
        }

        public void DrawBackground(SpriteBatch _batch) {

        }

        private void PlaySong()
        {
            string songFilePath = Path.Combine(songFolder, currentMap.Song);
            MediaPlayer.Play(Song.FromUri(songFilePath, new Uri(songFilePath, UriKind.Absolute)));
        }


    }
}