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
    public partial class boardStorage : boardBase
    {
        public List<RadTreeNode> nodeCollection = new List<RadTreeNode>();

        public event NodeClickEventHandler NodeClicked;
        public delegate void NodeClickEventHandler(object sender, EventArgs e);

        public boardStorage()
        {
            InitializeComponent();
        }


        public virtual void OnNodeClicked(object sender, EventArgs e)
        {
            if (NodeClicked != null)
                NodeClicked(sender, e);
        }


        private void boardSiteSniper_Load(object sender, EventArgs e)
        {
            tvwCat.LoadXML(Application.StartupPath + @"\storage.xml");
            //tvwCat.Nodes[0].ImageIndex = 0;
            tvwCat.SelectedNode = tvwCat.Nodes[0];
        }




        private void AddCat_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(13))
            {
                if (tvwCat.SelectedNode.ImageIndex == 1)
                {
                    Msg.Error("Category cannot be added below web sites.");
                    return;
                }
                if (AddCat.Text != "")
                {
                    RadTreeNode nodeNew = tvwCat.SelectedNode.Nodes.Add(AddCat.Text);
                    nodeNew.ImageIndex = 0;
                    AddCat.Text = "";
                    tvwCat.SaveXML(Application.StartupPath + @"\storage.xml");
                    tvwCat.SelectedNode.Expand();
                }
                contextMenuStrip.Close();
            }

            
        }

        private void AddSite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                if (tvwCat.SelectedNode.ImageIndex == 0)
                {
                    if (AddSite.Text != "")
                    {
                        RadTreeNode nodeNew = tvwCat.SelectedNode.Nodes.Add(AddSite.Text);
                        nodeNew.ImageIndex = 1;
                        AddSite.Text = "";
                        tvwCat.SaveXML(Application.StartupPath + @"\storage.xml");
                        tvwCat.SelectedNode.Expand();
                    }
                    contextMenuStrip.Close();

                }
                else
                    Msg.Error("You cannot add site under a site. Please select a category where you want to add the site");
                
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvwCat.SelectedNode.Level > 0)
            {
                if (Msg.Question("Do you want to remove the selected item?") == DialogResult.Yes)
                {
                    tvwCat.SelectedNode.Remove();
                    tvwCat.SaveXML(Application.StartupPath + @"\storage.xml");
                }
            }
            else
                Msg.Error("You cannot remove the root category");
        }

        private void mnuBulkImport_Click(object sender, EventArgs e)
        {
            if (tvwCat.SelectedNode.ImageIndex == 0)
            {
                PasteURL frmURLPaste = new PasteURL();
                if (frmURLPaste.ShowDialog() == DialogResult.OK)
                {
                    string[] arLines = frmURLPaste.URLText.Text.Split(new string[]{Environment.NewLine},StringSplitOptions.None);
                    foreach (string sLine in arLines)
                    {
                        if (sLine.Trim() != "")
                        {
                            RadTreeNode nodeNew = tvwCat.SelectedNode.Nodes.Add(sLine);
                            nodeNew.ImageIndex = 1;
                            tvwCat.SaveXML(Application.StartupPath + @"\storage.xml");
                            tvwCat.SelectedNode.Expand();
                        }
                    }
                    //contextMenuStrip.Close();
                }
            }
            else
                Msg.Error("Please select a category where you want to add the site");
        }

        private void tvwCat_Selected(object sender, EventArgs e)
        {
            this.OnNodeClicked(this, e);
        }
    }
}

