using System;
using System.Collections.Generic;
using MO1.Definitions;
using System.IO;
using MO1.Tech;
using MO1.Definitions.Entities;
using System.Collections;
using System.Linq;

namespace MO1.Content
{
    public static class PlayerFile
    {
        private static Coord _playerFileCoord;
        private static Charactor _pc;

        public static void Load()
        {
            string PlayerFile = Path.Combine(Data.BaseDir, "Player.txt");
            if (File.Exists(PlayerFile))
            {
                using (StreamReader sr = new StreamReader(PlayerFile))
                {
                    int x = Convert.ToInt32(sr.ReadLine());
                    int y = Convert.ToInt32(sr.ReadLine());
                    int z = Convert.ToInt32(sr.ReadLine());
                    _playerFileCoord = new Coord(x, y, z);
                }
            }
            else
            {
                _playerFileCoord = new Coord(Map.XSize / 2, Map.YSize / 2, Map.ZSize / 2);
            }
            if (Map.Get(_playerFileCoord).Entity == null)
            {
                Entity temp = NewCharactor();
                temp.Coord = _playerFileCoord;
            }
            _pc = (Charactor)Map.Get(_playerFileCoord).Entity;
        }

        public static void Save()
        {
            _playerFileCoord = _pc.Coord;

            string PlayerFile = Path.Combine(Data.BaseDir, "Player.txt");
            if (File.Exists(PlayerFile))
            {
                File.Delete(PlayerFile);
            }

            using (StreamWriter sw = new StreamWriter(PlayerFile))
            {
                sw.WriteLine(_playerFileCoord.X);
                sw.WriteLine(_playerFileCoord.Y);
                sw.WriteLine(_playerFileCoord.Z);          
            }

        }

        public static void Apply(Coord c)
        {
            Entity temp;
            if (Map.Get(_playerFileCoord).Entity == null)
            {
                temp = NewCharactor();
            }
            else
            {
                temp = Map.Get(_playerFileCoord).Entity;
            }
            temp.Coord = c;
            _playerFileCoord = c;
            _pc = (Charactor)Map.Get(_playerFileCoord).Entity;
        }

        public static Charactor NewCharactor()
        {
            Charactor temp = new Charactor();
            temp.Name = "The Chosen One";
            temp.Inventory.Equiped[MO1.Definitions.Items.EquipmentSlot.Weapon] = new MO1.Definitions.Items.Weapons.ShortSword();
            return temp;
        }

        public static Coord GetCoord()
        {
            return _pc.Coord;
        }

    }
}
