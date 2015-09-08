using System;
using System.Collections.Generic;
using MO1.Definitions;

namespace MO1.Definitions.Entities
{
    public class Monster : Entity
    {
        public int ImageRef;

        //iClonable
        public override object Clone()
        {
            Charactor newPerson = (Charactor)this.MemberwiseClone();


            return newPerson;
        }

        public override void Initialise()
        {
            throw new NotImplementedException();
        }

    }


}
