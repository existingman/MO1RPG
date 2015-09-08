using System;
using System.Collections.Generic;

namespace MO1.Definitions.Items
{
    public enum AmmoType { Arrow, bolt, stone, knife, surrican }
    public class Ammo : Equipment
    {
        public AmmoType AmmoType { get; set; }
        public override EquipmentSlot Slot
        {
            get
            {
                return EquipmentSlot.Quiver;
            }
            set
            {
                //base.Slot = value;
            }
        }


    }
}
