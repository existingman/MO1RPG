using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MO1VSSolution.Definitions;
using MO1VSSolution.Editor;

namespace Editor
{
    public partial class TerrainEditor : Form
    {
        PictureBox[,] board = new PictureBox[5, 5];
        public TerrainEditor()
        {
            InitializeComponent();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    board[x, y] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(board[x, y])).BeginInit();
                    board[x, y].Image = global::Editor.Properties.Resources.wall;
                    board[x, y].Margin = new System.Windows.Forms.Padding(0);
                    board[x, y].Name = "picturebox" + x.ToString() + "," + y.ToString();
                    board[x, y].Size = new System.Drawing.Size(50, 50);
                    board[x, y].Location = new Point(x * 50, y * 50);
                    this.panel.Controls.Add(board[x, y]);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            Data.Terrains.Add(new Terrain());
            hScrollBar1.Maximum = Data.Terrains.Count;
            hScrollBar1.Value = Data.Terrains.Count;

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBar1.Value.ToString();
            textBox1.Text = Data.Terrains[hScrollBar1.Value].name;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch(comboBox1.SelectedIndex)
            //Data.Terrains[hScrollBar1.Value].Type = comboBox1.SelectedIndex
        }
    }
}
