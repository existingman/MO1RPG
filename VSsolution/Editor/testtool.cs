using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MO1.Content;
using MO1.Definitions;

namespace MO1.Editor
{
    public partial class testtool : Form
    {
        public testtool()
        {
            InitializeComponent();
        }

        private void testtool_Load(object sender, EventArgs e)
        {
            genericListFillerControl1.Init((IList)Data.Items, typeof(Item));
        }
    }
}
