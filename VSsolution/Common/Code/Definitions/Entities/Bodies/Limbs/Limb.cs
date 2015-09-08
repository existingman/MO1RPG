using System;
using System.Collections.Generic;
using System.Linq;

namespace MO1.Definitions.Entities.Bodies.Limbs
{
    public abstract class Limb
    {
        private Body _owner;
        protected Side _orientation;
        public abstract String Name { get; }
        public List<BodyParts.BodyPart> Segments = new List<BodyParts.BodyPart>();
        
        public Limb(Body owner, Side s)
        {
            _owner = owner;
            _owner.Limbs.Add(this);
            _orientation = s;
        }
    }
}
