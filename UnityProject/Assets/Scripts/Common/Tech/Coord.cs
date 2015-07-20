﻿using System;
using System.Collections.Generic;

namespace MO1.Tech
{
    public struct Coord
    {
        public int X;
        public int Y;
        public int Z;
        public Coord(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return "X:" + X.ToString() + ", Y:" + Y.ToString() + ", Z:" + Z.ToString();
        }

        public static Coord Zero = new Coord(0, 0, 0);

        public Coord Plus(Coord c)
        {
            return new Coord(X + c.X, Y + c.Y, Z + c.Z);
        }

        public bool Equals(Coord c)
        {
            if (c.X != X) return false;
            if (c.Y != Y) return false;
            if (c.Z != Z) return false;
            return true;
        }

        public bool IsNear(Coord c)
        {
            Coord diff = new Coord((int)Math.Abs(X - c.X), (int)Math.Abs(Y - c.Y), (int)Math.Abs(Z - c.Z));
            if (diff.X > 1) return false;
            if (diff.Y > 1) return false;
            if (diff.Z > 1) return false;
            return true;
        }

        public Coord StairCheck()
        {
            Coord target = this;
            if (MO1.Content.Map.Get(MO1.Content.Player.PlayerCharactor.Coord).TerrainType == Definitions.TerrainType.stairs)
            {
                Coord Target2 = target.Plus(new Coord(0, 0, 1));
                if (Tech.isValid(Target2))
                {
                    if (MO1.Content.Map.Get(Target2).TerrainType == Definitions.TerrainType.stairs)
                    {
                        target = Target2;
                    }
                }
                Target2 = target.Plus(new Coord(0, 0, -1));
                if (Tech.isValid(Target2))
                {
                    if (MO1.Content.Map.Get(Target2).TerrainType == Definitions.TerrainType.stairs)
                    {
                        target = Target2;
                    }
                }
            }
            return target;
        }
    }
}