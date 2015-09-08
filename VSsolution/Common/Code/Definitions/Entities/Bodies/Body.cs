using System;
using System.Collections.Generic;
using System.Linq;
using MO1.Definitions.Entities.Bodies.Organs;
using MO1.Definitions.Entities.Bodies.BodyParts;
using MO1.Definitions.Entities.Bodies.Limbs;


namespace MO1.Definitions.Entities.Bodies
{
    public enum Side { Left, Right, Medial };
    public abstract class Body
    {
        public Entity Owner;
        public List<BodyPart> Members = new List<BodyPart>();
        public List<Organ> Organs = new List<Organ>();
        public List<Limb> Limbs = new List<Limb>();

        public bool Alive = true;
        public bool Concious = true;
        public bool Blind { get { return GetFunction(typeof(Eye)) > 0.3f; } }

        public float Blood = 1;
        public float Bleeding = 0;
        public float BreathRate = 1;
        public float Oxygenation = 1;
        public float HeartRate = 1;
        public float BloodPressure { get { return Blood * HeartRate; } }
        public float Vitals { get { return BloodPressure * Oxygenation; } }

        public Body(Entity o)
        {
            Owner = o;
        }

        public float GetFunction(Type T)
        {
            var temp = Organs.Where(item => item.GetType() == T);
            float function = 0;
            foreach(Organ o in temp)
            {
                if(o.Function > 0)
                {
                    function += o.Function;
                }
            }
            return function;
        }

        public void tick()
        {
            while(Vitals < 1)
            {
                float HeartFunction = GetFunction(typeof(Heart));
                float LungFunction = GetFunction(typeof(Lung));
                if (HeartRate < HeartFunction || BreathRate < LungFunction)
                {
                    if (HeartRate < HeartFunction)
                    {
                        HeartRate += 0.1f;
                    }
                    if (BreathRate < LungFunction)
                    {
                        BreathRate += 0.1f;
                    }
                }
                else
                {
                    break;
                }
            }
            Oxygenation += (BreathRate * BloodPressure - 1) / 3;
            CheckVitals();
        }

        public void CheckVitals()
        {
            if (Concious && Vitals < 0.5f)
            {
                Concious = false;
                //add anouncement
            }
            if (!Concious && Vitals > 0.5f)
            {
                Concious = true;
                //add anouncement
            }
            if (Vitals < 0.25f) Kill();
        }

        public void Kill()
        {
            Alive = false;
        }

    }
}
