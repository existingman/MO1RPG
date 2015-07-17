using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Content;
using MO1.Definitions;
using MO1.Tech;

namespace MO1.Boards
{
    public static class Board
    {
        const int xDim = 21;
        const int yDim = 21;
        const int zDim = 1;
        public static GameObject Root;
        public static TileDisplay[, ,] Tile;
        public static GameObject[] layer;

        public static void Initialise()
        {
            Root = new GameObject("Root");
            layer = new GameObject[zDim];
            for (int z = 0; z < zDim; z++ )
            {
                layer[z] = new GameObject();
                layer[z].name = "layer" + z.ToString();
                layer[z].transform.parent = Root.transform;
                layer[z].transform.position = new Vector3(0, 0, z);
            }
            Tile = new TileDisplay [xDim, yDim, zDim];

            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {
                    for (int z = 0; z < zDim; z++)
                    {
                        Tile[x, y, z] = new TileDisplay();
                        Tile[x, y, z].Root.name = "Tile:" + x.ToString() + "," + y.ToString() + "," + z.ToString(); 
                        Tile[x, y, z].Root.transform.parent = layer[z].transform;
                        Tile[x, y, z].Root.transform.position = new Vector3(x - xDim/2f, y - yDim/2f, 0);
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
                        Coord target = new Coord(x + Player.PlayerCharactor.Coord.X - xDim / 2, y + Player.PlayerCharactor.Coord.Y - yDim / 2, z + Player.PlayerCharactor.Coord.Z - zDim / 2);
                        if (z == 0)
                        {
                            target = target.StairCheck();
                        }
                        
                        if (Tech.Tech.isValid(target))
                        {
                            Tile[x, y, z].Display(Map.Tile[target.X, target.Y, target.Z]);
                        }
                        else
                        {
                            Tile[x, y, z].BlankOut();
                        }
                    }
                }
            }
        }


    }
}
