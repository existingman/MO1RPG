using System;
using System.Collections.Generic;

namespace MO1.Definitions
{
    public enum ImageType { terrains, props, entities, items };
    public interface IThing
    {
        ImageType Type{ get;}
        int DefaultImageRef { get;}
    }
}
