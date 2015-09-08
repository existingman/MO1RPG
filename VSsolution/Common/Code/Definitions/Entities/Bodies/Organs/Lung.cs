using System;
using System.Collections.Generic;


namespace MO1.Definitions.Entities.Bodies.Organs
{
    public class Lung : Organ
    {
        Side _side;
        public override string Name { get { return _side.ToString() + " Lung"; } }
        public override event LogEvent OrganDamage;

        public Lung(BodyParts.BodyPart o, Side s)
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
                    explanation = explanation + " causing compression of lung tissue.";
                    Function -= Pack.Force / 50;
                    break;
                case Combat.DamageType.Piercing:
                    explanation = explanation + " causing lung to collapse";
                    Function = 0;
                    break;
                case Combat.DamageType.Slashing:
                    if (Pack.Force > 1f)
                    {
                        explanation = explanation + " causing lung to collapse.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " but it fails to penitrait.";
                    }
                    break;
            }
            OrganDamage(explanation);
            remaining.Force -= Resistance;
            return remaining;
        }
    }
}
