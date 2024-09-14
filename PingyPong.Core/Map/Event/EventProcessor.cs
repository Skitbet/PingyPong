using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using PingyPong.Entity;
using PingyPong.Screen;

namespace PingyPong.Map
{
    public class EventProcessor
    {
        private List<MapEvent> events;
        private float currentTime;

        public EventProcessor(List<MapEvent> events)
        {
            this.events = events;
        }

        public void Update(float gameTime, GameScreen screen)
        {
            currentTime = gameTime;

            for (int i = events.Count - 1; i >= 0; i--)
            {
                var mapEvent = events[i];
                if (currentTime >= mapEvent.Time)
                {
                    mapEvent.Process(screen);
                    events.RemoveAt(i);
                }
            }
        }
    }

}