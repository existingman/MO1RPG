using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1.Definitions.Actions;

namespace MO1.Definitions.Dialogues
{
    public enum ReplyLinkType { Conversation, Juncture, Quest, End }
    public class Reply 
    {
        public string Text;
        public ReplyLinkType LinkType = ReplyLinkType.Juncture;
        public int Ref;
        public MO1.Definitions.Actions.Action Action;
        public bool Enabled = true;


    }
}
