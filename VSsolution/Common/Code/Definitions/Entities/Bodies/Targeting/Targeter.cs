using System;
using System.Collections.Generic;

namespace MO1.Definitions.Entities.Bodies
{
    public abstract class Targeter
    {
        public abstract List<Target> GetTargets();
    }
}
