using System;
using System.Collections.Generic;

namespace MO1.Definitions.Combat
{
    class ThrowAttack: Attack
    {
        public override AttackType AttackType { get { return Combat.AttackType.Ranged; } }
    }
}
