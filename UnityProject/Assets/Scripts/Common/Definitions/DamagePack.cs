using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;

namespace MO1.Definitions
{
    public struct DamagePack
    {
        public DamageType Type;
        public float Force;
        public DamagePack(DamageType type, float force)
        {
            Type = type;
            Force = force;
        }
    }
}
