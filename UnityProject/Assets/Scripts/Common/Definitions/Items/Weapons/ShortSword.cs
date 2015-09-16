using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;

namespace MO1.Definitions.Items.Weapons
{
    public class ShortSword: Weapon
    {
        public override List<Attack> Attacks
        {
            get
            {
                List<Attack> temp = new List<Attack>();
                temp.Add(new MeleeAttack(this, AttackName.Jab, DamageType.Piercing, 1f, 1f));
                temp.Add(new MeleeAttack(this, AttackName.Slash, DamageType.Slashing, 1f, 1f));
                return temp;
            }
        }

        public override WeaponType WeaponType
        {
            get { return WeaponType.ShortSword; }
        }

        

    }
}
