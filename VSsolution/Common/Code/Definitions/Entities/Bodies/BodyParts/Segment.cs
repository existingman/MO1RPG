using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.Organs;

namespace MO1.Definitions.Entities.Bodies.BodyParts
{
    public class Segment: BodyPart
    {
        private string _name;
        public override string Name { get { return _name; } }

        public Segment(Body b, string name)
            :base(b)
        {
            _name = name;
        }

        public override DamagePack TakeDamage(DamagePack pack)
        {
            DamagePack remainder = pack;
            remainder = randomOrgan(Softs).TakeDamage(remainder);
            if (remainder.Force > 0)
            {
                remainder = randomOrgan(Bones).TakeDamage(remainder);
            }
            return remainder;
        }

    }
}
