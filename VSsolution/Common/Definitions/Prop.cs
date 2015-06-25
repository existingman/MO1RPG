using System;
using System.Collections.Generic;
using MO1.Definitions;



namespace MO1.Definitions
{
    public enum PropType { decoration, obstruction, door, window, container, pile, lever}
    public class Prop : IThing
    {
        public static List<String> DescriptionList = new List<string>();
        public static List<String> StepOnList = new List<string>();

        //IThing stuff
        public ImageType Type()
        {
            return ImageType.props;
        }
        public int DefaultImageRef()
        {
            return imageRef1;
        }


        //GenericStuff
        public PropType proptype;
        public string Name = "Unnamed";
        public int imageRef1;
        public int DescriptionRef;
        public int StepOnRef;

        //Individual stuff
        public Tile Owner;


        
    }
}
