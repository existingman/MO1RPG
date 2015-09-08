using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MO1.Definitions;
using MO1.Definitions.Entities;
using MO1.Definitions.Charactors;
using MO1.Definitions.Dialogues;
using MO1.Tech;
using Newtonsoft.Json;
using System.Collections;
using MO1.Definitions.Entities.AIs;


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
        public static List<Item> Items = new List<Item>();
        public static List<Faction> Factions = new List<Faction>();


  
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

            /*
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            while (true)
            {
                BaseDir = Directory.GetParent(BaseDir).FullName;
                string test = Path.GetFileName(BaseDir);
                if (test.Contains("MO1RPG"))
                {
                    break;
                }
                if (BaseDir == null)
                {
                    break;
                }
            }
            BaseDir = Path.Combine(BaseDir, "Game");
               */
            BaseDir = "C:/Projects/MO1RPG/Game";
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

            var entitiesGroupedByType = Entities.GroupBy(i => i.GetType()).ToList();
            foreach (var entityTypeGroup in entitiesGroupedByType)
            {
                filename = Path.Combine(dataDir, "entities." + entityTypeGroup.Key + ".txt");
                tempJson = JsonConvert.SerializeObject(entityTypeGroup.ToArray());
                System.IO.File.WriteAllText(filename, tempJson);
            }

            filename = Path.Combine(dataDir, "dialogues.txt");
            tempJson = JsonConvert.SerializeObject(Dialogues.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);

            filename = Path.Combine(dataDir, "quests.txt");
            tempJson = JsonConvert.SerializeObject(Quests.ToArray());
            System.IO.File.WriteAllText(filename, tempJson);


            var itemsGroupedByType = Items.GroupBy(i => i.GetType()).ToList();
            foreach(var itemTypeGroup in itemsGroupedByType)
            {
                filename = Path.Combine(dataDir, "items." +itemTypeGroup.Key + ".txt");

                tempJson = JsonConvert.SerializeObject(itemTypeGroup.ToArray());
                System.IO.File.WriteAllText(filename, tempJson);
            }
            
        }

        public static void Load()
        {
            string filename;
            string tempJson;
            string dataDir = Path.Combine(BaseDir, "data");

            filename = Path.Combine(dataDir, "terrains.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Terrains = (List<Terrain>)JsonConvert.DeserializeObject(tempJson, typeof(List<Terrain>));
            if (Terrains.Count == 0) Terrains.Add( new Terrain());

            filename = Path.Combine(dataDir, "props.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Props = (List<Prop>)JsonConvert.DeserializeObject(tempJson, typeof(List<Prop>));
            if (Props.Count == 0) Props.Add(new Prop());

            var entityFiles = Directory.GetFiles(dataDir, "entities.*");
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
                foreach (var entity in parsedEntities)
                {
                    Entities.Add((Entity)entity);
                }
            }


            filename = Path.Combine(dataDir, "dialogues.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Dialogues = (List<Dialogue>)JsonConvert.DeserializeObject(tempJson, typeof(List<Dialogue>));
            if (Dialogues.Count == 0) Dialogues.Add(new Dialogue());


            filename = Path.Combine(dataDir, "quests.txt");
            tempJson = System.IO.File.ReadAllText(filename);
            Quests = (List<Quest>)JsonConvert.DeserializeObject(tempJson, typeof(List<Quest>));
            if (Quests.Count == 0) Quests.Add(new Quest());


            var itemFiles = Directory.GetFiles(dataDir, "items.*");
            foreach(var itemFile in itemFiles)
            {
                //Expect something like "MyDir/items.M01.Definitions.Hat.txt"
                var typeName = itemFile;
                // remove the directory
                typeName = typeName.Replace('\\', '/').Split('/').Last();
                //remove the "items." and ".txt"
                typeName = typeName.Replace("items.", "").Replace(".txt", "");

                //Figure out type bases on type name
                var itemType = Type.GetType(typeName);
                var itemListType = typeof(List<>).MakeGenericType(itemType);

                tempJson = System.IO.File.ReadAllText(itemFile);
                IList parsedItems = (IList)JsonConvert.DeserializeObject(tempJson, itemListType);
                foreach(var item in parsedItems)
                {
                    Items.Add((Item)item);
                }
            }

        }


    }
}
