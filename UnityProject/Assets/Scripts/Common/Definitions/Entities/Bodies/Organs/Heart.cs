using System;
using System.Collections.Generic;

namespace MO1.Definitions.Entities.Bodies.Organs
{
    public class Heart : Organ
    {
        public override string Name {get { return "heart"; }}
        public override event LogEvent OrganDamage;

        public Heart(BodyParts.BodyPart o)
            :base(o)
        {
           
        }

        public override DamagePack TakeDamage(DamagePack Pack)
        {
            string explanation = entity.Name + " recives " + Pack.Force.ToString() + " newtons of " + Pack.Type.ToString() + " force to the " + Name + "!";
            DamagePack remaining = Pack;

            switch (Pack.Type)
            {
                case Combat.DamageType.Blunt:
                    if (Pack.Force > 2)
                    {
                        explanation = explanation + " causing heart chamber rupture.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " causing a minor contusion of the heart tissue.";
                        Function -= Pack.Force / 50;
                        body.Blood -= Pack.Force / 200;
                    }
                    break;
                case Combat.DamageType.Piercing:
                    explanation = explanation + " causing serios internal bleeding.";
                    body.Bleeding += Pack.Force / 50;
                    break;
                case Combat.DamageType.Slashing:
                    explanation = explanation + " causing laceration of heart tissue.";
                    body.Bleeding += Pack.Force / 100;
                    Function -= Pack.Force / 100;
                    break;
            }
            OrganDamage(explanation);
            remaining.Force -= Resistance;
            return remaining;
        }
    }
}
