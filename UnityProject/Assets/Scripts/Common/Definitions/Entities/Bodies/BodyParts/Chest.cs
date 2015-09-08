using System;
using System.Collections.Generic;

using MO1.Definitions.Combat;
using MO1.Definitions.Entities.Bodies.Organs;
using MO1.Tech;

namespace MO1.Definitions.Entities.Bodies.BodyParts
{
    class Chest : BodyPart
    {
        public override string Name { get { return "Chest"; } }

        private const int ribnum = 8;
        private Bone[] _ribs;
        private Heart _heart;
        private Lung _leftLung;
        private Lung _rightLung;

        public Chest(Body b)
            :base(b)
        {
            Bone[] _ribs = new Bone[ribnum];
            for(int x = 0; x < ribnum; x++)
            {
                string place = Tech.Tech.Place(x + 1);
                _ribs[x] = new Bone(this, place + " rib");
            }
            _heart = new Heart(this);
            _leftLung = new Lung(this, Side.Left);
            _rightLung = new Lung(this, Side.Right);
        }

        public override DamagePack TakeDamage(DamagePack Pack)
        {
            System.Random Rnd = new Random();
            DamagePack running = Pack;
            int x = Rnd.Next(ribnum);
            switch (Pack.Type)
            {
                case DamageType.Blunt:
                    foreach(Bone r in ribtargets(x))
                    {
                        running = r.TakeDamage(running);
                    }

                    return woundRandom(running);
                    break;

                case DamageType.Piercing:
                    if(Rnd.NextDouble() > 0.5)
                    {
                        if(_ribs[x].Function > 0)
                        {
                            running = _ribs[x].TakeDamage(running);
                        }
                    }
                    return woundRandom(running);

                    break;

                case DamageType.Slashing:
                    if (Rnd.NextDouble() > 0.2)
                    {
                        foreach (Bone r in ribtargets(x))
                        {
                            running = r.TakeDamage(running);
                        }
                    }
                    return woundRandom(running);
                    break;
            }
            return running;
        }

        private DamagePack woundRandom(DamagePack Pack)
        {
            if (Pack.Force > 0)
            {
                System.Random RND = new Random();
                switch (RND.Next(3))
                {
                    case 0:
                        return _leftLung.TakeDamage(Pack);

                    case 1:
                        return _heart.TakeDamage(Pack);

                    case 2:
                        return _rightLung.TakeDamage(Pack);

                    default:
                        return new DamagePack();
                }
            }
            else
            {
                return new DamagePack();
            }
        }


        private List<Bone> ribtargets(int x)
        {
            List<Bone> tempList = new List<Bone>();
            int offset = 0;
            int found = 0;
            while (found < 4)
            {
                int temp = x + offset;
                if (temp >= 0 && temp < ribnum)
                {
                    found++;
                    if (_ribs[temp].Function > 0)
                    {
                        tempList.Add(_ribs[temp]);
                    }
                }
                if (offset > 0)
                {
                    offset *= -1;
                }
                else
                {
                    offset *= -1;
                    offset++;
                }
            }
            return tempList;
        }

    }
}
