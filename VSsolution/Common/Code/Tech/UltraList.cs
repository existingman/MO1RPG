using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MO1.Definitions;

namespace MO1.Tech
{
    public class UltraList<T> : List<T> where T: new()
    {
        private readonly List<T> originalList;
        public void AddMember()
        {
            originalList.Add(new T());
        }

    }
}
