using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MO1.Definitions;
using MO1.Tech;
using MO1.Content;
using System.Collections;

using MO1.Definitions.Entities;

namespace MO1.Editor.UserControls
{
    public delegate void IndexChange(int i);

    public partial class ListSelector : UserControl
    {
        public event IndexChange selection;

        public Type EntityType { get; set; }
        public IList SrcList { get; set; }

        public ListSelector()
        {
            InitializeComponent();
        }

        public void Init(IList srcList, Type entityType)
        {
            SrcList = srcList;
            EntityType = entityType;
            Refresh();
        }


        public int Value { get { return hScrollBar1.Value; } }

        public void Refresh()
        {
            if (SrcList.Count - 1 < hScrollBar1.Value) hScrollBar1.Value = 0;
            if (SrcList.Count > 1)
            {
                hScrollBar1.Minimum = 0;
                hScrollBar1.Maximum = SrcList.Count - 2 + hScrollBar1.LargeChange;
                hScrollBar1.Enabled = true;
                hScrollBar1.Refresh();
            }
            else
            {
                hScrollBar1.Enabled = false;
            }
            if (SrcList.Count > 0)
            {
                textBox1.Enabled = true;
                textBox1.Text = ((INameable)(SrcList[hScrollBar1.Value])).Name;
                textBox2.Text = hScrollBar1.Value.ToString();
                button2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                button2.Enabled = false;
            }


        }

        private void ListSelector_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (selection != null) selection(hScrollBar1.Value);
            Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ((INameable)(SrcList[hScrollBar1.Value])).Name = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newObject = Activator.CreateInstance(EntityType);
            SrcList.Add(newObject);
            Refresh();
            hScrollBar1.Value = SrcList.Count -1;
            Refresh();
            if (selection != null) selection(hScrollBar1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SrcList.RemoveAt(hScrollBar1.Value);
            hScrollBar1.Value = hScrollBar1.Minimum;
            Refresh();
            if (selection != null) selection(hScrollBar1.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
