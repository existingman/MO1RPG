using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1.Tech;
using MO1.Content;

namespace MO1.Definitions.Actions
{
    class AlterLock : Action
    {
        Coord Coord;
        DoorState Doorstate;
        public AlterLock(Coord c, DoorState d)
        {
            Coord = c;
            Doorstate = d;
        }

        public override void Do()
        {
            Map.Get(Coord).DoorState = Doorstate;
        }


    }
}
