using System;
using System.Collections.Generic;

namespace MO1.Definitions.Entities.Bodies.Organs
{
    public class Brain : Organ
    {
        public override string Name { get { return "Brain"; } }
        public override event LogEvent OrganDamage;

        public Brain(BodyParts.BodyPart o)
            : base(o)
        {
            
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
                        explanation = explanation + " causing it to scramble.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " causing severe brain damage.";
                        Function -= Pack.Force / 50f;
                    }
                    break;
                case Combat.DamageType.Piercing:
                    explanation = explanation + " causing a deep perferation.";
                    Function -= Pack.Force / 50f;
                    break;
                case Combat.DamageType.Slashing:
                    if (Pack.Force > Resistance)
                    {
                        explanation = explanation + " amputating vital brain functions.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " causing severe brain damage.";
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
