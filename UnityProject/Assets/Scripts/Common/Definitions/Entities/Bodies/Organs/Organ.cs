using System;
using System.Collections.Generic;
using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.BodyParts;

namespace MO1.Definitions.Entities.Bodies.Organs
{
    public delegate void LogEvent(string explanation);

    public abstract class Organ : IDamageable
    {
        public abstract event LogEvent OrganDamage;

        public float Function = 1;
        public BodyPart Owner;
        protected Body body { get { return Owner.Owner; } }
        protected Entity entity { get { return Owner.Owner.Owner; } }
        public abstract string Name { get; }
        public float Resistance = 2f;

        public Organ(BodyPart o)
        {
            Owner = o;
            Owner.Organs.Add(this);
            Owner.Owner.Organs.Add(this);
        }

        public abstract DamagePack TakeDamage(DamagePack pack);

    }
}
