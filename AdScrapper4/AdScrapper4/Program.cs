using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Utility.ModifyRegistry;

namespace AdScrapper4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ModifyRegistry objReg = new ModifyRegistry();

            objReg.ShowError = true;
            objReg.BaseRegistryKey = Registry.CurrentUser;
            objReg.SubKey = @"SOFTWARE\\Microsoft\\Internet Explorer\\Main";
            objReg.Write("Display Inline Images", "no");
            objReg.Write("Play_Background_Sounds", "no");
            objReg.Write("Play_Animations", "no");
            objReg.SubKey = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\3";
            objReg.Write("1400", 3);


            Application.Run(new Form1());


            objReg.BaseRegistryKey = Registry.CurrentUser;
            objReg.SubKey = @"SOFTWARE\\Microsoft\\Internet Explorer\\Main";
            objReg.Write("Display Inline Images", "yes");
            objReg.Write("Play_Background_Sounds", "yes");
            objReg.Write("Play_Animations", "yes");
            objReg.SubKey = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\3";
            objReg.Write("1400", 0);
        }
    }
}
