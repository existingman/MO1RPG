using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MO1.Content;

namespace MO1.Editor
{
    public partial class NewMap : Form
    {
        public NewMap()
        {
            InitializeComponent();
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Map.New((int)XControl.Value, (int)YControl.Value, (int)ZControl.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
