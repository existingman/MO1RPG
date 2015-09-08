using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MO1.Content;
using MO1.Definitions;
using MO1.Definitions.Entities;
using System.Windows.Forms;

namespace MO1.Editor
{


    public partial class EntityEditor : Form
    {
        public EntityEditor()
        {
            InitializeComponent();
        }

        private void EntityEditor_Load(object sender, EventArgs e)
        {
            listSelector1.Init(Data.Entities, typeof(Charactor));
            listSelector1.selection += set;

            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Monster) });
            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Charactor) });
        }



        public void set(int i)
        {
            Type t = Data.Entities[i].GetType();
            propertyGrid1.SelectedObject = Data.Entities[i];
            for (var j = 0; j < comboBox1.Items.Count; ++j)
            {
                if (((EasyToRead)comboBox1.Items[j]).TypeVal == t)
                {
                    //Will trigger comboBox1_SelectedIndexChanged_1 but that is okay selected object is set
                    comboBox1.SelectedIndex = j;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type t1 = Data.Entities[listSelector1.Value].GetType();
            Type t2 = ((EasyToRead)comboBox1.SelectedItem).TypeVal;
            if (t1 != t2)
            {
                Data.Entities[listSelector1.Value] = (Entity)Activator.CreateInstance(t2);
                propertyGrid1.SelectedObject = Data.Entities[listSelector1.Value];
            }
        }


    }
}
