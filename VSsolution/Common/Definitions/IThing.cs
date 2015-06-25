using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO1.Definitions
{
    public enum ImageType { terrains, props, entities, items };
    interface IThing
    {
        public ImageType Type();
        public int DefaultImageRef();
    }
}
