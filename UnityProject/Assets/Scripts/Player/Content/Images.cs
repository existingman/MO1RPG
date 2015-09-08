using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Definitions;
using System.IO;
using MO1.Definitions.Items;
using MO1.Definitions.Combat;

namespace MO1.Content
{
    public static class Images
    {
        public static int TileResolution = 50;

        public static Sprite Black;
        public static Sprite Gray;
        public static Sprite Blue;

        public static Dictionary<ImageType, Sprite[]> Image;

        public static Dictionary<int, MatContent> EquipmentSprite;

        public static Dictionary<AttackName, Sprite> AttackSprite;


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

            List<EquipmentSlot> exceptions = new List<EquipmentSlot>()
            {
                EquipmentSlot.Weapon,
                EquipmentSlot.Shield
            };
            EquipmentSprite = new Dictionary<int,MatContent>();
            foreach(string s in BaseStats.MatBaseIndicies.Keys)
            {
                //EquipmentSprite.Add(BaseStats.MatBaseIndicies[s], new MatContent());
                MatContent temp = new MatContent();
                foreach (EquipmentSlot e in Enum.GetValues(typeof(EquipmentSlot)))
                {
                    if (!exceptions.Contains(e))
                    {
                        string filename = "images/equipment/" + s + "/" + e.ToString();
                        temp.Equ.Add(e, Sprite.Create(Resources.Load(filename) as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution));
                    }
                }
                foreach (WeaponType w in Enum.GetValues(typeof(WeaponType)))
                {
                    string filename = "images/equipment/" + s + "/" + w.ToString();
                    temp.Wep.Add(w, Sprite.Create(Resources.Load(filename) as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution));
                }
                EquipmentSprite.Add(BaseStats.MatBaseIndicies[s], temp);
            }

            AttackSprite = new Dictionary<AttackName, Sprite>();
            foreach(AttackName n in Enum.GetValues(typeof(AttackName)))
            {
                string filename = "images/attacks/" + n.ToString();
                AttackSprite.Add(n, Sprite.Create(Resources.Load(filename) as Texture2D, new Rect(0, 0, TileResolution, TileResolution), new Vector2(), (float)TileResolution));
            }

            
        }

        public static void Get(Equipment e, SpriteRenderer target)
        {
            if (e.Slot == EquipmentSlot.Weapon || e.Slot == EquipmentSlot.Shield)
            {
                if(e.Slot == EquipmentSlot.Weapon)
                {

                }
                if(e.Slot == EquipmentSlot.Shield)
                {

                }
            }
            else
            {
                target.sprite = EquipmentSprite[e.GetMatStat().BaseRef].Equ[e.Slot];
                Color temp = new Color();  /// add h s l functionality here.
                target.color = temp;
            }
        }

    }

    public class MatContent
    {
        public Dictionary<EquipmentSlot, Sprite> Equ = new Dictionary<EquipmentSlot, Sprite>();
        public Dictionary<WeaponType, Sprite> Wep = new Dictionary<WeaponType, Sprite>();
    }

}
