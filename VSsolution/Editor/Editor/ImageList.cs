using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MO1;
using MO1.Definitions;
using MO1.Content;


namespace MO1.Editor
{
    public delegate void refDelegate(int _ref, ImageList sender);
    public class ImageList
    {
        public event refDelegate UserInput;

        private PictureBox[,] _board;
        private HScrollBar _scrollbar;
        private Panel _panel;
        private List<Image> _images;
        private int _x;
        private int _y;
        private Point _position;
        private Control _owner;

        public ImageList(int x, int y, List<IThing> list, Point position, Control owner)
        {
            _x = x;
            _y = y;
            _images = new List<Image>();
            foreach(IThing i in list)
            {
                _images.Add(ImageData.Images[i.Type][i.DefaultImageRef]);
            }
            _position = position;
            _owner = owner;
            make();
        }

        public ImageList(int x, int y, List<Image> images, Point position, Control owner)
        {
            _x = x;
            _y = y;
            _images = images;
            _position = position;
            _owner = owner;
            make();
        }

        private void make()
        {
            _panel = new Panel();
            //((System.ComponentModel.ISupportInitialize)(_panel)).BeginInit();
            _panel.Location = _position;
            _panel.Name = "panel";
            _panel.Size = new Size(_x * 50, _y * 50);
            _panel.TabIndex = 0;
            _owner.Controls.Add(_panel);
            _panel.MouseUp += _panel_MouseUp;

            _board = new PictureBox[_x, _y];
            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    _board[x, y] = new PictureBox();
                    //((System.ComponentModel.ISupportInitialize)(_board[x, y])).BeginInit();
                    _board[x, y].Image = global::MO1.Editor.Properties.Resources.wall;
                    _board[x, y].Margin = new System.Windows.Forms.Padding(0);
                    _board[x, y].Name = "picturebox" + x.ToString() + "," + y.ToString();
                    _board[x, y].Size = new System.Drawing.Size(50, 50);
                    _board[x, y].Location = new Point(x * 50, y * 50);
                    _board[x, y].MouseUp += _panel_MouseUp;
                    _panel.Controls.Add(_board[x, y]);
                }
            }

            _scrollbar = new HScrollBar();
            //((System.ComponentModel.ISupportInitialize)(_scrollbar)).BeginInit();
            _scrollbar.Margin = new System.Windows.Forms.Padding(0);
            _scrollbar.Name = "scrollBar";
            _scrollbar.Size = new System.Drawing.Size(_x * 50, 20);
            _scrollbar.Location = new Point(_position.X, _position.Y + _y * 50);
            _owner.Controls.Add(_scrollbar);
            _scrollbar.ValueChanged += _scrollbar_ValueChanged;

            update();
        }

        void _panel_MouseUp(object sender, MouseEventArgs e)
        {
            Point target = _panel.PointToClient(Form.MousePosition);
            int xTarg = target.X / 50;
            int yTarg = target.Y / 50;
            if (xTarg == _x -1 && yTarg == _y -1)
            {
                UserInput(-1, this);
            }
            else
            {
                int number = (xTarg + _scrollbar.Value) * _y + yTarg;
                if (UserInput != null && number < _images.Count) UserInput(number, this);
            }
        }

        void _scrollbar_ValueChanged(object sender, EventArgs e)
        {
            update();
        }


        private void update()
        {
            if(_images.Count > _x*_y)
            {
                _scrollbar.Maximum = (int)Math.Ceiling((decimal)((_images.Count - _x * _y)/_y));
                _scrollbar.Enabled = true;
            }
            else
            {
                _scrollbar.Maximum = 0;
                _scrollbar.Enabled = false;
            }
            int current = _scrollbar.Value / _y;
            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    if (current < _images.Count)
                    {
                        _board[x, y].Image = _images[current];
                    }
                    else
                    {
                        _board[x, y].Image = null;
                    }
                    current++;
                }
            }
            _board[_x - 1, _y - 1].Image = ImageData.No;
        }


    }
}
