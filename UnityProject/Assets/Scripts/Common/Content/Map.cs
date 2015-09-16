using System;
using System.Collections.Generic;
using MO1.Definitions;
using System.IO;
using MO1.Tech;
using Newtonsoft.Json;
using MO1.Definitions.Entities;
using System.Collections;
using System.Linq;

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

        public static void Load()
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

            /*
           string tempJson;
           var entityFiles = Directory.GetFiles(Data.BaseDir, "entities.*");
           foreach (var entityFile in entityFiles)
           {
               //Expect something like "MyDir/items.M01.Definitions.Hat.txt"
               var typeName = entityFile;
               // remove the directory
               typeName = typeName.Replace('\\', '/').Split('/').Last();
               //remove the "entities." and ".txt"
               typeName = typeName.Replace("entities.", "").Replace(".txt", "");

               //Figure out type bases on type name
               var entityType = Type.GetType(typeName);
               var entityListType = typeof(List<>).MakeGenericType(entityType);

               tempJson = System.IO.File.ReadAllText(entityFile);
               IList parsedEntities = (IList)JsonConvert.DeserializeObject(tempJson, entityListType);

               foreach(Entity e in parsedEntities)
               {
                   //e.Initialise();
                   Map.Get(e.Coord).Entity = e;
               }
           }
             * */
            string filename = Path.Combine(Data.BaseDir, "entities.txt");
            if (File.Exists(filename))
            {
                string tempJson = System.IO.File.ReadAllText(filename);

#if UNITY_EDITOR
                // replace assembly names 
                    tempJson = tempJson.Replace("MO1Common", "Assembly-CSharp");
#endif
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                IList parsedEntities = (IList)JsonConvert.DeserializeObject<List<Entity>>(tempJson, settings);
                foreach (Entity e in parsedEntities)
                {
                    //e.Initialise();
                    Map.Get(e.Coord).Entity = e;
                }
            }
        }

        public static void Save()
        {
            List<Entity> Entities = new List<Entity>();
            //Dictionary<Entity, Coord> Coords = new Dictionary<Entity, Coord>();

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
                            if (Tile[x, y, z].Entity != null)
                            {
                                Entities.Add(Tile[x, y, z].Entity);
                                //Coords.Add(Tile[x, y, z].Entity, new Coord(x, y, z));
                            }

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

            /*
            string tempJson;
            string filename;
            var entitiesGroupedByType = Entities.GroupBy(i => i.GetType()).ToList();
            foreach (var entityTypeGroup in entitiesGroupedByType)
            {
                filename = Path.Combine(Data.BaseDir, "entities." + entityTypeGroup.Key + ".txt");
                tempJson = JsonConvert.SerializeObject(entityTypeGroup.ToArray());
                System.IO.File.WriteAllText(filename, tempJson);
            }
             * */
            string filename = Path.Combine(Data.BaseDir, "entities.txt");
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            string tempJson = JsonConvert.SerializeObject(Entities, settings);
            System.IO.File.WriteAllText(filename, tempJson);

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
                    Entity temp = (Entity)Data.Entities[Ref].Clone();
                    temp.Coord = new Coord(x, y, z);
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
