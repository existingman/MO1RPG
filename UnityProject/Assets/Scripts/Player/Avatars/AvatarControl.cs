using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


using MO1.Boards;
using MO1.Content;
using MO1.Definitions;
using MO1.Definitions.Items;
using MO1.Definitions.Entities;
using MO1.Definitions.Entities.Bodies;
using MO1.Tech;

namespace MO1.Avatars
{
    public enum BodyJoint { Root, LShoulder, RShoulder, LElbow, RElbow, LHip, RHip, LKnee, RKnee }
    public enum BodySegs { Torso, LArm, RArm, LWrist, RWrist, LThigh, RThigh, LShin, RShin}

    public class AvatarControl : MonoBehaviour
    {
        public Charactor Charactor;
        BoxCollider2D _collider;
        public Dictionary<EquipmentSlot, SpriteRenderer> Slots;
        public Dictionary<BodyJoint, Transform> Joints;
        public Dictionary<BodySegs, SpriteRenderer> Segments;
        List<GameObject> AllChildren;
        

        public void Init(Charactor c)
        {
            Charactor = c;

            Slots = new Dictionary<EquipmentSlot, SpriteRenderer>();

            List<GameObject> temp = new List<GameObject>();
            temp.Add(this.gameObject);
            AllChildren = getall(temp);

            foreach (EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
            {
                //Debug.Log("checking: " + slot.ToString());
                string tempName = slot.ToString();
                foreach (GameObject g in AllChildren)
                {
                    if (g.name.Contains(tempName))
                    {
                        Slots.Add(slot, g.GetComponent<SpriteRenderer>());
                        //Debug.Log("found");
                        break;
                    }
                }
            }

            Joints = new Dictionary<BodyJoint, Transform>();
            foreach (BodyJoint joint in Enum.GetValues(typeof(BodyJoint)))
            {
                string tempName = joint.ToString();
                //Debug.Log("checking: " + tempName);
                foreach (GameObject g in AllChildren)
                {
                    if (g.name.Contains(tempName))
                    {
                        Joints.Add(joint, g.transform);
                        //Debug.Log("found");
                        break;
                    }
                }
            }

            Segments = new Dictionary<BodySegs, SpriteRenderer>();
            foreach (BodySegs seg in Enum.GetValues(typeof(BodySegs)))
            {
                string tempName = seg.ToString();
                //Debug.Log("checking: " + tempName);
                foreach (GameObject g in AllChildren)
                {
                    if (g.name.Contains(tempName))
                    {
                        Segments.Add(seg, g.GetComponent<SpriteRenderer>());
                        //Debug.Log("found");
                        break;
                    }
                }
            }
            _collider = this.gameObject.AddComponent<BoxCollider2D>();
            _collider.size = new Vector2(0.8f, 1);

        }

        private List<GameObject> getall(List<GameObject> param)
        {
            List<GameObject> temp = new List<GameObject>();
            
            foreach(GameObject g in param)
            {
                for (int x = 0; x < g.transform.childCount; x++)
                {
                    temp.Add(g.transform.GetChild(x).gameObject);
                }
            }
            if (temp.Count > 0)
            {
                List<GameObject> temp2 = getall(temp);
                temp.AddRange(temp2);
            }
            
            return temp;
        }


        public void Position()
        {
            Coord relativeCoord = Charactor.Coord.Minus(PlayerCTR.PlayerCharactor.Coord);
            Joints[BodyJoint.Root].position = new Vector3(relativeCoord.X * 50, relativeCoord.Y * 50, relativeCoord.Z * 50);
        }



        public SpriteRenderer get(EquipmentSlot slot)
        {
            return Slots[slot];
        }

        public Transform get(BodyJoint joint)
        {
            return Joints[joint];
        }

        public SpriteRenderer get(BodySegs seg)
        {
            return Segments[seg];
        }



        public void Refresh(EquipmentSlot slot)
        {
            get(slot).sprite = null;
        }

        public void Refresh()
        {
            foreach(EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
            {
                Refresh(slot);
            }
        }

        void OnMouseEnter()
        {
            if (MainControl.ValidTargets.Contains((Entity)Charactor) && MainControl.Targeting)
            {
                expand();
            }
        }

        private void expand()
        {
            transform.localScale = new Vector3(5, 5, 1);
            foreach(Target t in Charactor.Targets)
            {
                //Debug.Log("checking: " + t.Ref.ToString());
                String name = "";
                if (t.Ref.GetType() == typeof(EquipmentSlot))
                {
                    if (Charactor.Inventory.Equiped[(EquipmentSlot)(t.Ref)] == null)
                    {
                        name = t.Ref.ToString() + "Gap";
                    }
                    else
                    {
                        name = t.Ref.ToString();
                    }
                }
                if (t.Ref.GetType() == typeof(HumanoidParts))
                {
                    name = t.Ref.ToString();
                }
                foreach(GameObject g in AllChildren)
                {
                    if(g.name == name)
                    {
                        SubTargetBaseMono temp = g.GetComponent<SubTargetBaseMono>();
                        temp.Active = true;
                        temp.Target = t;
                        break;
                    }
                }
            }
            MainControl.Tick -= Check;
        }

        public void Check()
        {
            if (!_collider.bounds.Contains(Input.mousePosition))
            {
                transform.localScale = new Vector3(1, 1, 1);
                MainControl.Tick -= Check;
            }
        }

    }
}
