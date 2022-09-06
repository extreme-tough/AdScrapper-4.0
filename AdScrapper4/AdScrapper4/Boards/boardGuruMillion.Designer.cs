namespace AdScrapper4.Boards
{
    partial class boardGuruMillion
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
            this.txtImportFile = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.FileSelect = new Telerik.WinControls.UI.RadButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImportFile
            // 
            this.txtImportFile.Location = new System.Drawing.Point(4, 37);
            this.txtImportFile.Name = "txtImportFile";
            this.txtImportFile.Size = new System.Drawing.Size(206, 20);
            this.txtImportFile.TabIndex = 16;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 17);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(100, 14);
            this.radLabel1.TabIndex = 15;
            this.radLabel1.Text = "Select file to import";
            // 
            // FileSelect
            // 
            this.FileSelect.AllowShowFocusCues = true;
            this.FileSelect.Location = new System.Drawing.Point(210, 37);
            this.FileSelect.Name = "FileSelect";
            this.FileSelect.Size = new System.Drawing.Size(20, 20);
            this.FileSelect.TabIndex = 17;
            this.FileSelect.Text = "...";
            this.FileSelect.Click += new System.EventHandler(this.FileSelect_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(4, 64);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(221, 13);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.quantcast.com/quantcast-top-million.zip";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // boardGuruMillion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.FileSelect);
            this.Controls.Add(this.txtImportFile);
            this.Controls.Add(this.radLabel1);
            this.Name = "boardGuruMillion";
            ((System.ComponentModel.ISupportInitialize)(this.txtImportFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton FileSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public Telerik.WinControls.UI.RadTextBox txtImportFile;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
