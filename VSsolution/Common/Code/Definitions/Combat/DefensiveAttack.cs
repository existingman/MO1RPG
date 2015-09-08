using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MO1.Definitions.Combat
{
    class DefensiveAttack: Attack
    {
        public override AttackType AttackType { get { return Combat.AttackType.Defensive; } }
    }
}
