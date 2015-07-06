using System;
using System.Collections.Generic;
using MO1.Definitions;
using System.IO;

namespace MO1.Content
{
    public static class Map
    {
        public static int XSize;
        public static int YSize;
        public static int ZSize;

        public static Tile[, ,] Tile;

        public static void New(int _x, int _y, int _z)
        {
           XSize = _x;
           YSize = _y;
           ZSize = _z;
           for (int x = 0; x < XSize; x++)
           {
               for (int y = 0; y < YSize; y++)
               {
                   for (int z = 0; z < ZSize; z++)
                   {
                       Tile[x, y, z] = new Tile();
                   }
               }
           }
        }

        public static void Load( string filepath )
        {
           string MapFile = Path.Combine(Data.BaseDir, "map.txt");
           if (File.Exists(MapFile))
           {
               using (StreamReader sr = new StreamReader(MapFile))
               {
                   XSize = Convert.ToInt32(sr.ReadLine());
                   YSize = Convert.ToInt32(sr.ReadLine());
                   ZSize = Convert.ToInt32(sr.ReadLine());
                   New(XSize, YSize, ZSize);
                   for (int x = 0; x < XSize; x++)
                   {
                       for (int y = 0; y < YSize; y++)
                       {
                           for (int z = 0; z < ZSize; z++)
                           {
                               Tile[x, y, z].TerrainRef = Convert.ToInt32(sr.ReadLine());
                               Tile[x, y, z].PropRef = Convert.ToInt32(sr.ReadLine());
                               Tile[x, y, z].EntityRef = Convert.ToInt32(sr.ReadLine());

                               Tile[x, y, z].LineOfSight = Convert.ToBoolean(sr.ReadLine());
                               Tile[x, y, z].Discovered = Convert.ToBoolean(sr.ReadLine());
                               Tile[x, y, z].Traversed = Convert.ToBoolean(sr.ReadLine());

                               if (Tile[x, y, z].PropRef != -1)
                               {
                                   Tile[x, y, z].DoorState = (DoorState)Convert.ToInt32(sr.ReadLine());
                                   Tile[x, y, z].KeyRef = Convert.ToInt32(sr.ReadLine());
                                   Tile[x, y, z].ActionRef = Convert.ToInt32(sr.ReadLine());
                               }
                           }
                       }
                   }
               }
           }
        }

        public static void Save(string filepath)
        {

        }

        public static void Apply(ImageType type, int Ref, int x, int y, int z)
        {
            switch (type)
            {
                case ImageType.terrains:
                    Tile[x, y, z].TerrainRef = Ref;
                    break;

                case ImageType.props:
                    Tile[x, y, z].PropRef = Ref;
                    break;

                case ImageType.entities:
                    Tile[x, y, z].EntityRef = Ref;
                    break;
                case ImageType.items:

                    break;
            }
        }

    }
}
