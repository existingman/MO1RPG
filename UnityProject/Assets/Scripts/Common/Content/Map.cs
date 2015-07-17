using System;
using System.Collections.Generic;
using MO1.Definitions;
using System.IO;
using MO1.Tech;

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
           Tile = new Tile[XSize, YSize, ZSize];
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

        public static void Load(  )
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
                               Tile[x, y, z].Coord = new Tech.Coord(x, y, z);
                               Tile[x, y, z].TerrainRef = Convert.ToInt32(sr.ReadLine());
                               Tile[x, y, z].PropRef = Convert.ToInt32(sr.ReadLine());
                               //Tile[x, y, z].EntityRef = Convert.ToInt32(sr.ReadLine());

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
            else
           {
               New(50, 50, 5);
           }
        }

        public static void Save()
        {
            string MapFile = Path.Combine(Data.BaseDir, "map.txt");
            if (File.Exists(MapFile))
            {
                File.Delete(MapFile);
            }
            using (StreamWriter sw = new StreamWriter(MapFile))
            {
                sw.WriteLine(XSize);
                sw.WriteLine(YSize);
                sw.WriteLine(ZSize);
                for (int x = 0; x < XSize; x++)
                {
                    for (int y = 0; y < YSize; y++)
                    {
                        for (int z = 0; z < ZSize; z++)
                        {
                            sw.WriteLine(Tile[x, y, z].TerrainRef);
                            sw.WriteLine(Tile[x, y, z].PropRef);
                            //sw.WriteLine(Tile[x, y, z].EntityRef);

                            sw.WriteLine(Tile[x, y, z].LineOfSight);
                            sw.WriteLine(Tile[x, y, z].Discovered);
                            sw.WriteLine(Tile[x, y, z].Traversed);

                            if (Tile[x, y, z].PropRef != -1)
                            {
                                sw.WriteLine((int)(Tile[x, y, z].DoorState));
                                sw.WriteLine(Tile[x, y, z].KeyRef);
                                sw.WriteLine(Tile[x, y, z].ActionRef);
                            }
                        }
                    }
                }
            }
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
                    Tile[x, y, z].Entity = Data.Entities[Ref];
                    // -------------- insert code to clone entity !!!! ---- This code currebtly links every instance to Data array!! --------------------------------
                    break;
                case ImageType.items:

                    break;
            }
        }

       public static Tile Get (Coord c)
       {
            return Tile[c.X, c.Y, c.Z];
       }

    }
}
