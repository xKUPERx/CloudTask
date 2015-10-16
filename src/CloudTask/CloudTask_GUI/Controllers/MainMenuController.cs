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
        #region Methods
        public void OnCaseSaveAs(Object sender, EventArgs e)
        {
            SaveCaseAs();
        }

        public void OnCaseSave(Object sender, EventArgs e)
        {
            SaveCase();
        }

        public void OnOpenCase(object sender, BackstageViewItemEventArgs e)
        {
            LoadCase();
        }

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
                if (DialogBoxTemplates.ShowErrorDialogBox("Can not save case to current path! Press \"yes\" to try again.") == DialogResult.OK)
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
                CaseKeeper.CurrentCase.CopyDelegate(loadedCase);
                CaseKeeper.CurrentCase = loadedCase;              
                CaseKeeper.CurrentCase.OnCaseUpdate();
            }
            else
            {
                if (DialogBoxTemplates.ShowErrorDialogBox("Can not load case from current path! Press \"yes\" to load another case file.") == DialogResult.OK)
                {
                    LoadCase();
                }
            }
        }
        #endregion Methods
    }
}
