using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;

namespace MO1.Definitions
{
    public interface IDamageable
    {
        

        DamagePack TakeDamage(DamagePack Pack);
    }
}
