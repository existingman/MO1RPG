using System;
using System.Collections.Generic;
using MO1.Definitions.Charactors;
using MO1.Definitions.Combat;
using MO1.Definitions.Items;
using MO1.Definitions.Dialogues;

namespace MO1.Definitions.Entities
{
    public enum RaceType { human, goblin }
    public class Charactor: Entity
    {
        public Inventory Inventory = new Inventory();
        public CharactorStats Stats = new CharactorStats();
        public RaceType Race = RaceType.human;
        public int HitPoints = 100;
        public int DialogueRef { get; set; }

        public Charactor()
        {

        }

        public override void Initialise()
        {
            MO1.Content.Map.Get(Coord).Entity = this;
            Body = new Bodies.Humanoid(this);
            Targeter = new Bodies.CharacterTargeter(this);
            AI = new AI(this);
        }

        //helpers
        public Dialogue GetDialogue() 
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

        //iClonable
        public override object Clone()
        {
            Charactor newPerson = new Charactor();
            newPerson.Inventory = (Inventory)Inventory.Clone();
            newPerson.Race = Race;
            newPerson.DialogueRef = DialogueRef;
            newPerson.Name = Name;
            return newPerson;
        }


        //stuff
        public List<Attack> Attacks()
        {
            List<Attack> temp = new List<Attack>();
            foreach(EquipmentSlot e in Inventory.Equiped.Keys)
            {
                temp.AddRange(Inventory.Equiped[e].Attacks);
            }
            return temp;
        }


    }
}
