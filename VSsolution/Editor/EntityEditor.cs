using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MO1.Content;
using MO1.Definitions;
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
            listSelector1.Init(Data.Entities, typeof(Entity));
            listSelector1.selection += set;
            foreach (EntityType t in Enum.GetValues(typeof(EntityType)))
            {
                comboBox1.Items.Add(t);
            }
        }



        public void set(int i)
        {
            Type t = Data.Entities[i].GetType();
            var tempObject = Data.Entities[i];
            propertyGrid1.SelectedObject = Data.Entities[i];
            comboBox1.SelectedIndex = (int)(Entity.RevEntityDict[t]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type t1 = Data.Entities[listSelector1.Value].GetType();
            Type t2 = Entity.EntityDict[(EntityType)(comboBox1.SelectedIndex)];
            if( t1 != t2 )
            {
                Data.Entities[listSelector1.Value] = (Entity)Activator.CreateInstance(t2);
                propertyGrid1.SelectedObject = Data.Entities[listSelector1.Value];
            }
        }


    }
}
