using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTask_Model;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace CloudTask_GUI.Controllers
{
    class TableGridCaseAdapter
    {
        #region Members


        public DevExpress.XtraGrid.GridControl CurrentGridControl { get; set; }
        private Case m_currentCase { get; set; }
        private INode m_currentNode { get; set; }
        private INode m_lastNode { get; set; }
        private GridView m_gridView{ get; set; }
        public List<Node> DataSourceList { get; private set; }
        #endregion Members

        #region Constructors

        public TableGridCaseAdapter(DevExpress.XtraGrid.GridControl newGridControl)
        {
            m_currentCase = CaseKeeper.CurrentCase;
            CurrentGridControl = newGridControl;
            CaseKeeper.CaseUpdate += new CaseKeeper.CaseUpdateEventHandler(this.OnCaseUpdate);
            m_gridView = ((GridView)CurrentGridControl.MainView);
            m_gridView.CellValueChanged += new CellValueChangedEventHandler(GridViewCellValueChanged);
        }

        ~TableGridCaseAdapter()
        {
            m_gridView.CellValueChanged -= new CellValueChangedEventHandler(GridViewCellValueChanged);
        }

        #endregion Constructors

        #region Methods

        public void TreeListFocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            m_currentNode = e.Node.GetValue(GUIConstants.TreeListOriginalNoteColumnName) as INode;
            if (m_currentNode != null)
            {
                INodeCollection nodesList = null;
                if (m_currentNode is BaseContainerNode)
                {
                    nodesList = m_currentNode.Nodes;
                }

                else if ((m_currentNode is Node) && (m_lastNode != null ? m_currentNode.Parent != m_lastNode.Parent : true))
                {
                    nodesList = m_currentNode.Parent.Nodes;
                }
                else if (m_currentNode.Parent == m_currentCase)
                {
                    nodesList = m_currentCase.Nodes;
                }
                else
                {
                    return;
                }
                SetGridData(nodesList);
            }
        }

        public INode GetDataSourceListParent()
        {
            return DataSourceList.Count > 0 ? DataSourceList[0].Parent : null;
        }

        private void OnCaseUpdate(object sender)
        {
            Case newCase = sender as Case;
            if (newCase == null)
            {
                return;
            }

            INodeCollection nodesList = null;
            if (m_currentCase == newCase)
            {
                if (m_currentCase.Nodes.Count > 0)
                {
                    nodesList = (m_currentNode != null && m_currentNode is BaseContainerNode) ? m_currentNode.Nodes : m_currentNode.Parent.Nodes;
                }
                else
                {
                    nodesList = new INodeCollection();
                }
            }
            else 
            {
                m_currentCase = newCase;
                nodesList = m_currentCase.Nodes;
            }
            SetGridData(nodesList);
        }

        private void SetGridData(INodeCollection nodesList)    
        {
            DataSourceList = new List<Node>();
            foreach (INode node in nodesList)
            {
                Node temp = node as Node;
                if (temp != null)
                {
                    DataSourceList.Add(temp);
                }
            }

            CurrentGridControl.BeginUpdate();
            CurrentGridControl.DataSource = DataSourceList;
            CurrentGridControl.EndUpdate();

            m_lastNode = m_currentNode;
        }

        private void GridViewCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            CaseKeeper.OnCaseUpdate();
        }



        //public void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) //image in grind
        //{
        //    GridView view = sender as GridView;
        //    //if (e.Column.FieldName == "NodesIcon" && e.IsGetData) e.Value = getTotalValue(view, e.ListSourceRowIndex);
        //    if (e.Column.FieldName == "NodesIcon" && e.IsGetData)
        //    {
        //        DevExpress.Utils.SharedImageCollection images = view.Images as DevExpress.Utils.SharedImageCollection;
        //        e.Value = images.Container.Components.GetEnumerator().Current;
        //    }
        //}

        #endregion Methods
    }
}
