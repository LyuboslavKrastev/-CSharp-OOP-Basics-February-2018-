
using System.Collections.Generic;

public class Treasure
    {
        public string Type { get; set; }
        public Dictionary<string, long> SubTypes { get; set; } = new Dictionary<string, long>();
    }

