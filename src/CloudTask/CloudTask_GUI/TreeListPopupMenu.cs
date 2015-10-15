using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using System.ComponentModel;
using DevExpress.XtraTreeList;
using CloudTask_Model;

namespace CloudTask_GUI
{
    class TreeListPopupMenu : CLoudTaskBasePopupMenu
    {
        #region Members
     
        private TreeListCaseAdapter m_treeListCaseAdapter { get; set; }

        #endregion Members

        #region Constructors
        public TreeListPopupMenu(System.Windows.Forms.Control form, TreeListCaseAdapter treeListCaseAdapter)
            :base(form)
        {            
            m_treeListCaseAdapter = treeListCaseAdapter;
            m_currentCase = m_treeListCaseAdapter.m_currentCase;
            m_treeListCaseAdapter.m_treeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeListShowGridMenu);
        }

        ~TreeListPopupMenu()
        {
            m_treeListCaseAdapter.m_treeList.PopupMenuShowing -= new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeListShowGridMenu);
        }
        #endregion Constructors

        #region Methods
        private void treeListShowGridMenu(object sender, PopupMenuShowingEventArgs e) 
        {
            try
            {
                m_popupMenu.ItemLinks.Clear();
                TreeList treeList = sender as TreeList;
                TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Point);

                m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BAR_BUTTON_ADD_NEW_TASK_CAPTION]);
                m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BAR_BUTTON_ADD_NEW_CATEGORY_CAPTION]);
                if (hitInfo.Node != null)
                {
                    m_currentNode = hitInfo.Node.GetValue(GUIConstants.TREE_LIST_ORIGINAL_NOTE_COLUMN) as INode;
                    treeList.FocusedNode = hitInfo.Node;
                    m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BAR_BUTTON_DELETE_NODE_CAPTION]);

                }
                m_popupMenu.ShowPopup(m_barManager, treeList.PointToScreen(e.Point));
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Can't build TableGridPopupMenu, exception:\n\t{0}", ex.ToString()));
            }
        }
        #endregion Methods
    }
}
