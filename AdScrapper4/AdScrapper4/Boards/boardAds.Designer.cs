namespace AdScrapper4.Boards
{
    partial class boardAds
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.CountryList = new Telerik.WinControls.UI.RadComboBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.Keywords = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.Pages = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Keywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pages)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(9, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(54, 14);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Keywords";
            this.radLabel2.ThemeName = "Office2007Black";
            // 
            // CountryList
            // 
            this.CountryList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CountryList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CountryList.Location = new System.Drawing.Point(10, 130);
            this.CountryList.Name = "CountryList";
            this.CountryList.Size = new System.Drawing.Size(215, 20);
            this.CountryList.TabIndex = 11;
            this.CountryList.Text = "";
            this.CountryList.ThemeName = "Office2007Black";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(9, 110);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(44, 14);
            this.radLabel5.TabIndex = 10;
            this.radLabel5.Text = "Country";
            this.radLabel5.ThemeName = "Office2007Black";
            // 
            // Keywords
            // 
            this.Keywords.AcceptsReturn = true;
            this.Keywords.Location = new System.Drawing.Point(10, 23);
            this.Keywords.Multiline = true;
            this.Keywords.Name = "Keywords";
            // 
            // 
            // 
            this.Keywords.RootElement.StretchVertically = true;
            this.Keywords.Size = new System.Drawing.Size(215, 81);
            this.Keywords.TabIndex = 2;
            this.Keywords.ThemeName = "Office2007Black";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(9, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(54, 14);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Keywords";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(9, 110);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(44, 14);
            this.radLabel6.TabIndex = 10;
            this.radLabel6.Text = "Country";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(10, 165);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(36, 14);
            this.radLabel7.TabIndex = 13;
            this.radLabel7.Text = "Pages";
            // 
            // Pages
            // 
            this.Pages.Location = new System.Drawing.Point(9, 186);
            this.Pages.Name = "Pages";
            this.Pages.Size = new System.Drawing.Size(215, 20);
            this.Pages.TabIndex = 14;
            this.Pages.Text = "10";
            // 
            // boardAds
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.CountryList);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.Keywords);
            this.Name = "boardAds";
            this.Load += new System.EventHandler(this.boardSEO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Keywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        public Telerik.WinControls.UI.RadTextBox Keywords;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        public Telerik.WinControls.UI.RadTextBox Pages;
        public Telerik.WinControls.UI.RadComboBox CountryList;
    }
}
