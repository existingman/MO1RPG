using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MO1.Definitions;

namespace MO1.Editor
{
    public static class MapData
    {
        public static int XSize = 50;
        public static int YSize = 50;
        public static int ZSize = 5;

        public static int[, ,] TerrainMap;
        public static int[, ,] PropMap;
        public static int[, ,] EntityMap;

        public static void Intialise()
        {
            TerrainMap = new int[XSize, YSize, ZSize];
            PropMap = new int[XSize, YSize, ZSize];
            EntityMap = new int[XSize, YSize, ZSize];
            for (int x = 0; x < XSize; x++)
            {
                for (int y = 0; y < YSize; y++)
                {
                    for (int z = 0; z < ZSize; z++)
                    {
                        TerrainMap[x, y, z] = 0;
                        PropMap[x, y, z] = 0;
                        EntityMap[x, y, z] = 0;
                    }
                }
            }
        }

        public static void Apply(ImageType type, int Ref, int x, int y, int z )
        {
            switch(type)
            {
                case ImageType.terrains:
                    TerrainMap[x, y, z] = Ref;
                    break;

                case ImageType.props:
                    PropMap[x, y, z] = Ref;
                    break;

                case ImageType.entities:
                    EntityMap[x, y, z] = Ref;
                    break;
                case ImageType.items:

                    break;
            }
        }
    }
}
