using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MO1.Definitions.Entities;
using MO1.Definitions;
using MO1.Boards;
using MO1.Tech;
using MO1.Content;
using MO1.Definitions.Items;
using MO1.Definitions.Entities.Bodies;

namespace MO1.Avatars
{
    public class Avatar
    {
        public AvatarControl Ctr;
        public GameObject Capsule;
        public Entity Entity;
        
        public Avatar(Entity e)
        {
            if (e.GetType() == typeof(Charactor))
            {
                Capsule = GameObject.Instantiate(Resources.Load("Prefabs/Avatars/human1")) as GameObject;
                Ctr = Capsule.AddComponent<AvatarControl>();
                Entity = e;
                Ctr.Init((Charactor)e);
                ((Charactor)e).Inventory.SlotUpdate += Don;
            }
            Entity.OnMove += Position;
            PlayerCTR.PlayerCharactor.OnMove += Position;
            ReDress();
        }

        public void Position()
        {
            Coord relativeCoord = Entity.Coord.Minus(PlayerCTR.PlayerCharactor.Coord);
            Capsule.transform.position = new Vector3(relativeCoord.X, relativeCoord.Y, relativeCoord.Z);
            bool found = false;
            foreach(Coord c in PlayerCTR.PlayerCharactor.VisionField())
            {
                if(c.Equals(Entity.Coord))
                {
                    found = true;
                    break;
                }
            }
            Show(found);
            if(Entity.Coord.VectorDist(PlayerCTR.PlayerCharactor.Coord) > 20f)
            {
                Remove();
            }

        }

        public void Remove()
        {
            Entity.OnMove -= Position;
            PlayerCTR.PlayerCharactor.OnMove -= Position;
            UnityEngine.MonoBehaviour.Destroy(Capsule);
            if (Entity.GetType() == typeof(Charactor))
            {
                ((Charactor)Entity).Inventory.SlotUpdate -= Don;
            }

        }

        public void Show(bool b)
        {
            Capsule.SetActive(b);
        }

        public void Don(EquipmentSlot slot)
        {
            if (((Charactor)Entity).Inventory.Equiped.ContainsKey(slot))
            {
                if (slot == EquipmentSlot.Weapon || slot == EquipmentSlot.Shield || slot == EquipmentSlot.Quiver)
                {
                
                }
                else
                {
                    Images.Get(((Charactor)Entity).Inventory.Equiped[slot], Ctr.Slots[slot]);
                }
            }
            else
            {
                Ctr.Slots[slot].sprite = null;
            }
        }

        public void ReDress()
        {
            foreach(EquipmentSlot e in Ctr.Slots.Keys)
            {
                Don(e);
            }
        }

        public void ActivateTargets(List<Target> targets)
        {
            foreach(Target t in targets)
            {
                Type type = t.Ref.GetType();
                if(type == typeof(HumanoidParts))
                {
                    HumanoidParts h = (HumanoidParts)(t.Ref);
                }
                if(type == typeof(EquipmentSlot))
                {
                    EquipmentSlot h = (EquipmentSlot)(t.Ref);

                }
            }
        }

    }
}
