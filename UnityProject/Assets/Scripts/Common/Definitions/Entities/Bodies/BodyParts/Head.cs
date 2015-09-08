using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.Organs;

namespace MO1.Definitions.Entities.Bodies.BodyParts
{
    public class Head : BodyPart
    {
        public override string Name { get { return "Head"; } }

        public Brain Brain;
        public Bone Skull;

        public Head(Body b)
            : base(b)
        {
            Brain = new Brain(this);
            Skull = new Bone(this, "Skull");
        }

        public override DamagePack TakeDamage(DamagePack pack)
        {
            DamagePack remainder = pack;
            remainder = randomOrgan(Bones).TakeDamage(remainder);
            if (remainder.Force > 0)
            {
                remainder = Brain.TakeDamage(remainder);
            }
            return remainder;
        }

    }
}

