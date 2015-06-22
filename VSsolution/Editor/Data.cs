using System;
using System.Collections.Generic;
using System.IO;
using MO1VSSolution.Definitions;
using System.Drawing;

namespace Editor
{
    public static class Data
    {
        //Image List declarations
        public enum ImageType { terrains, props, entities, items };
        public static Dictionary<ImageType, List<string>> ImageNames = new Dictionary<ImageType, List<string>>();
        public static Dictionary<ImageType, List<Image>> Images = new Dictionary<ImageType, List<Image>>();

        //Object list declarations
        public static List<Terrain> Terrains = new List<Terrain>();

        //Base Directory for saving and loading Data
        public static string BaseDir;


        public static void Initialise()
        {
            foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                ImageNames.Add(type, new List<string>());
                Images.Add(type, new List<Image>());
            }
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

        public static void GetImages()
        {
            Console.WriteLine("Getting Images...");
            string dir = Path.Combine(Data.BaseDir, "images");
            string folderPath;
            Dictionary<ImageType, List<string>> TempNames = new Dictionary<ImageType, List<string>>();

            foreach( ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                TempNames.Add(type, new List<string>());
                folderPath = Path.Combine(dir, type.ToString());
                foreach (string file in Directory.EnumerateFiles(folderPath, "*.png"))
                {
                    TempNames[type].Add(Path.GetFileNameWithoutExtension(file));
                    //Images[type].Add(Image.FromFile(file));
                }
            }
            foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                foreach (string target in TempNames[type])
                {
                    //Console.WriteLine(target);
                    bool found = false;
                    foreach(string check in ImageNames[type])
                    {
                        if(check == target)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) ImageNames[type].Add(target);
                }
            }

            string imagelist = Path.Combine(dir, "list.dat");
            using (BinaryWriter writer = new BinaryWriter(File.Open(imagelist, FileMode.Create)))
            {
                foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
                {
                    writer.Write(ImageNames[type].Count);
                    foreach (string image in ImageNames[type])
                    {
                        //Console.WriteLine(image);
                        writer.Write(image);
                    }
                }
            }
            LoadImages();
        }

        public static void LoadImages()
        {
            string dir = Path.Combine(Data.BaseDir, "images");

            string data = Path.Combine(dir, "list.dat");
            Images = new Dictionary<ImageType, List<Image>>();
            if (!File.Exists(data))
            {
                using (System.IO.FileStream fs = File.Open(data, FileMode.Open))
                {
                    foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
                    {
                        ImageNames.Add(type, new List<string>());
                        int num = fs.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("The image list dat file was not present!");
            }



            string folderPath;
            Images = new Dictionary<ImageType, List<Image>>();
            foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                Images.Add(type, new List<Image>());
                folderPath = Path.Combine(dir, type.ToString());
                foreach(string image in ImageNames[type])
                {
                    string file = image + ".PNG";
                    string fileName = Path.Combine(folderPath, file);
                    Images[type].Add(Image.FromFile(fileName)); 
                }
            }
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
