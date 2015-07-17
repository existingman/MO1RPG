using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MO1.Definitions.Dialogues;
using MO1.Definitions.Charactors;
using MO1.Definitions;

namespace MO1.Editor.UserControls
{
    public partial class ReplyControl : UserControl
    {
        public Reply Target;
        public Juncture TargetJuncture;
        public Conversation TargetConversation;
        public Dialogue TargetDialogue;

        public ReplyControl(Reply target, Juncture juncture, Conversation convo)
        {
            Target = target;
            TargetJuncture = juncture;
            TargetConversation = convo;
            TargetDialogue = null;
            InitializeComponent();
            refresh();
        }
        public ReplyControl(Reply target, Juncture juncture, Conversation convo, Dialogue d)
        {
            Target = target;
            TargetJuncture = juncture;
            TargetConversation = convo;
            TargetDialogue = d;
            InitializeComponent();
            refresh();
        }

        private void refresh()
        {
            textBox1.Text = Target.Text;
            numericUpDown1.Value = Target.Ref;
            foreach(ReplyLinkType t in Enum.GetValues(typeof(ReplyLinkType)))
            {
                comboBox1.Items.Add(t);
            }
            comboBox1.SelectedIndex = ((int)(Target.LinkType));
            checkBox1.Checked = Target.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Target.Ref = (int)numericUpDown1.Value;
            switch(Target.LinkType)
            {
                case ReplyLinkType.Conversation:
                    textBox2.Text = TargetDialogue.Conversations[Target.Ref].Name + "...    " +  TargetDialogue.Conversations[Target.Ref].Junctures[0].Speach;
                break;
                case ReplyLinkType.End:
                    textBox2.Text = "(end dialogue)";
                break;
                case ReplyLinkType.Juncture:
                    textBox2.Text = TargetConversation.Junctures[Target.Ref].Speach;
                break;
                case ReplyLinkType.Quest:
                    textBox2.Text = MO1.Content.Data.Quests[Target.Ref].Name + "...   " + MO1.Content.Data.Quests[Target.Ref].IntialConversation.Junctures[0].Speach;
                break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TargetJuncture.Replies.Remove(this.Target);
            this.Dispose();
        }

        private void ReplyControl_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Target.Text = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Target.LinkType = (ReplyLinkType)(comboBox1.SelectedIndex);
            //Target.LinkType = (ReplyLinkType.Juncture);

            switch (Target.LinkType)
            {
                case ReplyLinkType.Conversation:
                    numericUpDown1.Enabled = true;
                    numericUpDown1.Maximum = TargetDialogue.Conversations.Count - 1;
                    break;
                case ReplyLinkType.End:
                    numericUpDown1.Enabled = false;
                    break;
                case ReplyLinkType.Juncture:
                    numericUpDown1.Enabled = true;
                    numericUpDown1.Maximum = TargetConversation.Junctures.Count - 1;                    
                    break;
                case ReplyLinkType.Quest:
                    numericUpDown1.Enabled = true;
                    numericUpDown1.Maximum = MO1.Content.Data.Quests.Count - 1;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Target.Enabled = checkBox1.Checked;
        }
    }
}
