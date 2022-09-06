using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AdScrapper4.Classes
{
    class TrendsCrawler
    {
        private System.Windows.Forms.WebBrowser webBrowser;
        HashSet<string> CollectedLinks = new HashSet<string>();
        int depth = 0;
        public int MaxDepth;
        public string GUID;
        private string TopLevelDomain;
        public ArrayList URLList = new ArrayList();

        public delegate void OnLinkCollected   (string PointingURL, string LandingURL, string DocumentText, string Title, string PageContent,    int nCurrentDepth);

        public event OnLinkCollected urlPageLoadNotifications;

        public TrendsCrawler()
        {
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);
        }

        private void webBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public ArrayList StartCrawl(string site)
        {

            depth++;
            Crawl(site);
            depth--;
            return URLList;
        }

        private void Crawl(string site)
        {
            HtmlElementCollection LinkCol;
            string UrlPart;
            string PageContent;
            string PointingURL;
            string URL;
            int nPos, nPos1;
            string HTMLText;
            bool FollowThisDomain = true;

            System.Windows.Forms.WebBrowser webBrowser1 = new System.Windows.Forms.WebBrowser();
            System.Windows.Forms.WebBrowser webBrowser2 = new System.Windows.Forms.WebBrowser();

            webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);
            webBrowser2.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);

            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;

            if (MaxDepth == 0)
            {
                //  foreach (OnLinkCollected callback in urlPageLoadNotifications.GetInvocationList())
                //     callback.BeginInvoke(site, "", "",Title , Content, depth, null, null);
            }
            else
            {

                int i = 0;
                DateTime navStarted1 = DateTime.Now;
                webBrowser1.Navigate("http://www.quantcast.com/" + site);
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    if (DateTime.Now >= navStarted1.AddMinutes(BrowseTimeout))
                    {
                        webBrowser1.Stop();
                        break;
                    }
                    Application.DoEvents();
                }


                URL = "";
                HTMLText = webBrowser1.Document.Body.InnerHtml;
                nPos = HTMLText.IndexOf("Audience Also Visits <IMG", 1);

                while (true)
                {
                    if (nPos == -1) break;
                    nPos = HTMLText.IndexOf("c-affinity-quiet", nPos);
                    if (nPos == -1) break;
                    nPos = HTMLText.IndexOf(@"href=""/", nPos);
                    nPos1 = HTMLText.IndexOf(@"""", nPos + 7);
                    UrlPart = HTMLText.Substring(nPos + 7, nPos1 - nPos - 7);
                    //UrlPart = UrlPart.Replace("http://www.quantcast.com/", "");
                    nPos = nPos1;
                    depth++;
                    URLList.Add(UrlPart);
                    if (depth <= MaxDepth)
                        Crawl(UrlPart);
                    depth--;

                }
                return;
            }
        }
    }
}
