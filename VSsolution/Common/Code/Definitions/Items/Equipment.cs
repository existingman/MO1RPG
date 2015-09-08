using System;
using System.Collections.Generic;
using MO1.Content;
using MO1.Definitions.Combat;

namespace MO1.Definitions.Items
{
    public enum EquipmentSlot { LSabaton, RSabaton, LGreve, RGreve, LPoleyn, RPoleyn, LFanPlate, RFanPlate, LCuisse, RCuisse, Tassat, BreastPlate, Gorget, Helmet, Visor, Come, LPauldron, RPauldron, LReverbrace, RReverbrace, LCouter, RCouter, LVambrace, RVambrace, LGauntlet, RGauntlet, MailTunic, PaddedTunic, Weapon, Shield, Quiver, none }

    public class Equipment: Item
    {
        public virtual EquipmentSlot Slot { get; set; }
        public List<Attack> Attacks = new List<Attack>();
        public string MatName
        {
            get { return BaseStats.MatStats.Name(_matRef); }
            set { _matRef = BaseStats.MatStats.IndexOf(value); }
        }

        private int _matRef;
        
        public MatStat GetMatStat()
        {
            return BaseStats.MatStats.Get(_matRef);
        }

        
        

    }
}
