using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



using MO1.Boards;
using MO1.Content;
using MO1.Definitions;
using MO1.Definitions.Items;
using MO1.Definitions.Entities;
using MO1.Tech;

namespace MO1.Avatars
{
    public enum BodyJoint { Root, LShoulder, RShoulder, LElbow, RElbow, LHip, RHip, LKnee, RKnee }
    public enum BodySegs { Torso, LArm, RArm, LWrist, RWrist, LThigh, RThigh, LShin, RShin}

    public class AvatarControl : MonoBehaviour
    {
        public Charactor Charactor;
        public Dictionary<EquipmentSlot, SpriteRenderer> Slots;
        public Dictionary<BodyJoint, Transform> Joints;
        public Dictionary<BodySegs, SpriteRenderer> Segments;

        public void Init(Charactor c)
        {
            Debug.Log("Initialising new caractor ctr");
            Charactor = c;

            Slots = new Dictionary<EquipmentSlot, SpriteRenderer>();

            List<GameObject> temp = new List<GameObject>();
            temp.Add(this.gameObject);
            List<GameObject> AllChildren = getall(temp);

            foreach (EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
            {
                Debug.Log("checking: " + slot.ToString());
                string tempName = slot.ToString();
                foreach (GameObject g in AllChildren)
                {
                    if (g.name.Contains(tempName))
                    {
                        Slots.Add(slot, g.GetComponent<SpriteRenderer>());
                        Debug.Log("found");
                        break;
                    }
                }
            }

            Joints = new Dictionary<BodyJoint, Transform>();
            foreach (BodyJoint joint in Enum.GetValues(typeof(BodyJoint)))
            {
                string tempName = joint.ToString();
                Debug.Log("checking: " + tempName);
                foreach (GameObject g in AllChildren)
                {
                    if (g.name.Contains(tempName))
                    {
                        Joints.Add(joint, g.transform);
                        Debug.Log("found");
                        break;
                    }
                }
            }

            Segments = new Dictionary<BodySegs, SpriteRenderer>();
            foreach (BodySegs seg in Enum.GetValues(typeof(BodySegs)))
            {
                string tempName = seg.ToString();
                Debug.Log("checking: " + tempName);
                foreach (GameObject g in AllChildren)
                {
                    if (g.name.Contains(tempName))
                    {
                        Segments.Add(seg, g.GetComponent<SpriteRenderer>());
                        Debug.Log("found");
                        break;
                    }
                }
            }

            BoxCollider2D tempCollider = Joints[BodyJoint.Root].gameObject.AddComponent<BoxCollider2D>();
            tempCollider.size = new Vector2(2, 5);

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

        void OnMouseOver()
        {
            Joints[BodyJoint.Root].transform.localScale = new Vector3(5, 5, 5);
        }

        void OnMouseOut()
        {
            Joints[BodyJoint.Root].transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
