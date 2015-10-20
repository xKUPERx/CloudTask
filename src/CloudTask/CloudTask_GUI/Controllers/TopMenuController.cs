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
        #endregion Members

        #region Constructors
        public TopMenuController()
        {
            baseCaseController = new BaseCaseController();
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
        #endregion Delegates
    }
}
