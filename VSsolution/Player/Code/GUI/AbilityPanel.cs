using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using MO1.Content;
using MO1.Definitions.Combat;

namespace MO1.GUI
{
    public static class AbilityPanel
    {
        public static List<GameObject> Buttons = new List<GameObject>();
        public static GameObject _canvasObject;
 
        public static void Initialise()
        {
            MO1.PlayerCTR.PlayerCharactor.Inventory.SlotUpdate += EquipmentChanged;
            EquipmentChanged(MO1.Definitions.Items.EquipmentSlot.none);
            Draw();
        }

        public static void EquipmentChanged(MO1.Definitions.Items.EquipmentSlot E)
        {
            Refresh();
        }


        public static void Refresh()
        {
            if (_canvasObject != null) close();
            Draw();

        }

        public static void Draw()
        {
            _canvasObject = new GameObject("Canvas");
            var canvas = _canvasObject.AddComponent<Canvas>();
            _canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.pixelPerfect = true;

            int x = 0;
            Attack temp;
            foreach (Attack a in MO1.PlayerCTR.PlayerCharactor.Attacks())
            {
                x++;
                temp = a;
                var buttonObject = new GameObject( a.Name + " Btn");
                var image = buttonObject.AddComponent<Image>();
                image.transform.parent = canvas.transform;
                image.rectTransform.sizeDelta = new Vector2(50, 50);
                image.rectTransform.anchoredPosition = Vector2.zero;
                image.rectTransform.position = new Vector2(52 * x, 27);
                image.sprite = Images.AttackSprite[a.Name];

                var button = buttonObject.AddComponent<Button>();
                button.targetGraphic = image;

                button.onClick.AddListener(() =>
                {
                    MO1.MainControl.SelectAttack(temp);
                });

            }
        }

        public static void close()
        {
            GameObject.Destroy(_canvasObject);
        }
    }
}
