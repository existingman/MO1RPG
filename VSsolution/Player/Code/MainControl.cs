using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Boards;
using MO1.Content;
using MO1.Tech;

namespace MO1
{
    public class MainControl : MonoBehaviour
    {

        public void DoStuff()
        {
            
        }

        void Start()
        {
            Data.Initialise();
            MO1.Content.Images.Load();
            Data.Load();
            Map.Load();
            Player.Initialise();
            Board.Initialise();

            
        }

        int timer = 0;
        int count = 0;
        void Update()
        {
            timer++;
            if(timer > 30)
            {
                timer = 0;
                count++;
                //Debug.Log("30frames X " + count.ToString());
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
                Coord target = Player.PlayerCharactor.Coord.Plus(keyDirections[Event.current]);
                target = target.StairCheck();

                Player.WalkTo(Map.Get(target));
                Board.Refresh();
                 

            }
            
        }



    }
}
