using System;
using System.Collections.Generic;

namespace MO1.Definitions.Items
{
    public enum AmmoType { Arrow, bolt, stone, knife, surrican }
    class Ammo: Equipment
    {
        public AmmoType AmmoType;
    }
}
