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
    class MainMenuController
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

        #region Methods

        private void SaveCaseAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CloudTask Cases (*.ctc) | *.ctc";
                saveFileDialog.InitialDirectory = (CaseKeeper.CurrentCasePath == null || CaseKeeper.CurrentCasePath.Length == 0) ? CaseKeeper.AppPath : CaseKeeper.CurrentCasePath;
                if (!saveFileDialog.CheckPathExists)
                {
                    saveFileDialog.InitialDirectory = "C:\\";
                }
                DialogResult dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    SaveCaseToFile(saveFileDialog.FileName);
                }
            }
        }

        private void SaveCase()
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (CaseKeeper.CurrentCasePath != null && CaseKeeper.CurrentCasePath.Length > 0 && System.IO.File.Exists(CaseKeeper.CurrentCasePath))
                {
                    SaveCaseToFile(CaseKeeper.CurrentCasePath);
                }
                else
                {
                    SaveCaseAs();
                }
            }
        }

        private void SaveCaseToFile(string path)
        {
            JsonParser jsonparser = new JsonParser(path);
            bool saveResult = jsonparser.SaveCaseToFile(CaseKeeper.CurrentCase);
            if (saveResult)
            {
                CaseKeeper.CurrentCasePath = path;
            }
            else 
            {
                if (DialogBoxTemplates.ShowErrorDialogBox(CaseKeeper.AppMainForm, CloudTask_GUI.Properties.Resources.ResourceManager.GetString("CaseSaveErrorMessageForDialogBox")) == DialogResult.OK)
                {
                    SaveCaseAs();
                }
            }
        }

        private void LoadCase()
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CloudTask Cases (*.ctc) | *.ctc";
                openFileDialog.InitialDirectory = CaseKeeper.AppPath;

                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    LoadCaseFromFile(openFileDialog.FileName);
                }
            }
        }

        private void LoadCaseFromFile(string path)
        {
            JsonParser jsonparser = new JsonParser(path);
            Case loadedCase = new Case();
            bool loadResult = jsonparser.LoadCaseFromFile(out loadedCase);
            if (loadResult)
            {
                CaseKeeper.CurrentCasePath = path;
                CaseKeeper.CurrentCase = loadedCase;              
            }
            else
            {
                if (DialogBoxTemplates.ShowErrorDialogBox(CaseKeeper.AppMainForm, CloudTask_GUI.Properties.Resources.ResourceManager.GetString("CaseLoadErrorMessageForDialogBox")) == DialogResult.OK)
                {
                    LoadCase();
                }
            }
        }

        private void CreateNewCase()
        {
            DialogResult dialogResult = DialogBoxTemplates.ShowYesNoCancelDialogBox(CaseKeeper.AppMainForm, CloudTask_GUI.Properties.Resources.ResourceManager.GetString("SaveChangesInCurrentCase"));
            if (dialogResult != DialogResult.Cancel)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    SaveCase();
                }                
                NewCaseFormController newCaseFormController = new NewCaseFormController();
                newCaseFormController.ShowForm(CaseKeeper.AppMainForm);
                Case newCase = newCaseFormController.m_newCase;
                if (newCase != null)
                {
                    CaseKeeper.CurrentCase = newCase;
                }              
            }
        }

        private void DeleteCase()
        {
            if (DialogBoxTemplates.ShowYesNoWarningDialogBox(CaseKeeper.AppMainForm, CloudTask_GUI.Properties.Resources.ResourceManager.GetString("DeleteCurrentCaseQuestion")) == DialogResult.Yes)
            {
                if (System.IO.File.Exists(CaseKeeper.CurrentCasePath))
                {
                    try
                    {
                        System.IO.File.Delete(CaseKeeper.CurrentCasePath);
                    }
                    catch (System.Exception ex)
                    {
                        Log.Logger.WriteErrorMessage(string.Format("Can not Delete Case file!\n\tPath to case: {0}\n\tException: {1}", CaseKeeper.CurrentCasePath, ex.ToString()));
                        DialogBoxTemplates.ShowErrorDialogBox(CaseKeeper.AppMainForm, string.Format("{0}\"{1}\"", CloudTask_GUI.Properties.Resources.ResourceManager.GetString("CaseDeletionError"), CaseKeeper.CurrentCasePath));
                    }
                }
                CaseKeeper.CurrentCase = new Case();
            }
        }

        
        #endregion Methods
    }
}
