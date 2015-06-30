using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MO1VSSolution.Editor;

namespace Editor
{
    public partial class Main : Form
    {
        PictureBox[,] board = new PictureBox[10, 10]; 
        public Main()
        {
            Data.Initialise();
            InitializeComponent();
            for(int x = 0; x < 10; x++)
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

        private void TerrainEditor_Click(object sender, EventArgs e)
        {
            (new TerrainEditor()).ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Load_Click(object sender, EventArgs e)
        {
            //Data.Load();
            ImageData.LoadImages();
            for (int i = 0; i < ImageData.Images[ImageType.terrains].Count; i++)
            {
                if (i < 10) board[i, 0].Image = ImageData.Images[ImageType.terrains][i];
            }
        }

        private void getImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageData.Get();
            for (int i = 0; i < ImageData.Images[ImageType.terrains].Count; i++)
            {
                if(i < 10) board[i, 1].Image = ImageData.Images[ImageType.terrains][i];
            }
        }

        private void panel_MouseClick(object sender, EventArgs e)
        {

        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((decimal)MousePosition.X / 50);
            int y = (int)Math.Floor((decimal)MousePosition.Y / 50);
            label1.Text = x.ToString() + "," + y.ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Data.Save();
        }

        private void terrainEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TerrainEditor();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}
