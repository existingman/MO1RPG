using System;
using System.Collections.Generic;
using UnityEngine;

namespace MO1.Content
{
    public static class Images
    {
        public static int TileResolution = 50;

        public static Sprite Black;
        public static Sprite Gray;


        public static Sprite[] Terrains;
        public static Sprite[] Props;
        public static Sprite[] Items;
        public static Sprite[] Entities;


        public static void Load()
        {
            Black = Sprite.Create(Resources.Load("images/black") as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution);
            Black = Sprite.Create(Resources.Load("images/gray") as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution);

            string root = "images/terrain/";
            
        }
    }
}
