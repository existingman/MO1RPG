using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MO1.Definitions.Dialogues;
using MO1.Definitions;

namespace MO1.Editor.UserControls
{

    public partial class JunctureControl : UserControl
    {
        public Juncture TargetJuncture;
        public Conversation TargetConversation;
        public Dialogue TargetDialogue;

        private List<Control> _replyControls;
        public JunctureControl()
        {
            InitializeComponent();
            _replyControls = new List<Control>();
        }
        public JunctureControl(Juncture junc)
        {
            TargetJuncture = junc;
            InitializeComponent();
        }

        public void Set (Juncture j, Conversation c, Dialogue d)
        {
            TargetJuncture = j;
            TargetConversation = c;
            TargetDialogue = d;
            Refresh();
        }
        public void Set(Juncture j, Conversation c)
        {
            TargetJuncture = j;
            TargetConversation = c;
            TargetDialogue = null;
            Refresh();
        }

        public const int itemheight = 60;
        public void Refresh()
        {
            textBox1.Text = TargetJuncture.Speach;

            foreach (Control r in _replyControls)
            {
                r.Dispose();
            }
            _replyControls = new List<Control>();
            foreach(Reply r in TargetJuncture.Replies)
            {
                ReplyControl temp;
                if (TargetDialogue != null)
                {
                    temp = new ReplyControl(r, TargetJuncture, TargetConversation, TargetDialogue);
                }
                else
                {
                    temp = new ReplyControl(r, TargetJuncture, TargetConversation);
                }
                
                _replyControls.Add(temp);
                panel1.Controls.Add(temp);
                
          
            }
            Button button = new Button();
            button.Text = "Add";
            button.Click += add;

            _replyControls.Add(button);
            panel1.Controls.Add(button);

            int totalheight = _replyControls.Count * itemheight;
            if (totalheight > panel1.Height)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Maximum = totalheight - panel1.Height;
                vScrollBar1.Value = 0;
            }
            else
            {
                vScrollBar1.Visible = false;
            }
            for(int y = 0; y < _replyControls.Count; y++)
            {
                _replyControls[y].Location = new Point(0, y * itemheight);
            }

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            for (int y = 0; y < _replyControls.Count; y++)
            {
                _replyControls[y].Location = new Point(0, y * itemheight - vScrollBar1.Value);
            }
        }


        public void add(object sender, EventArgs e)
        {
            TargetJuncture.Replies.Add(new Reply());
            Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TargetJuncture.Speach = textBox1.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void JunctureControl_Load(object sender, EventArgs e)
        {

        }

    }
}
