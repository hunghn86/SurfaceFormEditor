namespace FormEditor {
partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose ( bool disposing ) {
        if ( disposing && ( components != null ) ) {
            components.Dispose();
        }
        base.Dispose ( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOSDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.androidDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemUnDo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReDo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTabOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl4Toolbox = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnl4Toolbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(128, 26);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(656, 535);
            this.splitContainer.SplitterDistance = 453;
            this.splitContainer.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(453, 535);
            this.tabControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItemTools,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDesignToolStripMenuItem,
            this.saveDesignToolStripMenuItem,
            this.toolStripSeparator5,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.newToolStripMenuItem.Text = "&File";
            // 
            // importDesignToolStripMenuItem
            // 
            this.importDesignToolStripMenuItem.Name = "importDesignToolStripMenuItem";
            this.importDesignToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.importDesignToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.importDesignToolStripMenuItem.Text = "&Import Design";
            this.importDesignToolStripMenuItem.Click += new System.EventHandler(this.importDesignToolStripMenuItem_Click);
            // 
            // saveDesignToolStripMenuItem
            // 
            this.saveDesignToolStripMenuItem.Name = "saveDesignToolStripMenuItem";
            this.saveDesignToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDesignToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveDesignToolStripMenuItem.Text = "&Save Design";
            this.saveDesignToolStripMenuItem.Click += new System.EventHandler(this.saveDesignToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(189, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLDesignToolStripMenuItem,
            this.toolStripSeparator2,
            this.hTMLToolStripMenuItem,
            this.iOSDesignToolStripMenuItem,
            this.androidDesignToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // xMLDesignToolStripMenuItem
            // 
            this.xMLDesignToolStripMenuItem.Name = "xMLDesignToolStripMenuItem";
            this.xMLDesignToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.xMLDesignToolStripMenuItem.Text = "XML Design";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // hTMLToolStripMenuItem
            // 
            this.hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
            this.hTMLToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.hTMLToolStripMenuItem.Text = "HTML";
            // 
            // iOSDesignToolStripMenuItem
            // 
            this.iOSDesignToolStripMenuItem.Name = "iOSDesignToolStripMenuItem";
            this.iOSDesignToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.iOSDesignToolStripMenuItem.Text = "iOS Design";
            // 
            // androidDesignToolStripMenuItem
            // 
            this.androidDesignToolStripMenuItem.Name = "androidDesignToolStripMenuItem";
            this.androidDesignToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.androidDesignToolStripMenuItem.Text = "Android Design";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemUnDo,
            this.ToolStripMenuItemReDo,
            this.toolStripSeparator3,
            this.ToolStripMenuItemCut,
            this.ToolStripMenuItemCopy,
            this.ToolStripMenuItemPaste,
            this.ToolStripMenuItemDelete,
            this.toolStripSeparator4});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // ToolStripMenuItemUnDo
            // 
            this.ToolStripMenuItemUnDo.Name = "ToolStripMenuItemUnDo";
            this.ToolStripMenuItemUnDo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.ToolStripMenuItemUnDo.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItemUnDo.Text = "Undo";
            this.ToolStripMenuItemUnDo.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemReDo
            // 
            this.ToolStripMenuItemReDo.Name = "ToolStripMenuItemReDo";
            this.ToolStripMenuItemReDo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.ToolStripMenuItemReDo.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItemReDo.Text = "Redo";
            this.ToolStripMenuItemReDo.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // ToolStripMenuItemCut
            // 
            this.ToolStripMenuItemCut.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemCut.Image")));
            this.ToolStripMenuItemCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItemCut.Name = "ToolStripMenuItemCut";
            this.ToolStripMenuItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ToolStripMenuItemCut.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItemCut.Text = "Cut";
            this.ToolStripMenuItemCut.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // ToolStripMenuItemCopy
            // 
            this.ToolStripMenuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemCopy.Image")));
            this.ToolStripMenuItemCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
            this.ToolStripMenuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItemCopy.Text = "Copy";
            this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // ToolStripMenuItemPaste
            // 
            this.ToolStripMenuItemPaste.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemPaste.Image")));
            this.ToolStripMenuItemPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItemPaste.Name = "ToolStripMenuItemPaste";
            this.ToolStripMenuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ToolStripMenuItemPaste.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItemPaste.Text = "Paste";
            this.ToolStripMenuItemPaste.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItemDelete.Text = "Delete";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItemTools
            // 
            this.toolStripMenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTabOrder});
            this.toolStripMenuItemTools.Name = "toolStripMenuItemTools";
            this.toolStripMenuItemTools.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItemTools.Text = "&Tools";
            // 
            // toolStripMenuItemTabOrder
            // 
            this.toolStripMenuItemTabOrder.Name = "toolStripMenuItemTabOrder";
            this.toolStripMenuItemTabOrder.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItemTabOrder.Text = "Tab Order";
            this.toolStripMenuItemTabOrder.Click += new System.EventHandler(this.toolStripMenuItemTabOrder_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItemAbout.Text = "About...";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.OnAbout);
            // 
            // pnl4Toolbox
            // 
            this.pnl4Toolbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl4Toolbox.Controls.Add(this.listBox1);
            this.pnl4Toolbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl4Toolbox.Location = new System.Drawing.Point(0, 24);
            this.pnl4Toolbox.Margin = new System.Windows.Forms.Padding(2);
            this.pnl4Toolbox.Name = "pnl4Toolbox";
            this.pnl4Toolbox.Size = new System.Drawing.Size(123, 537);
            this.pnl4Toolbox.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(119, 533);
            this.listBox1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnl4Toolbox);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APV Form Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl4Toolbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUnDo;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReDo;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCut;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopy;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPaste;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTools;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTabOrder;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.Panel pnl4Toolbox;
    private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStripMenuItem importDesignToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveDesignToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xMLDesignToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem hTMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iOSDesignToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem androidDesignToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}

