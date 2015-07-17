namespace MO1.Editor
{
    partial class NewMap
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
            this.XControl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.YControl = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ZControl = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.XControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZControl)).BeginInit();
            this.SuspendLayout();
            // 
            // XControl
            // 
            this.XControl.Location = new System.Drawing.Point(12, 29);
            this.XControl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XControl.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.XControl.Name = "XControl";
            this.XControl.Size = new System.Drawing.Size(52, 20);
            this.XControl.TabIndex = 0;
            this.XControl.Tag = "";
            this.XControl.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Size";
            // 
            // YControl
            // 
            this.YControl.Location = new System.Drawing.Point(70, 29);
            this.YControl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YControl.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.YControl.Name = "YControl";
            this.YControl.Size = new System.Drawing.Size(52, 20);
            this.YControl.TabIndex = 2;
            this.YControl.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z Size";
            // 
            // ZControl
            // 
            this.ZControl.Location = new System.Drawing.Point(128, 29);
            this.ZControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ZControl.Name = "ZControl";
            this.ZControl.Size = new System.Drawing.Size(52, 20);
            this.ZControl.TabIndex = 4;
            this.ZControl.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 90);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ZControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XControl);
            this.Name = "NewMap";
            this.Text = "NewMap";
            ((System.ComponentModel.ISupportInitialize)(this.XControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown XControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown YControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ZControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}