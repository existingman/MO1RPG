using System;
using System.Collections.Generic;
using UnityEngine;
using MO1VSSolution.Definitions.Tiles;
using MO1VSSolution.Content;

namespace MO1VSSolution.Boards
{
    public class TileDisplay
    {
        public GameObject Root;
        private GameObject _terrain;
        private GameObject _prop;
        private GameObject _entity;
        private GameObject _overlay;


        public SpriteRenderer Terrain;
        public SpriteRenderer Prop;
        public SpriteRenderer Entity;
        public SpriteRenderer Overlay;

        
        public TileDisplay()
        {
            Root = new GameObject();

            _terrain = new GameObject();
            _terrain.transform.parent = Root.transform;
            Terrain = _terrain.AddComponent<SpriteRenderer>();

            _prop = new GameObject();
            _prop.transform.parent = Root.transform;
            Prop = _prop.AddComponent<SpriteRenderer>();

            _entity = new GameObject();
            _entity.transform.parent = Root.transform;
            Entity = _entity.AddComponent<SpriteRenderer>();

            _overlay = new GameObject();
            _overlay.transform.parent = Root.transform;
            Overlay = _overlay.AddComponent<SpriteRenderer>();
        }

        public void Display(Tile tile)
        {
            if (tile.Discovered)
            {
                if (tile.Terrain != null)
                {
                    Terrain.sprite = Images.Terrains[(int)(tile.Terrain.Image)];
                }
                else
                {
                    Terrain.sprite = null;
                }
                if (tile.Prop != null)
                {
                    Prop.sprite = Images.Terrains[(int)(tile.Prop.Image)];
                }
                else
                {
                    Prop.sprite = null;
                }
                if (tile.LineOfSight)
                {
                    Overlay.sprite = null;
                    if (tile.Entity != null)
                    {
                        Entity.sprite = Images.Terrains[(int)(tile.Entity.Image)];
                    }
                    else
                    {
                        Entity.sprite = null;
                    }
                }
                else
                {
                    Overlay.sprite = Images.Gray;
                    Entity.sprite = null;
                }
            }
            else
            {
                Terrain.sprite = Images.Black;
                Prop.sprite = null;
                Entity.sprite = null;
            }
        }
    }
}
