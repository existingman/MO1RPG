using System;
using System.Collections.Generic;
using System.Linq;
using MO1.Definitions;

namespace MO1.Definitions.Dialogues
{
    public class Conversation: INameable
    {
        private string _name = "Unamed Conversation";
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<Juncture> Junctures = new List<Juncture>();


    }
}
