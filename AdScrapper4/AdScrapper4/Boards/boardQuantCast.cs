using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;    
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Common;
using AdScrapper4.Classes;

namespace AdScrapper4.Boards
{
    public partial class boardQuantCast : boardBase
    {
        public boardQuantCast()
        {
            InitializeComponent();
        }

        private void boardSEO_Load(object sender, EventArgs e)
        {
        }

        private void tvwCat_NodeCheckedChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            foreach (RadTreeNode rNode in e.Node.Nodes)
            {
                rNode.Checked = e.Node.Checked;
            }
        }

        private void cboEngines_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public override Boolean ValidateInput()
        {
            if (Depth.Text == "")
            {
                Msg.Error("Depth cannot be empty");
                return false;
            }

            try
            {
                if (int.Parse(Depth.Text) > 5)
                {
                    Msg.Error("Maximum depth can be only 5");
                    Depth.Text = "5";
                }
            }
            catch
            {
                Msg.Error("Please enter a number between 1 and 5");
            }

            if (URLList.Text=="")
            {
                Msg.Error("Please enter a list of URLs");
                return false;
            }
            return true;
        }
    }        
}
