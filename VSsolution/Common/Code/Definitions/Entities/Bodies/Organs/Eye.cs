using System;
using System.Collections.Generic;

namespace MO1.Definitions.Entities.Bodies.Organs
{
    public class Eye : Organ
    {
        Side _side;
        public override string Name { get { return _side.ToString() + " Eye"; } }
        public override event LogEvent OrganDamage;

        public Eye(BodyParts.BodyPart o, Side s)
            :base(o)
        {
            _side = s;
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
                        explanation = explanation + " causing it to rupture under pressure.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " but it springs back into shape.";
                    }
                    break;
                case Combat.DamageType.Piercing:
                    explanation = explanation + " causing eye to collapse";
                    Function = 0;
                    break;
                case Combat.DamageType.Slashing:
                    if (Pack.Force > Resistance)
                    {
                        explanation = explanation + " causing eye to collapse.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " causing partial lense damage";
                        Function -= Pack.Force / 50f;
                    }
                    break;
            }
            OrganDamage(explanation);
            remaining.Force -= Resistance;
            return remaining;
        }
    }
}
