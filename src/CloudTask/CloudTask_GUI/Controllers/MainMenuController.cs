using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using CloudTask_Model;

namespace CloudTask_GUI.Controllers
{
    class MainMenuController : BaseCaseController
    {
        #region Delegates

        public void CaseSaveAsClicked(Object sender, EventArgs e)
        {
            this.SaveCaseAs();
        }

        public void CaseSaveClicked(Object sender, EventArgs e)
        {
            this.SaveCase();
        }

        public void OpenCaseClicked(object sender, BackstageViewItemEventArgs e)
        {
            this.LoadCase();
        }

        public void NewCaseClicked(object sender, BackstageViewItemEventArgs e)
        {
            this.CreateNewCase();
        }

        public void DeleteCaseClicked(object sender, BackstageViewItemEventArgs e)
        {
            this.DeleteCase();
        }

        public void ExitClicked(object sender, BackstageViewItemEventArgs e)
        {
            DialogResult dialogResult = DialogBoxTemplates.ShowYesNoCancelDialogBox(CaseKeeper.AppMainForm, CloudTask_GUI.Properties.Resources.ResourceManager.GetString("SaveChangesInCurrentCase"));
            if (dialogResult != DialogResult.Cancel)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    SaveCase();
                }
                Application.Exit();
            }
        }

        #endregion Delegates


    }
}
