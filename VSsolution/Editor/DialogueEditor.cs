using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using MO1.Content;
using MO1.Definitions;
using MO1.Definitions.Dialogues;

namespace MO1.Editor
{
    public partial class DialogueEditor : Form
    {
        public DialogueEditor()
        {
            InitializeComponent();
        }

        private void DialogueEditor_Load(object sender, EventArgs e)
        {
            if (Data.Dialogues.Count == 0) Data.Dialogues.Add( new Dialogue() ); 
            listSelector1.Init(Data.Dialogues, typeof(Dialogue));
            listSelector1.selection += DialogueChange;
            
            if (Data.Dialogues[listSelector1.Value].Conversations.Count == 0) Data.Dialogues[listSelector1.Value].Conversations.Add( new Conversation() );
            listSelector2.Init(Data.Dialogues[listSelector1.Value].Conversations, typeof(Conversation));
            listSelector2.selection += ConversationChange;
            
            if (Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures.Count == 0) Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures.Add(new Juncture());
            listSelector3.Init(Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures, typeof(Juncture));
            listSelector3.selection += JunctureChange;

            junctureControl1.TargetDialogue = Data.Dialogues[listSelector1.Value];
            junctureControl1.TargetConversation = Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value];
            junctureControl1.TargetJuncture = Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures[listSelector3.Value];
            junctureControl1.Refresh();
        }

        public void DialogueChange( int i )
        {
            
            if (Data.Dialogues[listSelector1.Value].Conversations.Count == 0) Data.Dialogues[listSelector1.Value].Conversations.Add(new Conversation());
            listSelector2.Init(Data.Dialogues[listSelector1.Value].Conversations, typeof(Conversation));
            
            if (Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures.Count == 0) Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures.Add(new Juncture());
            listSelector3.Init(Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures, typeof(Juncture));

            junctureControl1.TargetDialogue = Data.Dialogues[i];
            junctureControl1.TargetConversation = Data.Dialogues[i].Conversations[listSelector2.Value];
            junctureControl1.TargetJuncture = Data.Dialogues[i].Conversations[listSelector2.Value].Junctures[listSelector3.Value];
            junctureControl1.Refresh();
        }

        public void ConversationChange( int i )
        {
            if (Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures.Count == 0) Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures.Add(new Juncture());
            listSelector3.Init(Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures, typeof(Juncture));

            junctureControl1.TargetConversation = Data.Dialogues[listSelector1.Value].Conversations[i];
            junctureControl1.TargetJuncture = Data.Dialogues[listSelector1.Value].Conversations[i].Junctures[listSelector3.Value];
            junctureControl1.Refresh();
        }

        public void JunctureChange( int i )
        {
            junctureControl1.TargetJuncture = Data.Dialogues[listSelector1.Value].Conversations[listSelector2.Value].Junctures[i];
            junctureControl1.Refresh();
        }

        private void listSelector1_Load(object sender, EventArgs e)
        {

        }


    }
}
