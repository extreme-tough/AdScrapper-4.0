using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;
using AdScrapper4.Classes;

namespace AdScrapper4.Boards
{
    public partial class boardSiteSniper : boardBase
    {
        public List<RadTreeNode> nodeCollection = new List<RadTreeNode>();

        public boardSiteSniper()
        {
            InitializeComponent();
        }

        private void boardSiteSniper_Load(object sender, EventArgs e)
        {
            tvwCat.LoadXML(Application.StartupPath + @"\directory.xml");
            tvwCat.SelectedNode = tvwCat.Nodes[0];
            tvwCat.CheckBoxes = true;
            tvwListOptions.LoadXML(Application.StartupPath + @"\searchlimit.xml");
            tvwListOptions.CheckBoxes = true;
        }


        public override Boolean ValidateInput()
        {
            if (Keywords.Text == "")
            {
                Msg.Error("Keywords cannot be empty");
                return false;
            }

            if (tvwCat.SelectedNodes.Count == 0)
            {
                Msg.Error("Please select atleast one site");
                return false;
            }
            return true;
        }

        private void tvwCat_NodeCheckedChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            foreach (RadTreeNode rNode in e.Node.Nodes)
            {
                rNode.Checked = e.Node.Checked;
            }

            if (e.Node.Level == 2)
                if (e.Node.Checked)
                    nodeCollection.Add(e.Node);
                else
                    nodeCollection.Remove(e.Node);        
        }

        private void AddCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                if (AddCat.Text != "")
                {
                    tvwCat.Nodes[0].Nodes.Add(AddCat.Text);
                    AddCat.Text = "";
                    tvwCat.SaveXML(Application.StartupPath + @"\directory.xml");
                }
                contextMenuStrip.Close();
            }
            
            
        }

        private void AddSite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                if (tvwCat.SelectedNode.Level == 1)
                {
                    if (AddSite.Text != "")
                    {
                        tvwCat.SelectedNode.Nodes.Add(AddSite.Text);
                        AddSite.Text = "";
                        tvwCat.SaveXML(Application.StartupPath + @"\directory.xml");
                    }
                    contextMenuStrip.Close();

                }
                else
                    Msg.Error("Please select a category where you want to add the site");
                
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvwCat.SelectedNode.Level > 0)
            {
                if (Msg.Question("Do you want to remove the selected item?") == DialogResult.Yes)
                {
                    tvwCat.SelectedNode.Remove();
                    tvwCat.SaveXML(Application.StartupPath + @"\directory.xml");
                }
            }
            else
                Msg.Error("You cannot remove the root category");
        }

        private void mnuBulkImport_Click(object sender, EventArgs e)
        {
            if (tvwCat.SelectedNode.Level == 1)
            {
                PasteURL frmURLPaste = new PasteURL();
                if (frmURLPaste.ShowDialog() == DialogResult.OK)
                {
                    string[] arLines = frmURLPaste.URLText.Text.Split(new string[]{Environment.NewLine},StringSplitOptions.None);
                    foreach (string sLine in arLines)
                    {
                        if (sLine.Trim() != "")
                        {
                            tvwCat.SelectedNode.Nodes.Add(sLine);
                            tvwCat.SaveXML(Application.StartupPath + @"\directory.xml");
                        }
                    }
                    //contextMenuStrip.Close();
                }
            }
            else
                Msg.Error("Please select a category where you want to add the site");
        }
    }
}

