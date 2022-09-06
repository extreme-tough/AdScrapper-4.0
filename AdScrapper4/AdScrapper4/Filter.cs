using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AdScrapper4.Classes;

namespace AdScrapper4
{
    
    public partial class Filter : Telerik.WinControls.UI.ShapedForm
    {
        public int BrowseTimeout;
        ArrayList arMetaDesc = new ArrayList();
        ArrayList arMetaWords = new ArrayList();
        ArrayList arTitles = new ArrayList();
        Boolean metaDataFetched = false;

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            cboNegCondition.SelectedIndex = 0;
            cboPosCondition.SelectedIndex = 0;
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butFetch_Click(object sender, EventArgs e)
        {
            arMetaDesc = new ArrayList();
            arMetaWords = new ArrayList();
            arTitles = new ArrayList();

            DateTime navStarted ;
            butFetch.Text = "Please wait...";
            butFetch.Enabled = false;
            foreach(string url in txtOriginal.Text.Split(new string[]{Environment.NewLine},StringSplitOptions.None))
            {
                navStarted = DateTime.Now;

                webBrowser1.Navigate(url);
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                    {
                        webBrowser1.Stop();
                        break;
                    }
                }
                arMetaDesc.Add(Utils.GetMetaDescription(webBrowser1));
                arMetaWords.Add(Utils.GetMetaTags(webBrowser1));
                arTitles.Add(webBrowser1.Document.Title);

            }
            metaDataFetched = true;
            butFetch.Text = "Fetch Meta Data";
            butFetch.Enabled = true;

            MessageBox.Show("Meta data downloaded", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private string[] ApplyPosFilter(string OriginalList, string PositiveWords)
        {
            string TempList = "";
            bool AddThisWord = false;
            string word;
            string[] words = OriginalList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] positiveList = PositiveWords.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            for(int i=0; i<words.Length; i++)
            {
                word = words[i].ToLower() ;
                AddThisWord = false;
                if (PositiveWords.Trim() != "")
                    foreach (string posWord in positiveList)
                    {
                        if (word != "")
                        {
                            switch (cboPosCondition.SelectedIndex)
                            {
                                case 0:
                                    if (word.Contains(posWord.ToLower()))
                                        AddThisWord = true;
                                    break;
                                case 1:
                                    if (arMetaWords[i].ToString().ToLower().Contains(posWord.ToLower()))
                                        AddThisWord = true;
                                    break;
                                case 2:
                                    if (arMetaDesc[i].ToString().ToLower().Contains(posWord.ToLower()))
                                        AddThisWord = true;
                                    break;
                                case 3:
                                    if (arTitles[i].ToString().ToLower().Contains(posWord.ToLower()))
                                        AddThisWord = true;
                                    break;

                            }

                        }
                    }
                else
                    AddThisWord = true;

                if (AddThisWord && word != "")
                    TempList += word + Environment.NewLine;
            }


            return TempList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        private string[] ApplyNegFilter(string OriginalList, string NegativeWords)
        {
            string TempList = "";
            bool AddThisWord = true;
            string word;
            string[] words = OriginalList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] negativeList = NegativeWords.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < words.Length; i++)
            {
                word = words[i].ToLower();
                AddThisWord = true;
                if (NegativeWords.Trim() != "")
                    foreach (string negWord in negativeList)
                    {
                        if (word != "")
                        {
                            switch (cboNegCondition.SelectedIndex)
                            {
                                case 0:
                                    if (word.Contains(negWord.ToLower()))
                                        AddThisWord = false;
                                    break;
                                case 1:
                                    if (arMetaWords[i].ToString().ToLower().Contains(negWord.ToLower()))
                                        AddThisWord = false;
                                    break;
                                case 2:
                                    if (arMetaDesc[i].ToString().ToLower().Contains(negWord.ToLower()))
                                        AddThisWord = false;
                                    break;
                                case 3:
                                    if (arTitles[i].ToString().ToLower().Contains(negWord.ToLower()))
                                        AddThisWord = false;
                                    break;
                            }

                        }
                    }
                else
                    AddThisWord = false;

                if (AddThisWord && word != "")
                    TempList += word + Environment.NewLine;
            }


            return TempList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string[] AfterPosFilter, AfterNegFilter;
            if (txtPosFilter.Text.Trim() != "")
            {
                AfterPosFilter = ApplyPosFilter(txtOriginal.Text, txtPosFilter.Text);
            }
            else
            {
                AfterPosFilter = txtOriginal.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            }

            if (txtNegFilter.Text.Trim() != "")
            {
                AfterNegFilter = ApplyNegFilter(string.Join(Environment.NewLine, AfterPosFilter), txtNegFilter.Text);
            }
            else
            {
                AfterNegFilter = AfterPosFilter;
            }

            txtFiltered.Text = string.Join(Environment.NewLine, AfterNegFilter);
        }



        private void butCopy2Original_Click(object sender, EventArgs e)
        {
            txtOriginal.Text = txtFiltered.Text;
        }

        private void txtOriginal_TextChanged(object sender, EventArgs e)
        {
            metaDataFetched = false;
        }

        private void cboPosCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPosCondition.SelectedIndex > 0 && !metaDataFetched)
            {
                Msg.Error("Please fetch the meta data before filtering using it");
                cboPosCondition.SelectedIndex = 0;
            }
        }

        private void cboNegCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNegCondition.SelectedIndex > 0 && !metaDataFetched)
            {
                Msg.Error("Please fetch the meta data before filtering using it");
                cboNegCondition.SelectedIndex = 0;
            }
        }

        
    }
}
