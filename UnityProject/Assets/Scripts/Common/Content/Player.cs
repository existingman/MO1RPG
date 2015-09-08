using System;
using System.Collections.Generic;
using System.IO;
using MO1.Definitions.Entities;
using MO1.Definitions;
using MO1.Tech;

namespace MO1.Content
{
    public static class Player
    {

        public static Charactor PlayerCharactor;

        public static void Initialise()
        {
            PlayerCharactor = new Charactor();
            PlayerCharactor.Coord = new Tech.Coord(20, 20, 2);
            AssertVision(true);
            PlayerCharactor.Inventory.SlotUpdate += EquipmentChanged;
        }

        public static void Load()
        {
            //PlayerCharactor.Coord = 
        }

        public static void Save()
        {
            
        }

        public static void EquipmentChanged( MO1.Definitions.Items.EquipmentSlot E)
        {

        }



        public static void AssertVision(bool seeing)
        {
            foreach (Coord c in PlayerCharactor.VisionField())
            {
                Map.Get(c).LineOfSight = seeing;
                Map.Get(c).Discovered = true;
            }
        }

        public static void WalkTo(Tile t)
        {
            if (t.Entity == null)
            {
                switch (t.DoorState)
                {
                    case Definitions.DoorState.open:
                        move(t.Coord);
                        return;

                    case Definitions.DoorState.closed:
                        t.DoorState = Definitions.DoorState.open;
                        UnityEngine.Debug.Log("Opening!");
                        Player.PlayerCharactor.UpdateVisionField();
                        Player.AssertVision(true);
                        return;

                    case Definitions.DoorState.lockedClosed:
                        UnityEngine.Debug.Log("Locked Shut!");
                        return;
                }
                switch (t.PropType)
                {
                    case Definitions.PropType.obstruction:
                        UnityEngine.Debug.Log("Theres a thing in the way...");
                        return;
                }
                switch (t.TerrainType)
                {
                    case Definitions.TerrainType.Floor:
                        move(t.Coord);
                        return;
                    case Definitions.TerrainType.Lava:
                        move(t.Coord);
                        UnityEngine.Debug.Log("this should really hurt!");
                        return;
                    case Definitions.TerrainType.None:

                        return;

                    case Definitions.TerrainType.secret:
                        move(t.Coord);
                        return;

                    case Definitions.TerrainType.Wall:
                        UnityEngine.Debug.Log("you've got your balls to the wall man!");
                        return;

                    case Definitions.TerrainType.Water:

                        return;

                    case Definitions.TerrainType.stairs:
                        move(t.Coord);
                        return;
                }
            }
            else
            {
                //entity not null

            }
        }

        public static void move(Tech.Coord c)
        {
            Player.AssertVision(false);
            Player.PlayerCharactor.Coord = c;            
            Player.AssertVision(true);
        }


    }
}
