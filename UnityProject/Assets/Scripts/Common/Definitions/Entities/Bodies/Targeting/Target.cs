using System;
using System.Collections.Generic;
using System.Linq;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.BodyParts;
using MO1.Definitions.Items;
using MO1.Definitions;

namespace MO1.Definitions.Entities.Bodies
{
    public class Target : IDamageable
    {
        public List<IDamageable> LineUp;
        public Enum Ref; 

        public Target(List<IDamageable> lineUp, Enum targetRef)
        {
            LineUp = lineUp;
            Ref = targetRef;
        }

        public virtual DamagePack TakeDamage(DamagePack Pack)
        {
            DamagePack running = Pack;

            foreach(IDamageable d in LineUp)
            {
                if (running.Force > 0)
                {
                    running = d.TakeDamage(running);
                }
                else
                {
                    break;
                }
            }
            return running;
        }

    }
}
