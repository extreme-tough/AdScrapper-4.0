namespace AdScrapper4
{
    partial class PasteURL
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
            this.URLText = new Telerik.WinControls.UI.RadTextBox();
            this.OKButton = new Telerik.WinControls.UI.RadButton();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.URLText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            this.SuspendLayout();
            // 
            // URLText
            // 
            this.URLText.AcceptsReturn = true;
            this.URLText.Location = new System.Drawing.Point(2, 3);
            this.URLText.Multiline = true;
            this.URLText.Name = "URLText";
            // 
            // 
            // 
            this.URLText.RootElement.StretchVertically = true;
            this.URLText.Size = new System.Drawing.Size(473, 408);
            this.URLText.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.AllowShowFocusCues = true;
            this.OKButton.Location = new System.Drawing.Point(319, 417);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.ThemeName = "Office2007Black";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AllowShowFocusCues = true;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(400, 417);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.ThemeName = "Office2007Black";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PasteURL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.URLText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PasteURL";
            this.Text = "Bulk URLs";
            this.ThemeName = "Office2007Black";
            ((System.ComponentModel.ISupportInitialize)(this.URLText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton OKButton;
        private Telerik.WinControls.UI.RadButton CancelButton;
        public Telerik.WinControls.UI.RadTextBox URLText;
    }
}