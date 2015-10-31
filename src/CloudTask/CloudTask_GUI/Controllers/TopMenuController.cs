using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;

namespace CloudTask_GUI.Controllers
{
    class TopMenuController
    {
        #region Members
        private BaseCaseController baseCaseController;
        private OneDriveController oneDriveController;
        #endregion Members

        #region Constructors
        public TopMenuController()
        {
            baseCaseController = new BaseCaseController();
            oneDriveController = new OneDriveController();
        }
        #endregion Constructors

        #region Delegates

        public void NewCaseClick(object sender, ItemClickEventArgs e)
        {
            baseCaseController.CreateNewCase();
        }

        public void OpenCaseClick(object sender, ItemClickEventArgs e)
        {
            baseCaseController.LoadCase();
        }

        public void SaveCaseClick(object sender, ItemClickEventArgs e)
        {
            baseCaseController.SaveCase();
        }

        public void TestDriveClick(object sender, ItemClickEventArgs e)
        {
            oneDriveController.Show();
        }
        #endregion Delegates
    }
}
