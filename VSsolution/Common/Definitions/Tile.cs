using System;
using System.Collections.Generic;
using MO1.Definitions;


namespace MO1.Definitions
{
    public class Tile
    {
        public int PropRef = -1;
        public int TerrainRef = -1;
        public int EntityRef = -1;

        //terrain State
        public bool LineOfSight = false;
        public bool Discovered = false;
        public bool Traversed = false;

        //Prop state
        public DoorState DoorState;
        public int KeyRef;
        public int ActionRef;


    }
}
