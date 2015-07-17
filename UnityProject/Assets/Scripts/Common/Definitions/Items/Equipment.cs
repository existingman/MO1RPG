using System;
using System.Collections.Generic;

namespace MO1.Definitions.Items
{
    public enum EqipmentSlot { LSabaton, RSabaton, LGreve, RGreve, LPoleyn, RPoleyn, LFanPlate, RFanPlate, LCuisse, RCuisse, Tassat, BreastPlate, Gorget, Helmet, Visor, Come, LPauldron, RPauldron, LReverbrace, RReverbrace, LCouter, RCouter, LVambrace, RVambrace, LGauntlet, RGauntlet, MailTunic, PaddedTunic, Weapon, Shield, Quiver }
    public enum Material { Copper, Tin, Bronze, Iron, Steel, Tempered, Wood}
    public class Equipment: Item
    {
        public EqipmentSlot Slot;
        public Material Material;
        


    }
}
