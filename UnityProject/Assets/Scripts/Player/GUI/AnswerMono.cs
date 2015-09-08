using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MO1.GUI
{
    class AnswerMono: MonoBehaviour
    {
        public void OnMouseUp()
        {
            this.GetComponent<Image>().color = new Color(.5f, .5f, .5f, .5f);
        }

        public void OnMouseDown()
        {
            this.GetComponent<Image>().color = new Color(.0f, .0f, .0f, .1f);
        }

        public void OnMouseOver()
        {
            this.GetComponent<Image>().color = new Color(.5f, .5f, .5f, .5f);
        }

        public void OnMouseOut()
        {
            this.GetComponent<Image>().color = new Color(.2f, .2f, .2f, .5f);
        }
    }
}
