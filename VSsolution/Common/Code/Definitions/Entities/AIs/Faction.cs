using System;
using System.Collections.Generic;
using System.Linq;

namespace MO1.Definitions.Entities.AIs
{
    public class Faction
    {
        public string Name;
        public List<Entity> Members = new List<Entity>();
        public List<Faction> AllyFactions = new List<Faction>();
        public List<Faction> EnemyFactions = new List<Faction>();

        public Faction(string name)
        {
            Name = name;
        }



    }
}
