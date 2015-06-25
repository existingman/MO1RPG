using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1;
using MO1.Tech;


namespace MO1.Definitions
{
    public enum TerrainType { None, Floor, Wall, Water, Lava }

    public class Terrain: IThing
    {
        //IThing Stuff
        public ImageType Type()
        {
            return ImageType.terrains;
        }
        public int DefaultImageRef();

        //Generic Stuff
        public TerrainType TerrainType = TerrainType.Floor;
        public string Name = "Unnamed";

        //individual stuff
        public Tile Owner;

        
        


    }
}
