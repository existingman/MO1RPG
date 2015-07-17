using System;
using System.Collections.Generic;
using MO1.Definitions.Dialogues;

namespace MO1.Definitions
{
    public enum QuestState { Invalid, Ready, Active, Failed, Completed, Closed }
    public class Quest
    {
        public String Name = "Unnamed Quest";
        public QuestState State = QuestState.Invalid;
        public Charactor Giver;
        public Charactor Reciver;
        public Item Reward;
        public Action Result;
        public Conversation IntialConversation;
        public Conversation ClosingConversation;
    }
}
