using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using MO1.Content;
using MO1.Definitions;
using MO1.Definitions.Items;

namespace MO1.Editor.UserControls
{
    public delegate void itemClick(ItemControl ctr);
    public partial class ItemControl : UserControl
    {
        public event itemClick Edit;
        public event itemClick Remove;
        public event itemClick Add;
        public Item Item;

        public ItemControl()
        {
            InitializeComponent();
        }

        public void Init(string slotname, Item i)
        {
            label1.Text = slotname;
            label2.Text = i.Name;
            Item = i;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        public void Init(string slotname)
        {
            Item = null;
            label1.Text = slotname;
            label2.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remove(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add(this);
        }
    }
}
