using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MO1.Definitions.Charactors;
using MO1.Definitions.Items;

namespace MO1.Editor.UserControls
{
    public partial class InventoryControl : UserControl
    {
        Inventory Target;
        Dictionary<ItemControl, EquipmentSlot> slots;
        Dictionary<ItemControl, int> items;
        Dictionary<NumericUpDown, CurrencyType> currencie;


        public InventoryControl()
        {
            InitializeComponent();
        }

        private void InventoryControl_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        {
            Clear();
        }

        public void Init(Inventory i)
        {
            Clear();
            slots = new Dictionary<ItemControl, EquipmentSlot>();
            Target = i;
            int count = 0;
            foreach(EquipmentSlot e in Enum.GetValues(typeof(EquipmentSlot)))
            {
                ItemControl temp = new ItemControl();
                temp.Location = new Point( 15, count * 50);
                if(Target.Equiped.ContainsKey(e))
                {
                    temp.Init(e.ToString(), Target.Equiped[e]);
                }
                else
                {
                    temp.Init(e.ToString());
                }
                slots.Add(temp, e);
                this.tabControl1.TabPages[0].Controls.Add(temp);
                temp.Add += AddToSlot;
                temp.Remove += RemoveFromSlot;
                temp.Edit += EditSlot;
                count++;
            }
            vScrollBar1.Maximum = 1500;

            items = new Dictionary<ItemControl, int>();
            for (int num = 0; num < Inventory.LootLimit; num++ )
            {
                ItemControl temp = new ItemControl();
                temp.Location = new Point(15, num * 50);
                if (Target.Loot[num] != null)
                {
                    temp.Init("item:" + num.ToString(), Target.Loot[num]);
                }
                else
                {
                    temp.Init("item:" + num.ToString());
                }
                items.Add(temp, num);
                this.tabControl1.TabPages[1].Controls.Add(temp);
                temp.Add += AddToItems;
                temp.Remove += RemoveFromItems;
                temp.Edit += EditItems;
            }
            vScrollBar2.Maximum = 1500;


            currencie = new Dictionary<NumericUpDown, CurrencyType>();
            count = 0;
            foreach (CurrencyType c in Enum.GetValues(typeof(CurrencyType)))
            {
                NumericUpDown temp = new NumericUpDown();
                temp.Location = new Point(50, count * 25);
                if (Target.Currency.ContainsKey(c))
                {
                    temp.Value = (decimal)Target.Currency[c];
                }
                else
                {
                    temp.Value = 0;
                }
                currencie.Add(temp, c);
                this.tabControl1.TabPages[2].Controls.Add(temp);
                temp.ValueChanged += CurrencyChange;
                Label temp2 = new Label();
                temp2.Text = c.ToString();
                temp2.Location = new Point(0, count * 25);
                this.tabControl1.TabPages[2].Controls.Add(temp2);

                count++;
            }


        }

        public void Clear()
        {
            if(slots != null)
            {
                foreach(ItemControl i in slots.Keys)
                {
                    i.Dispose();
                }
            }
        }

        public void AddToSlot(ItemControl i)
        {
            EquipmentSlot e = slots[i];
            Equipment temp = new Equipment();
            temp.Slot = e;
            Target.Equiped[e] = temp;
            propertyGrid1.SelectedObject = temp;
            i.Init(e.ToString(), temp);
        }

        public void RemoveFromSlot(ItemControl i)
        {
            Target.Equiped[slots[i]] = null;
        }

        public void EditSlot(ItemControl i)
        {
            propertyGrid1.SelectedObject = Target.Equiped[slots[i]];
        }



        public void AddToItems(ItemControl i)
        {
            Equipment temp = new Ammo();
            propertyGrid1.SelectedObject = temp;
            i.Init( "Item:" + items[i].ToString(), temp);
        }

        public void RemoveFromItems(ItemControl i)
        {
            Target.Equiped[slots[i]] = null;
        }

        public void EditItems(ItemControl i)
        {
            propertyGrid1.SelectedObject = Target.Loot[items[i]];
        }



        public void CurrencyChange(object sender, EventArgs e)
        {
            CurrencyType c = currencie[(NumericUpDown)sender];
            if(Target.Currency.ContainsKey(c))
            {
                if (((NumericUpDown)sender).Value == 0)
                {
                    Target.Currency.Remove(c);
                }
                else
                {
                    Target.Currency[c] = (float)(((NumericUpDown)sender).Value);
                }
            }
            else
            {
                if (((NumericUpDown)sender).Value != 0)
                {
                    Target.Currency.Add(c, (float)(((NumericUpDown)sender).Value));
                }
            }
        }



        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (slots != null)
            {
                foreach (ItemControl i in slots.Keys)
                {
                    int num = (int)(slots[i]);
                    i.Location = new Point(15, num * 50 - vScrollBar1.Value);
                }
            }
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (items != null)
            {
                foreach (ItemControl i in items.Keys)
                {
                    int num = (int)(items[i]);
                    i.Location = new Point(15, num * 50 - vScrollBar2.Value);
                }
            }
        }

    }
}
