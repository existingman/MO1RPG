using System;
using System.Collections.Generic;
using System.IO;
using MO1.Definitions;
using MO1.Definitions.Charactors;
using MO1.Tech;
using Newtonsoft.Json;



namespace MO1.Content
{
    public static class Data
    {
        //Object list declarations
        public static List<Terrain> Terrains = new List<Terrain>();
        public static List<Prop> Props = new List<Prop>();
        public static List<Entity> Entities = new List<Entity>();
        public static List<Dialogue> Dialogues = new List<Dialogue>();
        public static List<Quest> Quests = new List<Quest>();


  
        //Base Directory for saving and loading Data
        public static string BaseDir;


        public static void Initialise()
        {
            /*
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Directory.GetParent(BaseDir).FullName;
            BaseDir = Path.Combine(BaseDir, "UnityProject");
            BaseDir = Path.Combine(BaseDir, "Assets");
            BaseDir = Path.Combine(BaseDir, "Resources");
            */
            BaseDir = "C:/Projects/MO1Git/MO1RPG/Game";
        }

       


        public static void New()
        {
            string dir = Path.Combine(Data.BaseDir, "images");
            Directory.CreateDirectory(dir);
            Directory.CreateDirectory(Path.Combine(dir, "terrains"));
            Directory.CreateDirectory(Path.Combine(dir, "props"));
            Directory.CreateDirectory(Path.Combine(dir, "entities"));

        }

        public static void Save()
        {
            string filename;
            string tempJson;
            string dataDir = Path.Combine(BaseDir, "data");

            filename = Path.Combine(dataDir, "terrains.txt");
            tempJson = JsonConvert.SerializeObject(Terrains.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);

            filename = Path.Combine(dataDir, "props.txt");
            tempJson = JsonConvert.SerializeObject(Props.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);

            filename = Path.Combine(dataDir, "entities.txt");
            tempJson = JsonConvert.SerializeObject(Entities.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);

            filename = Path.Combine(dataDir, "dialogues.txt");
            tempJson = JsonConvert.SerializeObject(Dialogues.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);

            filename = Path.Combine(dataDir, "quests.txt");
            tempJson = JsonConvert.SerializeObject(Quests.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);


            /*
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
                 * */
        }

        public static void Load()
        {
            string filename;
            string tempJson;
            string dataDir = Path.Combine(BaseDir, "data");

            Terrains = new List<Terrain>();
            filename = Path.Combine(dataDir, "terrains.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Terrains = (List<Terrain>)JsonConvert.DeserializeObject(tempJson, typeof(List<Terrain>));
            if (Terrains.Count == 0) Terrains.Add( new Terrain());

            Props = new List<Prop>();
            filename = Path.Combine(dataDir, "props.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Props = (List<Prop>)JsonConvert.DeserializeObject(tempJson, typeof(List<Prop>));
            if (Props.Count == 0) Props.Add(new Prop());

            Entities = new List<Entity>();
            filename = Path.Combine(dataDir, "entities.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Entities = (List<Entity>)JsonConvert.DeserializeObject(tempJson, typeof(List<Entity>));
            if (Entities.Count == 0) Entities.Add(new Entity());


            Dialogues = new List<Dialogue>();
            filename = Path.Combine(dataDir, "dialogues.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Dialogues = (List<Dialogue>)JsonConvert.DeserializeObject(tempJson, typeof(List<Dialogue>));
            if (Dialogues.Count == 0) Dialogues.Add(new Dialogue());


            Quests = new List<Quest>();
            filename = Path.Combine(dataDir, "quests.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Quests = (List<Quest>)JsonConvert.DeserializeObject(tempJson, typeof(List<Quest>));
            if (Quests.Count == 0) Quests.Add(new Quest());



            /*
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
                Terrain terain = new Terrain();
                terain.imageRef1 = 0;
                Terrains.Add(terain);

                
                Prop prop = new Prop();
                prop.imageRef1 = 0;
                Props.Add(prop);

                Entity entity = new Entity();
                entity.imageRef1 = 0;
                Entities.Add(entity);
                
            }
             * */
        }


    }
}
