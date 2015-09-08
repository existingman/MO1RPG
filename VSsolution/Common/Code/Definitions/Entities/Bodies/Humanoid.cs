using System;
using System.Collections.Generic;
using System.Linq;

using MO1.Definitions.Entities.Bodies.Organs;
using MO1.Definitions.Entities.Bodies.BodyParts;
using MO1.Definitions.Entities.Bodies.Limbs;

namespace MO1.Definitions.Entities.Bodies
{
    public enum HumanoidParts { Face, Head, Neck, Chest, Adoman, LShoulder, LUpperArm, LElbo, LForeArm, LHand, RShoulder, RUpperArm, RElbo, RForeArm, RHand, LHip, LThigh, LKnee, LShin, LFoot, RHip, RThigh, RKnee, RShin, RFoot }

    public class Humanoid : Body
    {
        Arm LeftArm;
        Arm RightArm;
        Leg LeftLeg;
        Leg RightLeg;
        Head Head;
        Face Face;
        Neck Neck;
        Chest Chest;
        Adomen Adomen;

        public Humanoid(Entity o)
            :base(o)
        {
            LeftArm = new Arm(this, Side.Left);
            RightArm = new Arm(this, Side.Right);
            LeftLeg = new Leg(this, Side.Left);
            RightLeg = new Leg(this, Side.Right);

            Head = new Head(this);
            Face = new Face(this, Head);
            Neck = new Neck(this);
            Chest = new Chest(this);
            Adomen = new Adomen(this);
        }



        public BodyPart Get(HumanoidParts part)
        {
            switch(part)
            {
                case HumanoidParts.Adoman : return Adomen;
                case HumanoidParts.Chest: return Chest;
                case HumanoidParts.Face: return Face;
                case HumanoidParts.Head: return Head;
                case HumanoidParts.Neck: return Neck;
                case HumanoidParts.LElbo: return LeftArm.Elbow;
                case HumanoidParts.LFoot: return LeftLeg.Foot;
                case HumanoidParts.LForeArm: return LeftArm.ForeArm;
                case HumanoidParts.LHand: return LeftArm.Hand;
                case HumanoidParts.LHip: return LeftLeg.Hip;
                case HumanoidParts.LKnee: return LeftLeg.Knee;
                case HumanoidParts.LShin: return LeftLeg.Shin;
                case HumanoidParts.LShoulder: return LeftArm.Shoulder;
                case HumanoidParts.LThigh: return LeftLeg.Thigh;
                case HumanoidParts.LUpperArm: return LeftArm.UpperArm;
                case HumanoidParts.RElbo: return RightArm.Elbow;
                case HumanoidParts.RFoot: return RightLeg.Foot;
                case HumanoidParts.RForeArm: return RightArm.ForeArm;
                case HumanoidParts.RHand: return RightArm.Hand;
                case HumanoidParts.RHip: return RightLeg.Hip;
                case HumanoidParts.RKnee: return RightLeg.Knee;
                case HumanoidParts.RShin: return RightLeg.Shin;
                case HumanoidParts.RShoulder: return RightArm.Shoulder;
                case HumanoidParts.RThigh: return RightLeg.Thigh;
                case HumanoidParts.RUpperArm: return RightArm.UpperArm;
              
                default:
                    return null;
            }
        }

    }
}
