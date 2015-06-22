using System;
using System.Collections.Generic;
using MO1VSSolution.Definitions;


namespace MO1VSSolution.Definitions
{
    public enum TerrainType { Floor, Wall, Water, Lava }

    public class Terrain
    {
        public string name = "unnamed";
        public TerrainType Type = TerrainType.Floor;
        public int Image;
        public Tile Owner;

    }
}
