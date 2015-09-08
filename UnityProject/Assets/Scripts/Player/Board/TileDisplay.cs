using System;
using System.Collections.Generic;
using UnityEngine;
using MO1.Definitions;
using MO1.Content;

namespace MO1.Boards
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
        public SpriteRenderer Overlay;
        
        public TileDisplay()
        {
            Root = new GameObject();

            _terrain = new GameObject();
            _terrain.name = "Terrain Layer";
            _terrain.transform.parent = Root.transform;
            _terrain.transform.position = new Vector3(0,0,0);
            Terrain = _terrain.AddComponent<SpriteRenderer>();


            _prop = new GameObject();
            _prop.name = "Prop Layer";
            _prop.transform.parent = Root.transform;
            _prop.transform.position = new Vector3(0, 0, -0.01f);
            Prop = _prop.AddComponent<SpriteRenderer>();

            _overlay = new GameObject();
            _overlay.name = "Overlay Layer";
            _overlay.transform.parent = Root.transform;
            _overlay.transform.position = new Vector3(0, 0, -0.03f);
            Overlay = _overlay.AddComponent<SpriteRenderer>();
        }

        public void Display(Tile tile)
        {
            if (tile.Discovered)
            {
                //handle terrain layer
                if (tile.TerrainRef != -1)
                {
                    MO1.Definitions.Terrain temp = Data.Terrains[tile.TerrainRef];
                    if(temp.TerrainType == TerrainType.secret && tile.Traversed)
                    {
                        Terrain.sprite = Images.Image[ImageType.terrains][temp.imageRef2];
                    }
                    else
                    {
                        Terrain.sprite = Images.Image[ImageType.terrains][temp.imageRef1];
                    }
                }
                else
                {
                    Terrain.sprite = Images.Blue;
                }

                //handle Prop Layer
                if (tile.PropRef != -1)
                {
                    Prop temp = Data.Props[tile.PropRef];
                    if (tile.DoorState == DoorState.lockedOpen || tile.DoorState == DoorState.open)
                    {
                        Prop.sprite = Images.Image[ImageType.props][temp.imageRef2];
                    }
                    else
                    {
                        Prop.sprite = Images.Image[ImageType.props][temp.imageRef1];
                    }
                }
                else
                {
                    Prop.sprite = null;
                }

                //handle Entities and overlay
                if (tile.LineOfSight)
                {
                    Overlay.sprite = null;
                }
                else
                {
                    Overlay.sprite = Images.Gray;
                }
            }
            else
            {
                Terrain.sprite = Images.Black;
                Prop.sprite = null;
                Overlay.sprite = null;
            }
        }

        public void BlankOut()
        {
            Terrain.sprite = null;
            Prop.sprite = null;
            Overlay.sprite = null;
        }
    }
}
