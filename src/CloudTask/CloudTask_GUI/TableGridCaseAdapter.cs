using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTask_Model;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace CloudTask_GUI
{
    class TableGridCaseAdapter
    {
        #region Members

        public Case m_currentCase { get; set; }
        public INode m_currentNote { get; set; }
        public DevExpress.XtraGrid.GridControl m_currentGridControl { get; set; }

        private INode m_lastNode { get; set; }
        #endregion Members

        #region Constructors

        public TableGridCaseAdapter(Case newCase, DevExpress.XtraGrid.GridControl newGridControl)
        {
            m_currentCase = newCase;
            m_currentGridControl = newGridControl;
        }

        public TableGridCaseAdapter()
        {
            m_currentCase = null;
        }

        #endregion Constructors

        #region Methods

        public void TreeListFocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            m_currentNote = e.Node.GetValue(GUIConstants.TREE_LIST_ORIGINAL_NOTE_COLUMN) as INode;
            if (m_currentNote != null)
            {
                INodeCollection nodesList = null;
                if (m_currentNote is BaseContainerNode)
                {
                    nodesList = m_currentNote.Nodes;
                }
                else if ((m_currentNote is Node) && (m_lastNode != null ? m_currentNote.Parent != m_lastNode.Parent : true))
                {
                    nodesList = m_currentNote.Parent.Nodes;
                }
                else
                {
                    return;
                }

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

                m_lastNode = m_currentNote;
            }
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
