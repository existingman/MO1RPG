using System;
using System.Collections.Generic;
using MO1.Content;
using MO1.Definitions.Combat;

using Newtonsoft.Json;

namespace MO1.Definitions.Items
{
    public enum EquipmentSlot { LSabaton, RSabaton, LGreve, RGreve, LPoleyn, RPoleyn, LPoleynWing, RPoleynWing, LCuisse, RCuisse, LTassat, RTassat, Fauld, BreastPlate, Gorget, Helmet, Visor, Come, LPauldron, RPauldron, LPauldronWing, RPauldronWing, LReverbrace, RReverbrace, LCouter, RCouter, LCouterWing, RCouterWing, LVambrace, RVambrace, LGauntlet, RGauntlet, MailTunic, PaddedTunic, Weapon, Shield, Pouch, Quiver, none }

    public abstract class Equipment: Item
    {
        [JsonIgnore]
        public virtual EquipmentSlot Slot { get; set; }

        [JsonIgnore]
        public abstract List<Attack> Attacks { get; }

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
