namespace PingyPong.Map
{
    /// <summary>
    /// The information for events in the map json
    /// </summary>
    public class MapEventData()
    {
        public MapEventAction Action { get; set; }
        public float Time { get; set; }
        public float Speed { get; set; }
        public string Direction { get; set; }
        public string Paddle { get; set; }
        public int Position { get; set; }
    }
}