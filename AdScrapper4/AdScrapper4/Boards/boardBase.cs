using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdScrapper4.Boards
{
    public partial class boardBase : UserControl
    {
        public boardBase()
        {
            InitializeComponent();
        }

        public virtual Boolean ValidateInput()
        {
            return true;
        }
    }
}
