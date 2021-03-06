﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MO1.Definitions.Items
{
    public class Armour: Equipment, IDamageable
    {

        public virtual DamagePack TakeDamage(DamagePack Pack)
        {
            return Pack;
        }

        public override List<Combat.Attack> Attacks
        {
            get { return new List<Combat.Attack>(); }
        }

        protected override string generateName()
        {
 
            string slotText = Slot.ToString();
            string temp = this.MatName + " ";
            char first = slotText[0];
            string poop = "L";
            char L = poop[0];
            poop = "R";
            char R = poop[0];
            if (first.Equals(L))
            {
                temp = temp + "Left ";
                for(int c = 1; c < slotText.Count<char>(); c++)
                {
                    temp = temp + slotText[c].ToString();
                }
            }
            else
            {
                if (first.Equals(R))
                {
                    temp = temp + "Right ";
                    for (int c = 1; c < slotText.Count<char>(); c++)
                    {
                        temp = temp + slotText[c].ToString();
                    }
                }
                else
                {
                    temp = temp + slotText;
                }
            }
            return temp;
        }
    }
}
