using System;
using System.Collections.Generic;
using MO1.Definitions;


namespace MO1.Definitions
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
