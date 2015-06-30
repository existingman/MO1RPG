using System;
using System.Collections.Generic;
using System.IO;
using MO1VSSolution.Definitions;

namespace MO1VSSolution.Editor
{
    public static class Data
    {
        //Object list declarations
        public static List<Terrain> Terrains = new List<Terrain>();

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

        }

        public static void Load()
        {

        }


    }
}
