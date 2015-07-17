using System;
using System.Collections.Generic;

namespace MO1.Definitions.Dialogues
{
    public class Juncture : INameable
    {
        public String Speach;
        public List<Reply> Replies = new List<Reply>();

        public string Name
        {
            get
            {
                return Speach;
            }
            set
            {

            }
        }
    }
}
