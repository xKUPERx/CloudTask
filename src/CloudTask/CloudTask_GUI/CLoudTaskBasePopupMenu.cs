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
        public Case m_currentCase { get; set; }
        public DevExpress.XtraBars.PopupMenu m_popupMenu {get;private set;}
        public DevExpress.XtraBars.BarManager m_barManager { get; private set; }
        public Dictionary<string, DevExpress.XtraBars.BarButtonItem> m_barButtonsMap { get; private set; }
        #endregion Members

        #region Constructors
        public CLoudTaskBasePopupMenu(System.Windows.Forms.Control form)
        {                
                m_popupMenu = new DevExpress.XtraBars.PopupMenu();
                m_barManager = new DevExpress.XtraBars.BarManager();
                m_barButtonsMap = new Dictionary<string, BarButtonItem>();

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
                m_barButtonAddNewTask.Caption = GUIConstants.BAR_BUTTON_ADD_NEW_TASK_CAPTION;              
                m_barButtonAddNewTask.Id = 0;
                m_barButtonAddNewTask.Name = "barButtonAddNewTask";
                m_barButtonsMap[GUIConstants.BAR_BUTTON_ADD_NEW_TASK_CAPTION] = m_barButtonAddNewTask;
                // 
                // CreateNewCategory
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonAddNewCategory = new BarButtonItem();
                m_barButtonAddNewCategory.Caption = GUIConstants.BAR_BUTTON_ADD_NEW_CATEGORY_CAPTION;
                m_barButtonAddNewCategory.Id = 0;
                m_barButtonAddNewCategory.Name = "barButtonAddNewTask";
                m_barButtonsMap[GUIConstants.BAR_BUTTON_ADD_NEW_CATEGORY_CAPTION] = m_barButtonAddNewCategory;
                // 
                // DeleteNode
                //
                DevExpress.XtraBars.BarButtonItem m_barButtonDeleteElement = new BarButtonItem();
                m_barButtonDeleteElement.Caption = GUIConstants.BAR_BUTTON_DELETE_NODE_CAPTION;
                m_barButtonDeleteElement.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.Glyph")));
                m_barButtonDeleteElement.Id = 1;
                m_barButtonDeleteElement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonDeleteTask.LargeGlyph")));
                m_barButtonDeleteElement.Name = "barButtonDeleteTask";
                m_barButtonsMap[GUIConstants.BAR_BUTTON_DELETE_NODE_CAPTION] = m_barButtonDeleteElement;
             
                ((System.ComponentModel.ISupportInitialize)(this.m_popupMenu)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.m_barManager)).EndInit();
        }

        #endregion Constructors

        #region Methods

        private void barManagerItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Caption == GUIConstants.BAR_BUTTON_ADD_NEW_TASK_CAPTION)
                {
                    AddNewNodeClicked<Node>();
                }
                else if (e.Item.Caption == GUIConstants.BAR_BUTTON_ADD_NEW_CATEGORY_CAPTION)
                {
                    AddNewNodeClicked<Category>();
                }
                else if (e.Item.Caption == GUIConstants.BAR_BUTTON_DELETE_NODE_CAPTION)
                {
                    m_currentNode.Parent.Nodes.Remove(m_currentNode);
                }
                m_currentCase.OnCaseUpdate();
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Error during proccesing TableGridPopupMenu click, exception:\n\t{0}", ex.ToString()));
            }
        }

        private void AddNewNodeClicked<T>() where T : INode, new()
        {
            T itemToAdd = new T();
            if (m_currentNode == null && m_currentCase != null)
            {
                itemToAdd.Parent = m_currentCase;
                m_currentCase.Nodes.Add(itemToAdd);
            }
            else if (m_currentNode is BaseContainerNode)
            {
                itemToAdd.Parent = m_currentNode;
                m_currentNode.Nodes.Add(itemToAdd);
            }
            else
            {
                itemToAdd.Parent = m_currentNode.Parent;
                m_currentNode.Parent.Nodes.Add(itemToAdd);
            }
        }
        #endregion Methods
    }
}
