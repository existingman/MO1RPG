using System;
using System.Collections.Generic;
using UnityEngine;

using MO1.Definitions.Combat;

namespace MO1.GUI
{
    public class AttackBtnMono: MonoBehaviour
    {
        public Attack Attack;

        public void mouseUp()
        {
            MO1.MainControl.SelectAttack(Attack);
        }

        public void mouseDown()
        {

        }

        public void mouseOver()
        {

        }

        public void mouseOut()
        {

        }

    }
}
