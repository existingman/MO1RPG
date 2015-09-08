using System;
using System.Collections.Generic;
using MO1.Definitions;
using MO1.Content;
using MO1.Tech;
using MO1.Definitions.Entities;
using MO1.Definitions.Entities.Bodies;

namespace MO1.Definitions
{
    public delegate void bang();
    public abstract class Entity : INameable, ICloneable
    {
        public event bang OnMove;

        //GenericStuff
        public virtual int imageRef1
        {
            get { return 0; }
            set { }
        }

        //Individual stuff
        public Body Body;
        public AI AI;
        public Targeter Targeter;
        public List<Target> Targets;
        public List<Coord> VisionField() { return _visionField; }
        private List<Coord> _visionField;

        private List<int> FactionRefs = new List<int>();
        public List<Entities.AIs.Faction> Factions
        { 
            get 
            {
                List<Entities.AIs.Faction> temp = new List<Entities.AIs.Faction>();
                foreach(int i in FactionRefs)
                {
                    temp.Add(Data.Factions[i]);
                }
                return temp;
            } 
        }

        public abstract void Initialise();

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
                    if(OnMove != null) OnMove();
                }
            }
        }
        public Tile Owner() { return Content.Map.Get(_coord); }


        //Inameable stuff
        public string Name { get; set; }


        const int horrizon = 4;
        public void UpdateVisionField()
        {
            _visionField = new List<Coord>();
            for (int x = -horrizon; x < horrizon; x++)
            {
                for (int y = -horrizon; y < horrizon; y++)
                {
                    Coord target = _coord.Plus(new Coord(x, y, 0));
                    if (Tech.Tech.isValid(target))
                    {
                        if (target.IsNear(_coord))
                        {
                            _visionField.Add(target);
                            if(MO1.Content.Map.Get(_coord).TerrainType == TerrainType.stairs)
                            {
                                Coord myCoord;
                                myCoord = new Coord(target.X, target.Y, target.Z + 1);
                                if (Tech.Tech.isValid(myCoord))
                                {
                                    if(MO1.Content.Map.Get(myCoord).TerrainType == TerrainType.stairs)
                                    {
                                        _visionField.Add(myCoord);
                                    }
                                }
                                myCoord = new Coord(target.X, target.Y, target.Z - 1);
                                if (Tech.Tech.isValid(myCoord))
                                {
                                    if (MO1.Content.Map.Get(myCoord).TerrainType == TerrainType.stairs)
                                    {
                                        _visionField.Add(myCoord);
                                    }
                                }
                            }
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
                                    _visionField.Add(target);
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
            List<Coord> tempList = new List<Coord>();
            foreach(Coord c in _visionField)
            {
                if (Tech.Tech.isValid(c))
                {
                    if (MO1.Content.Map.Get(c).TerrainType == TerrainType.None)
                    {
                        int i = 0;
                        for (; ; )
                        {
                            i--;
                            Coord tempCoord = new Coord(c.X, c.Y, c.Z + i);
                            tempList.Add(tempCoord);
                            if (MO1.Content.Map.Get(tempCoord).TerrainType != TerrainType.None)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            foreach (Coord c in tempList)
            {
                _visionField.Add(c);
            }
        }

        public abstract object Clone();
        

    }
}
