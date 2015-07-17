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
using MO1.Editor;
using MO1.Content;

namespace MO1.Editor
{
    public partial class TerrainEditor : Form
    {
        ImageList _list;
        public TerrainEditor()
        {
            InitializeComponent();
            _list = new ImageList(5, 5, ImageData.Images[ImageType.terrains], new Point(290, 0), this);
            _list.UserInput += ImageInput;
            textBox1.TextChanged += textBox1_TextChanged;
            if (Data.Terrains.Count > 1)
            {
                hScrollBar1.Maximum = Data.Terrains.Count - 1;
            }
            else
            {
                hScrollBar1.Enabled = false;
            }
            comboBox1.DataSource = Enum.GetNames(typeof(TerrainType));
            this.ShowDialog();
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            Data.Terrains[hScrollBar1.Value].Name = textBox1.Text;
        }

        public void ImageInput(int iRef, ImageList il)
        {
            Data.Terrains[hScrollBar1.Value].imageRef1 = iRef;
            pictureBox1.Image = MO1.Content.ImageData.Images[ImageType.terrains][iRef];
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Data.Terrains.Add(new Terrain());
            hScrollBar1.Maximum = Data.Terrains.Count -1;
            hScrollBar1.Value = Data.Terrains.Count - 1;
            hScrollBar1.Enabled = true;
            textBox1.Text = "no name";

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBar1.Value.ToString();
            textBox1.Text = Data.Terrains[hScrollBar1.Value].Name;
            pictureBox1.Image = MO1.Content.ImageData.Images[ImageType.terrains][Data.Terrains[hScrollBar1.Value].imageRef1];
            comboBox1.SelectedIndex = (int)Data.Terrains[hScrollBar1.Value].TerrainType;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Terrains[hScrollBar1.Value].TerrainType = (TerrainType)comboBox1.SelectedIndex;
        }

        private void TerrainEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
