using System;
using System.Collections.Generic;
using System.Linq;

using MO1.Definitions.Entities.AIs;
using MO1.Content;
using MO1.Tech;

namespace MO1.Definitions.Entities.AIs
{
    public enum Mode { standing, searching, patroling, loitering, combat }
    public enum Allignment { allied, passive, hostile}
}

namespace MO1.Definitions.Entities
{
    public class AI
    {
        public Entity Owner;

        public Mode Mode = Mode.loitering;
        public Allignment Allignment;

        public List<DataPoint> DataPoints = new List<DataPoint>();

        public AI(Entity entity)
        {
            Owner = entity;
        }

        public virtual void Act()
        {
            foreach(Coord c in Owner.VisionField())
            {
                if(Map.Get(c).Entity != null)
                {
                    Entity temp = Map.Get(c).Entity;
                    if(DataPoints.TrueForAll(d => d.Entity != temp))
                    {
                        new DataPoint(temp, this.Owner);
                    }
                }
            }
            List<DataPoint> killList = new List<DataPoint>();
            foreach(DataPoint d in DataPoints)
            {
                if(!d.exposed) d.age++;
                if (d.age > 100) killList.Add(d);
            }
            foreach (DataPoint d in killList) d.Dispose();

            switch (Mode)
            {
                case AIs.Mode.combat:

                    break;
                case AIs.Mode.loitering:
                    Random RND = new Random();
                    Coord c = Owner.Coord.Plus(Tech.Tech.DirectionalSteps[(CardinalDirection)(RND.Next(4) * 2)]);
                    if (_walkable(c)) Owner.Coord = c;
                    break;
                case AIs.Mode.patroling:

                    break;
                case AIs.Mode.searching:

                    break;
                case AIs.Mode.standing:

                    break;
            }

        }

        private bool _walkable(Coord c)
        {
            Tile t = Map.Get(c);
            if(t.PropType == PropType.door)
            {
                if (t.DoorState == DoorState.open || t.DoorState == DoorState.lockedOpen)
                {
                    return true;
                }
            }
            if(t.TerrainType == TerrainType.Floor)
            {
                if(t.PropType != PropType.obstruction)
                {
                    return true;
                }
            }
            return false;
        }



    }
}
