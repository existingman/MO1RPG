using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MO1.Avatars
{
    public class GlowGreenMono : MonoBehaviour
    {
        public BoxCollider2D Collider;
        public SpriteRenderer SRenderer;

        void Start()
        {
            Collider = this.gameObject.AddComponent<BoxCollider2D>();
            Collider.size = new Vector2(0.3f, 0.3f);
            SRenderer = GetComponent<SpriteRenderer>();
            //Debug.Log("greenglow starting");
        }

        void OnMouseEnter()
        {
            SRenderer.color = Color.green;
            Debug.Log("mouseover greenglow");
        }

        void OnMouseExit()
        {
            SRenderer.color = Color.white;
            Debug.Log("mouseover greenglow");
        }

    }
}
