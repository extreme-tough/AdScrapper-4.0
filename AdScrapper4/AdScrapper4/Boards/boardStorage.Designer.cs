namespace AdScrapper4.Boards
{
    partial class boardStorage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(boardStorage));
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.tvwCat = new Telerik.WinControls.UI.RadTreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCat = new System.Windows.Forms.ToolStripTextBox();
            this.addSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSite = new System.Windows.Forms.ToolStripTextBox();
            this.mnuBulkImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.donutShape1 = new Telerik.WinControls.Tests.DonutShape();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvwCat)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLabel3
            // 
            this.radLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radLabel3.Location = new System.Drawing.Point(11, 3);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radLabel3.Size = new System.Drawing.Size(29, 14);
            this.radLabel3.TabIndex = 7;
            this.radLabel3.Text = "Sites";
            // 
            // tvwCat
            // 
            this.tvwCat.BackColor = System.Drawing.SystemColors.Control;
            this.tvwCat.ContextMenuStrip = this.contextMenuStrip;
            this.tvwCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCat.ImageList = this.imageList;
            this.tvwCat.Location = new System.Drawing.Point(10, 23);
            this.tvwCat.Name = "tvwCat";
            this.tvwCat.Size = new System.Drawing.Size(215, 391);
            this.tvwCat.TabIndex = 8;
            this.tvwCat.Text = "radTreeView1";
            this.tvwCat.ThemeName = "Office2007Black";
            this.tvwCat.Selected += new System.EventHandler(this.tvwCat_Selected);
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).ScrollBarThemeName = "Office2007Black";
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).DrawFill = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).DrawBorder = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(195)))), ((int)(((byte)(222)))));
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).BackColor2 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.tvwCat.GetChildAt(0))).ShouldPaint = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryToolStripMenuItem,
            this.addSiteToolStripMenuItem,
            this.mnuBulkImport,
            this.toolStripMenuItem1,
            this.deleteItemToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(148, 98);
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCat});
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addCategoryToolStripMenuItem.Text = "Add Category";
            // 
            // AddCat
            // 
            this.AddCat.Name = "AddCat";
            this.AddCat.Size = new System.Drawing.Size(100, 23);
            this.AddCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddCat_KeyPress);
            // 
            // addSiteToolStripMenuItem
            // 
            this.addSiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSite});
            this.addSiteToolStripMenuItem.Name = "addSiteToolStripMenuItem";
            this.addSiteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addSiteToolStripMenuItem.Text = "Add Site";
            // 
            // AddSite
            // 
            this.AddSite.Name = "AddSite";
            this.AddSite.Size = new System.Drawing.Size(100, 23);
            this.AddSite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddSite_KeyPress);
            // 
            // mnuBulkImport
            // 
            this.mnuBulkImport.Name = "mnuBulkImport";
            this.mnuBulkImport.Size = new System.Drawing.Size(147, 22);
            this.mnuBulkImport.Text = "Bulk Import";
            this.mnuBulkImport.Click += new System.EventHandler(this.mnuBulkImport_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder");
            this.imageList.Images.SetKeyName(1, "ie");
            // 
            // boardStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.tvwCat);
            this.Name = "boardStorage";
            this.Load += new System.EventHandler(this.boardSiteSniper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvwCat)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox AddCat;
        private System.Windows.Forms.ToolStripMenuItem addSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox AddSite;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBulkImport;
        public Telerik.WinControls.UI.RadTreeView tvwCat;
        private Telerik.WinControls.Tests.DonutShape donutShape1;
        private System.Windows.Forms.ImageList imageList;
    }
}
