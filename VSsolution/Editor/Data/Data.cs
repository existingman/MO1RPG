﻿using System;
using System.Collections.Generic;
using System.IO;
using MO1.Definitions;

namespace MO1.Editor
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
                sw.WriteLine(Terrains.Count);
                foreach (Terrain t in Terrains)
                {
                    sw.WriteLine(t.name);
                    sw.WriteLine((int)(t.Type));
                    sw.WriteLine(t.Image);
                }
            }
        }

        public static void Load()
        {
            ImageData.LoadImages();

            string contentlist = Path.Combine(BaseDir, "content.txt");
            if (File.Exists(contentlist))
            {
                using (StreamReader sr = new StreamReader(contentlist))
                {
                    int count = Convert.ToInt32(sr.ReadLine());
                    for (int c = 0; c < count; c++ )
                    {
                        Terrain t = new Terrain();
                        t.name = sr.ReadLine();
                        t.Type = (TerrainType)(Convert.ToInt32(sr.ReadLine()));
                        t.Image = Convert.ToInt32(sr.ReadLine());
                        Terrains.Add(t);
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