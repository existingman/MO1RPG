using System;
using System.Collections.Generic;
using MO1.Definitions.Combat;
using MO1.Content;

using Newtonsoft.Json;

namespace MO1.Definitions.Items
{
    public enum WeaponType { LongSword, ShortSword, Mace, Axe, Spear, Dagger, Bow, CrossBow }
    public enum DammageType { Slash, Pierce, Blunt }
    public abstract class Weapon : Equipment
    {
        [JsonIgnore]
        public abstract WeaponType WeaponType { get; }

        [JsonIgnore]
        public override EquipmentSlot Slot { get { return EquipmentSlot.Weapon; } }


        

    }
}
