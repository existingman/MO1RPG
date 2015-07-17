using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1;
using MO1.Tech;


namespace MO1.Definitions
{
    public enum TerrainType { None, Floor, Wall, Water, Lava, secret, stairs }

    public class Terrain: IThing
    {
        //IThing stuff
        public ImageType Type
        {
            get { return ImageType.props; }
        }
        public int DefaultImageRef
        {
            get { return imageRef1; }
        }

        //Generic Stuff
        public TerrainType TerrainType = TerrainType.Floor;
        public string Name = "Unnamed";
        public int imageRef1;
        public int imageRef2;

        //individual stuff
        public Tile Owner;

        
        public Terrain()
        {

        }

        public Terrain( TerrainType t )
        {
            TerrainType = t;
        }
    }
}
