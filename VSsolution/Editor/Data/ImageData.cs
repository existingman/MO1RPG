using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace MO1VSSolution.Editor
{
    public enum ImageType { terrains, props, entities, items };

    public static class ImageData
    {
        public static Dictionary<ImageType, List<string>> ImageNames = new Dictionary<ImageType, List<string>>();
        public static Dictionary<ImageType, List<Image>> Images = new Dictionary<ImageType, List<Image>>();

        public static void Initialise()
        {
            foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                ImageNames.Add(type, new List<string>());
                Images.Add(type, new List<Image>());
            }
        }

        public static void Get()
        {
            Console.WriteLine("Getting Images...");
            string dir = Path.Combine(Data.BaseDir, "images");
            string folderPath;

            foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                folderPath = Path.Combine(dir, type.ToString());
                foreach (string file in Directory.EnumerateFiles(folderPath, "*.png"))
                {
                    string temp = Path.GetFileNameWithoutExtension(file);
                    bool found = false;
                    foreach (string check in ImageNames[type])
                    {
                        if (check == temp)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        ImageNames[type].Add(temp);
                        Images[type].Add(Image.FromFile(file));
                    }
                }
            }

            string imagelist = Path.Combine(dir, "list.txt");
            if (File.Exists(imagelist))
            {
                File.Delete(imagelist);
            }
            using (StreamWriter sw = new StreamWriter(imagelist))
            {
                foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
                {
                    sw.WriteLine(ImageNames[type].Count);
                    foreach (string image in ImageNames[type])
                    {
                        sw.WriteLine(image);
                    }
                }
            }
        }

        public static void LoadImages()
        {
            string dir = Path.Combine(Data.BaseDir, "images");

            string data = Path.Combine(dir, "list.txt");
            Images = new Dictionary<ImageType, List<Image>>();
            ImageNames = new Dictionary<ImageType, List<String>>();

            if (File.Exists(data))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
                    {
                        Images.Add(type, new List<Image>());
                        ImageNames.Add(type, new List<String>());
                        string directory = Path.Combine(dir, type.ToString());
                        int num = Convert.ToInt32(sr.ReadLine());
                        for (int line = 0; line < num; line++)
                        {
                            string name = sr.ReadLine();
                            ImageNames[type].Add(name);
                            string filename = Path.Combine(directory, name);
                            filename = filename + ".PNG";
                            Images[type].Add(Image.FromFile(filename));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The image list dat file was not present!");
            }
        }
    }
}
