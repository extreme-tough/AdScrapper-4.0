namespace AdScrapper4.Boards
{
    partial class boardQuantCast
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.URLList = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.Depth = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.URLList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Depth)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(9, 18);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(34, 14);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Depth";
            // 
            // URLList
            // 
            this.URLList.AcceptsReturn = true;
            this.URLList.Location = new System.Drawing.Point(10, 84);
            this.URLList.Multiline = true;
            this.URLList.Name = "URLList";
            // 
            // 
            // 
            this.URLList.RootElement.StretchVertically = true;
            this.URLList.Size = new System.Drawing.Size(215, 168);
            this.URLList.TabIndex = 2;
            this.URLList.ThemeName = "Office2007Black";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(9, 64);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(48, 14);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "URL List";
            // 
            // Depth
            // 
            this.Depth.Location = new System.Drawing.Point(10, 38);
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(215, 20);
            this.Depth.TabIndex = 12;
            this.Depth.Text = "5";
            this.Depth.ThemeName = "Office2007Black";
            // 
            // boardQuantCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Depth);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.URLList);
            this.Controls.Add(this.radLabel1);
            this.Name = "boardQuantCast";
            this.Load += new System.EventHandler(this.boardSEO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.URLList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Depth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadTextBox URLList;
        public Telerik.WinControls.UI.RadTextBox Depth;
    }
}
