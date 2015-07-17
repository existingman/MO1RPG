using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MO1.Content;
using MO1.Definitions;

namespace MO1.Editor
{
    public delegate void BoadClick(int x, int y, int z);
    public class Board
    {
        public event BoadClick UserInput; 

        //public PictureBox[,] terrains;
        public PictureBox[,] props;
        public PictureBox[,] entities;
        public HScrollBar hScrollBar;
        public VScrollBar vScrollBar;
        public NumericUpDown zLevelControl;
        private Control _owner;
        private int boardSize;
        public Board(Control owner, int size)
        {
            _owner = owner;
            boardSize = size;
            //terrains = new PictureBox[boardSize, boardSize];
            props = new PictureBox[boardSize, boardSize];
            entities = new PictureBox[boardSize, boardSize];

            this.zLevelControl = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.zLevelControl)).BeginInit();
            this.zLevelControl.Location = new System.Drawing.Point(50 * size - 27, 50 * size);
            this.zLevelControl.Name = "zLevelControl";
            this.zLevelControl.Size = new System.Drawing.Size(47, 20);
            this.zLevelControl.TabIndex = 0;
            this.zLevelControl.ValueChanged += new System.EventHandler(this.zLevelControl_ValueChanged);
            _owner.Controls.Add(zLevelControl);
            ((System.ComponentModel.ISupportInitialize)(this.zLevelControl)).EndInit();

            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            //((System.ComponentModel.ISupportInitialize)(this.hScrollBar)).BeginInit();
            this.hScrollBar.Location = new System.Drawing.Point(0, 50 * size);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(50 * (size - 1), 17);
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            //((System.ComponentModel.ISupportInitialize)(this.hScrollBar)).EndInit();
            _owner.Controls.Add(hScrollBar);

            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            //((System.ComponentModel.ISupportInitialize)(this.vScrollBar)).BeginInit();
            this.vScrollBar.Location = new System.Drawing.Point(50 * size, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 50 * size);
            this.vScrollBar.TabIndex = 2;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            //((System.ComponentModel.ISupportInitialize)(this.vScrollBar)).EndInit();
            _owner.Controls.Add(vScrollBar);

            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    /*
                    terrains[x, y] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(terrains[x, y])).BeginInit();
                    terrains[x, y].Image = global::MO1.Editor.Properties.Resources.wall;
                    terrains[x, y].Margin = new System.Windows.Forms.Padding(0);
                    terrains[x, y].Name = "picturebox" + x.ToString() + "," + y.ToString();
                    terrains[x, y].Size = new System.Drawing.Size(50, 50);
                    terrains[x, y].Location = new Point(x * 50, y * 50);
                    _owner.Controls.Add(terrains[x, y]);
                    terrains[x, y].MouseUp += board_Click;
                     */

                    props[x, y] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(props[x, y])).BeginInit();
                    props[x, y].Image = global::MO1.Editor.Properties.Resources.wall;
                    props[x, y].Margin = new System.Windows.Forms.Padding(0);
                    props[x, y].Name = "picturebox" + x.ToString() + "," + y.ToString();
                    props[x, y].Size = new System.Drawing.Size(50, 50);
                    props[x, y].Location = new Point(x * 50, y * 50);
                    _owner.Controls.Add(props[x, y]);
                    props[x, y].MouseUp += board_Click;

                    entities[x, y] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(entities[x, y])).BeginInit();
                    entities[x, y].Image = global::MO1.Editor.Properties.Resources.wall;
                    entities[x, y].Margin = new System.Windows.Forms.Padding(0);
                    entities[x, y].Name = "picturebox" + x.ToString() + "," + y.ToString();
                    entities[x, y].Size = new System.Drawing.Size(50, 50);
                    entities[x, y].Location = new Point(x * 50, y * 50);
                    _owner.Controls.Add(entities[x, y]);
                    entities[x, y].MouseUp += board_Click;

                    
                }
            }

            initialise();
        }

        private void board_Click(object sender, EventArgs e)
        {
            Point target = _owner.PointToClient(Form.MousePosition);
            int xTarg = target.X / 50 + hScrollBar.Value;
            int yTarg = target.Y / 50 + vScrollBar.Value;
            int zTarg = (int)zLevelControl.Value;
            UserInput(xTarg, yTarg, zTarg);

        }

        public void Refresh()
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    Tile temp = Map.Tile[hScrollBar.Value + x, vScrollBar.Value + y, (int)zLevelControl.Value];
                    if (temp.TerrainRef == -1)
                    {
                        //terrains[x, y].Image = ImageData.BlueTint;
                        props[x, y].BackgroundImage = ImageData.BlueTint;
                    }
                    else
                    {
                        //terrains[x, y].Image = ImageData.Images[ImageType.terrains][Data.Terrains[temp.TerrainRef].imageRef1];
                        props[x, y].BackgroundImage = ImageData.Images[ImageType.terrains][Data.Terrains[temp.TerrainRef].imageRef1];
                    }

                    if (temp.PropRef == -1)
                    {
                        props[x, y].Image = null;
                    }
                    else
                    {
                        props[x, y].Image = ImageData.Images[ImageType.props][Data.Props[temp.PropRef].imageRef1];
                    }

                    if (temp.Entity == null)
                    {
                        entities[x, y].Image = null;
                    }
                    else
                    {
                        //entities[x, y].Image = ImageData.Images[ImageType.entities][Data.Entities[temp.EntityRef].imageRef1];
                        //display entity image;
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

        public void initialise()
        {
            vScrollBar.Maximum = Map.XSize - boardSize - 1;
            hScrollBar.Maximum = Map.YSize - boardSize - 1;
            zLevelControl.Maximum = Map.ZSize - 1;
            //Refresh();
        }

    }
}
