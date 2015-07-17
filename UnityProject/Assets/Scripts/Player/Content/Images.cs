using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Definitions;
using System.IO;


namespace MO1.Content
{
    public static class Images
    {
        public static int TileResolution = 50;

        public static Sprite Black;
        public static Sprite Gray;
        public static Sprite Blue;

        public static Dictionary<ImageType, Sprite[]> Image;

        public static void Load()
        {
            string dir = Path.Combine(Data.BaseDir, "images");
            Black = Sprite.Create(Resources.Load("images/black") as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution);
            Gray = Sprite.Create(Resources.Load("images/gray") as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution);
            Blue = Sprite.Create(Resources.Load("images/blue") as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution);

            Image = new Dictionary<ImageType, Sprite[]>();
            string data = Path.Combine(dir, "list.txt");
            using (StreamReader sr = new StreamReader(data))
            {
                foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
                {
                    string root = "images/" + type.ToString() + "/";
                    int num = Convert.ToInt32(sr.ReadLine());
                    Sprite[] temp = new Sprite[num];
                    for(int c = 0; c < num; c++)
                    {
                        string filename = sr.ReadLine();
                        temp[c] = Sprite.Create(Resources.Load(root + filename) as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution);
                    }
                    Image.Add(type, temp);
                }
            }

            

            
        }
    }
}
