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

namespace MO1.Editor
{
    public partial class Main : Form
    {
        ImageList TerrainList;
        ImageList PropList;
        ImageList EntityList;
        Board Board;
        public Main()
        {
            
            InitializeComponent();

            Board = new MO1.Editor.Board(panel, 13);
            Board.UserInput += board_Click;
            Board.initialise();
            
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
            Map.Load();
            Board.Refresh();
        }

        private void getImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageData.Get();
        }

        private void panel_MouseClick(object sender, EventArgs e)
        {

        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((decimal)MousePosition.X / 50);
            int y = (int)Math.Floor((decimal)MousePosition.Y / 50);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Data.Save();
            Map.Save();
            PlayerFile.Save();
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
                if (objectRef > -1)
                {
                    pictureBox1.Image = ImageData.Images[seltype][Data.Terrains[objectRef].imageRef1];
                }
                else
                {
                    pictureBox1.Image = ImageData.No;
                }
            }
            if (l.Equals(PropList))
            {
                seltype = ImageType.props;
                if (objectRef > -1)
                {
                    pictureBox1.Image = ImageData.Images[seltype][Data.Props[objectRef].imageRef1];
                }
                else
                {
                    pictureBox1.Image = ImageData.No;
                }
            }
            if (l.Equals(EntityList))
            {
                seltype = ImageType.entities;
                if (objectRef > -1)
                {
                    pictureBox1.Image = ImageData.Images[seltype][Data.Entities[objectRef].imageRef1];
                }
                else
                {
                    pictureBox1.Image = ImageData.No;
                }
            }
        }

        bool seccondClick = false;
        Coord FirstCoord;
        Tile TargetTile;
        private void board_Click(int xTarg, int yTarg, int zTarg)
        {
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

            if(radioButton4.Checked)
            {
                TargetTile = Map.Tile[xTarg, yTarg, zTarg];
                if (tabControl1.SelectedIndex == 0)
                {
                    pictureBox3.Image = ImageData.Images[ImageType.terrains][Data.Terrains[TargetTile.TerrainRef].imageRef1];
                    propertyGrid1.SelectedObject = TargetTile;
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    if (TargetTile.PropRef != -1)
                    {
                        pictureBox3.Image = ImageData.Images[ImageType.props][Data.Props[TargetTile.PropRef].imageRef1];
                    }
                    propertyGrid1.SelectedObject = TargetTile;
                }
                if (tabControl1.SelectedIndex == 2)
                {
                    if (TargetTile.Entity != null)
                    {
                        propertyGrid1.SelectedObject = TargetTile.Entity;
                        if (TargetTile.Entity.GetType() == typeof(MO1.Definitions.Entities.Charactor))
                        {
                            inventoryControl1.Init(((MO1.Definitions.Entities.Charactor)(TargetTile.Entity)).Inventory);
                        }
                        else
                        {
                            inventoryControl1.Init();
                        }
                    }
                    else
                    {
                        propertyGrid1.SelectedObject = null;
                        inventoryControl1.Init();
                    }
                }

            }


            Board.Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();
            //folderBrowserDialog1
            //folderBrowserDialog1.SelectedPath;
            //new NewMap();
            
        }



        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void propsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PropEditor();
        }

        private void dialogueEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DialogueEditor().ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void entityEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EntityEditor().ShowDialog();
        }

        private void itemEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ItemEditor().ShowDialog();
        }

        private void testToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new testtool().ShowDialog();
        }






    }
}
