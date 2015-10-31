using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using CloudTask_Model;
using System.ComponentModel;

namespace CloudTask_GUI
{
    class CLoudTaskBasePopupMenu
    {
        
        #region Members
        public INode m_currentNode { get; set; }
        public DevExpress.XtraBars.PopupMenu m_popupMenu {get;private set;}
        public DevExpress.XtraBars.BarManager m_barManager { get; private set; }
        public Dictionary<string, DevExpress.XtraBars.BarButtonItem> m_barButtonsMap { get; private set; }
        private Controllers.PopupMenuController controller;
        #endregion Members

        #region Constructors
        public CLoudTaskBasePopupMenu(System.Windows.Forms.Control form)
        {                
                m_popupMenu = new DevExpress.XtraBars.PopupMenu();
                m_barManager = new DevExpress.XtraBars.BarManager();
                m_barButtonsMap = new Dictionary<string, BarButtonItem>();
                controller = new Controllers.PopupMenuController();

                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                ((System.ComponentModel.ISupportInitialize)(this.m_popupMenu)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.m_barManager)).BeginInit();

                this.m_barManager.Form = form;
                this.m_barManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManagerItemClick);
                this.m_popupMenu.Manager = this.m_barManager;
                this.m_popupMenu.Name = "BasePopupMenu";
                // 
                // CreateNewTask
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonAddNewTask = new BarButtonItem();
                m_barButtonAddNewTask.Caption = GUIConstants.BarButtonAddNewTaskCaption;              
                m_barButtonAddNewTask.Id = 0;
                m_barButtonAddNewTask.Name = "barButtonAddNewTask";
                m_barButtonsMap[GUIConstants.BarButtonAddNewTaskCaption] = m_barButtonAddNewTask;
                // 
                // CreateNewCategory
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonAddNewCategory = new BarButtonItem();
                m_barButtonAddNewCategory.Caption = GUIConstants.BarButtonAddNewCategoryCaption;
                m_barButtonAddNewCategory.Id = 0;
                m_barButtonAddNewCategory.Name = "barButtonAddNewTask";
                m_barButtonsMap[GUIConstants.BarButtonAddNewCategoryCaption] = m_barButtonAddNewCategory;
                // 
                // DeleteNode
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonDeleteElement = new BarButtonItem();
                m_barButtonDeleteElement.Caption = GUIConstants.BarButtonDeleteNodeCaption;
                m_barButtonDeleteElement.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.Glyph")));
                m_barButtonDeleteElement.Id = 1;
                m_barButtonDeleteElement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.LargeGlyph")));
                m_barButtonDeleteElement.Name = "barButtonDeleteTask";
                m_barButtonsMap[GUIConstants.BarButtonDeleteNodeCaption] = m_barButtonDeleteElement;
             
                ((System.ComponentModel.ISupportInitialize)(this.m_popupMenu)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.m_barManager)).EndInit();
        }

        #endregion Constructors

        #region Methods

        private void barManagerItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                if (e.Item.Caption == GUIConstants.BarButtonAddNewTaskCaption)
                {
                    controller.AddNewNodeClicked<Node>(m_currentNode);
                }
                else if (e.Item.Caption == GUIConstants.BarButtonAddNewCategoryCaption)
                {
                    controller.AddNewNodeClicked<Category>(m_currentNode);
                }
                else if (e.Item.Caption == GUIConstants.BarButtonDeleteNodeCaption)
                {
                    controller.DeleteNode(m_currentNode);
                }
        }


        #endregion Methods
    }
}
