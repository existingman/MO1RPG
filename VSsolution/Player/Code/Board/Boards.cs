using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Content;
using MO1.Definitions;
using MO1.Definitions.Entities;
using MO1.Tech;
using MO1.Avatars;

namespace MO1.Boards
{
    public static class Board
    {
        const int xDim = 21;
        const int yDim = 21;
        const int zDim = 3;
        public static GameObject Root;
        public static TileDisplay[, ,] Tile;
        public static GameObject[] layer;
        public static List<Avatars.Avatar> Avatars = new List<Avatars.Avatar>();

        public static void Initialise()
        {
            Root = new GameObject("Root");
            layer = new GameObject[zDim];
            for (int z = 0; z < zDim; z++ )
            {
                layer[z] = new GameObject();
                layer[z].name = "layer" + z.ToString();
                layer[z].transform.parent = Root.transform;
                layer[z].transform.position = new Vector3(0, 0, -z);
                //layer[z].transform.localScale = new Vector3(0.5f + z * 0.2f, 0.5f + z * 0.2f, 1);
            }
            Tile = new TileDisplay [xDim, yDim, zDim];

            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {
                    for (int z = 0; z < zDim; z++)
                    {
                        float size = 0.5f + (z + 1) * (0.5f / zDim);
                        Tile[x, y, z] = new TileDisplay();
                        Tile[x, y, z].Root.name = "Tile:" + x.ToString() + "," + y.ToString() + "," + z.ToString(); 
                        Tile[x, y, z].Root.transform.parent = layer[z].transform;
                        Tile[x, y, z].Root.transform.localPosition = new Vector3((x - xDim / 2f) * size, (y - yDim / 2f) * size, 0);
                        Tile[x, y, z].Root.transform.localScale = new Vector3(size, size, 1);
                    }
                }
            }

            Refresh();

        }

        public static void Refresh()
        {
            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {
                    for (int z = 0; z < zDim; z++)
                    {
                        Coord target = new Coord(x + PlayerCTR.PlayerCharactor.Coord.X - xDim / 2, y + PlayerCTR.PlayerCharactor.Coord.Y - yDim / 2, z + PlayerCTR.PlayerCharactor.Coord.Z - zDim + 1);
                        if (z == zDim - 1)
                        {
                            target = target.StairCheck();
                        }
                        
                        if (Tech.Tech.isValid(target))
                        {
                            Tile[x, y, z].Display(Map.Tile[target.X, target.Y, target.Z]);
                            if (Map.Get(target).Entity != null)
                            {
                                bool found = false;
                                foreach (MO1.Avatars.Avatar a in Avatars)
                                {
                                    if (ReferenceEquals(a.Entity, Map.Get(target).Entity))
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found)
                                {
                                    Avatars.Add(new Avatars.Avatar(Map.Get(target).Entity));
                                }
                            }
                        }
                        else
                        {
                            Tile[x, y, z].BlankOut();
                        }
                    }
                }
            }
        }

        public static Avatars.Avatar GetAvatar(Entity entity)
        {
            foreach (MO1.Avatars.Avatar a in Avatars)
            {
                if (ReferenceEquals(a.Entity, entity))
                {
                    return a;
                }
            }
            return null;
        }


    }
}
