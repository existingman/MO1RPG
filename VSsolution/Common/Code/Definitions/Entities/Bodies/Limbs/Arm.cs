using System;
using System.Collections.Generic;
using System.Linq;

using MO1.Definitions.Entities.Bodies.BodyParts;
using MO1.Definitions.Entities.Bodies.Organs;


namespace MO1.Definitions.Entities.Bodies.Limbs
{
    public class Arm : Limb
    {
        public BodyPart Shoulder;
        public BodyPart UpperArm;
        public BodyPart Elbow;
        public BodyPart ForeArm;
        public BodyPart Hand;

        public override String Name { get { return _orientation.ToString() + " Arm"; } }

        public Arm(Body owner, Side s)
            : base(owner, s)
        {
            Shoulder = new Segment(owner, s.ToString() + " " + "Shoulder");
            new Bone(Shoulder, "Clavicle");
            new Bone(Shoulder, "Scapular");
            new Muscle(Shoulder, "Deltoids");
            new Artery(Shoulder, "Humeral Artery", 0.1f);
            this.Segments.Add(Shoulder);

            UpperArm = new Segment(owner, s.ToString() + " " + "UpperArm");
            new Bone(UpperArm, "Femur");
            new Muscle(UpperArm, "HamStrings");
            new Muscle(UpperArm, "Quadracepts");
            new Artery(Shoulder, "Humeral Artery", 0.1f);
            this.Segments.Add(UpperArm);

            Elbow = new Segment(owner, s.ToString() + " " + "Elbo");
            new Ligament(Elbow, "SomeLigament");
            new Ligament(Elbow, "anotherLigament");
            this.Segments.Add(Elbow);

            ForeArm = new Segment(owner, s.ToString() + " " + "ForeArm");
            new Bone(ForeArm, "Radius");
            new Bone(ForeArm, "Ulna");
            new Muscle(ForeArm, "Flexors");
            new Muscle(ForeArm, "Extensors");
            this.Segments.Add(ForeArm);

            Hand = new Segment(owner, s.ToString() + " " + "Hand");
            new Bone(Hand, "Carples");
            new Bone(Hand, "Meta-Carples");
            new Muscle(Hand, "Toe-flexors");
            new Muscle(Hand, "Toe-Extensors");
            this.Segments.Add(Hand);
        }
    }
}
