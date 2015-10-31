using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;

using CloudTask_Model;

namespace CloudTask_GUI.Controllers
{
    class xtraTabControlCaseAdapter
    {
        #region Members

        private DevExpress.XtraTab.XtraTabControl xtraTabControl {get; set; }

        private Node m_lastNode{get; set;}
        private Node m_currentNote { get; set; }

        private DevExpress.XtraEditors.TextEdit m_TaskNameControl{get; set;}
        private DevExpress.XtraEditors.DateEdit m_TaskStartDateControl{get; set;}
        private DevExpress.XtraEditors.DateEdit m_TaskFinishDateControl{get; set;}
        private DevExpress.XtraEditors.CheckEdit m_TaskIsDoneControl{get; set;}
        private DevExpress.XtraEditors.MemoEdit m_TaskTextControl{get; set;}  
        #endregion Members

        #region Constructors

        public xtraTabControlCaseAdapter(DevExpress.XtraTab.XtraTabControl control)
        {
            xtraTabControl = control;
        }

        ~xtraTabControlCaseAdapter()
        {
            ClearControls();
        }
        #endregion Constructors

        #region Methods

        public void TreeListFocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            Node m_currentNote = e.Node.GetValue(GUIConstants.TreeListOriginalNoteColumnName) as Node;
            if (m_currentNote != null)
            {
                UpdateContolsData(m_currentNote);
            }
            m_lastNode = m_currentNote;
        }

        public void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) 
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                List<Node> nodes = (List<Node>)view.GridControl.DataSource;
                m_currentNote = nodes[e.FocusedRowHandle];

                if (m_currentNote != null)
                {
                    UpdateContolsData(m_currentNote);
                }
                m_lastNode = m_currentNote;
            }
            catch { };

        }

        public bool SetupControls()
        {
            try
            {
                DevExpress.XtraTab.XtraTabPage currentPage = (DevExpress.XtraTab.XtraTabPage)xtraTabControl.Controls["xtraTabPageNodesProperties"];
                m_TaskNameControl = (DevExpress.XtraEditors.TextEdit)currentPage.Controls["textEditTaskName"];
                m_TaskStartDateControl = (DevExpress.XtraEditors.DateEdit)currentPage.Controls["dateEditStartDate"];
                m_TaskFinishDateControl = (DevExpress.XtraEditors.DateEdit)currentPage.Controls["dateEditFinishDate"];
                m_TaskIsDoneControl = (DevExpress.XtraEditors.CheckEdit)currentPage.Controls["checkEditIsDone"];

                currentPage = (DevExpress.XtraTab.XtraTabPage)xtraTabControl.Controls["xtraTabPageTaskText"];
                m_TaskTextControl = (DevExpress.XtraEditors.MemoEdit)currentPage.Controls["memoEditTaskText"];

                m_TaskNameControl.LostFocus += new EventHandler(OnControlsDataChanged);
                m_TaskStartDateControl.LostFocus += new EventHandler(OnControlsDataChanged);
                m_TaskFinishDateControl.LostFocus += new EventHandler(OnControlsDataChanged);
                m_TaskIsDoneControl.CheckedChanged += new EventHandler(OnControlsDataChanged);
                m_TaskTextControl.LostFocus += new EventHandler(OnControlsDataChanged);
                return true;
            }
            catch(System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("\nCan not setup notes properties pane, exception:\n\t{0}",ex.ToString()));
                return false;
            }
        }

        public void UpdateContolsData(Node node)
        {
            try
            {               
                m_TaskNameControl.Text = node.NodeName;
                m_TaskStartDateControl.DateTime = node.StartDate;
                m_TaskStartDateControl.Text = node.StartDate.ToString();
                m_TaskFinishDateControl.DateTime = node.FinishDate;
                m_TaskFinishDateControl.Text = node.FinishDate.ToString();
                m_TaskIsDoneControl.Checked = node.IsDone;
                m_TaskIsDoneControl.CheckState = node.IsDone == true ? System.Windows.Forms.CheckState.Checked : System.Windows.Forms.CheckState.Unchecked;
                m_TaskTextControl.Text = node.TaskText;                
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("\nCan not update notes properties pane, exception:\n\t{0}",ex.ToString()));
            }
        }

        private void ClearControls()
        {
            try
            {
                m_TaskNameControl.LostFocus -= new EventHandler(OnControlsDataChanged);
                m_TaskStartDateControl.LostFocus -= new EventHandler(OnControlsDataChanged);
                m_TaskFinishDateControl.LostFocus -= new EventHandler(OnControlsDataChanged);
                m_TaskIsDoneControl.CheckedChanged -= new EventHandler(OnControlsDataChanged);
                m_TaskTextControl.LostFocus -= new EventHandler(OnControlsDataChanged);
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("\nError during xtraTabControlCaseAdapter.ClearControls(), exception:\n\t{0}", ex.ToString()));
            }
        }

        private void OnControlsDataChanged(Object sender, EventArgs e)
        {
            if (m_currentNote != null)
            {
                if (sender is DevExpress.XtraEditors.DateEdit)
                {
                    DevExpress.XtraEditors.DateEdit control = sender as DevExpress.XtraEditors.DateEdit;
                    if (control.Name == m_TaskStartDateControl.Name)
                    {
                        m_currentNote.StartDate = m_TaskStartDateControl.DateTime;
                    }
                    else
                    {
                        m_currentNote.FinishDate = m_TaskFinishDateControl.DateTime;
                    }
                }
                else if (sender is DevExpress.XtraEditors.TextEdit && ((DevExpress.XtraEditors.TextEdit)sender).Name == m_TaskNameControl.Name)
                {
                    m_currentNote.NodeName = m_TaskNameControl.Text;
                }
                else if (sender is DevExpress.XtraEditors.CheckEdit)
                {
                    m_currentNote.IsDone = m_TaskIsDoneControl.Checked;
                }
                else if (sender is DevExpress.XtraEditors.MemoEdit)
                {
                    m_currentNote.TaskText = m_TaskTextControl.Text;
                }
                CaseKeeper.OnCaseUpdate();
            }
        }
        #endregion Methods
    }
}
