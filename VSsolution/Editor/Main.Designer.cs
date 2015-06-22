namespace Editor
{
    partial class Main
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Load = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripMenuItem();
            this.DataEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.getImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.zLevelControl = new System.Windows.Forms.NumericUpDown();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zLevelControl)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Edit,
            this.View,
            this.DataEntry,
            this.Tool,
            this.Help});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1178, 24);
            this.MainMenuStrip.TabIndex = 6;
            this.MainMenuStrip.Text = "MainMenuStrip";
            this.MainMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Load});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(100, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(100, 22);
            this.Load.Text = "Load";
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Edit
            // 
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(39, 20);
            this.Edit.Text = "Edit";
            // 
            // View
            // 
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(44, 20);
            this.View.Text = "View";
            // 
            // DataEntry
            // 
            this.DataEntry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getImagesToolStripMenuItem,
            this.terrainEditorToolStripMenuItem,
            this.propsEditorToolStripMenuItem,
            this.entityEditorToolStripMenuItem});
            this.DataEntry.Name = "DataEntry";
            this.DataEntry.Size = new System.Drawing.Size(73, 20);
            this.DataEntry.Text = "Data Entry";
            // 
            // getImagesToolStripMenuItem
            // 
            this.getImagesToolStripMenuItem.Name = "getImagesToolStripMenuItem";
            this.getImagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.getImagesToolStripMenuItem.Text = "Get Images";
            this.getImagesToolStripMenuItem.Click += new System.EventHandler(this.getImagesToolStripMenuItem_Click);
            // 
            // terrainEditorToolStripMenuItem
            // 
            this.terrainEditorToolStripMenuItem.Name = "terrainEditorToolStripMenuItem";
            this.terrainEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.terrainEditorToolStripMenuItem.Text = "Terrain Editor";
            this.terrainEditorToolStripMenuItem.Click += new System.EventHandler(this.terrainEditorToolStripMenuItem_Click);
            // 
            // propsEditorToolStripMenuItem
            // 
            this.propsEditorToolStripMenuItem.Name = "propsEditorToolStripMenuItem";
            this.propsEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.propsEditorToolStripMenuItem.Text = "Props Editor";
            // 
            // entityEditorToolStripMenuItem
            // 
            this.entityEditorToolStripMenuItem.Name = "entityEditorToolStripMenuItem";
            this.entityEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.entityEditorToolStripMenuItem.Text = "Entity Editor";
            // 
            // Tool
            // 
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(43, 20);
            this.Tool.Text = "Tool";
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(44, 20);
            this.Help.Text = "Help";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // zLevelControl
            // 
            this.zLevelControl.Location = new System.Drawing.Point(738, 577);
            this.zLevelControl.Name = "zLevelControl";
            this.zLevelControl.Size = new System.Drawing.Size(47, 20);
            this.zLevelControl.TabIndex = 8;
            // 
            // hScrollBar
            // 
            this.hScrollBar.Location = new System.Drawing.Point(15, 577);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(720, 17);
            this.hScrollBar.TabIndex = 9;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Location = new System.Drawing.Point(768, 54);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 523);
            this.vScrollBar.TabIndex = 10;
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(15, 54);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(750, 520);
            this.panel.TabIndex = 11;
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(785, 191);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(381, 17);
            this.hScrollBar1.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(788, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 134);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 108);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 603);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.zLevelControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "Main";
            this.Text = "Editor";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zLevelControl)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem View;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Load;
        private System.Windows.Forms.ToolStripMenuItem DataEntry;
        private System.Windows.Forms.ToolStripMenuItem Tool;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem getImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terrainEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propsEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entityEditorToolStripMenuItem;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown zLevelControl;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

