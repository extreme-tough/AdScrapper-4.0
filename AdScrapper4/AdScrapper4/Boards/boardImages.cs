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
    public partial class boardImages : boardBase
    {
        public boardImages()
        {
            InitializeComponent();
        }
        public override Boolean ValidateInput()
        {
            if (Keywords.Text == "")
            {
                Msg.Error("Keyword cannot be empty");
                return false;
            }

            if (ImageWidth.Text != "" && ImageHeight.Text == "")
            {
                Msg.Error("Please enter height of the image");
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
            return true;
        }
    }
}
