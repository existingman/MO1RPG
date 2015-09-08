using System;
using System.Collections.Generic;
using MO1.Definitions.Combat;
using MO1.Content;

namespace MO1.Definitions.Items
{
    public enum WeaponType { LongSword, ShortSword, Mace, Axe, Spear, Dagger, Bow, CrossBow }
    public enum DammageType { Slash, Pierce, Blunt }
    public class Weapon : Equipment
    {
        public WeaponType WeaponType { get; set; }
        
        public override EquipmentSlot Slot { get { return EquipmentSlot.Weapon; } }

    }
}
