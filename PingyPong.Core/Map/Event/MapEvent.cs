using PingyPong.Screen;

namespace PingyPong.Map
{
    public abstract class MapEvent
    {
        public float Time { get; set; }

        /// <summary>
        /// Ran when the event is time to process
        /// </summary>
        /// <param name="screen"></param>
        public abstract void Process(GameScreen screen);
    }
}