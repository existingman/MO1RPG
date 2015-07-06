using System;
using System.Collections.Generic;
using System.IO;
using MO1.Definitions;

namespace MO1.Content
{
    public static class Data
    {
        //Object list declarations
        public static List<Terrain> Terrains = new List<Terrain>();
        public static List<Prop> Props = new List<Prop>();
        public static List<Entity> Entities = new List<Entity>();



        //Base Directory for saving and loading Data
        public static string BaseDir;


        public static void Initialise()
        {
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Path.Combine(BaseDir, "UnityProject");
            BaseDir = Path.Combine(BaseDir, "Assets");
            BaseDir = Path.Combine(BaseDir, "Resources");
        }

       


        public static void New()
        {
            string dir = Path.Combine(Data.BaseDir, "images");
            Directory.CreateDirectory(dir);
            Directory.CreateDirectory(Path.Combine(dir, "terrains"));
            Directory.CreateDirectory(Path.Combine(dir, "props"));
            Directory.CreateDirectory(Path.Combine(dir, "entities"));

            string fileName = "gameData";
            string pathString = Path.Combine(Data.BaseDir, fileName);
            if (!File.Exists(pathString))
            {
                using (System.IO.FileStream fs = File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }

        public static void Save()
        {
            string contentlist = Path.Combine(BaseDir, "content.txt");
            if (File.Exists(contentlist))
            {
                File.Delete(contentlist);
            }
            using (StreamWriter sw = new StreamWriter(contentlist))
            {
                //Run through each of the lists of game elements and save all of their references to disk
                //Terrains
                sw.WriteLine(Terrains.Count);
                foreach (Terrain t in Terrains)
                {
                    sw.WriteLine(t.Name);
                    sw.WriteLine((int)(t.TerrainType));
                    sw.WriteLine(t.imageRef1);
                    sw.WriteLine(t.imageRef2);
                }

                //props
                sw.WriteLine(Props.Count);
                foreach (Prop p in Props)
                {
                    sw.WriteLine(p.Name);
                    sw.WriteLine((int)(p.proptype));
                    sw.WriteLine(p.imageRef1);
                    sw.WriteLine(p.imageRef2);
                    sw.WriteLine(p.DescriptionRef);
                }

                //entities
                sw.WriteLine(Entities.Count);
                foreach (Entity e in Entities)
                {
                    sw.WriteLine(e.Name);
                    sw.WriteLine(e.imageRef1);
                }

            }
        }

        public static void Load()
        {
            string contentlist = Path.Combine(BaseDir, "content.txt");
            if (File.Exists(contentlist))
            {
                using (StreamReader sr = new StreamReader(contentlist))
                {
                    //runs through each of the lists of game elements and fills it from the disk
                    //terrains
                    int count = Convert.ToInt32(sr.ReadLine());
                    for (int c = 0; c < count; c++ )
                    {
                        Terrain t = new Terrain();
                        t.Name = sr.ReadLine();
                        t.TerrainType = (TerrainType)(Convert.ToInt32(sr.ReadLine()));
                        t.imageRef1 = Convert.ToInt32(sr.ReadLine());
                        t.imageRef2 = Convert.ToInt32(sr.ReadLine());
                        Terrains.Add(t);
                    }

                    //props
                    count = Convert.ToInt32(sr.ReadLine());
                    for (int c = 0; c < count; c++)
                    {
                        Prop p = new Prop();
                        p.Name = sr.ReadLine();
                        p.proptype = (PropType)(Convert.ToInt32(sr.ReadLine()));
                        p.imageRef1 = Convert.ToInt32(sr.ReadLine());
                        p.imageRef2 = Convert.ToInt32(sr.ReadLine());
                        p.DescriptionRef = Convert.ToInt32(sr.ReadLine());
                        Props.Add(p);
                    }
                    //entities
                    count = Convert.ToInt32(sr.ReadLine());
                    for (int c = 0; c < count; c++)
                    {
                        Entity e = new Entity();
                        e.Name = sr.ReadLine();
                        e.imageRef1 = Convert.ToInt32(sr.ReadLine());
                        Entities.Add(e);
                    }
                }
            }
            else
            {
                Console.WriteLine("content file not found");
            }
        }


    }
}
