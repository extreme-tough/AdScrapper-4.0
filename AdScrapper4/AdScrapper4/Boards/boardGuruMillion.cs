using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdScrapper4.Classes;
namespace AdScrapper4.Boards
{
    public partial class boardGuruMillion : boardBase
    {
        public boardGuruMillion()
        {
            InitializeComponent();
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtImportFile.Text = openFileDialog.FileName;
        }

        public override Boolean ValidateInput()
        {
            
            if (txtImportFile.Text == "")
            {
                Msg.Error("Please select a file to import");
                return false;
            }
            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process objProcess = new System.Diagnostics.Process();
            objProcess.StartInfo.FileName = "http://www.quantcast.com/quantcast-top-million.zip";
            objProcess.Start();
        }
    }
}
