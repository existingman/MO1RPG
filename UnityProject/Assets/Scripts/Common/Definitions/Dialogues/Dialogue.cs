using System;
using System.Collections.Generic;
using MO1.Definitions.Dialogues;

namespace MO1.Definitions.Dialogues
{
    public class Dialogue : INameable
    {
        private string _name = "Unamed Dialogue";
        public String Name
        {
            get { return _name;  }
            set { _name = value; }
        }

        public int EntryPoint = 0;
        public List<Conversation> Conversations = new List<Conversation>();


    }
}
