using System;
using System.Collections.Generic;

namespace MO1.Definitions.Items
{
    public class Shield : Equipment
    {
        public override EquipmentSlot Slot { get { return EquipmentSlot.Shield; } }

        public override List<Combat.Attack> Attacks
        {
            get { return new List<Combat.Attack>(); }
        }
    }
}
