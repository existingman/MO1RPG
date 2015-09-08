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
using MO1.Definitions.Entities;

namespace MO1.Editor
{
    public partial class CharactorEditor : Form
    {
        public CharactorEditor()
        {
            comboBox1.DataSource = Enum.GetNames(typeof(RaceType));


            InitializeComponent();
        }
    }
}
