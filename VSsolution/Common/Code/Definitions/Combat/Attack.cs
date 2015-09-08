using System;
using System.Collections.Generic;

using MO1.Definitions.Items;
using MO1.Definitions.Entities.Bodies;
using MO1.Definitions.Entities;

namespace MO1.Definitions.Combat
{
    public enum AttackType { Melee, Ranged, Defensive }
    public enum DamageType { Piercing, Slashing, Blunt }
    public enum AttackName { Slash, Pummel, Hack, Cleave, Jab, Stab, Thrust, Parry, Shoot, Throw, Bash }
    public abstract class Attack
    {
        public Weapon Owner;
        public Charactor Holder;
        public AttackName Name;
        public abstract AttackType AttackType { get; }
        public DamageType DamageType;
        public float SkillWeighting;
        public float StrengthWeighting;
        public float Range;

        public virtual void Do(Target t)
        {
            Random RND = new Random();
            DamagePack d = new DamagePack();
            d.Type = DamageType;
            float skill = Holder.Stats.GetSkill(Name, Owner.WeaponType);
            d.Force = SkillWeighting * skill + StrengthWeighting * Holder.Stats.strength;
            float proximity = (float)RND.NextDouble() / skill;

            // NOT IMPLEMENTED - change target if missing

            t.TakeDamage(d);
        }

    }
}
