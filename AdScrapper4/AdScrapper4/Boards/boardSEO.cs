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
    public partial class boardSEO : boardBase
    {
        public boardSEO()
        {
            InitializeComponent();
        }

        private void boardSEO_Load(object sender, EventArgs e)
        {

            LoadCountryList();
            CountryList.SelectedIndex = 0;
            EngineList.SetItemChecked(0, true);
        }

        private void tvwCat_NodeCheckedChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            foreach (RadTreeNode rNode in e.Node.Nodes)
            {
                rNode.Checked = e.Node.Checked;
            }
        }


        private void LoadCountryList()
        {
            ArrayList arPlugs;
            string locData;
            string[] arlocData;
            SearchLocations objLoc;
            string[] DataParts;
            RadComboBoxItem CountryItem;
            try
            {
                locData = File.ReadAllText(Application.StartupPath + @"\googleloc.lst");
            }
            catch
            {
                MessageBox.Show("Could not open googleloc.lst", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            arlocData = locData.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string locLine in arlocData)
            {
                if (locLine != "")
                {
                    DataParts = locLine.Split(new string[] { "," }, StringSplitOptions.None);
                    objLoc = new SearchLocations();
                    objLoc.LocationName = DataParts[0];
                    objLoc.GoogleLocationCode = DataParts[1];
                    objLoc.BingLocationCode = DataParts[2];
                    CountryItem = new RadComboBoxItem();
                    CountryItem.Text = objLoc.LocationName;
                    CountryItem.Tag = objLoc;
                    CountryList.Items.Add(CountryItem);

                }
            }
            try
            {
                //CountryList.SetItemChecked(0, true);
            }
            catch { }

        }

        public override Boolean ValidateInput()
        {
            if (Keywords.Text == "")
            {
                Msg.Error("Keyword cannot be empty");
                return false;
            }
            if (Pages.Text == "")
            {
                Msg.Error("Pages cannot be empty");
                return false;
            }
            int res;
            if (!int.TryParse(Pages.Text,out res))
            {
                Msg.Error("Please enter a number");
            }
            if (EngineList.CheckedItems.Count == 0)
            {
                Msg.Error("Please select atleast one search engine");
                return false;
            }

            return true;
        }
    }
}
