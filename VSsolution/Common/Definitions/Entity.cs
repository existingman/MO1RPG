using System;
using System.Collections.Generic;
using MO1.Definitions;


namespace MO1.Definitions
{
    public class Entity
    {
        //IThing stuff
        public ImageType Type()
        {
            return ImageType.entities;
        }
        public int DefaultImageRef()
        {
            return imageRef1;
        }

        //GenericStuff
        public string Name = "Unnamed";
        public int imageRef1;

        //Individual stuff
        public Tile Owner;
    }
}
