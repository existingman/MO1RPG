using System;
using System.Collections.Generic;
using System.IO;
using MO1.Definitions.Entities;
using MO1.Definitions;
using MO1.Tech;
using MO1.Content;

namespace MO1
{
    public static class PlayerCTR
    {

        public static Charactor PlayerCharactor;

        public static void Initialise()
        {
            PlayerCharactor = (Charactor)MO1.Content.Map.Get(Content.PlayerFile.GetCoord()).Entity;
            AssertVision(true);
            PlayerCharactor.Inventory.SlotUpdate += EquipmentChanged;
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
                        PlayerCTR.PlayerCharactor.UpdateVisionField();
                        PlayerCTR.AssertVision(true);
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
                GUI.DialogueGUI.initiate(((Charactor)t.Entity).GetDialogue());

            }
        }

        public static void move(Tech.Coord c)
        {
            PlayerCTR.AssertVision(false);
            PlayerCTR.PlayerCharactor.Coord = c;            
            PlayerCTR.AssertVision(true);
        }


    }
}
