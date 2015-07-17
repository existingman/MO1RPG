using System;
using System.Collections.Generic;

namespace MO1.Definitions.Actions
{
    public enum ActionType { enableReply, alterLock, chain, openDialogue, alterDialogue  }

    public abstract class Action
    {
        public virtual void Do()
        { }


        public static Dictionary<ActionType, Type> ActionTypes = new Dictionary<ActionType, Type>()
        {
            {ActionType.enableReply, typeof(EnableReply) },
        };

    }
}
