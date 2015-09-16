using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Definitions;
using MO1.Boards;
using MO1.Content;
using MO1.Tech;
using MO1.GUI;

namespace MO1
{
    public class MainControl : MonoBehaviour
    {
        public static event Bang Tick;

        void Start()
        {
            //The order off these initialisations can be important.
            //Images cannot load untill Base stats initialises because it gets the material set names
            //Board requires images, map and player because it displays the content.
            Data.Initialise();
            BaseStats.Init();
            MO1.Content.Images.Load();
            Data.Load();
            Map.Load();
            PlayerFile.Load();
            PlayerCTR.Initialise();
            Board.Initialise();
            AbilityPanel.Initialise();
            DialogueGUI.Initialise();
            
        }

        int timer = 0;
        int count = 0;
        void Update()
        {
            if(Tick != null) Tick();
            timer++;
            if(timer > 30)
            {
                timer = 0;
                count++;
            }
        }

        public static Dictionary<Event, Coord> keyDirections = new Dictionary<Event, Coord>()
        {
            {Event.KeyboardEvent("w"), new Coord(0,1,0)},
            {Event.KeyboardEvent("s"), new Coord(0,-1,0)},
            {Event.KeyboardEvent("a"), new Coord(-1,0,0)},
            {Event.KeyboardEvent("d"), new Coord(1,0,0)},
            {Event.KeyboardEvent("r"), new Coord(0,0,1)},
            {Event.KeyboardEvent("f"), new Coord(0,0,-1)},
        };

        void OnGUI()
        {
            if (keyDirections.ContainsKey(Event.current))
            {
                Coord target = PlayerCTR.PlayerCharactor.Coord.Plus(keyDirections[Event.current]);
                target = target.StairCheck();

                PlayerCTR.WalkTo(Map.Get(target));
                Board.Refresh();
            }
            
        }


        public static MO1.Definitions.Combat.Attack Attack;
        public static List<Entity> ValidTargets = new List<Entity>();
        public static bool Targeting = false;
        public static void SelectAttack(MO1.Definitions.Combat.Attack attack)
        {
            Attack = attack;
            Targeting = true;
            if(Attack.AttackType == Definitions.Combat.AttackType.Melee)
            {
                foreach(Coord c in PlayerCTR.PlayerCharactor.Coord.Surrounding(1))
                {
                    if(Map.Get(c).Entity != null)
                    {
                        ValidTargets.Add(Map.Get(c).Entity);
                    }
                }
            }
        }

        public static void SelectTarget(MO1.Definitions.Entities.Bodies.Target target)
        {
            Attack.Do(target);
            Targeting = false;
        }



    }
}
