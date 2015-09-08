using System;
using System.Collections.Generic;
using MO1.Tech;
using MO1.Content;

namespace MO1.Definitions
{
    public class Tile
    {
        public Coord Coord = new Coord(0, 0, 0);

        public int PropRef = -1;
        public int TerrainRef = -1;

        //terrain State
        public bool LineOfSight = false;
        public bool Discovered = false;
        public bool Traversed = false;

        //Prop state
        public DoorState DoorState {get; set;}
        public int KeyRef { get; set; }
        public int ActionRef { get; set; }

        //Entity
        public Entity Entity;

        public bool opaque()
        {
            if(TerrainRef == -1)
            {
                return false;
            }
            else
            {
                if(Data.Terrains[TerrainRef].TerrainType == TerrainType.Wall)
                {
                    if (PropRef != -1)
                    {
                        if (Data.Props[PropRef].proptype == PropType.door)
                        {
                            if (DoorState == Definitions.DoorState.lockedOpen || DoorState == Definitions.DoorState.open)
                            {
                                return false;
                            }
                        }
                        if (Data.Props[PropRef].proptype == PropType.window)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        public bool Obstructed()
        {
            if(TerrainType == TerrainType.Wall || TerrainType == TerrainType.None)
            {
                if (PropType == PropType.door)
                {
                    if (DoorState == DoorState.open || DoorState == DoorState.lockedOpen)
                    {
                        return false;
                    }
                }
                if (PropType == PropType.window)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if(PropType == Definitions.PropType.obstruction)
                {
                    return true;
                }
                return false;
            }
        }

        



        //helpers
        public TerrainType TerrainType
        {
            get
            {
                if (TerrainRef == -1)
                {
                    return TerrainType.None;
                }
                else
                {
                    return Data.Terrains[TerrainRef].TerrainType;
                }
            }
        }

        public PropType PropType
        {
            get
            {
                if (PropRef == -1)
                {
                    return PropType.none;
                }
                else
                {
                    return Data.Props[PropRef].proptype;
                }
            }
        }

    }
}
