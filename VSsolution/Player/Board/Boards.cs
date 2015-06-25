using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Content;
using MO1.Definitions.Tiles;

namespace MO1.Boards
{
    public static class Board
    {
        const int xDim = 11;
        const int yDim = 11;
        const int zDim = 5;
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
                        Tile[x, y, z].Display(Map.Tile[x + Player.Coord.X - xDim / 2, y + Player.Coord.Y - yDim / 2, z + Player.Coord.Z - zDim / 2]);
                    }
                }
            }
        }


    }
}
