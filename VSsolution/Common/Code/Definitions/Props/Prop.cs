using System;
using System.Collections.Generic;
using MO1.Definitions;



namespace MO1.Definitions
{
    public enum PropType { none, decoration, obstruction, door, window, container, pile, lever}
    public enum DoorState { none, lockedOpen, lockedClosed, open, closed }
    public class Prop : IThing
    {
        public static List<String> DescriptionList = new List<string>();

        //IThing stuff
        public ImageType Type
        {
            get { return ImageType.props; }
        }
        public int DefaultImageRef
        {
            get { return imageRef1; }
        }


        //GenericStuff
        public PropType proptype;
        public string Name = "Unnamed";
        public int imageRef1;
        public int imageRef2;
        public int DescriptionRef;

        //Individual stuff
        public Tile Owner;


        public Prop()
        {

        }

        public Prop( PropType t)
        {
            proptype = t;
        }
    }
}
