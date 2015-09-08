namespace MO1.Editor
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
            this.components = new System.ComponentModel.Container();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Load = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripMenuItem();
            this.DataEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.getImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogueEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TerrainTab = new System.Windows.Forms.TabPage();
            this.PropTab = new System.Windows.Forms.TabPage();
            this.EntityTab = new System.Windows.Forms.TabPage();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inventoryControl1 = new MO1.Editor.UserControls.InventoryControl();
            this.MainMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.MainMenuStrip.Size = new System.Drawing.Size(1362, 24);
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
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
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
            this.entityEditorToolStripMenuItem,
            this.playerEditorToolStripMenuItem,
            this.dialogueEditorToolStripMenuItem,
            this.itemEditorToolStripMenuItem});
            this.DataEntry.Name = "DataEntry";
            this.DataEntry.Size = new System.Drawing.Size(73, 20);
            this.DataEntry.Text = "Data Entry";
            // 
            // getImagesToolStripMenuItem
            // 
            this.getImagesToolStripMenuItem.Name = "getImagesToolStripMenuItem";
            this.getImagesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.getImagesToolStripMenuItem.Text = "Get Images";
            this.getImagesToolStripMenuItem.Click += new System.EventHandler(this.getImagesToolStripMenuItem_Click);
            // 
            // terrainEditorToolStripMenuItem
            // 
            this.terrainEditorToolStripMenuItem.Name = "terrainEditorToolStripMenuItem";
            this.terrainEditorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.terrainEditorToolStripMenuItem.Text = "Terrain Editor";
            this.terrainEditorToolStripMenuItem.Click += new System.EventHandler(this.terrainEditorToolStripMenuItem_Click);
            // 
            // propsEditorToolStripMenuItem
            // 
            this.propsEditorToolStripMenuItem.Name = "propsEditorToolStripMenuItem";
            this.propsEditorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.propsEditorToolStripMenuItem.Text = "Props Editor";
            this.propsEditorToolStripMenuItem.Click += new System.EventHandler(this.propsEditorToolStripMenuItem_Click);
            // 
            // entityEditorToolStripMenuItem
            // 
            this.entityEditorToolStripMenuItem.Name = "entityEditorToolStripMenuItem";
            this.entityEditorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.entityEditorToolStripMenuItem.Text = "Entity Editor";
            this.entityEditorToolStripMenuItem.Click += new System.EventHandler(this.entityEditorToolStripMenuItem_Click);
            // 
            // playerEditorToolStripMenuItem
            // 
            this.playerEditorToolStripMenuItem.Name = "playerEditorToolStripMenuItem";
            this.playerEditorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.playerEditorToolStripMenuItem.Text = "Player Editor";
            // 
            // dialogueEditorToolStripMenuItem
            // 
            this.dialogueEditorToolStripMenuItem.Name = "dialogueEditorToolStripMenuItem";
            this.dialogueEditorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dialogueEditorToolStripMenuItem.Text = "Dialogue Editor";
            this.dialogueEditorToolStripMenuItem.Click += new System.EventHandler(this.dialogueEditorToolStripMenuItem_Click);
            // 
            // itemEditorToolStripMenuItem
            // 
            this.itemEditorToolStripMenuItem.Name = "itemEditorToolStripMenuItem";
            this.itemEditorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.itemEditorToolStripMenuItem.Text = "Item Editor";
            this.itemEditorToolStripMenuItem.Click += new System.EventHandler(this.itemEditorToolStripMenuItem_Click);
            // 
            // Tool
            // 
            this.Tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolToolStripMenuItem});
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(43, 20);
            this.Tool.Text = "Tool";
            // 
            // testToolToolStripMenuItem
            // 
            this.testToolToolStripMenuItem.Name = "testToolToolStripMenuItem";
            this.testToolToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.testToolToolStripMenuItem.Text = "test tool";
            this.testToolToolStripMenuItem.Click += new System.EventHandler(this.testToolToolStripMenuItem_Click);
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(44, 20);
            this.Help.Text = "Help";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 27);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(727, 692);
            this.panel.TabIndex = 11;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TerrainTab);
            this.tabControl1.Controls.Add(this.PropTab);
            this.tabControl1.Controls.Add(this.EntityTab);
            this.tabControl1.Location = new System.Drawing.Point(972, 37);
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
            this.PropTab.Size = new System.Drawing.Size(370, 141);
            this.PropTab.TabIndex = 1;
            this.PropTab.Text = "Props";
            this.PropTab.UseVisualStyleBackColor = true;
            // 
            // EntityTab
            // 
            this.EntityTab.Location = new System.Drawing.Point(4, 22);
            this.EntityTab.Name = "EntityTab";
            this.EntityTab.Size = new System.Drawing.Size(370, 141);
            this.EntityTab.TabIndex = 2;
            this.EntityTab.Text = "Entities";
            this.EntityTab.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(1028, 206);
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
            this.radioButton2.Location = new System.Drawing.Point(1028, 229);
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
            this.radioButton3.Location = new System.Drawing.Point(1028, 252);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(43, 17);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.Text = "Box";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(1028, 276);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(55, 17);
            this.radioButton4.TabIndex = 20;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Select";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1098, 207);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Delete";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(1089, 230);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(252, 142);
            this.propertyGrid1.TabIndex = 24;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(972, 322);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(972, 266);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(972, 210);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // inventoryControl1
            // 
            this.inventoryControl1.Location = new System.Drawing.Point(733, 392);
            this.inventoryControl1.Name = "inventoryControl1";
            this.inventoryControl1.Size = new System.Drawing.Size(608, 327);
            this.inventoryControl1.TabIndex = 25;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 722);
            this.Controls.Add(this.inventoryControl1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "Main";
            this.Text = "Editor";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolStripMenuItem playerEditorToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem dialogueEditorToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem itemEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private UserControls.InventoryControl inventoryControl1;
    }
}

