using System;
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
    class TableGridPopupMenu
    {
        #region Members
        public static string BAR_BUTTON_ADD_NEW_TASK_CAPTION = CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonAddNewTask.Caption");
        public static string BAR_BUTTON_DELETE_TASK_CAPTION = CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonDeleteTask.Caption");

        private DevExpress.XtraBars.PopupMenu m_popupMenu {get;set;}
        private DevExpress.XtraBars.BarManager m_barManager { get; set; }
        private DevExpress.XtraGrid.Views.Grid.GridView m_gridView { get; set; }
        private TableGridCaseAdapter m_tableGridCaseAdapter { get; set; }

        private Dictionary<string, DevExpress.XtraBars.BarButtonItem> m_barButtonsMap;
        #endregion Members

        #region Constructors
        public TableGridPopupMenu(System.Windows.Forms.Control form, TableGridCaseAdapter tableGridCaseAdapter)
        {
            try
            {                
                m_popupMenu = new DevExpress.XtraBars.PopupMenu();
                m_barManager = new DevExpress.XtraBars.BarManager();
                m_barButtonsMap = new Dictionary<string, BarButtonItem>();
               // m_gridView = gridView;
                m_tableGridCaseAdapter = tableGridCaseAdapter;
                m_gridView = (DevExpress.XtraGrid.Views.Grid.GridView)m_tableGridCaseAdapter.m_currentGridControl.MainView; 
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                ((System.ComponentModel.ISupportInitialize)(this.m_popupMenu)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.m_barManager)).BeginInit();


                this.m_barManager.Form = form;
                this.m_barManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager_ItemClick);
                this.m_popupMenu.Manager = this.m_barManager;
                this.m_popupMenu.Name = "TableGridPopupMenu";

                // 
                // CreateNewNode
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonAddNewTask = new BarButtonItem();
                m_barButtonAddNewTask.Caption = BAR_BUTTON_ADD_NEW_TASK_CAPTION;
                //barButtonAddNewTask.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.Glyph")));
                m_barButtonAddNewTask.Id = 0;
                //barButtonAddNewTask.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.LargeGlyph")));
                m_barButtonAddNewTask.Name = "barButtonAddNewTask";
                m_barButtonsMap[BAR_BUTTON_ADD_NEW_TASK_CAPTION] = m_barButtonAddNewTask;
                // 
                // DeleteNode
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonDeleteTask = new BarButtonItem();
                m_barButtonDeleteTask.Caption = BAR_BUTTON_DELETE_TASK_CAPTION;
                m_barButtonDeleteTask.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.Glyph")));
                m_barButtonDeleteTask.Id = 1;
                m_barButtonDeleteTask.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.LargeGlyph")));
                m_barButtonDeleteTask.Name = "barButtonDeleteTask";
                m_barButtonsMap[BAR_BUTTON_DELETE_TASK_CAPTION] = m_barButtonDeleteTask;
             
                m_gridView.PopupMenuShowing += new PopupMenuShowingEventHandler(this.gridView_ShowGridMenu);
                ((System.ComponentModel.ISupportInitialize)(this.m_popupMenu)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.m_barManager)).EndInit();
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Exception during TableGridPopupMenu initialization, ex:\n\t {0}", ex.ToString()));
            }
        }

        ~TableGridPopupMenu()
        {
            m_gridView.PopupMenuShowing -= new PopupMenuShowingEventHandler(this.gridView_ShowGridMenu);
        }

        #endregion Constructors

        #region Methods

        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView view = m_tableGridCaseAdapter.m_currentGridControl.FocusedView as GridView;
            List<Node> nodes = (List<Node>)view.GridControl.DataSource;
            try
            {
                if (e.Item.Caption == BAR_BUTTON_ADD_NEW_TASK_CAPTION)
                {
                    if (m_tableGridCaseAdapter.m_currentNote == null && m_tableGridCaseAdapter.m_currentCase != null)
                    {
                        m_tableGridCaseAdapter.m_currentCase.Nodes.Add(new Node(m_tableGridCaseAdapter.m_currentCase));
                    }
                    else if (m_tableGridCaseAdapter.m_currentNote is BaseContainerNode)
                    {
                        m_tableGridCaseAdapter.m_currentNote.Nodes.Add(new Node(m_tableGridCaseAdapter.m_currentNote));
                    }
                    else
                    {
                        m_tableGridCaseAdapter.m_currentNote.Parent.Nodes.Add(new Node(m_tableGridCaseAdapter.m_currentNote));
                    }
                }
                else if (e.Item.Caption == BAR_BUTTON_DELETE_TASK_CAPTION)
                {
                    if (view.FocusedRowHandle < nodes.Count)
                    {
                        if (m_tableGridCaseAdapter.m_currentNote is BaseContainerNode)
                        {
                             m_tableGridCaseAdapter.m_currentNote.Nodes.Remove(nodes[view.FocusedRowHandle]);
                        }
                        else
                        {                  
                            m_tableGridCaseAdapter.m_currentNote.Parent.Nodes.Remove(nodes[view.FocusedRowHandle]);                          
                        }
                        
                    }
                    else
                    {
                        Log.Logger.WriteErrorMessage(string.Format("Wrong FocusedRowHandle during try to delete node from TableGrid, FocusedRowHandle: {0} , count of nodes in grid: {1}", view.FocusedRowHandle, nodes.Count));
                    }

                }
                m_tableGridCaseAdapter.m_currentCase.OnCaseUpdate();
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Error during proccesing TableGridPopupMenu click, exception:\n\t{0}", ex.ToString()));
            }
        }

        private void gridView_ShowGridMenu(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                m_popupMenu.ItemLinks.Clear();
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRowCell)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    m_popupMenu.ItemLinks.Add(m_barButtonsMap[BAR_BUTTON_DELETE_TASK_CAPTION]);

                }
                m_popupMenu.ItemLinks.Add(m_barButtonsMap[BAR_BUTTON_ADD_NEW_TASK_CAPTION]);
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
