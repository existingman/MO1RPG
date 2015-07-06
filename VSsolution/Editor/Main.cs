using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MO1.Editor;
using MO1.Definitions;
using MO1.Tech;
using MO1.Content;

namespace Editor
{
    public partial class Main : Form
    {
        ImageList TerrainList;
        ImageList PropList;
        ImageList EntityList;
        PictureBox[,] board;
        private const int boardSize = 15;
        public Main()
        {
            Data.Initialise();
            Data.Load();
            InitializeComponent();
            board = new PictureBox[boardSize, boardSize];
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    board[x, y] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(board[x, y])).BeginInit();
                    board[x, y].Image = global::Editor.Properties.Resources.wall;
                    board[x, y].Margin = new System.Windows.Forms.Padding(0);
                    board[x, y].Name = "picturebox" + x.ToString() + "," + y.ToString();
                    board[x, y].Size = new System.Drawing.Size(50, 50);
                    board[x, y].Location = new Point(x * 50, y * 50);
                    this.panel.Controls.Add(board[x, y]);
                    board[x, y].MouseUp += board_Click;

                }
            }
            List<Image> temp = new List<Image>();
            foreach(Terrain t in Data.Terrains)
            {
                temp.Add(ImageData.Images[ImageType.terrains][t.imageRef1]);
            }
            TerrainList = new ImageList(7, 2, temp, new Point(0, 0), this.tabControl1.TabPages[0]);
            TerrainList.UserInput += select;

            temp = new List<Image>();
            foreach (Prop p in Data.Props)
            {
                temp.Add(ImageData.Images[ImageType.props][p.imageRef1]);
            }
            PropList = new ImageList(7, 2, temp, new Point(0, 0), this.tabControl1.TabPages[1]);
            PropList.UserInput += select;

            temp = new List<Image>();
            foreach (Entity e in Data.Entities)
            {
                temp.Add(ImageData.Images[ImageType.entities][e.imageRef1]);
            }
            EntityList = new ImageList(7, 2, temp, new Point(0, 0), this.tabControl1.TabPages[2]);
            EntityList.UserInput += select;
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
            Data.Load();
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

        
        ImageType seltype;
        int objectRef;
        int objectRef2;
        public void select(int image, ImageList l)
        {
            if (objectRef != null)
            {
                objectRef2 = objectRef;
                pictureBox2.Image = pictureBox1.Image;
            }
            objectRef = image;
            if (l.Equals(TerrainList))
            {
                seltype = ImageType.terrains;
                pictureBox1.Image = ImageData.Images[seltype][Data.Terrains[objectRef].imageRef1];
            }
            if (l.Equals(PropList))
            {
                seltype = ImageType.props;
                pictureBox1.Image = ImageData.Images[seltype][Data.Props[objectRef].imageRef1];
            }
            if (l.Equals(EntityList))
            {
                seltype = ImageType.entities;
                pictureBox1.Image = ImageData.Images[seltype][Data.Entities[objectRef].imageRef1];
            }
        }

        bool seccondClick = false;
        Coord FirstCoord;
        private void board_Click(object sender, EventArgs e)
        {
            Point target = panel.PointToClient(Form.MousePosition);
            int xTarg = target.X / 50 + hScrollBar.Value;
            int yTarg = target.Y / 50 + vScrollBar.Value;
            int zTarg = (int)zLevelControl.Value;
            if (radioButton1.Checked)
            {
                Map.Apply(seltype, objectRef, xTarg, yTarg, zTarg);
            }

            if (radioButton2.Checked || radioButton3.Checked)
            {
                if(seccondClick)
                {
                    Coord seccondCoord = new Coord(xTarg, yTarg, zTarg);
                    for(int x = Math.Min(FirstCoord.X , seccondCoord.X); x <= Math.Max(FirstCoord.X , seccondCoord.X); x++)
                    {
                        for(int y = Math.Min(FirstCoord.Y , seccondCoord.Y); y <= Math.Max(FirstCoord.Y , seccondCoord.Y); y++)
                        { 
                            for (int z = Math.Min(FirstCoord.Z, seccondCoord.Z); z <= Math.Max(FirstCoord.Z, seccondCoord.Z); z++)
                            {
                                Map.Apply(seltype, objectRef, x, y, z);
                            }
                        }
                    }
                    if (radioButton3.Checked)
                    {
                        for (int x = Math.Min(FirstCoord.X, seccondCoord.X); x <= Math.Max(FirstCoord.X, seccondCoord.X); x++)
                        {
                            for (int z = Math.Min(FirstCoord.Z, seccondCoord.Z); z <= Math.Max(FirstCoord.Z, seccondCoord.Z); z++)
                            {
                                Map.Apply(seltype, objectRef2, x, FirstCoord.Y, z);
                                Map.Apply(seltype, objectRef2, x, seccondCoord.Y, z);
                            } 
                        }
                        for (int y = Math.Min(FirstCoord.Y, seccondCoord.Y); y <= Math.Max(FirstCoord.Y, seccondCoord.Y); y++)
                        {
                            for (int z = Math.Min(FirstCoord.Z, seccondCoord.Z); z <= Math.Max(FirstCoord.Z, seccondCoord.Z); z++)
                            {
                                Map.Apply(seltype, objectRef2, FirstCoord.X, y, z);
                                Map.Apply(seltype, objectRef2, seccondCoord.X, y, z);
                            }
                        }
                    }
                    seccondClick = false;
                }
                else
                {
                    FirstCoord = new Coord(xTarg, yTarg, zTarg);
                    seccondClick = true;
                }
            }


            Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Map.Intialise();
            vScrollBar.Maximum = Map.XSize - boardSize - 1;
            hScrollBar.Maximum = Map.YSize - boardSize - 1;
            zLevelControl.Maximum = Map.ZSize - 1;
        }

        public void Refresh()
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    Tile temp =  Map.Tile[hScrollBar.Value + x, vScrollBar.Value + y, (int)zLevelControl.Value];
                    if(temp.TerrainRef == -1)
                    {
                        board[x, y].Image = null;
                    }
                    else
                    {
                        board[x, y].Image = ImageData.Images[ImageType.terrains][Data.Terrains[temp.TerrainRef].imageRef1];
                    }
                }
            }
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Refresh();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Refresh();
        }

        private void zLevelControl_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }




    }
}
