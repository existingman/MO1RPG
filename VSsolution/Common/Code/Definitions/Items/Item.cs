using System;
using System.Collections.Generic;
using MO1.Definitions.Items;


namespace MO1.Definitions
{
    public abstract class Item: INameable, ICloneable
    {
        public int ImageRef = 0;
        public int stacks = 1;

        //Inameable stuff
        public virtual string Name{ get; set;}

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
