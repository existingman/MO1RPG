using System;
using System.Collections.Generic;
using MO1.Definitions.Items;


namespace MO1.Definitions
{
    public abstract class Item: ICloneable
    {
        public int ImageRef = 0;
        public int stacks = 1;

        protected string _name;
        public string Name
        {
            get
            {
                if(_name == "")
                {
                    return generateName();
                }
                else
                {
                    return _name;
                }
            }
            set
            {
                _name = value;
            }
        }

        protected virtual string generateName()
        {
            return "Unamed";
        }

        //Icloneable
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
