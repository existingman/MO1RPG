using System;
using System.Collections.Generic;

namespace MO1.Definitions.Entities.Bodies.Organs
{
    public class Artery : Organ
    {
        private Body body { get { return Owner.Owner; } }
        private Entity entity { get { return Owner.Owner.Owner; } }
        private String _name;
        private float _bloodShare;
        public override string Name { get { return _name; } }
        public override event LogEvent OrganDamage;

        public Artery(BodyParts.BodyPart o, string name, float bloodshare)
            : base(o)
        {
            _name = name;
            _bloodShare = bloodshare;
        }

        public override DamagePack TakeDamage(DamagePack Pack)
        {
            string explanation = entity.Name + " recives " + Pack.Force.ToString() + " newtons of " + Pack.Type.ToString() + " force to the " + Name + "!";
            DamagePack remaining = Pack;

            switch (Pack.Type)
            {
                case Combat.DamageType.Blunt:
                    if (Pack.Force > Resistance)
                    {
                        explanation = explanation + " causing a heamorage";
                        body.Blood -= Pack.Force / 100;
                    }
                    else
                    {
                        explanation = explanation + " but it does nothing.";
                    }
                    break;
                case Combat.DamageType.Piercing:
                    explanation = explanation + " causing it to sever and retract.";
                    Function = 0;
                    body.Bleeding += _bloodShare / 10f;
                    break;
                case Combat.DamageType.Slashing:
                    explanation = explanation + " creating an open and gushing wound!";
                    Function = 0;
                    body.Bleeding += _bloodShare / 5f;
                    break;
            }
            OrganDamage(explanation);
            remaining.Force -= Resistance;
            return remaining;
        }
    }
}