using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MO1.Avatars
{
    public class SubTargetBaseMono : MonoBehaviour
    {
        public bool Active = false;
        public Color Color = Color.green;
        public SpriteRenderer SRenderer;
        public MO1.Definitions.Entities.Bodies.Target Target;

        void Start()
        {
            SRenderer = GetComponent<SpriteRenderer>();
        }

        void OnMouseEnter()
        {
            if(Active) glow();
        }

        void OnMouseExit()
        {
            dim();
        }

        void OnClick()
        {
            if (Active) MainControl.SelectTarget(Target);
        }

        protected virtual void glow()
        {
            SRenderer.color = Color;
        }

        protected virtual void dim()
        {
            SRenderer.color = Color.white;
        }



    }
}
