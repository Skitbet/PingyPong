using System.Collections.Generic;
using System.Linq;

namespace PingyPong.Map
{
    public class RhythmMap
    {
        public string Song { get; set; }
        public string Background { get; set; }
        public int BPM { get; set; }
        public List<MapEventData> Events { get; set; }

        public List<MapEvent> CreateEventList()
        {
            return Events.Select(MapEventFactory.CreateEvent).ToList();
        }
    }
}