using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdScrapper4.Classes
{
    public static class Msg
    {
        public static  DialogResult Info(string Message)
        {
            return MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static  DialogResult Error(string Message)
        {
            return MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static  DialogResult Question(string Message)
        {
            return MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }


    public class Utils
    {
        public static string ClearHTMLTags(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            string temp = source;
            while (temp.IndexOf('<') != -1 && temp.IndexOf('>') != -1)
            {
                int start = temp.IndexOf('<');
                int end = temp.IndexOf('>');
                temp = temp.Remove(start, end - start + 1);
            }
            return temp;
        }


        public static string GetMetaTags(WebBrowser webBrowserObj)
        {
            HtmlElementCollection objElements = webBrowserObj.Document.GetElementsByTagName("meta");
            if (objElements == null) return "";
            foreach (HtmlElement objElem in objElements)
            {
                if (objElem.GetAttribute("name").ToLower().StartsWith("keyword")
                    || objElem.GetAttribute("http-equiv").ToLower().StartsWith("keyword"))
                {
                    return objElem.GetAttribute("content");
                }
            }
            return "";
        }

        public static string GetMetaDescription(WebBrowser webBrowserObj)
        {
            HtmlElementCollection objElements = webBrowserObj.Document.GetElementsByTagName("meta");
            if (objElements == null) return "";
            foreach (HtmlElement objElem in objElements)
            {
                if (objElem.GetAttribute("name").ToLower() == "description" ||
                    objElem.GetAttribute("http-equiv").ToLower() == "description")
                {
                    return objElem.GetAttribute("content");
                }
            }
            return "";
        }
    }
}
