namespace AdScrapper4
{
    partial class Filter
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
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtOriginal = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtPosFilter = new Telerik.WinControls.UI.RadTextBox();
            this.txtNegFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtFiltered = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.CloseButton = new Telerik.WinControls.UI.RadButton();
            this.ApplyButton = new Telerik.WinControls.UI.RadButton();
            this.butFetch = new Telerik.WinControls.UI.RadButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.butCopy2Original = new Telerik.WinControls.UI.RadButton();
            this.radComboBoxItem3 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.radComboBoxItem4 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.radComboBoxItem5 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.cboNegCondition = new Telerik.WinControls.UI.RadComboBox();
            this.radComboBoxItem8 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.cboPosCondition = new Telerik.WinControls.UI.RadComboBox();
            this.radComboBoxItem1 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.radComboBoxItem2 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.radComboBoxItem6 = new Telerik.WinControls.UI.RadComboBoxItem();
            this.radComboBoxItem7 = new Telerik.WinControls.UI.RadComboBoxItem();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNegFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butFetch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCopy2Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNegCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPosCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Caption = "Filter";
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(800, 23);
            this.radTitleBar1.TabIndex = 1;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "radTitleBar1";
            this.radTitleBar1.ThemeName = "Office2007Black";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 29);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(64, 14);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Original List";
            this.radLabel2.ThemeName = "Office2007Black";
            // 
            // txtOriginal
            // 
            this.txtOriginal.AcceptsReturn = true;
            this.txtOriginal.Location = new System.Drawing.Point(12, 49);
            this.txtOriginal.Multiline = true;
            this.txtOriginal.Name = "txtOriginal";
            // 
            // 
            // 
            this.txtOriginal.RootElement.StretchVertically = true;
            this.txtOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOriginal.Size = new System.Drawing.Size(223, 418);
            this.txtOriginal.TabIndex = 7;
            this.txtOriginal.ThemeName = "Office2007Black";
            this.txtOriginal.TextChanged += new System.EventHandler(this.txtOriginal_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(241, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(87, 14);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Positive Filtering";
            this.radLabel1.ThemeName = "Office2007Black";
            // 
            // txtPosFilter
            // 
            this.txtPosFilter.AcceptsReturn = true;
            this.txtPosFilter.Location = new System.Drawing.Point(241, 75);
            this.txtPosFilter.Multiline = true;
            this.txtPosFilter.Name = "txtPosFilter";
            // 
            // 
            // 
            this.txtPosFilter.RootElement.StretchVertically = true;
            this.txtPosFilter.Size = new System.Drawing.Size(319, 165);
            this.txtPosFilter.TabIndex = 16;
            this.txtPosFilter.ThemeName = "Office2007Black";
            // 
            // txtNegFilter
            // 
            this.txtNegFilter.AcceptsReturn = true;
            this.txtNegFilter.Location = new System.Drawing.Point(241, 302);
            this.txtNegFilter.Multiline = true;
            this.txtNegFilter.Name = "txtNegFilter";
            // 
            // 
            // 
            this.txtNegFilter.RootElement.StretchVertically = true;
            this.txtNegFilter.Size = new System.Drawing.Size(319, 165);
            this.txtNegFilter.TabIndex = 20;
            this.txtNegFilter.ThemeName = "Office2007Black";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(241, 257);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(92, 14);
            this.radLabel3.TabIndex = 17;
            this.radLabel3.Text = "Negative Filtering";
            this.radLabel3.ThemeName = "Office2007Black";
            // 
            // txtFiltered
            // 
            this.txtFiltered.AcceptsReturn = true;
            this.txtFiltered.Location = new System.Drawing.Point(566, 49);
            this.txtFiltered.Multiline = true;
            this.txtFiltered.Name = "txtFiltered";
            // 
            // 
            // 
            this.txtFiltered.RootElement.StretchVertically = true;
            this.txtFiltered.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFiltered.Size = new System.Drawing.Size(223, 418);
            this.txtFiltered.TabIndex = 21;
            this.txtFiltered.ThemeName = "Office2007Black";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(566, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(63, 14);
            this.radLabel4.TabIndex = 22;
            this.radLabel4.Text = "Filtered List";
            this.radLabel4.ThemeName = "Office2007Black";
            // 
            // CloseButton
            // 
            this.CloseButton.AllowShowFocusCues = true;
            this.CloseButton.Location = new System.Drawing.Point(714, 482);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 24;
            this.CloseButton.Text = "Close";
            this.CloseButton.ThemeName = "Office2007Black";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.AllowShowFocusCues = true;
            this.ApplyButton.Location = new System.Drawing.Point(633, 482);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 23;
            this.ApplyButton.Text = "OK";
            this.ApplyButton.ThemeName = "Office2007Black";
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // butFetch
            // 
            this.butFetch.AllowShowFocusCues = true;
            this.butFetch.Location = new System.Drawing.Point(12, 482);
            this.butFetch.Name = "butFetch";
            this.butFetch.Size = new System.Drawing.Size(119, 23);
            this.butFetch.TabIndex = 26;
            this.butFetch.Text = "Fetch Meta Data ";
            this.butFetch.ThemeName = "Office2007Black";
            this.butFetch.Click += new System.EventHandler(this.butFetch_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(187, 520);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 27;
            // 
            // butCopy2Original
            // 
            this.butCopy2Original.AllowShowFocusCues = true;
            this.butCopy2Original.Location = new System.Drawing.Point(513, 482);
            this.butCopy2Original.Name = "butCopy2Original";
            this.butCopy2Original.Size = new System.Drawing.Size(114, 23);
            this.butCopy2Original.TabIndex = 28;
            this.butCopy2Original.Text = "Copy to Original";
            this.butCopy2Original.ThemeName = "Office2007Black";
            this.butCopy2Original.Click += new System.EventHandler(this.butCopy2Original_Click);
            // 
            // radComboBoxItem3
            // 
            this.radComboBoxItem3.Name = "radComboBoxItem3";
            this.radComboBoxItem3.Text = "URL";
            // 
            // radComboBoxItem4
            // 
            this.radComboBoxItem4.Name = "radComboBoxItem4";
            this.radComboBoxItem4.Text = "Meta Words";
            // 
            // radComboBoxItem5
            // 
            this.radComboBoxItem5.Name = "radComboBoxItem5";
            this.radComboBoxItem5.Text = "Meta Description";
            // 
            // cboNegCondition
            // 
            this.cboNegCondition.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboNegCondition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboNegCondition.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radComboBoxItem3,
            this.radComboBoxItem4,
            this.radComboBoxItem5,
            this.radComboBoxItem8});
            this.cboNegCondition.Location = new System.Drawing.Point(241, 278);
            this.cboNegCondition.Name = "cboNegCondition";
            this.cboNegCondition.Size = new System.Drawing.Size(319, 20);
            this.cboNegCondition.TabIndex = 25;
            this.cboNegCondition.Text = "radComboBox1";
            this.cboNegCondition.ThemeName = "Office2007Black";
            this.cboNegCondition.SelectedIndexChanged += new System.EventHandler(this.cboNegCondition_SelectedIndexChanged);
            // 
            // radComboBoxItem8
            // 
            this.radComboBoxItem8.Name = "radComboBoxItem8";
            this.radComboBoxItem8.Text = "Title";
            // 
            // cboPosCondition
            // 
            this.cboPosCondition.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboPosCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cboPosCondition.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radComboBoxItem1,
            this.radComboBoxItem2,
            this.radComboBoxItem6,
            this.radComboBoxItem7});
            this.cboPosCondition.Location = new System.Drawing.Point(242, 50);
            this.cboPosCondition.Name = "cboPosCondition";
            this.cboPosCondition.Size = new System.Drawing.Size(318, 20);
            this.cboPosCondition.TabIndex = 29;
            this.cboPosCondition.Text = "radComboBox1";
            this.cboPosCondition.SelectedIndexChanged += new System.EventHandler(this.cboPosCondition_SelectedIndexChanged);
            // 
            // radComboBoxItem1
            // 
            this.radComboBoxItem1.Name = "radComboBoxItem1";
            this.radComboBoxItem1.Text = "URL";
            // 
            // radComboBoxItem2
            // 
            this.radComboBoxItem2.Name = "radComboBoxItem2";
            this.radComboBoxItem2.Text = "Meta Words";
            // 
            // radComboBoxItem6
            // 
            this.radComboBoxItem6.Name = "radComboBoxItem6";
            this.radComboBoxItem6.Text = "Meta Description";
            // 
            // radComboBoxItem7
            // 
            this.radComboBoxItem7.Name = "radComboBoxItem7";
            this.radComboBoxItem7.Text = "Title";
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(800, 517);
            this.Controls.Add(this.cboPosCondition);
            this.Controls.Add(this.butCopy2Original);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.butFetch);
            this.Controls.Add(this.cboNegCondition);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtFiltered);
            this.Controls.Add(this.txtNegFilter);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtPosFilter);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radTitleBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter";
            this.ThemeName = "Office2007Black";
            this.Load += new System.EventHandler(this.Filter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNegFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butFetch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCopy2Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNegCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPosCondition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtFiltered;
        private Telerik.WinControls.UI.RadTextBox txtPosFilter;
        private Telerik.WinControls.UI.RadTextBox txtNegFilter;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton CloseButton;
        private Telerik.WinControls.UI.RadButton ApplyButton;
        private Telerik.WinControls.UI.RadButton butFetch;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Telerik.WinControls.UI.RadButton butCopy2Original;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem3;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem4;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem5;
        private Telerik.WinControls.UI.RadComboBox cboNegCondition;
        private Telerik.WinControls.UI.RadComboBox cboPosCondition;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem1;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem2;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem6;
        public Telerik.WinControls.UI.RadTextBox txtOriginal;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem8;
        private Telerik.WinControls.UI.RadComboBoxItem radComboBoxItem7;
    }
}