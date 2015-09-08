using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;

namespace MO1.Definitions.Items.Weapons
{
    class ShortSword: Weapon
    {

        public ShortSword()
        {
            Attacks.Add(new MeleeAttack(this, AttackName.Jab, DamageType.Piercing, 1f, 1f));
            Attacks.Add(new MeleeAttack(this, AttackName.Slash, DamageType.Slashing, 1f, 1f));
        }

    }
}
