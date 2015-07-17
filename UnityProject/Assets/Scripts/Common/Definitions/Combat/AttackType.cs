using System;
using System.Collections.Generic;

namespace MO1.Definitions.Combat
{
    public enum AttackType { Melee, Ranged, Defensive }
    public enum DamageType { Piercing, Slashing, Blunt }
    public class Attack
    {
        public AttackType AttackType;
        public DamageType DammageType;
        public float SkillWeighting;
        public float StrengthWeighting;
    }
}
