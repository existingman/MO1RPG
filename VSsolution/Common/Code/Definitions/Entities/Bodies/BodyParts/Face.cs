using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.Organs;

namespace MO1.Definitions.Entities.Bodies.BodyParts
{
    public class Face : BodyPart
    {
        public override string Name { get { return "Face"; } }
        private Head _head;
        public Eye LeftEye;
        public Eye RightEye;

        public Face(Body b, Head h)
            : base(b)
        {
            _head = h;
            LeftEye = new Eye(this, Side.Left);
            RightEye = new Eye(this, Side.Right);
        }

        public override DamagePack TakeDamage(DamagePack pack)
        {
            DamagePack remainder = pack;
            Random RND = new Random();
            if (RND.NextDouble() > 0.5)
            {
                remainder = LeftEye.TakeDamage(remainder);
            }
            else
            {
                remainder = RightEye.TakeDamage(remainder);
            }
            if (remainder.Force > 0)
            {
                if (remainder.Type != DamageType.Piercing)
                {
                    remainder = _head.TakeDamage(remainder);
                }
            }
            if (remainder.Force > 0)
            {
                remainder = _head.Brain.TakeDamage(remainder);
            }
            return remainder;
        }

    }
}

