using System;
using System.Collections.Generic;
using MO1.Definitions.Items;
using MO1.Definitions.Entities.Bodies;

namespace MO1.Definitions.Combat
{
    public class ShootAttack : Attack
    {
        public AmmoType AmmoType { get; set; }

        public override AttackType AttackType { get { return Combat.AttackType.Ranged; } }

        public static void Apply(Target t)
        {

        }
    }

    

}
