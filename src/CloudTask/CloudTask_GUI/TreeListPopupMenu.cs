using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using System.ComponentModel;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using System.Windows.Forms;

using CloudTask_Model;

namespace CloudTask_GUI
{
    class TreeListPopupMenu : CLoudTaskBasePopupMenu
    {
        #region Members

        private Controllers.TreeListCaseAdapter m_treeListCaseAdapter { get; set; }

        #endregion Members

        #region Constructors
        public TreeListPopupMenu(System.Windows.Forms.Control form, Controllers.TreeListCaseAdapter treeListCaseAdapter)
            :base(form)
        {            
            m_treeListCaseAdapter = treeListCaseAdapter;
            m_treeListCaseAdapter.m_treeList.MouseDown += new MouseEventHandler(this.treeListMouseDown);
        }

        ~TreeListPopupMenu()
        {
            m_treeListCaseAdapter.m_treeList.MouseDown -= new MouseEventHandler(this.treeListMouseDown);
        }
        #endregion Constructors

        #region Methods

        private void treeListMouseDown(object sender, MouseEventArgs e)
        {
            TreeList treeList = sender as TreeList;
            RowInfo rowInfo = treeList.ViewInfo.GetRowInfoByPoint(e.Location);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                m_popupMenu.ItemLinks.Clear();               
                m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BarButtonAddNewTaskCaption]);
                m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BarButtonAddNewCategoryCaption]);               
                if (rowInfo != null)
                {
                    m_currentNode = rowInfo.Node.GetValue(GUIConstants.TreeListOriginalNoteColumnName) as INode;
                    treeList.FocusedNode = rowInfo.Node;
                    m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BarButtonDeleteNodeCaption]);
                }
                else 
                {
                    m_currentNode = Controllers.CaseKeeper.CurrentCase;
                }
                m_popupMenu.ShowPopup(m_barManager, treeList.PointToScreen(e.Location));
            }
            //else if (e.Button == System.Windows.Forms.MouseButtons.Left && rowInfo == null) // ПРи нажатии в пустое место девера левой кнопкой - открытие кейса
            //{

            //}
        }

        #endregion Methods
    }
}
