using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MO1.Definitions;
using MO1.Definitions.Items;
using MO1.Content;

namespace MO1.Editor
{

    public partial class ItemEditor : Form
    {
        public ItemEditor()
        {
            InitializeComponent();
        }

        private void ItemEditor_Load(object sender, EventArgs e)
        {
            listSelector1.Init(Data.Items, typeof(Item));
            listSelector1.selection += set;

            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Armour) });
            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Ammo) });
            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Currency) });
            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Key) });
            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Shield) });
            comboBox1.Items.Add(new EasyToRead() { TypeVal = typeof(Weapon) });

            
        }

        public void set(int i)
        {
            Type t = Data.Items[i].GetType();
            propertyGrid1.SelectedObject = Data.Items[i];

            for(var j = 0; j < comboBox1.Items.Count; ++j)
            {
                if(((EasyToRead)comboBox1.Items[j]).TypeVal == t)
                {
                    //Will trigger comboBox1_SelectedIndexChanged_1 but that is okay selected object is set
                    comboBox1.SelectedIndex = j;
                }
            }
            //comboBox1.SelectedText = t.Name;
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Type t1 = Data.Items[listSelector1.Value].GetType();
            Type t2 = ((EasyToRead)comboBox1.SelectedItem).TypeVal;
            if (t1 != t2)
            {
                Data.Items[listSelector1.Value] = (Item)Activator.CreateInstance(t2);
                propertyGrid1.SelectedObject = Data.Items[listSelector1.Value];
            }
        }


    }
    public class EasyToRead
    {
        public Type TypeVal;
        public override string ToString()
        {
            return TypeVal.Name;
        }
    }

}
