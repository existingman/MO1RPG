using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1.Definitions.Items;

namespace MO1.Definitions.Charactors
{
    public class Inventory
    {
        public const int LootLimit = 20;

        public Dictionary<EqipmentSlot, Item> Equiped = new Dictionary<EqipmentSlot, Item>();
        public Dictionary<CurrencyType, float> Currency = new Dictionary<CurrencyType, float>();
        public Item[] Loot = new Item[LootLimit];

        public void Equip(int i)
        {
            if(i > 0 && i < LootLimit)
            {
                if(Loot[i].GetType().IsSubclassOf(typeof(Equipment)))
                {
                    EqipmentSlot targetSlot = ((Equipment)(Loot[i])).Slot;
                    if(Equiped.ContainsKey(targetSlot))
                    {
                        Item temp = Equiped[targetSlot];
                        Equiped[targetSlot] = Loot[i];
                        Loot[i] = temp;
                    }
                    else
                    {
                        Equiped.Add(targetSlot, Loot[i]);
                        Loot[i] = null;
                    }
                }
            }
        }

        public void UnEquip(EqipmentSlot s)
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
            }
            else
            {
                //handle full inventory needs implementing
            }
        }

    }
}
