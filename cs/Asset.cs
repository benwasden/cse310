using System;

namespace AssetManager
{
    public class Asset
    {
        public required string Tag { get; set; }
        public required string Model { get; set; }
        public required string Serial { get; set; }
        public required string Room { get; set; }
        public required string Owner { get; set; }
        public required string Status { get; set; }
    }

}