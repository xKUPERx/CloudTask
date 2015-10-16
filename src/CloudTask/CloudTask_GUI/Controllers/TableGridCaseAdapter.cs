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

        private Case m_currentCase { get; set; }
        private INode m_currentNode { get; set; }
        public DevExpress.XtraGrid.GridControl m_currentGridControl { get; set; }

        private INode m_lastNode { get; set; }
        #endregion Members

        #region Constructors

        public TableGridCaseAdapter(DevExpress.XtraGrid.GridControl newGridControl)
        {
            m_currentCase = CaseKeeper.CurrentCase;
            m_currentGridControl = newGridControl;
            m_currentCase.CaseUpdate += new Case.CaseUpdateEventHandler(this.OnCaseUpdate);
        }

        public TableGridCaseAdapter()
        {
            m_currentCase = null;
        }

        #endregion Constructors

        #region Methods

        public void TreeListFocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            m_currentNode = e.Node.GetValue(GUIConstants.TREE_LIST_ORIGINAL_NOTE_COLUMN) as INode;
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
                nodesList = (m_currentNode != null && m_currentNode is BaseContainerNode) ? m_currentNode.Nodes : m_currentNode.Parent.Nodes;
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
            List<Node> nodes = new List<Node>();
            foreach (INode node in nodesList)
            {
                Node temp = node as Node;
                if (temp != null)
                {
                    nodes.Add(temp);
                }
            }

            m_currentGridControl.BeginUpdate();
            m_currentGridControl.DataSource = nodes;
            m_currentGridControl.EndUpdate();

            m_lastNode = m_currentNode;
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
