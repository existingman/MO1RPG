﻿using System;
using System.Collections.Generic;

namespace MO1.Definitions.Entities.Bodies.Organs
{
    public class Ligament : Organ
    {
        private String _name;
        public override string Name { get { return _name; } }
        public override event LogEvent OrganDamage;

        public Ligament(BodyParts.BodyPart o, string name)
            : base(o)
        {
            _name = name;
        }

        public override DamagePack TakeDamage(DamagePack Pack)
        {
            string explanation = entity.Name + " recives " + Pack.Force.ToString() + " newtons of " + Pack.Type.ToString() + " force to the " + Name + "!";
            DamagePack remaining = Pack;

            switch (Pack.Type)
            {
                case Combat.DamageType.Blunt:
                    if (Pack.Force > Resistance * 2)
                    {
                        explanation = explanation + " causing a partial rupture.";
                        Function -= Pack.Force / 200f;
                    }
                    else
                    {
                        explanation = explanation + " causing no effect.";
                    }
                    break;
                case Combat.DamageType.Piercing:
                    explanation = explanation + " causing localised fragmentation.";
                    Function -= Pack.Force / 50f;
                    break;
                case Combat.DamageType.Slashing:
                    if (Pack.Force > Resistance)
                    {
                        explanation = explanation + " causing it to cleave in two.";
                        Function = 0;
                    }
                    else
                    {
                        explanation = explanation + " but the bone deflects the impact!";
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