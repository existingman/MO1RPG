using System;
using System.Collections.Generic;

using MO1.Tech;

namespace MO1.Definitions.Entities.AIs
{
    public class DataPoint
    {
        public Entity Entity;
        public Entity Owner;
        public Coord Coord;
        public bool current;
        public int age = 0;
        public bool exposed { get { return Owner.VisionField().Contains(Coord); } }

        public DataPoint(Entity e, Entity owner)
        {
            Entity = e;
            Entity.OnMove += Update;
            Owner = owner;
            Owner.OnMove += Update;
            Owner.AI.DataPoints.Add(this);
            Update();
        }

        public void Update()
        {
            if(Owner.VisionField().Contains(Entity.Coord))
            {
                Coord = Entity.Coord;
                current = true;
            }
            if (exposed && !Entity.Coord.Equals(Coord)) current = false;
        }

        public void Dispose()
        {
            Entity.OnMove -= Update;
            Owner.OnMove -= Update;
            Owner.AI.DataPoints.Remove(this);
        }

    }
}
