﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraBars;

using CloudTask_Model;

using System.ComponentModel;

namespace CloudTask_GUI
{
    class TableGridPopupMenu : CLoudTaskBasePopupMenu
    {
        #region Members
        private TableGridCaseAdapter m_tableGridCaseAdapter { get; set; }
        private DevExpress.XtraGrid.Views.Grid.GridView m_gridView { get; set; }

        #endregion Members

        #region Constructors
        public TableGridPopupMenu(System.Windows.Forms.Control form, TableGridCaseAdapter tableGridCaseAdapter)
            :base(form)
        {            
                m_tableGridCaseAdapter = tableGridCaseAdapter;
                m_currentCase = m_tableGridCaseAdapter.m_currentCase;
                m_gridView = (DevExpress.XtraGrid.Views.Grid.GridView)m_tableGridCaseAdapter.m_currentGridControl.MainView;            
                m_gridView.PopupMenuShowing += new PopupMenuShowingEventHandler(this.gridViewShowGridMenu);
        }

        ~TableGridPopupMenu()
        {
            m_gridView.PopupMenuShowing -= new PopupMenuShowingEventHandler(this.gridViewShowGridMenu);
        }

        #endregion Constructors

        #region Methods

        private void gridViewShowGridMenu(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                m_popupMenu.ItemLinks.Clear();
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BAR_BUTTON_ADD_NEW_TASK_CAPTION]);
                if (hitInfo.InRowCell)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    m_currentNode = ((List<Node>)view.GridControl.DataSource)[view.FocusedRowHandle];                                    
                    m_popupMenu.ItemLinks.Add(m_barButtonsMap[GUIConstants.BAR_BUTTON_DELETE_NODE_CAPTION]);
                }              
                m_popupMenu.ShowPopup(m_barManager, view.GridControl.PointToScreen(e.Point));
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Can't build TableGridPopupMenu, exception:\n\t{0}", ex.ToString()));
            }
        }

        #endregion Methods
    }
}
        

        //int rowHandle;
        //GridColumn column;
