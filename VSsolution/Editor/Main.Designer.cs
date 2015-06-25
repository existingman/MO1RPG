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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TerrainTab = new System.Windows.Forms.TabPage();
            this.PropTab = new System.Windows.Forms.TabPage();
            this.EntityTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zLevelControl)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.Load,
            this.newToolStripMenuItem});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(152, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(152, 22);
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
            this.getImagesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.getImagesToolStripMenuItem.Text = "Get Images";
            this.getImagesToolStripMenuItem.Click += new System.EventHandler(this.getImagesToolStripMenuItem_Click);
            // 
            // terrainEditorToolStripMenuItem
            // 
            this.terrainEditorToolStripMenuItem.Name = "terrainEditorToolStripMenuItem";
            this.terrainEditorToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.terrainEditorToolStripMenuItem.Text = "Terrain Editor";
            this.terrainEditorToolStripMenuItem.Click += new System.EventHandler(this.terrainEditorToolStripMenuItem_Click);
            // 
            // propsEditorToolStripMenuItem
            // 
            this.propsEditorToolStripMenuItem.Name = "propsEditorToolStripMenuItem";
            this.propsEditorToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.propsEditorToolStripMenuItem.Text = "Props Editor";
            // 
            // entityEditorToolStripMenuItem
            // 
            this.entityEditorToolStripMenuItem.Name = "entityEditorToolStripMenuItem";
            this.entityEditorToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
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
            this.zLevelControl.ValueChanged += new System.EventHandler(this.zLevelControl_ValueChanged);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Location = new System.Drawing.Point(15, 577);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(720, 17);
            this.hScrollBar.TabIndex = 9;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Location = new System.Drawing.Point(768, 54);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 523);
            this.vScrollBar.TabIndex = 10;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(15, 54);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(750, 520);
            this.panel.TabIndex = 11;
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TerrainTab);
            this.tabControl1.Controls.Add(this.PropTab);
            this.tabControl1.Controls.Add(this.EntityTab);
            this.tabControl1.Location = new System.Drawing.Point(788, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 167);
            this.tabControl1.TabIndex = 14;
            // 
            // TerrainTab
            // 
            this.TerrainTab.Location = new System.Drawing.Point(4, 22);
            this.TerrainTab.Name = "TerrainTab";
            this.TerrainTab.Padding = new System.Windows.Forms.Padding(3);
            this.TerrainTab.Size = new System.Drawing.Size(370, 141);
            this.TerrainTab.TabIndex = 0;
            this.TerrainTab.Text = "Terrains";
            this.TerrainTab.UseVisualStyleBackColor = true;
            this.TerrainTab.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // PropTab
            // 
            this.PropTab.Location = new System.Drawing.Point(4, 22);
            this.PropTab.Name = "PropTab";
            this.PropTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropTab.Size = new System.Drawing.Size(370, 108);
            this.PropTab.TabIndex = 1;
            this.PropTab.Text = "Props";
            this.PropTab.UseVisualStyleBackColor = true;
            // 
            // EntityTab
            // 
            this.EntityTab.Location = new System.Drawing.Point(4, 22);
            this.EntityTab.Name = "EntityTab";
            this.EntityTab.Size = new System.Drawing.Size(370, 108);
            this.EntityTab.TabIndex = 2;
            this.EntityTab.Text = "Entities";
            this.EntityTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(788, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(844, 223);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Click";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(844, 246);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(37, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Fill";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(844, 269);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(43, 17);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.Text = "Box";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(788, 283);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 603);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TerrainTab;
        private System.Windows.Forms.TabPage PropTab;
        private System.Windows.Forms.TabPage EntityTab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

