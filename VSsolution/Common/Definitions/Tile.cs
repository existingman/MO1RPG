using System;
using System.Collections.Generic;
using MO1VSSolution.Definitions;


namespace MO1VSSolution.Definitions
{
    public class Tile
    {
        public bool LineOfSight;
        public bool Discovered;

        public Prop Prop;
        public Terrain Terrain;
        public Entity Entity;
    }
}
