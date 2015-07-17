using System;
using System.Collections.Generic;
using MO1.Definitions.Dialogues;
using MO1.Content;

namespace MO1.Definitions.Actions
{
    class EnableReply : Action
    {
        public int DialogueRef = -1;
        public int ConversationRef = -1;
        public int JunctureRef = -1;
        public int ReplyRef = -1;
        public bool Make = true;

        public EnableReply(int replyRef, int junctureRef, int conversationRef, int dialogueRef, bool m)
        {
            ReplyRef = replyRef;
            JunctureRef = junctureRef;
            ConversationRef = conversationRef;
            DialogueRef = dialogueRef;
            Make = m;
        }

        public override void Do()
        {
            Data.Dialogues[DialogueRef].Conversations[ConversationRef].Junctures[JunctureRef].Replies[ReplyRef].Enabled = Make;
        }
    }
}
