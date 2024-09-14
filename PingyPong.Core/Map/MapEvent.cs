using PingyPong.Screen;

namespace PingyPong.Map {
    public abstract class MapEvent {
        public float Time { get; set; }
        public abstract void Process(GameScreen screen);
    }
}