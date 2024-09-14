using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using PingyPong.Entity;
using PingyPong.Screen;

namespace PingyPong.Map
{
    public static class MapEventFactory
    {
        /// <summary>
        /// Creates the MapEvent from the json data provided
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static MapEvent CreateEvent(MapEventData data)
        {
            switch (data.Action)
            {
                case MapEventAction.BallSpeed:
                    return new BallSpeedEvent { Time = data.Time, Speed = data.Speed };
                case MapEventAction.BallDirection:
                    return new BallDirectionEvent { Time = data.Time, Direction = data.Direction };
                case MapEventAction.PaddleMove:
                    return new PaddleMoveEvent { Time = data.Time, Paddle = data.Paddle, Position = data.Position };
                default:
                    throw new ArgumentException("Unknown Event Action: " + data.Action);
            }
        }
    }

}