using System;
using System.Collections.Generic;

using MO1.Content;
using MO1.Definitions.Items;

namespace MO1.Definitions.Combat
{
    public class MeleeAttack : Attack
    {
        public override AttackType AttackType { get { return Combat.AttackType.Melee; } }

        public MeleeAttack(Weapon owner, AttackName name, DamageType d, float skill, float strength)
        {
            Owner = owner;
            Name = name;
            DamageType = d;
            SkillWeighting = skill;
            StrengthWeighting = strength;
        }

        public DamagePack DoAttack()
        {
            return new DamagePack();
        }

    }
}
