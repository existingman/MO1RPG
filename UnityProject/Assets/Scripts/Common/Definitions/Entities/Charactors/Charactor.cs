using System;
using System.Collections.Generic;
using MO1.Definitions.Charactors;

namespace MO1.Definitions
{
    public enum RaceType { human, goblin }
    public class Charactor: Entity
    {
        public Inventory Inventory = new Inventory();
        public RaceType Race = RaceType.human;
        public int HitPoints = 100;
        public int DialogueRef = -1;

        //helpers
        public Dialogue Dialogue 
        { 
            get 
            {
                if (DialogueRef != -1)
                {
                    return MO1.Content.Data.Dialogues[DialogueRef];
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
