using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.Organs;

namespace MO1.Definitions.Entities.Bodies.BodyParts
{
    public class Adomen : BodyPart
    {
        public override string Name { get { return "Adomen"; } }

        public Adomen(Body b)
            : base(b)
        {

        }

        public override DamagePack TakeDamage(DamagePack pack)
        {
            return pack;
        }

    }
}
