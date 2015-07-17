using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1.Tech;
using MO1.Definitions.Entities;

namespace MO1.Definitions
{
    public enum EntityType { None, Monster, Charactor }
    public class Entity : INameable
    {
        public static Dictionary<EntityType, Type> EntityDict = new Dictionary<EntityType, Type>()
        {
            {EntityType.None, typeof(Entity)},
            {EntityType.Charactor, typeof(Charactor)},
            {EntityType.Monster, typeof(Monster)}
        };

        public static Dictionary<Type, EntityType> RevEntityDict = new Dictionary<Type, EntityType>()
        {
            {typeof(Entity), EntityType.None},
            {typeof(Charactor), EntityType.Charactor},
            {typeof(Monster), EntityType.Monster}
        };

        //GenericStuff
        public int imageRef1 {get; set;}

        //Individual stuff
        public List<Coord> VisionField;
        private Tech.Coord _coord;
        public Tech.Coord Coord
        {
            get { return _coord; }
            set
            {
                if(!value.Equals(new Tech.Coord(0,0,0)))
                {
                    Content.Map.Get(_coord).Entity = null;
                    _coord = value;
                    Content.Map.Get(_coord).Entity = this;
                    UpdateVisionField();
                }
            }
        }
        public Tile Owner { get { return Content.Map.Get(_coord); } }

        //Inameable stuff
        private string _name = "Unnamed";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        const int horrizon = 4;
        public void UpdateVisionField()
        {
            VisionField = new List<Coord>();
            for (int x = -horrizon; x < horrizon; x++)
            {
                for (int y = -horrizon; y < horrizon; y++)
                {
                    Coord target = _coord.Plus(new Coord(x, y, 0));
                    if (Tech.Tech.isValid(target))
                    {
                        if (target.IsNear(_coord))
                        {
                            VisionField.Add(target);
                        }
                        else
                        {
                            Coord temp = _coord;
                            for (; ; )
                            {
                                double angle = (Math.Atan2((double)(target.Y - temp.Y), (double)(target.X - temp.X)) + Math.PI) / (2 * Math.PI) * 8;
                                int poop = (int)Math.Round(angle);
                                if (poop > 7) poop -= 8;
                                CardinalDirection direction = (CardinalDirection)(poop);
                                temp = temp.Plus(Tech.Tech.DirectionalSteps[direction]);
                                if (temp.Equals(target))
                                {
                                    VisionField.Add(target);
                                    break;
                                }
                                if (MO1.Content.Map.Get(temp).opaque())
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
