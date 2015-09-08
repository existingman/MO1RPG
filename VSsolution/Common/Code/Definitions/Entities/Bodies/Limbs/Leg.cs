using System;
using System.Collections.Generic;
using System.Linq;

using MO1.Definitions.Entities.Bodies.BodyParts;
using MO1.Definitions.Entities.Bodies.Organs;


namespace MO1.Definitions.Entities.Bodies.Limbs
{
    public class Leg : Limb
    {
        public Segment Hip;
        public Segment Thigh;
        public Segment Knee;
        public Segment Shin;
        public Segment Foot;

        public override String Name { get { return _orientation.ToString() + " Leg"; } }

        public Leg(Body owner, Side s)
            :base(owner, s)
        {
            Hip = new Segment(owner, s.ToString() + " " + "Hip");
            new Bone(Hip, "Illium");
            new Muscle(Hip, "Glutorials");
            new Muscle(Hip, "Tensor Fasia Latae");
            new Artery(Hip, "Femeral Artery", 0.1f);
            this.Segments.Add(Hip);

            Thigh = new Segment(owner, s.ToString() + " " + "Thigh");
            new Bone(Thigh, "Femur");
            new Muscle(Thigh, "HamStrings");
            new Muscle(Thigh, "Quadracepts");
            new Artery(Thigh, "Femeral Artery", 0.1f);
            this.Segments.Add(Thigh);

            Knee = new Segment(owner, s.ToString() + " " + "Knee");
            new Bone(Knee, "Patella");
            new Ligament(Knee, "SomeLigament");
            new Ligament(Knee, "anotherLigament");
            this.Segments.Add(Knee);

            Shin = new Segment(owner, s.ToString() + " " + "Shin");
            new Bone(Shin, "Tibia");
            new Bone(Shin, "Fibula");
            new Muscle(Shin, "Calf");
            new Muscle(Shin, "Peronius");
            this.Segments.Add(Shin);

            Foot = new Segment(owner, s.ToString() + " " + "Foot");
            new Bone(Foot, "Carples");
            new Bone(Foot, "Meta-Carples");
            new Muscle(Foot, "Toe-flexors");
            new Muscle(Foot, "Toe-Extensors");
            this.Segments.Add(Foot);
        }
    }
}
