namespace MO1.Editor
{
    partial class testtool
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
            this.genericListFillerControl1 = new MO1.Editor.UserControls.genericListFillerControl();
            this.SuspendLayout();
            // 
            // genericListFillerControl1
            // 
            this.genericListFillerControl1.ListType = null;
            this.genericListFillerControl1.Location = new System.Drawing.Point(1, 1);
            this.genericListFillerControl1.Name = "genericListFillerControl1";
            this.genericListFillerControl1.Size = new System.Drawing.Size(354, 534);
            this.genericListFillerControl1.SrcList = null;
            this.genericListFillerControl1.TabIndex = 0;
            // 
            // testtool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 515);
            this.Controls.Add(this.genericListFillerControl1);
            this.Name = "testtool";
            this.Text = "testtool";
            this.Load += new System.EventHandler(this.testtool_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.genericListFillerControl genericListFillerControl1;
    }
}