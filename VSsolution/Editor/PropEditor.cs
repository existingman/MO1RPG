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
    public partial class PropEditor : Form
    {
        ImageList _list;
        public PropEditor()
        {
            InitializeComponent();
            _list = new ImageList(5, 5, ImageData.Images[ImageType.props], new Point(290, 0), this);
            _list.UserInput += ImageInput;
            textBox1.TextChanged += textBox1_TextChanged;
            if (Data.Props.Count > 1)
            {
                hScrollBar1.Maximum = Data.Props.Count - 1;
            }
            else
            {
                hScrollBar1.Enabled = false;
            }
            comboBox1.DataSource = Enum.GetNames(typeof(PropType));
            this.ShowDialog();
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            Data.Props[hScrollBar1.Value].Name = textBox1.Text;
        }

        public void ImageInput(int iRef, ImageList il)
        {
            if (radioButton1.Checked)
            {
                Data.Props[hScrollBar1.Value].imageRef1 = iRef;
                pictureBox1.Image = MO1.Content.ImageData.Images[ImageType.props][iRef];
            }
            else
            {
                Data.Props[hScrollBar1.Value].imageRef2 = iRef;
                pictureBox2.Image = MO1.Content.ImageData.Images[ImageType.props][iRef];
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Data.Props.Add(new Prop());
            hScrollBar1.Maximum = Data.Props.Count - 1;
            hScrollBar1.Value = Data.Props.Count - 1;
            hScrollBar1.Enabled = true;
            textBox1.Text = "no name";

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBar1.Value.ToString();
            textBox1.Text = Data.Props[hScrollBar1.Value].Name;
            pictureBox1.Image = MO1.Content.ImageData.Images[ImageType.props][Data.Props[hScrollBar1.Value].imageRef1];
            pictureBox2.Image = MO1.Content.ImageData.Images[ImageType.props][Data.Props[hScrollBar1.Value].imageRef2];
            comboBox1.SelectedIndex = (int)Data.Props[hScrollBar1.Value].proptype;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Props[hScrollBar1.Value].proptype = (PropType)comboBox1.SelectedIndex;
        }

        private void PropEditor_Load(object sender, EventArgs e)
        {
            this.ShowDialog();
        }
    }
}
