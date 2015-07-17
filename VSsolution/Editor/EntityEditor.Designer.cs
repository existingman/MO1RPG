namespace MO1.Editor
{
    partial class EntityEditor
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.listSelector1 = new MO1.Editor.UserControls.ListSelector();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(253, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.AllowDrop = true;
            this.propertyGrid1.Location = new System.Drawing.Point(12, 122);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(362, 245);
            this.propertyGrid1.TabIndex = 4;
            // 
            // listSelector1
            // 
            this.listSelector1.EntityType = null;
            this.listSelector1.Location = new System.Drawing.Point(12, 12);
            this.listSelector1.Name = "listSelector1";
            this.listSelector1.Size = new System.Drawing.Size(221, 90);
            this.listSelector1.SrcList = null;
            this.listSelector1.TabIndex = 0;
            // 
            // EntityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 481);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listSelector1);
            this.Name = "EntityEditor";
            this.Text = "EntityEditor";
            this.Load += new System.EventHandler(this.EntityEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ListSelector listSelector1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}