using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using CloudTask_Model;

namespace CloudTask_GUI.Controllers
{
    class BaseCaseController
    {
        #region Methods

        public void SaveCaseAs()
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

        public void SaveCase()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
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

        public void LoadCase()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
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

        public void CreateNewCase()
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

        public void DeleteCase()
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

        #endregion Methods
    }
}
