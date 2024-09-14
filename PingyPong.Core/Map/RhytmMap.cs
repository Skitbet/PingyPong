using System.Collections.Generic;

namespace PingyPong.Map {
    public class RhythmMap {
        public string Song { get; set; }
        public int BPM { get; set; }
        public List<MapEvent> Events { get; set; }
    }
}