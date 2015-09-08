using System;
using System.Collections.Generic;

namespace MO1.Tech
{
    public enum CardinalDirection { West, SW, South, SE, East, NE, North, NW };


    public static class Tech
    {
        public static string Place(int p)
        {
            switch (p)
            {
                case 1:
                    return "1st";
                    break;
                case 2:
                    return "2nd";
                    break;
                case 3:
                    return "3rd";
                    break;
                default:
                    return p.ToString() + "th";
                    break;
            }
        }

        public static bool isValid(Coord coord)
        {
            if (coord.X < 0) return false;
            if (coord.Y < 0) return false;
            if (coord.Z < 0) return false;
            if (coord.X >= MO1.Content.Map.XSize) return false;
            if (coord.Y >= MO1.Content.Map.YSize) return false;
            if (coord.Z >= MO1.Content.Map.ZSize) return false;

            return true;
        }

        public static Dictionary<CardinalDirection, Coord> DirectionalSteps = new Dictionary<CardinalDirection, Coord>()
        {
            { CardinalDirection.East,   new Coord( 1, 0, 0 ) },
            { CardinalDirection.NE,     new Coord( 1, 1, 0 ) },
            { CardinalDirection.North,  new Coord( 0, 1, 0 ) },
            { CardinalDirection.NW,     new Coord(-1, 1, 0 ) },
            { CardinalDirection.West,   new Coord(-1, 0, 0 ) },
            { CardinalDirection.SW,     new Coord(-1,-1, 0 ) },
            { CardinalDirection.South,  new Coord( 0,-1, 0 ) },
            { CardinalDirection.SE,     new Coord( 1,-1, 0 ) },
        };






    }


}
