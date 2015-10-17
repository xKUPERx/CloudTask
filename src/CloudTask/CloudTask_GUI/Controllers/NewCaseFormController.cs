using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTask_Model;
namespace CloudTask_GUI.Controllers
{
    class NewCaseFormController
    {
        #region Members
        private NewCaseForm m_newCaseForm {get;set;}
        public Case m_newCase { get; private set; }
        #endregion Members

        #region Constructors
        public NewCaseFormController()
        {
            m_newCaseForm = new NewCaseForm();
            m_newCase = null;
            m_newCaseForm.simpleButtonOk.Click += new EventHandler(this.ButtonOkClicked);
            m_newCaseForm.simpleButtonCancel.Click += new EventHandler(this.ButtonCancelClicked);
        }

        ~NewCaseFormController()
        {
            m_newCaseForm.simpleButtonOk.Click -= new EventHandler(this.ButtonOkClicked);
            m_newCaseForm.simpleButtonCancel.Click -= new EventHandler(this.ButtonCancelClicked);
        }
        #endregion Constructors

        #region Methods
        public void ShowForm(DevExpress.XtraEditors.XtraForm parentForm)
        {
            m_newCaseForm.ShowDialog(parentForm);
        }

        private void ButtonOkClicked(Object sender, EventArgs e)
        {
            m_newCase = m_newCaseForm.textEditNewCaseName.Text.Length > 0 ? new Case(m_newCaseForm.textEditNewCaseName.Text) : new Case();
            m_newCaseForm.Close();
        }

        private void ButtonCancelClicked(Object sender, EventArgs e)
        {           
            m_newCaseForm.Close();
        }
        #endregion Methods
    }
}
