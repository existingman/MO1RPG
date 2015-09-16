using System;
using System.Collections.Generic;

namespace MO1.Definitions.Items
{
    public enum CurrencyType { copper, silver, gold, iron, tin, food, gems}
    public class Currency : Item
    {
        public float Amount { get; set; }
        public CurrencyType CurrencyType { get; set; }

        protected override string generateName()
        {
            return Amount.ToString() + " " + CurrencyType.ToString();
        }

    }
}
