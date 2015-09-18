using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace CloudTask_GUI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private string appPath = null;
        public MainForm()
        {
            InitializeComponent();
            appPath = Application.StartupPath;

            string resxFile = @"F:\CloudTask\trunk\src\CloudTask\CloudTask_Model\Resources\HeaderResources_EN.resx";


            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                // Retrieve the string resource for the title.
                this.Text = resxSet.GetString("ApplicationTitle");
            }
            //this.Text = CommanderControlLib.CommonProjectDefinitions.GetApplicationTitle;
        }
    }
}
