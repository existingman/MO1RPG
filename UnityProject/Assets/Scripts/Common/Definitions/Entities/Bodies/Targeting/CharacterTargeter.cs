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
                if(info.Minor == EquipmentSlot.none)
                {
                    if(_owner.Inventory.Equiped[info.Major] != null)
                    {
                        layers.Add((Armour)(_owner.Inventory.Equiped[info.Major]));
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
                    if (_owner.Inventory.Equiped[info.Major] != null)
                    {
                        targets.Add(new Target(layers, info.Major));
                    }
                    else
                    {
                        targets.Add(new Target(layers, h));
                    }
                }
                else
                {
                    if (_owner.Inventory.Equiped[info.Major] != null || _owner.Inventory.Equiped[info.Minor] != null)
                    {
                        if(_owner.Inventory.Equiped[info.Major] != null )
                        {
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
                        targets.Add(new Target(layers, info.Major));


                        layers = new List<IDamageable>();
                        if (_owner.Inventory.Equiped[info.Minor] != null)
                        {                          
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
                        targets.Add(new Target(layers, info.Minor));
                    }
                    else 
                    {
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
                        targets.Add(new Target(layers, h));
                    }
                }
            }
            return targets;  
        }

        public static Dictionary<HumanoidParts, targetinfo> LookUp = new Dictionary<HumanoidParts, targetinfo>()
        {
            {HumanoidParts.Adoman, new targetinfo(true, EquipmentSlot.Fauld, EquipmentSlot.none) },
            {HumanoidParts.Chest, new targetinfo(true,  EquipmentSlot.BreastPlate, EquipmentSlot.none) },
            {HumanoidParts.Face, new targetinfo(false,  EquipmentSlot.Visor, EquipmentSlot.none) },
            {HumanoidParts.Head, new targetinfo(false,  EquipmentSlot.Helmet, EquipmentSlot.none) },

            {HumanoidParts.LElbo, new targetinfo(true,  EquipmentSlot.LCouter, EquipmentSlot.LCouterWing) },
            {HumanoidParts.LFoot, new targetinfo(true,  EquipmentSlot.LSabaton, EquipmentSlot.none) },
            {HumanoidParts.LForeArm, new targetinfo(true,  EquipmentSlot.LVambrace, EquipmentSlot.none) },
            {HumanoidParts.LHand, new targetinfo(true,  EquipmentSlot.LGauntlet, EquipmentSlot.none) },
            {HumanoidParts.LHip, new targetinfo(true,  EquipmentSlot.LTassat, EquipmentSlot.none) },
            {HumanoidParts.LKnee, new targetinfo(true,  EquipmentSlot.LPoleyn, EquipmentSlot.LPoleynWing) },
            {HumanoidParts.LShin, new targetinfo(true,  EquipmentSlot.LGreve, EquipmentSlot.none) },
            {HumanoidParts.LShoulder, new targetinfo(true,  EquipmentSlot.LPauldron, EquipmentSlot.LPauldronWing) },
            {HumanoidParts.LThigh, new targetinfo(true,  EquipmentSlot.LCuisse, EquipmentSlot.none) },
            {HumanoidParts.LUpperArm, new targetinfo(true,  EquipmentSlot.LReverbrace, EquipmentSlot.none) },

            {HumanoidParts.RElbo, new targetinfo(true,  EquipmentSlot.RCouter, EquipmentSlot.RCouterWing) },
            {HumanoidParts.RFoot, new targetinfo(true,  EquipmentSlot.RSabaton, EquipmentSlot.none) },
            {HumanoidParts.RForeArm, new targetinfo(true,  EquipmentSlot.RVambrace, EquipmentSlot.none) },
            {HumanoidParts.RHand, new targetinfo(true,  EquipmentSlot.RGauntlet, EquipmentSlot.none) },
            {HumanoidParts.RHip, new targetinfo(true,  EquipmentSlot.RTassat, EquipmentSlot.none) },
            {HumanoidParts.RKnee, new targetinfo(true,  EquipmentSlot.RPoleyn, EquipmentSlot.RPoleynWing) },
            {HumanoidParts.RShin, new targetinfo(true,  EquipmentSlot.RGreve, EquipmentSlot.none) },
            {HumanoidParts.RShoulder, new targetinfo(true,  EquipmentSlot.RPauldron, EquipmentSlot.RPauldronWing) },
            {HumanoidParts.RThigh, new targetinfo(true,  EquipmentSlot.RCuisse, EquipmentSlot.none) },
            {HumanoidParts.RUpperArm, new targetinfo(true,  EquipmentSlot.RReverbrace, EquipmentSlot.none) },
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
