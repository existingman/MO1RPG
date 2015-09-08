using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MO1.Editor.UserControls
{
    public partial class genericListFillerControl : UserControl
    {
        public Type ListType { get; set; }
        public IList SrcList { get; set; }


        public genericListFillerControl()
        {
            InitializeComponent();
        }

        private void genericListFillerControl_Load(object sender, EventArgs e)
        {

        }

        public void Init(IList srcList, Type entityType)
        {
            SrcList = srcList;
            ListType = entityType;
            listSelector1.Init(srcList, entityType);
            listSelector1.selection += set;
            foreach (var item in Assembly.GetAssembly(typeof(MO1.Definitions.Item)).GetTypes().Where(x => entityType.IsAssignableFrom(x) && !x.IsAbstract && x != entityType))
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.DisplayMember = "Name";            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type t1 = SrcList[listSelector1.Value].GetType();
            Type t2 = (Type)comboBox1.SelectedItem;
            if (t1 != t2)
            {
                SrcList[listSelector1.Value] = Activator.CreateInstance(t2);
                propertyGrid1.SelectedObject = SrcList[listSelector1.Value];
            }
        }

        public void set(int i)
        {
            propertyGrid1.SelectedObject = SrcList[i];
            comboBox1.SelectedItem = SrcList[i].GetType();
        }


    }
}
