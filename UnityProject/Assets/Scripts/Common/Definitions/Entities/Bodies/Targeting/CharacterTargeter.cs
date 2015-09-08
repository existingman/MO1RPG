using System;
using System.Collections.Generic;

using MO1.Definitions.Items;

namespace MO1.Definitions.Entities.Bodies
{
    public class CharacterTargeter: Targeter
    {
        private Charactor _owner;
 
        public CharacterTargeter(Charactor o)
        {
            _owner = o;
        }

        public override List<Target> GetTargets()
        {
            List<Target> targets = new List<Target>();
            foreach (HumanoidParts h in Enum.GetValues(typeof(HumanoidParts)))
            {
                targetinfo info = LookUp[h];
                List<IDamageable> layers = new List<IDamageable>();
                Enum tempEnum;
                if(info.Minor == EquipmentSlot.none)
                {
                    tempEnum = h;
                    if(_owner.Inventory.Equiped[info.Major] != null)
                    {
                        layers.Add((Armour)(_owner.Inventory.Equiped[info.Major]));
                        tempEnum = info.Major;
                    }
                    if(info.Tuniccoverage)
                    {
                        if(_owner.Inventory.Equiped[EquipmentSlot.MailTunic] != null)
                        {
                            layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.MailTunic]));
                        }
                        if (_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic] != null)
                        {
                            layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic]));
                        }
                    }
                    layers.Add(((Humanoid)(_owner.Body)).Get(h));
                    targets.Add(new Target(layers, tempEnum) );
                }
                else
                {
                    if (_owner.Inventory.Equiped[info.Major] != null || _owner.Inventory.Equiped[info.Minor] != null)
                    {
                        tempEnum = h;
                        if(_owner.Inventory.Equiped[info.Major] != null )
                        {
                            tempEnum = info.Major;
                            layers.Add((Armour)(_owner.Inventory.Equiped[info.Major]));
                        }
                        if (info.Tuniccoverage)
                        {
                            if (_owner.Inventory.Equiped[EquipmentSlot.MailTunic] != null)
                            {
                                layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.MailTunic]));
                            }
                            if (_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic] != null)
                            {
                                layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic]));
                            }
                        }
                        layers.Add(((Humanoid)(_owner.Body)).Get(h));
                        targets.Add(new Target(layers, tempEnum));


                        layers = new List<IDamageable>();
                        tempEnum = h;
                        if (_owner.Inventory.Equiped[info.Minor] != null)
                        {
                            tempEnum = info.Minor;                            
                            layers.Add((Armour)(_owner.Inventory.Equiped[info.Minor]));
                        }
                        if (info.Tuniccoverage)
                        {
                            if (_owner.Inventory.Equiped[EquipmentSlot.MailTunic] != null)
                            {
                                layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.MailTunic]));
                            }
                            if (_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic] != null)
                            {
                                layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic]));
                            }
                        }
                        layers.Add(((Humanoid)(_owner.Body)).Get(h));
                        targets.Add(new Target(layers, tempEnum));
                    }
                    else 
                    {
                        tempEnum = h;
                        if (info.Tuniccoverage)
                        {
                            if (_owner.Inventory.Equiped[EquipmentSlot.MailTunic] != null)
                            {
                                layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.MailTunic]));
                            }
                            if (_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic] != null)
                            {
                                layers.Add((Armour)(_owner.Inventory.Equiped[EquipmentSlot.PaddedTunic]));
                            }
                        }
                        layers.Add(((Humanoid)(_owner.Body)).Get(h));
                        targets.Add(new Target(layers, tempEnum));
                    }
                }
            }
            return targets;  
        }

        public static Dictionary<HumanoidParts, targetinfo> LookUp = new Dictionary<HumanoidParts, targetinfo>()
        {
            {HumanoidParts.Adoman, new targetinfo(true, EquipmentSlot.Tassat, EquipmentSlot.none) },
            {HumanoidParts.Chest, new targetinfo(true,  EquipmentSlot.BreastPlate, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(false,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Head, new targetinfo(false,  EquipmentSlot.Helmet, EquipmentSlot.none) },

            {HumanoidParts.LElbo, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(true,  EquipmentSlot.Visor, EquipmentSlot.none) },
        };


        public struct targetinfo
        {
            public bool Tuniccoverage;
            public EquipmentSlot Minor;
            public EquipmentSlot Major;

            public targetinfo(bool tunic, EquipmentSlot major, EquipmentSlot minor)
            {
                Tuniccoverage = tunic;
                Major = major;
                Minor = minor;
            }
        }
    }
}
