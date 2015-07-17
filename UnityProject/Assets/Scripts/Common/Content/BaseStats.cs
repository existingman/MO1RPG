using System;
using System.Collections.Generic;

namespace MO1.Content
{
    static class BaseStats
    {
        public struct MatStats
        {
            public float[] Resistances;
            public float[] DamageModifier;
            public MatStats(float slashingModifier, float piercingModifier, float bluntModifier, float slashingResistance, float piercingResistance, float bluntResistance)
            {
                Resistances = new float[3];
                DamageModifier = new float[3];
            }
        }
       // public static Dictionary<>
    }
}
