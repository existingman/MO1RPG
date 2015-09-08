using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MO1.Tech
{
    public class TripleDict<T>
    {
        List<T> list = new List<T>();
        List<string> names = new List<string>();

        public void Add(string name, T item)
        {
            list.Add(item);
            names.Add(name);
        }

        public void Replace( int i, T item)
        {
            list[i] = item;
        }

        public void Replace(int i, string name)
        {
            names[i] = name;
        }

        public void Replace(string name, T item)
        {
            list[IndexOf(name)] = item;
        }

        public string Name(int i)
        {
            return names[i];
        }

        public string Name(T item)
        {
            for(int x = 0; x < names.Count; x++)
            {
                if (ReferenceEquals(list[x], item)) return names[x];
            }
            return "";
        }

        public T Get(int i)
        {
            return list[i];
        }

        public T Get(string name)
        {
            return list[IndexOf(name)];
        }

        public int IndexOf(string name)
        {
            for(int x = 0; x < names.Count; x++)
            {
                if (names[x] == name) return x;
            }
            return -1;
        }

        public int IndexOf( T item )
        {
            for (int x = 0; x < names.Count; x++)
            {
                if (ReferenceEquals(list[x], item)) return x;
            }
            return -1;
        }

    }
}
