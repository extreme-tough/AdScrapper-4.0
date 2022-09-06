using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Xml;

using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using AdScrapper4.Boards;
using AdScrapper4.Classes;
using Common;

namespace AdScrapper4
{
    enum SearchTypes
    {
        SEARCH,
        ADS,
        IMAGES,
        QUANTCAST,
        SITESNIPER,
        GURU,
        STORAGE,
        NONE
    }
    public partial class Form1 : Telerik.WinControls.UI.ShapedForm
    {
        SearchTypes currentSearch = new SearchTypes();
        boardSEO brdSEO ;
        boardAds brdAds;
        boardImages brdImages;
        boardQuantCast brdQC;
        boardSiteSniper brdSite;
        boardGuruMillion brdGuru;
        boardStorage brdStorage;

        DataTable dataStore = new DataTable("adscrapper");
        HashSet<string> hashURL = new HashSet<string>();
        Random rnd = new Random();

        int BrowseTimeout;
        bool IsSearchStopped=true;
        int MaxDepth;
        int depth = 0;
        string RSSUrl;
        int curRow = 0;

        int MinWaitSec;
        int MaxWaitSec;
        
        public Form1()
        {
            InitializeComponent();

            

            currentSearch = SearchTypes.NONE;
        }


        private void getAllNodeURLs(RadTreeNode InputNode)
        {
            foreach (RadTreeNode node in InputNode.Nodes)
            {
                if (node.ImageIndex == 1)
                {
                    DataRow dr = dataStore.NewRow();
                    dr["URL"] = node.Text;
                    dataStore.Rows.Add(dr);
                    Application.DoEvents();
                    
                }
                else
                    getAllNodeURLs(node);
            }
        }

        private void brdStorage_NodeClicked(object sender, EventArgs e)
        {
            CreateStorageTable();
            GridView.DataSource = dataStore;
            LoadGridLayout();
            SetStatus("Loading list...");
            if (brdStorage.tvwCat.SelectedNode.ImageIndex==0)
            {
                getAllNodeURLs(brdStorage.tvwCat.SelectedNode);
                //foreach(RadTreeNode node in brdStorage.tvwCat.SelectedNode.Nodes)
                //{
                //    if (node.ImageIndex == 1)
                //    {
                //        DataRow dr = dataStore.NewRow();
                //        dr["URL"] = node.Text;
                //        dataStore.Rows.Add(dr);
                //        Application.DoEvents();
                //    }
                //}
            }
            currentSearch = SearchTypes.STORAGE;
            SetStatus("Ready");
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            

            if (!IsSearchStopped)
            {
                //Stop teh searh
                SearchButton.Text = "Search";
                IsSearchStopped = true;
                return;
            }
            else
                SearchButton.Text = "Stop";

            IsSearchStopped = false;

            GridView.EnableSorting = true;

            switch (currentSearch)
            {
                case SearchTypes.SEARCH:
                    if (brdSEO.ValidateInput())
                    {
                        SetStatus("Searching. Please wait...");
                        DoSEOSearch();
                        SetStatus("Ready");
                    }
                    break;
                case SearchTypes.ADS:
                    if (brdAds.ValidateInput())
                    {
                        SetStatus("Searching. Please wait...");
                        DoADSSearch();
                        SetStatus("Ready");
                    }
                    break;
                case SearchTypes.IMAGES:
                    if (brdImages.ValidateInput())
                    {
                        SetStatus("Searching. Please wait...");
                        DoIMGSearch();
                        SetStatus("Ready");
                    }
                    break;
                case SearchTypes.SITESNIPER:
                    if (brdSite.ValidateInput())
                    {
                        SetStatus("Searching. Please wait...");
                        DoSiteSearch();
                        SetStatus("Ready");
                    }
                    break;
                case SearchTypes.QUANTCAST:
                    GridView.EnableSorting = false;
                    if (brdQC.ValidateInput())
                    {
                        SetStatus("Importing. Please wait...");
                        DoQCSearch();
                        SetStatus("Ready");
                    }
                    foreach (GridViewDataColumn grdCol in GridView.Columns)
                        grdCol.SortOrder = RadSortOrder.None;
                    
                    break;

                case SearchTypes.GURU:
                    if (brdGuru.ValidateInput())
                    {
                        DoGuruSearch();
                        SetStatus("Ready");
                    }
                    break;
                case SearchTypes.STORAGE:
                    SetStatus("Loading storage...");
                    DoStorage();
                    SetStatus("Ready");
                    break;
            }

            IsSearchStopped = true;

            if (currentSearch == SearchTypes.GURU)
                SearchButton.Text = "Import";
            else
                SearchButton.Text = "Search";


        }



        #region Search Action Methods

        private void DoStorage()
        {
            Msg.Info("Nothing to search for current project");
        }

        private void DoADSSearch()
        {
            int m_Pages;
            DateTime navStarted;
            string SearchTerm, HTMLContent;
            int index = 1;
            int startVal;
            string Title, Content;
            string URL, AnchorURL;
            int nPos1, nPos2 = 0, EndPos;
            string sNavTo;
            string Keyword;

            CreateADSTable();
            GridView.DataSource = dataStore;
            LoadGridLayout();

            SearchLocations objLoc = (brdAds.CountryList.SelectedItem as RadComboBoxItem).Tag as SearchLocations;

            m_Pages = int.Parse(brdAds.Pages.Text);

            #region Ads Scrapping
            foreach (string strKeyword in brdAds.Keywords.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                Keyword = strKeyword.Trim();                
                if (Keyword == "") continue;

                SetStatus("Searching Ads for " + Keyword + " Page 1...");
                SearchTerm = Keyword.Replace(" ", "+");
                navStarted = DateTime.Now;
                webBrowser.Navigate("http://www.google.com/search?hl=en&q=" + SearchTerm + "&gl=" + objLoc.GoogleLocationCode);

                while (true)
                {
                    if (IsSearchStopped) return; // Search is stopped
                    while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                        if (IsSearchStopped) return;
                        if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                        {
                            webBrowser.Stop();
                            break;
                        }
                    }
                    try
                    {
                        HTMLContent = webBrowser.DocumentText;

                        nPos1 = HTMLContent.IndexOf("Sponsored Links");
                        if (nPos1 == -1)
                        {
                            //No sponsored Ads found
                        }
                        else
                        {
                            string[] splitter = { "&amp;q=" };

                            EndPos = HTMLContent.IndexOf("Search Results");
                            while (true)
                            {
                                try
                                {
                                    nPos1 = HTMLContent.IndexOf("<h3>", nPos1);
                                    if (HTMLContent.Substring(nPos1 + 4, 8) != "<a id=an")
                                        break;
                                    nPos1 = HTMLContent.IndexOf("href=\"", nPos1);
                                    nPos2 = HTMLContent.IndexOf("\" >", nPos1);
                                    URL = HTMLContent.Substring(nPos1 + 6, nPos2 - nPos1 - 6);



                                    nPos1 = HTMLContent.IndexOf("</a>", nPos2);
                                    Title = HTMLContent.Substring(nPos2 + 3, nPos1 - nPos2 - 3);
                                    Title = AdScrapper4.Classes.Utils.ClearHTMLTags(Title);

                                    nPos1 = HTMLContent.IndexOf("</h3>", nPos1);
                                    nPos2 = HTMLContent.IndexOf("<cite>", nPos1);
                                    Content = HTMLContent.Substring(nPos1 + 5, nPos2 - nPos1 - 5);
                                    Content = AdScrapper4.Classes.Utils.ClearHTMLTags(Content);

                                    nPos1 = HTMLContent.IndexOf("</cite>", nPos2);
                                    AnchorURL = HTMLContent.Substring(nPos2 + 6, nPos1 - nPos2 - 6);
                                    AnchorURL = AdScrapper4.Classes.Utils.ClearHTMLTags(AnchorURL);


                                    sNavTo = "http://www.google.com" + URL.Replace("&amp;", "&");
                                    navStarted = DateTime.Now;
                                    webBrowser2.Navigate(sNavTo);
                                    while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                                    {
                                        //if (webBrowser1.ReadyState == WebBrowserReadyState.Interactive) break;
                                        Application.DoEvents();
                                        if (IsSearchStopped) return;
                                        if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                                        {
                                            webBrowser2.Stop();
                                            break;
                                        }
                                    }

                                    URL = webBrowser2.Url.ToString();


                                    AnchorURL = webBrowser2.Url.Host;

                                    DataRow dr = dataStore.NewRow();
                                    dr["Engine"] = "Adwords";
                                    dr["Keyword"] = Keyword;
                                    URL = URL.ToLower().Replace("http://www.", "").Replace("http://", "");
                                    dr["Actual URL"] = URL.Replace("https://www.", "").Replace("https://", "");
                                    AnchorURL= AnchorURL.ToLower().Replace("http://www.", "").Replace("http://", "");
                                    dr["Root URL"] = AnchorURL.Replace("https://www.", "").Replace("https://", "");
                                    dr["Title"] = Title;
                                    dr["Description"] = Content;
                                    dataStore.Rows.Add(dr);

                                    Application.DoEvents();
                                }
                                catch { }
                            }
                        }
                    }
                    catch { break; }


                    startVal = index * 10;
                    index++;
                    if (index >= m_Pages + 1)
                        break;
                    SetStatus("Wait delay for next page");
                    System.Threading.Thread.Sleep(rnd.Next(MinWaitSec, MaxWaitSec) * 1000);
                    SetStatus("Searching Ads for " + Keyword + " Page " + index.ToString() + "...");
                    navStarted = DateTime.Now;
                    webBrowser.Navigate("http://www.google.com/search?hl=en&q=" + SearchTerm + "&start=" + startVal.ToString().Trim() + "&sa=N" + "&gl=" + objLoc.GoogleLocationCode);
                }
            }
            #endregion
                        
        }
        private void DoSEOSearch()
        {
            int m_Pages;
            DateTime navStarted;
            string SearchTerm;
            string EngineName;
            int index = 1;
            int startVal;
            string Title, Content;
            string URL;
            int nPos1, nPos2 = 0;
            string Keyword;

            CreateSEOTable();
            GridView.DataSource = dataStore;
            LoadGridLayout();
                        
            m_Pages =int.Parse( brdSEO.Pages.Text);

            SearchLocations objLoc = (brdSEO.CountryList.SelectedItem as RadComboBoxItem).Tag as SearchLocations;

            foreach (object objEngine in brdSEO.EngineList.CheckedItems)
            {

                

                EngineName = objEngine.ToString().ToUpper();
                switch (EngineName)
                {
                    case "GOOGLE":
                        #region Google Scrapping
                        foreach (string strKeyword in brdSEO.Keywords.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                        {

                            Keyword = strKeyword.Trim();
                            if (Keyword == "") continue;

                            index = 1;
                            nPos2 = 0;
                            nPos1 = 0;

                            SetStatus("Searching " + Keyword + " on engine " + EngineName + " Page 1...");
                            SearchTerm = Keyword.Replace(" ", "+");
                            navStarted = DateTime.Now;
                            webBrowser.Navigate("http://www.google.com/search?hl=en&q=" + SearchTerm + "&gl=" + objLoc.GoogleLocationCode);

                            while (true)
                            {
                                if (IsSearchStopped) return; // Search is stopped
                                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                                {
                                    Application.DoEvents();
                                    if (IsSearchStopped) return;
                                    if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                                    {
                                        webBrowser.Stop();
                                        break;
                                    }
                                }

                                try
                                {
                                    HtmlElementCollection colLinks = webBrowser.Document.Links;
                                    for (int i = 0; i < colLinks.Count; i++)
                                    {
                                        if (IsSearchStopped) return;
                                        HtmlElement oLink = colLinks[i];
                                        if (oLink.OuterHtml.StartsWith(@"<A class=l onmousedown=""return clk(this.href") &&
                                            (oLink.InnerText != "Cached" && oLink.InnerText != "Similar pages") &&
                                            (!oLink.OuterHtml.Contains("news_result")) &&
                                            (oLink.OuterHtml.Contains("','res',")))
                                        {
                                            URL = oLink.GetAttribute("href").ToLower();
                                            Title = oLink.InnerText;
                                            try
                                            {
                                                Content = oLink.Parent.NextSibling.InnerText;
                                                Content = Content.Substring(0, Content.IndexOf("\r\n"));
                                            }
                                            catch
                                            {
                                                Content = "";
                                            }
                                            DataRow dr = dataStore.NewRow();
                                            dr["Keyword"] = Keyword;
                                            dr["Engine"] = "Google";
                                            URL = URL.ToLower().Replace("http://www.", "").Replace("http://", "");
                                            dr["URL"] = URL.Replace("https://www.", "").Replace("https://", "");
                                            dr["Title"] = Title;
                                            dr["Description"] = Content;
                                            dataStore.Rows.Add(dr);
                                        }
                                    }
                                }
                                catch { }



                                startVal = index * 10;
                                index++;
                                if (index >= m_Pages + 1)
                                    break;
                                if (brdSEO.radDelayed.IsChecked)
                                {
                                    SetStatus("Wait delay for next page");
                                    System.Threading.Thread.Sleep(rnd.Next(MinWaitSec, MaxWaitSec) * 1000);
                                }
                                navStarted = DateTime.Now;
                                SetStatus("Searching " + Keyword + " on engine " + EngineName + " Page " + index.ToString() + "...");
                                webBrowser.Navigate("http://www.google.com/search?hl=en&q=" + SearchTerm + "&start=" + startVal.ToString().Trim() + "&sa=N" + "&gl=" + objLoc.GoogleLocationCode);

                            }
                        }
                        #endregion
                        break;
                    case "YAHOO":
                        #region Yahoo Scrapping
                        foreach (string strKeyword in brdSEO.Keywords.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                        {
                            Keyword = strKeyword.Trim();
                            if (Keyword == "") continue;

                            index = 1;
                            nPos2 = 0;
                            nPos1 = 0;

                            SetStatus("Searching " + Keyword + " on engine " + EngineName + " Page 1...");
                            SearchTerm = Keyword.Replace(" ", "+");
                            navStarted = DateTime.Now;
                            webBrowser.Navigate("http://search.yahoo.com/search?p=" + SearchTerm );

                            while (true)
                            {
                                if (IsSearchStopped) return; // Search is stopped
                                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                                {
                                    Application.DoEvents();
                                    if (IsSearchStopped) return;
                                    if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                                    {
                                        webBrowser.Stop();
                                        break;
                                    }
                                }
                                try
                                {
                                    HtmlElementCollection colLinks = webBrowser.Document.Links;

                                    for (int i = 0; i < colLinks.Count; i++)
                                    {
                                        if (IsSearchStopped) return;
                                        HtmlElement oLink = colLinks[i];
                                        if (oLink.OuterHtml.Contains("yschttl spt"))
                                        {
                                            bool ProcessThis = true;

                                            Title = oLink.InnerText;
                                            try
                                            {
                                                Content = oLink.Parent.Parent.NextSibling.InnerText;
                                            }
                                            catch
                                            {
                                                Content = "";
                                            }
                                            URL = oLink.GetAttribute("ourl").ToLower();

                                            if (URL.Trim() == "")
                                            {
                                                nPos1 = oLink.OuterHtml.IndexOf("**", 0);
                                                if (nPos1 == -1)
                                                    ProcessThis = false;
                                                else
                                                {
                                                    nPos2 = oLink.OuterHtml.IndexOf("\">", nPos1);
                                                    if (nPos2 == -1)
                                                        ProcessThis = false;
                                                    else
                                                    {
                                                        URL = oLink.OuterHtml.Substring(nPos1 + 2, nPos2 - nPos1 - 2);
                                                        URL = HttpUtility.UrlDecode(URL);
                                                    }
                                                }

                                            }

                                            if (ProcessThis)
                                            {
                                                DataRow dr = dataStore.NewRow();
                                                dr["Keyword"] = Keyword;
                                                dr["Engine"] = "Yahoo";
                                                URL= URL.ToLower().Replace("http://www.", "").Replace("http://", "");
                                                dr["URL"] = URL.Replace("https://www.", "").Replace("https://", "");
                                                dr["Title"] = Title;
                                                dr["Description"] = Content;
                                                dataStore.Rows.Add(dr);
                                            }
                                        }

                                    }
                                }

                                catch { }



                                startVal = index * 10+1;
                                index++;
                                if (index == m_Pages + 1)
                                    break;
                                if (brdSEO.radDelayed.IsChecked)
                                {
                                    SetStatus("Wait delay for next page");
                                    System.Threading.Thread.Sleep(rnd.Next(MinWaitSec, MaxWaitSec) * 1000);
                                }
                                SetStatus("Searching " + Keyword + " on engine " + EngineName + " Page " + index.ToString() + "...");
                                navStarted = DateTime.Now;
                                webBrowser.Navigate("http://search.yahoo.com/search?p=" + SearchTerm + "&b=" + startVal.ToString().Trim());

                            }
                        }
                        #endregion
                        break;
                    case "BING":
                        #region Bing Scrapping
                        foreach (string strKeyword in brdSEO.Keywords.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                        {
                            Keyword = strKeyword.Trim();
                            if (Keyword == "") continue;

                            index = 1;
                            nPos2 = 0;
                            nPos1 = 0;

                            SetStatus("Searching " + Keyword + " on engine " + EngineName + " Page 1...");
                            SearchTerm = Keyword.Replace(" ", "+");
                            navStarted = DateTime.Now;
                            webBrowser.Navigate("http://search.msn.com/results.aspx?q=" + SearchTerm + "&setmkt=" + objLoc.BingLocationCode);

                            while (true)
                            {
                                if (IsSearchStopped) return; // Search is stopped
                                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                                {
                                    Application.DoEvents();
                                    if (IsSearchStopped) return;
                                    if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                                    {
                                        webBrowser.Stop();
                                        break;
                                    }
                                }

                                try
                                {
                                    HtmlElementCollection colLinks = webBrowser.Document.GetElementsByTagName("DIV");

                                    for (int i = 0; i < colLinks.Count; i++)
                                    {

                                        if (IsSearchStopped) return;
                                        HtmlElement oLink = colLinks[i];
                                        if (oLink.OuterHtml.StartsWith("\r\n<DIV class=sb_tlst>"))
                                        {
                                            URL = oLink.GetElementsByTagName("A")[0].GetAttribute("href").ToLower();
                                            Title = oLink.InnerText;
                                            try
                                            {
                                                Content = oLink.Parent.Children[2].InnerText;
                                            }
                                            catch
                                            {
                                                Content = "";
                                            }

                                            DataRow dr = dataStore.NewRow();
                                            dr["Keyword"] = Keyword;
                                            dr["Engine"] = "Bing";
                                            URL = URL.ToLower().Replace("http://www.", "").Replace("http://", "");
                                            dr["URL"] = URL.Replace("https://www.", "").Replace("https://", "");
                                            dr["Title"] = Title;
                                            dr["Description"] = Content;
                                            dataStore.Rows.Add(dr);
                                        }

                                    }
                                }
                                catch { }


                                startVal = index * 10 + 1;
                                index++;
                                if (index == m_Pages + 1)
                                    break;
                                if (brdSEO.radDelayed.IsChecked)
                                {
                                    SetStatus("Wait delay for next page");
                                    System.Threading.Thread.Sleep(rnd.Next(MinWaitSec, MaxWaitSec) * 1000);
                                }

                                SetStatus("Searching " + Keyword + " on engine " + EngineName + " Page " + index.ToString() + "...");
                                string NewURL = "http://search.msn.com/results.aspx?q=" + SearchTerm + "&first=" + startVal.ToString().Trim() + "&setmkt=" + objLoc.BingLocationCode;
                                navStarted = DateTime.Now;

                                webBrowser.Navigate(NewURL);
                            }
                        }
                        #endregion
                        break;
                }
            }
        }
        private void DoIMGSearch()
        {
            int m_Pages;
            DateTime navStarted;
            string SearchTerm, HTMLContent;
            int index = 1;
            int startVal;
            string Title, Content;
            string URL, ImgURL;
            int i;
            string Params="";
            string Keyword;
            ArrayList arSizes = new ArrayList();
            CreateIMGTable();
            GridView.DataSource = dataStore;
            LoadGridLayout();

            m_Pages = int.Parse(brdImages.Pages.Text);

            if (brdImages.ImageWidth.Text != "" && brdImages.ImageHeight.Text != "")
                Params = "&imgw=" + brdImages.ImageWidth.Text.Trim() + "&imgh=" +  brdImages.ImageHeight.Text.Trim();


            

            foreach (string strKeyword in brdImages.Keywords.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                Keyword = strKeyword.Trim();
                if (Keyword == "") continue;

                SetStatus("Searching Images for " + Keyword + " Page 1...");
                SearchTerm = Keyword.Replace(" ", "+") ;
                navStarted = DateTime.Now;
                webBrowser.Navigate("http://images.google.com/images?&q=" + SearchTerm + Params);
                while (true)
                {
                    if (IsSearchStopped) return;
                    while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        if (IsSearchStopped) return;
                        if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                        {
                            webBrowser.Stop();
                            break;
                        }
                        Application.DoEvents();
                    }
                    try
                    {
                        HTMLContent = webBrowser.Document.Body.InnerHtml;
                    }
                    catch
                    {
                        HTMLContent = "";
                    }
                    try
                    {
                        arSizes = getImageSizesArray(HTMLContent);
                    }
                    catch { }

                    i = 0;

                    try
                    {
                        foreach (HtmlElement oElem in webBrowser.Document.GetElementsByTagName("A"))
                        {
                            if (oElem.GetAttribute("href").StartsWith("http://images.google.com/imgres?"))
                            {
                                ImgURL = oElem.GetAttribute("href");
                                ImgURL = ImgURL.Substring(ImgURL.IndexOf("imgrefurl="));
                                ImgURL = ImgURL.Replace("imgrefurl=", "");
                                ImgURL = ImgURL.Substring(0, ImgURL.IndexOf("&"));



                                DataRow dr = dataStore.NewRow() ;
                                dr["Keyword"] = Keyword;
                                dr["Landing URL"] = HttpUtility.UrlDecode(ImgURL);
                                dr["Image Size"] = arSizes[i];
                                dataStore.Rows.Add(dr);
                                i++;
                            }
                        }
                    }
                    catch {  }
                    startVal = index * 10;
                    index++;
                    if (index >= m_Pages + 1)
                    {
                        break;
                    }
                    SetStatus("Wait delay for next page");
                    System.Threading.Thread.Sleep(rnd.Next(MinWaitSec, MaxWaitSec) * 1000);

                    SetStatus("Searching Images for " + Keyword + " Page " + index.ToString() + "...");
                    navStarted = DateTime.Now;
                    webBrowser.Navigate("http://images.google.com/images?&q=" + SearchTerm + "&start=" + startVal.ToString().Trim() + "&sa=N" + Params);
                }

            }
        }
        private void DoGuruSearch()
        {
            int index = 1;
            string[] arLines;
            string[] urlParts;
            bool StartAdd = false;

            CreateGuruTable();
            DataTable dtLocal = dataStore.Clone();

            LoadGridLayout();

            GridView.DataSource = null;

            arLines = File.ReadAllLines(brdGuru.txtImportFile.Text);
            int i = 0;
            
            foreach (string URL in arLines)
            {
                if (StartAdd)
                {
                    if (URL != "")
                    {
                        urlParts = URL.Split(new string[] { "\t" }, StringSplitOptions.None);
                        DataRow dr = dtLocal.NewRow();
                        dr["URL"] = urlParts[1];
                        dtLocal.Rows.Add(dr);
                        SetStatus("Importing URL count " + i.ToString() + "/1000000");

                        i++;
                    }
                }
                if (URL.StartsWith("Rank"))
                    StartAdd = true;
                Application.DoEvents();
            }
            dataStore = dtLocal.Copy();
            GridView.DataSource = dataStore;
            GridView.Refresh();
        }
        private void DoSiteSearch()
        {
            int m_Pages;
            DateTime navStarted;
            HashSet<string> hsURL = new HashSet<string>();
            string SearchTerm, HTMLContent;            
            int index = 1;
            int startVal;
            string Title, Content;
            string URL, ImgURL, Keyword;
            StringBuilder Params = new StringBuilder("");
            ArrayList arSizes;
            CreateSiteTable();
            GridView.DataSource = dataStore;
            LoadGridLayout();
            int LinksAdded = 0;

            m_Pages = int.Parse(brdSite.Pages.Text);


            foreach (RadTreeNode nodeSite in brdSite.nodeCollection)
            {
                index = 1;
                hsURL = new HashSet<string>();
                foreach (string strKeyword in brdSite.Keywords.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    Keyword = strKeyword.Trim();
                    if (Keyword == "") continue;

                    SetStatus("Searching results for " + Keyword + " Page 1...");
                    if (brdSite.radPharse.IsChecked)
                        SearchTerm = "\"" + Keyword + "\"";
                    else
                        SearchTerm = Keyword.Replace(" ", "+");
                    Params = new StringBuilder("");

                    foreach (RadTreeNode nodeTree in brdSite.tvwListOptions.Nodes)
                    {
                        if (nodeTree.Checked)
                        {
                            if (Params.Length == 0)
                                Params.Append(nodeTree.Text + ":" + SearchTerm);
                            else
                                Params.Append(" " + nodeTree.Text + ":" + SearchTerm);

                        }

                    }

                    if (Params.Length == 0)
                        Params.Append(SearchTerm + " site:" + nodeSite.Text);
                    else
                        Params.Append(" site:" + nodeSite.Text);



                    navStarted = DateTime.Now;
                    if (brdSite.radGoogle.IsChecked)
                    {
                        if (Params.Length == 0)
                            webBrowser.Navigate("http://www.google.com/search?&q=" + SearchTerm);
                        else
                            webBrowser.Navigate("http://www.google.com/search?&q=" + Params);
                    }
                    else if (brdSite.radmyWebSearch.IsChecked)
                    {
                        if (Params.Length == 0)
                            webBrowser.Navigate("http://search.mywebsearch.com/mywebsearch/GGmain.jhtml?searchfor=" + SearchTerm);
                        else
                            webBrowser.Navigate("http://search.mywebsearch.com/mywebsearch/GGmain.jhtml?searchfor=" + Params);
                    }
                    else 
                    {
                        if (Params.Length == 0)
                            webBrowser.Navigate("http://search.conduit.com/Results.aspx?q=" + SearchTerm);
                        else
                            webBrowser.Navigate("http://search.conduit.com/Results.aspx?q=" + Params);
                    }


                    while (true)
                    {
                        LinksAdded = 0;

                        if (IsSearchStopped) return;
                        while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                        {
                            if (IsSearchStopped) return;
                            if (DateTime.Now >= navStarted.AddMinutes(BrowseTimeout))
                            {
                                webBrowser.Stop();
                                break;
                            }
                            Application.DoEvents();
                        }

                        try
                        {
                            HtmlElementCollection colLinks = webBrowser.Document.Links;
                            

                            for (int i = 0; i < colLinks.Count; i++)
                            {
                                if (IsSearchStopped) return;
                                HtmlElement oLink = colLinks[i];


                                if (brdSite.radGoogle.IsChecked)
                                {
                                    #region Google Search
                                    if (oLink.OuterHtml.StartsWith(@"<A class=l onmousedown=""return clk(this.href") &&
                                        (oLink.InnerText != "Cached" && oLink.InnerText != "Similar pages") &&
                                        (!oLink.OuterHtml.Contains("news_result")) &&
                                        (oLink.OuterHtml.Contains("','res',")))
                                    {
                                        URL = oLink.GetAttribute("href").ToLower();
                                        Title = oLink.InnerText;
                                        try
                                        {
                                            Content = oLink.Parent.NextSibling.InnerText;
                                            Content = Content.Substring(0, Content.IndexOf("\r\n"));
                                        }
                                        catch
                                        {
                                            Content = "";
                                        }
                                        if (hsURL.Add(URL))
                                        {
                                            DataRow dr = dataStore.NewRow();
                                            dr["Category"] = nodeSite.Parent.Text;
                                            dr["Site"] = nodeSite.Text;
                                            dr["Keyword"] = Keyword;
                                            dr["URL"] = URL;
                                            dr["Title"] = Title;
                                            dr["Description"] = Content;

                                            string[] arURLParts = URL.Split(new string[] { "/dp/" }, StringSplitOptions.None);
                                            if (arURLParts.Length == 2)
                                                dr["Asin Number"] = arURLParts[1].Replace("/", "");
                                            else
                                                dr["Asin Number"] = "";
                                            dataStore.Rows.Add(dr);
                                        }
                                        LinksAdded++;
                                    }
                                    #endregion
                                }
                                else if (brdSite.radmyWebSearch.IsChecked)
                                {
                                    #region MyWebSearch Search
                                    if (oLink.Id !=null &&  oLink.Id.StartsWith("rw"))
                                    {
                                        
                                        try
                                        {
                                            Content = oLink.NextSibling.NextSibling.InnerText;
                                            //Content = Content.Substring(0, Content.IndexOf("\r\n"));
                                        }
                                        catch
                                        {
                                            Content = "";
                                        }
                                        try
                                        {
                                            URL = oLink.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                                        }
                                        catch 
                                        {
                                            URL = "";
                                        }
                                        Title = oLink.InnerText;
                                        if (hsURL.Add(URL))
                                        {
                                            DataRow dr = dataStore.NewRow();
                                            dr["Category"] = nodeSite.Parent.Text;
                                            dr["Site"] = nodeSite.Text;
                                            dr["Keyword"] = Keyword;
                                            dr["URL"] = URL;
                                            dr["Title"] = Title;
                                            dr["Description"] = Content;

                                            string[] arURLParts = URL.Split(new string[] { "/dp/" }, StringSplitOptions.None);
                                            if (arURLParts.Length == 2)
                                                dr["Asin Number"] = arURLParts[1].Replace("/", "");
                                            else
                                                dr["Asin Number"] = "";
                                            dataStore.Rows.Add(dr);
                                        }
                                        LinksAdded++;
                                    }
                                    #endregion
                                }
                                else 
                                {
                                    #region Conduit Search
                                    if (oLink.Id != null && oLink.Id.StartsWith("results_results__ctl") && oLink.Id.EndsWith("_title"))
                                    {

                                        Title = oLink.InnerText;
                                        try
                                        {
                                            URL = oLink.GetAttribute("href");
                                        }
                                        catch
                                        {
                                            URL = "";
                                        }

                                        try
                                        {
                                            Content = oLink.Parent.NextSibling.InnerText;
                                            //Content = Content.Substring(0, Content.IndexOf("\r\n"));
                                        }
                                        catch
                                        {
                                            Content = "";
                                        }


                                        if (hsURL.Add(URL))
                                        {
                                            DataRow dr = dataStore.NewRow();
                                            dr["Category"] = nodeSite.Parent.Text;
                                            dr["Site"] = nodeSite.Text;
                                            dr["Keyword"] = Keyword;
                                            dr["URL"] = URL;
                                            dr["Title"] = Title;
                                            dr["Description"] = Content;

                                            string[] arURLParts = URL.Split(new string[] { "/dp/" }, StringSplitOptions.None);
                                            if (arURLParts.Length == 2)
                                                dr["Asin Number"] = arURLParts[1].Replace("/", "");
                                            else
                                                dr["Asin Number"] = "";
                                            dataStore.Rows.Add(dr);
                                        }
                                        LinksAdded++;
                                    }                                    
                                    #endregion
                                }
                            }
                            if (LinksAdded < 10)
                                break;
                        }
                        catch { }





                        startVal = index * 10;
                        index++;
                        if (index >= m_Pages + 1)
                            break;

                        if (brdSite.radDelayed.IsChecked)
                        {
                            SetStatus("Wait delay for next page");
                            System.Threading.Thread.Sleep(rnd.Next(MinWaitSec, MaxWaitSec) * 1000);
                        }

                        SetStatus("Searching " + Keyword + " Page " + index.ToString() + "...");
                        navStarted = DateTime.Now;
                        if (brdSite.radGoogle.IsChecked)
                        {
                            if (Params.Length == 0)
                                webBrowser.Navigate("http://www.google.com/search?&q=" + SearchTerm + "&start=" + startVal.ToString().Trim() + "&sa=N");
                            else
                                webBrowser.Navigate("http://www.google.com/search?&q=" + Params + "&start=" + startVal.ToString().Trim() + "&sa=N");
                        }
                        else if (brdSite.radmyWebSearch.IsChecked)
                        {
                            if (Params.Length == 0)
                                webBrowser.Navigate("http://search.mywebsearch.com/mywebsearch/GGmain.jhtml?searchfor=" + SearchTerm + "&pn=" + index.ToString());
                            else
                                webBrowser.Navigate("http://search.mywebsearch.com/mywebsearch/GGmain.jhtml?searchfor=" + Params + "&pn=" + index.ToString());
                        }
                        else
                        {
                            if (Params.Length == 0)
                                webBrowser.Navigate("http://search.conduit.com/Results.aspx?q=" + SearchTerm + "&start=" + startVal.ToString().Trim());
                            else
                                webBrowser.Navigate("http://search.conduit.com/Results.aspx?q=" + Params + "&start=" + startVal.ToString().Trim());
                        }

                    }

                }
            
            }
        }
        private void DoQCSearch()
        {
            int nDepth;
            DateTime navStarted;
            string SearchTerm;
            string EngineName;
            int index = 1;
            int startVal;
            string Title, Content;
            int nPos1, nPos2 = 0;
            string OtherURL;

            CreateQCTable();
            GridView.DataSource = dataStore;
            LoadGridLayout();

            nDepth = int.Parse(brdQC.Depth.Text);
            MaxDepth = nDepth;

            
            foreach (string URL in brdQC.URLList.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                
                depth = 0;
                FetchURLs(URL);
                
            }
                
            
        }
        #endregion

        private ArrayList getImageSizesArray(string HTMLContent)
        {
            int nPos1,nPos2;
            string rawData, imagesize;
            string[] arRawData;
            string[] fields;
            ArrayList retVal = new ArrayList(0);

            nPos1 = HTMLContent.IndexOf("dyn.setResults([[");
            nPos2 = HTMLContent.IndexOf("]]);", nPos1);

            rawData = HTMLContent.Substring(nPos1 + 17, nPos2 - nPos1 - 17);
            arRawData = rawData.Split(new string[] { "],[" }, StringSplitOptions.None);
            foreach (string rowData in arRawData)
            {
                fields = rowData.Split(new string[] { "\",\"" }, StringSplitOptions.None);
                imagesize = fields[9].Split(new string[] { "-" }, StringSplitOptions.None)[0].Replace("\"","");
                retVal.Add(imagesize);
            }
            return retVal;
        }


        #region Project types Toolbar Clicks
        private void rbSEO_Click(object sender, EventArgs e)
        {
            brdSEO = new boardSEO();
            foreach(Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            //pnlParameters.Controls.Clear();
            pnlParameters.Controls.Add(brdSEO);
            currentSearch = SearchTypes.SEARCH;
            SearchButton.Text = "Search";
        }

        private void rbAds_Click(object sender, EventArgs e)
        {
            brdAds = new boardAds();
            foreach (Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            pnlParameters.Controls.Add(brdAds);
            currentSearch = SearchTypes.ADS;
            SearchButton.Text = "Search";
        }
        private void rbImages_Click(object sender, EventArgs e)
        {
            brdImages = new boardImages();
            foreach (Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            pnlParameters.Controls.Add(brdImages);
            currentSearch = SearchTypes.IMAGES;
            SearchButton.Text = "Search";
        }

        private void rbQC_Click(object sender, EventArgs e)
        {
            brdQC = new boardQuantCast();
            foreach (Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            pnlParameters.Controls.Add(brdQC);
            currentSearch = SearchTypes.QUANTCAST;
            SearchButton.Text = "Search";
        }


        private void rbSite_Click(object sender, EventArgs e)
        {
            brdSite = new boardSiteSniper();
            foreach (Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            pnlParameters.Controls.Add(brdSite);
            currentSearch = SearchTypes.SITESNIPER;
            SearchButton.Text = "Search";
        }

        private void rbGuru_Click(object sender, EventArgs e)
        {
            brdGuru = new boardGuruMillion();
            foreach (Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            pnlParameters.Controls.Add(brdGuru);
            currentSearch = SearchTypes.GURU;
            SearchButton.Text = "Import";
        }

        private void rbStorage_Click(object sender, EventArgs e)
        {
            brdStorage = new boardStorage();
            foreach (Control ctl in pnlParameters.Controls)
                ctl.Dispose();
            pnlParameters.Controls.Add(brdStorage);
            currentSearch = SearchTypes.STORAGE;
            SearchButton.Text = "Search";
            brdStorage.NodeClicked += new boardStorage.NodeClickEventHandler(brdStorage_NodeClicked);
        }

        #endregion

        private void AddFilter_Click(object sender, EventArgs e)
        {
            ArrayList arDesc = new ArrayList();

            StringBuilder URL = new StringBuilder("");
            try
            {
                if (GridView.CurrentColumn != null)
                {
                    if (GridView.CurrentColumn.HeaderText.Contains("URL"))
                    {
                        foreach (GridViewDataRowInfo grRow in GridView.Rows)
                        {
                            URL.Append(grRow.Cells[GridView.CurrentColumn.HeaderText].Value.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            catch { }

            


            Filter frmFilter = new Filter();
            frmFilter.BrowseTimeout = BrowseTimeout;
            frmFilter.txtOriginal.Text = URL.ToString();
            frmFilter.ShowDialog();
            
        }

        private void ReadConfigValues()
        {
            BrowseTimeout = int.Parse(ConfigurationManager.AppSettings["BrowseTimeout_Mnts"]);
            RSSUrl =ConfigurationManager.AppSettings["RSSUrl"];
            MinWaitSec = int.Parse( ConfigurationManager.AppSettings["MinWaitSecs"]);
            MaxWaitSec = int.Parse(ConfigurationManager.AppSettings["MaxWaitSecs"]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            if (Properties.Settings.Default.MyState == FormWindowState.Normal)
            {
                this.Size = Properties.Settings.Default.MySize;
                this.Location = Properties.Settings.Default.MyLoc;
            }
            else
                this.WindowState = Properties.Settings.Default.MyState;
            Show();
            SetStatus("Loading. Please wait...");
            this.Enabled = false;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;
            ReadConfigValues();
            LoadRSSMenu();
            this.Enabled = true;
            SetStatus("Ready");

        }


        #region Create Tables Code
        private void CreateQCTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("Start URL"));
            dataStore.Columns.Add(new DataColumn("1st Level URL"));
            dataStore.Columns.Add(new DataColumn("2nd Level URL"));
            dataStore.Columns.Add(new DataColumn("3rd Level URL"));
            dataStore.Columns.Add(new DataColumn("4th Level URL"));
            dataStore.Columns.Add(new DataColumn("5th Level URL"));
            dataStore.Columns.Add(new DataColumn("All URLs"));
        }

        private void CreateSEOTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("Engine"));
            dataStore.Columns.Add(new DataColumn("Keyword"));
            dataStore.Columns.Add(new DataColumn("URL"));
            dataStore.Columns.Add(new DataColumn("Title"));
            dataStore.Columns.Add(new DataColumn("Description"));
        }

        private void CreateADSTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("Engine"));
            dataStore.Columns.Add(new DataColumn("Keyword"));
            dataStore.Columns.Add(new DataColumn("Actual URL"));
            dataStore.Columns.Add(new DataColumn("Root URL"));
            dataStore.Columns.Add(new DataColumn("Title"));
            dataStore.Columns.Add(new DataColumn("Description"));
        }
        private void CreateStorageTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("URL"));
        }
        private void CreateIMGTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("Keyword"));
            dataStore.Columns.Add(new DataColumn("Landing URL"));            
            dataStore.Columns.Add(new DataColumn("Image Size"));
        }

        private void CreateSiteTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("Category"));
            dataStore.Columns.Add(new DataColumn("Site"));
            dataStore.Columns.Add(new DataColumn("Keyword"));
            dataStore.Columns.Add(new DataColumn("URL"));
            dataStore.Columns.Add(new DataColumn("Title"));
            dataStore.Columns.Add(new DataColumn("Description"));
            dataStore.Columns.Add(new DataColumn("Asin Number"));
        }
        private void CreateGuruTable()
        {
            dataStore = new DataTable("adscrapper");
            dataStore.Columns.Add(new DataColumn("URL"));
        }

        #endregion

        private void butVisitURL_Click(object sender, EventArgs e)
        {
            if (GridView.CurrentCell != null)
            {
                string URL = GridView.CurrentCell.Value.ToString();
                if (URL != "")
                {
                    Process objProcess = new Process();
                    if (URL.ToLower().StartsWith("http"))
                        objProcess.StartInfo.FileName = URL;
                    else
                        objProcess.StartInfo.FileName = "http://" + URL;
                    objProcess.Start();
                }
            }
        }

        private void butCopyURL_Click(object sender, EventArgs e)
        {
            if (GridView.CurrentCell != null)
            {
                string URL = GridView.CurrentCell.Value.ToString();
                if (URL != "")
                {
                    Clipboard.SetText(URL);
                }
            }
        }

        private void rbExport_Click(object sender, EventArgs e)
        {
            RadGridViewExcelExporter exporter;
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            saveFileDialog.FileName = "Export.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetStatus("Exporting. Please wait...");
                exporter = new RadGridViewExcelExporter();
                exporter.Export(GridView, saveFileDialog.FileName, "Sheet1");
                AdScrapper4.Classes.Msg.Info("File exported as " + saveFileDialog.FileName);
                SetStatus("Ready");
            }

        }

        private void rbSave_Click(object sender, EventArgs e)
        {
            switch (currentSearch)
            {
                case SearchTypes.SEARCH:
                    saveFileDialog.Filter = "Search File (*.sea)|*.sea";
                    break;
                case SearchTypes.ADS:
                    saveFileDialog.Filter = "Adscrap File (*.ads)|*.ads";
                    break;
                case SearchTypes.IMAGES:
                    saveFileDialog.Filter = "Image Scrap File (*.ims)|*.ims";
                    break;
                case SearchTypes.GURU:
                    saveFileDialog.Filter = "Guru Million File (*.guru)|*.guru";
                    break;
                case SearchTypes.SITESNIPER:
                    saveFileDialog.Filter = "Site Sniper File (*.ssn)|*.ssn";
                    break;
                case SearchTypes.QUANTCAST:
                    saveFileDialog.Filter = "Trends File (*.trn)|*.trn";
                    break;
                default:
                    Msg.Info("Can't save the current project");
                    break;
            }

            
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetStatus("Saving. Please wait...");
                dataStore.TableName = "adscrapper";
                dataStore.WriteXml(saveFileDialog.FileName);
                SetStatus("Ready");
            }

        }


        #region Locked Code
        private void BestFitColumns()
        {
            foreach (GridViewDataColumn column in GridView.Columns)
            {
                column.BestFit();
            }
        }
        private void SetStatus(string Message)
        {
            StatusLabel.Text = Message;
            StatusBar.Refresh();
            Application.DoEvents();
        }
        private void butSaveLayout_Click(object sender, EventArgs e)
        {
            SaveGridLayout();
        }
        private void GridView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            SaveGridLayout();
        }

        private void SaveGridLayout()
        {
            try
            {
                switch (currentSearch)
                {
                    case SearchTypes.SEARCH:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_search.xml");
                        break;
                    case SearchTypes.ADS:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_ads.xml");
                        break;
                    case SearchTypes.IMAGES:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_images.xml");
                        break;
                    case SearchTypes.GURU:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_guru.xml");
                        break;
                    case SearchTypes.SITESNIPER:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_sniper.xml");
                        break;
                    case SearchTypes.QUANTCAST:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_trends.xml");
                        break;
                    case SearchTypes.STORAGE:
                        GridView.SaveLayout(Application.StartupPath + @"\grid_storage.xml");
                        break;
                }
            }
            catch { }
        }


        private void LoadGridLayout()
        {
            try
            {
                switch (currentSearch)
                {
                    case SearchTypes.SEARCH:
                        if (File.Exists(Application.StartupPath + @"\grid_search.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_search.xml");
                        break;
                    case SearchTypes.ADS:
                        if (File.Exists(Application.StartupPath + @"\grid_ads.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_ads.xml");
                        break;
                    case SearchTypes.IMAGES:
                        if (File.Exists(Application.StartupPath + @"\grid_images.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_images.xml");
                        break;
                    case SearchTypes.GURU:
                        if (File.Exists(Application.StartupPath + @"\grid_guru.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_guru.xml");
                        break;
                    case SearchTypes.SITESNIPER:
                        if (File.Exists(Application.StartupPath + @"\grid_sniper.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_sniper.xml");
                        break;
                    case SearchTypes.QUANTCAST:
                        if (File.Exists(Application.StartupPath + @"\grid_trends.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_trends.xml");
                        break;
                    case SearchTypes.STORAGE:
                        if (File.Exists(Application.StartupPath + @"\grid_storage.xml"))
                            GridView.LoadLayout(Application.StartupPath + @"\grid_storage.xml");
                        break;
                }
            }
            catch
            {
                try
                {
                    SaveGridLayout();
                }
                catch { }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MyState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MySize = this.Size;
                Properties.Settings.Default.MyLoc = this.Location;
            }

            else
            {
                Properties.Settings.Default.MySize = this.RestoreBounds.Size;
                Properties.Settings.Default.MyLoc = this.RestoreBounds.Location;
            }
            Properties.Settings.Default.MyState = this.WindowState;
            Properties.Settings.Default.Save();
        }
        #endregion

        private void rbOpen_Click(object sender, EventArgs e)
        {

            openFileDialog.Filter = "Search File (*.sea)|*.sea|Adscrap File (*.ads)|*.ads" + 
                "|Image Scrap File (*.ims)|*.ims|Guru Million File (*.guru)|*.guru" +
                "|Site Sniper File (*.ssn)|*.ssn|Trends File (*.trn)|*.trn";


            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetStatus("Opening. Please wait...");
                dataStore = new DataTable("adscrapper");
                dataStore.ReadXmlSchema(openFileDialog.FileName);
                dataStore.ReadXml(openFileDialog.FileName);
                
                
                GridView.DataSource = dataStore;

                SetStatus("Ready");
            }
            GridView.EnableSorting = true;
            switch (openFileDialog.FilterIndex)
            {
                case 0:
                    rbSEO_Click(sender, e);
                    break;
                case 1:
                    rbAds_Click(sender, e);
                    break;
                case 2:
                    rbImages_Click(sender, e);
                    break;
                case 3:
                    rbGuru_Click(sender, e);
                    break;
                case 4:
                    rbSite_Click(sender,e);
                    break;
                case 5:
                    rbQC_Click(sender, e);
                    GridView.EnableSorting = false;
                    break;
            }
            LoadGridLayout();
        }

        private void rbFilter_Click(object sender, EventArgs e)
        {
            AddFilter_Click(sender, e);
        }


        private void FetchURLs(string URL)
        {
            MaxDepth = int.Parse( brdQC.Depth.Text);
            depth = 0;
            hashURL = new HashSet<string>();
            hashURL.Add(URL);
            StartTrendsCrawl(URL);
        }

        public void StartTrendsCrawl(string site)
        {
            int rowIndex;

            DataRow dr = dataStore.NewRow();
            ArrayList urlList = new ArrayList();
            ArrayList tempList = new ArrayList();
            ArrayList newList = new ArrayList();

            rowIndex = dataStore.Rows.Count;

            dr["Start URL"] = site;
            dr["1st Level URL"] = "";
            dr["2nd Level URL"] = "";
            dr["3rd Level URL"] = "";
            dr["4th Level URL"] = "";
            dr["5th Level URL"] = "";
            dr["All URLs"] = "";
            dataStore.Rows.Add(dr);

            
            curRow = rowIndex;

            SetStatus("Fetching level 1 URLs");
            urlList = Crawl(site,1);
            newList = new ArrayList();

            curRow = rowIndex;
            if (MaxDepth >= 2)
            {
                SetStatus("Fetching level 2 URLs");
                foreach (string url in urlList)
                {
                    tempList = Crawl(url, 2);
                    newList.AddRange(tempList);
                }
            }

            urlList = new ArrayList();
            curRow = rowIndex;
            if (MaxDepth >= 3)
            {
                SetStatus("Fetching level 3 URLs");
                foreach (string url in newList)
                {
                    tempList = Crawl(url, 3);
                    urlList.AddRange(tempList);
                }
            }

            newList = new ArrayList();
            curRow = rowIndex;
            if (MaxDepth >= 4)
            {
                SetStatus("Fetching level 4 URLs");
                foreach (string url in urlList)
                {
                    tempList = Crawl(url, 4);
                    newList.AddRange(tempList);
                }
            }

            urlList = new ArrayList();
            curRow = rowIndex;
            if (MaxDepth >= 5)
            {
                SetStatus("Fetching level 5 URLs");
                foreach (string url in newList)
                {
                    tempList = Crawl(url, 5);
                    urlList.AddRange(tempList);
                }
            }

            curRow = rowIndex;
            foreach (string url in hashURL)
            {
                if (curRow < dataStore.Rows.Count)
                    dataStore.Rows[curRow][6] = url;
                else
                {
                    DataRow dr1 = dataStore.NewRow();
                    dr1[6] = url;
                    dataStore.Rows.Add(dr1);
                }
                curRow++;
            }

            SetStatus("Ready");
        }

        private ArrayList Crawl(string site,int Deep)
        {
            HtmlElementCollection LinkCol;
            string UrlPart;
            string PageContent;
            string PointingURL;
            string URL;
            int nPos, nPos1;
            string HTMLText;
            ArrayList URLList = new ArrayList();
            bool FollowThisDomain = true;
            string URLSub;


            if (IsSearchStopped) return URLList;

            DateTime navStarted1 = DateTime.Now;
            webBrowser.Navigate("http://trends.google.com/websites?q=" + site + "&sa=N");
            while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                if (IsSearchStopped) return URLList;

                if (DateTime.Now >= navStarted1.AddMinutes(BrowseTimeout))
                {
                    webBrowser.Stop();
                    break;
                }
                Application.DoEvents();
            }


            try
            {

                foreach (HtmlElement oElem in webBrowser.Document.GetElementsByTagName("DIV"))
                {
                    try
                    {
                        if (oElem.Children.Count > 0)
                        {
                            if (oElem.Children[0].TagName == "H2" & oElem.Children[0].InnerText == "Also visited")
                            {
                                foreach (HtmlElement oElemSub in oElem.GetElementsByTagName("TD"))
                                {
                                    if (oElemSub.OuterHtml.StartsWith("\r\n<TD class=trends-barchart-name-cell>"))
                                    {

                                        URLSub = oElemSub.InnerText;
                                        if (hashURL.Add(URLSub))
                                        {

                                            if (curRow < dataStore.Rows.Count)
                                            {
                                                dataStore.Rows[curRow][Deep] = URLSub;
                                            }
                                            else
                                            {
                                                DataRow dr = dataStore.NewRow();
                                                dr[Deep] = URLSub;
                                                dataStore.Rows.Add(dr);
                                            }
                                            curRow++;
                                            URLList.Add(URLSub);
                                        }
                                    }

                                }
                                break;
                            }
                        }
                    }
                    catch { }
                }

            }
            catch { }


            return URLList;
        }


        private void LoadRSSMenu()
        {
            string RSSData;
            try
            {
                WebClient Client = new WebClient();
                Stream strm = Client.OpenRead(RSSUrl);
                StreamReader sr = new StreamReader(strm);
                C1.Win.C1Ribbon.RibbonButton rbMenu;

                string title = "";
                string link;

                RSSData = sr.ReadToEnd();

                XmlDocument objXMLDoc = new XmlDocument();
                objXMLDoc.LoadXml(RSSData);
                foreach (XmlNode ParentNode in objXMLDoc.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode ChildNode in ParentNode.ChildNodes)
                    {
                        if (ChildNode.Name == "item")
                        {
                            foreach (XmlNode tmpNode in ChildNode.ChildNodes)
                            {
                                if (tmpNode.Name == "title")
                                    title = tmpNode.InnerText;
                                if (tmpNode.Name == "link")
                                {
                                    link = tmpNode.InnerText;
                                    rbMenu = new C1.Win.C1Ribbon.RibbonButton();
                                    rbMenu.Tag = link;
                                    rbMenu.Text = title;
                                    rbMenu.SmallImage = global::AdScrapper4.Properties.Resources.rss;
                                    rbMenu.Click += new System.EventHandler(this.RSSLink_Click);
                                    rbRSS.Items.Add(rbMenu);
                                }
                            }
                        }
                    }
                }
            }
            catch { Msg.Error("Could not read RSS Feed"); }

        }

        private void RSSLink_Click(object sender, EventArgs e)
        {
            C1.Win.C1Ribbon.RibbonButton rbMenu = (C1.Win.C1Ribbon.RibbonButton) sender;
            
            Process objProcess = new Process();
            objProcess.StartInfo.FileName = rbMenu.Tag.ToString();
            objProcess.Start();
        }

        private void rbBestFit_Click(object sender, EventArgs e)
        {
            BestFitColumns();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = dataStore.Clone();
            dataStore = dt.Clone();
            GridView.DataSource = dataStore;
        }

        private void butVisitURL_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void butSaveLayout_MouseHover(object sender, EventArgs e)
        {

        }

        private void butVisitURL_MouseMove(object sender, MouseEventArgs e)
        {
            lblToolTip.Text = "Visit the URL";
            lblToolTip.Refresh(); 
        }

        private void butSaveLayout_MouseMove(object sender, MouseEventArgs e)
        {
            lblToolTip.Text = "Save grid layout";
            lblToolTip.Refresh();
        }

        private void butCopyURL_MouseMove(object sender, MouseEventArgs e)
        {
            lblToolTip.Text = "Copy cell value";
            lblToolTip.Refresh();
        }

        private void rbBestFit_MouseMove(object sender, MouseEventArgs e)
        {
            lblToolTip.Text = "Best fit columns";
            lblToolTip.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Width< 885)
            {
                this.Width = 885;
            }
            if (this.Height< 591)
            {
                this.Height = 591;
            }
        }



    }
}
