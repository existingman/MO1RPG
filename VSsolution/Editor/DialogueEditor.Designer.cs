namespace MO1.Editor
{
    partial class DialogueEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.junctureControl1 = new MO1.Editor.UserControls.JunctureControl();
            this.listSelector3 = new MO1.Editor.UserControls.ListSelector();
            this.listSelector2 = new MO1.Editor.UserControls.ListSelector();
            this.listSelector1 = new MO1.Editor.UserControls.ListSelector();
            this.SuspendLayout();
            // 
            // junctureControl1
            // 
            this.junctureControl1.Location = new System.Drawing.Point(12, 108);
            this.junctureControl1.Name = "junctureControl1";
            this.junctureControl1.Size = new System.Drawing.Size(602, 341);
            this.junctureControl1.TabIndex = 3;
            // 
            // listSelector3
            // 
            this.listSelector3.EntityType = null;
            this.listSelector3.Location = new System.Drawing.Point(457, 12);
            this.listSelector3.Name = "listSelector3";
            this.listSelector3.Size = new System.Drawing.Size(222, 90);
            this.listSelector3.SrcList = null;
            this.listSelector3.TabIndex = 2;
            // 
            // listSelector2
            // 
            this.listSelector2.EntityType = null;
            this.listSelector2.Location = new System.Drawing.Point(227, 12);
            this.listSelector2.Name = "listSelector2";
            this.listSelector2.Size = new System.Drawing.Size(224, 90);
            this.listSelector2.SrcList = null;
            this.listSelector2.TabIndex = 1;
            // 
            // listSelector1
            // 
            this.listSelector1.EntityType = null;
            this.listSelector1.Location = new System.Drawing.Point(2, 12);
            this.listSelector1.Name = "listSelector1";
            this.listSelector1.Size = new System.Drawing.Size(228, 90);
            this.listSelector1.SrcList = null;
            this.listSelector1.TabIndex = 0;
            this.listSelector1.Load += new System.EventHandler(this.listSelector1_Load);
            // 
            // DialogueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 455);
            this.Controls.Add(this.junctureControl1);
            this.Controls.Add(this.listSelector3);
            this.Controls.Add(this.listSelector2);
            this.Controls.Add(this.listSelector1);
            this.Name = "DialogueEditor";
            this.Text = "DialogueEditor";
            this.Load += new System.EventHandler(this.DialogueEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ListSelector listSelector1;
        private UserControls.ListSelector listSelector2;
        private UserControls.ListSelector listSelector3;
        private UserControls.JunctureControl junctureControl1;
    }
}