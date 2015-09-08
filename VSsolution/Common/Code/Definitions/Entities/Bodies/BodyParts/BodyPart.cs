using System;
using System.Collections.Generic;
using System.Linq;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.Organs;

namespace MO1.Definitions.Entities.Bodies.BodyParts
{
    public abstract class BodyPart : IDamageable
    {
        public Body Owner;
        public int hp = 100;
        public List<Organ> Organs = new List<Organ>();
        public abstract string Name { get;}
        

        public BodyPart(Body b)
        {
            Owner = b;
            Owner.Members.Add(this);
        }

        public abstract DamagePack TakeDamage(DamagePack Pack);

        protected List<Organ> Bones { get { return (List<Organ>)(Organs.Where(item => item.GetType() == typeof(Bone))); } }
        protected List<Organ> Softs { get { return (List<Organ>)(Organs.Where(item => item.GetType() != typeof(Bone))); } }

        protected Organ randomOrgan(List<Organ> list)
        {
            if (list.Count > 0)
            {
                Random RND = new Random();
                return list[RND.Next(list.Count)];
            }
            else
            {
                return null;
            }
        }


    }
}
