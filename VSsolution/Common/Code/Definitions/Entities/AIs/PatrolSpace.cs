using System;
using System.Collections.Generic;

using MO1.Tech;

namespace MO1.Definitions.Entities
{
    public struct PatrolSpace
    {
        Coord Lowerbound;
        Coord Upperbound;

        public PatrolSpace(Coord c1, Coord c2)
        {
            Lowerbound = new Coord(lower(c1.X, c2.X), lower(c1.Y, c2.Y), lower(c1.Z, c2.Z));
            Upperbound = new Coord(higher(c1.X, c2.X), higher(c1.Y, c2.Y), higher(c1.Z, c2.Z));
        }

        public List<Coord> Get()
        {
            List<Coord> temp = new List<Coord>();
            for (int x = Lowerbound.X; x <= Upperbound.X; x++)
            {
                for (int y = Lowerbound.Y; y <= Upperbound.Y; y++)
                {
                    for (int z = Lowerbound.Z; z <= Upperbound.Z; z++)
                    {
                        temp.Add(new Coord(x, y, z));
                    }
                }
            }
            return temp;
        }


        private static int lower(int a, int b)
        {
            if(a > b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        private static int higher(int a, int b)
        {
            if (a < b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }


    }
}
