using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1.Definitions.Items;

namespace MO1.Definitions.Charactors
{
    public delegate void changed(EquipmentSlot e);
    public class Inventory: ICloneable
    {
        public const int LootLimit = 20;

        public event changed SlotUpdate;

        public Dictionary<EquipmentSlot, Equipment> Equiped = new Dictionary<EquipmentSlot, Equipment>();
        public Dictionary<CurrencyType, float> Currency = new Dictionary<CurrencyType, float>();
        public Item[] Loot = new Item[LootLimit];




        public void Equip(int i)
        {
            if(i > 0 && i < LootLimit)
            {
                if(Loot[i].GetType().IsSubclassOf(typeof(Equipment)))
                {
                    EquipmentSlot targetSlot = ((Equipment)(Loot[i])).Slot;
                    if(Equiped.ContainsKey(targetSlot))
                    {
                        Item temp = Equiped[targetSlot];
                        Equiped[targetSlot] = (Equipment)Loot[i];
                        Loot[i] = temp;
                    }
                    else
                    {
                        Equiped.Add(targetSlot, (Equipment)Loot[i]);
                        Loot[i] = null;
                    }
                    SlotUpdate(targetSlot);
                }
            }
        }

        public void UnEquip(EquipmentSlot s)
        {
            int space = -1;
            for(int x = 0; x < LootLimit; x++)
            {
                if(Loot[x] == null)
                {
                    space = x;
                    break;
                }
            }
            if(space > -1)
            {
                Loot[space] = Equiped[s];
                Equiped.Remove(s);
                SlotUpdate(s);
            }
            else
            {
                //handle full inventory needs implementing
            }
        }

        //IClonable
        public object Clone()
        {
            Inventory temp = new Inventory();
            foreach (EquipmentSlot e in Equiped.Keys)
            {
                temp.Equiped.Add(e, (Equipment)Equiped[e].Clone());
            }
            foreach (CurrencyType c in Currency.Keys)
            {
                temp.Currency.Add(c, Currency[c]);
            }
            for (int i = 0; i < LootLimit; i++)
            {
                if (Loot[i] != null)
                {
                    temp.Loot[i] = (Item)Loot[i].Clone();
                }
            }
            return temp;
        }
    }
}
