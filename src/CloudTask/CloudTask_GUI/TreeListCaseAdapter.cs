using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using CloudTask_Model;

namespace CloudTask_GUI
{
    public class TreeListCaseAdapter : TreeList.IVirtualTreeListData
    {
        #region Members

        public Case m_currentCase {get; set;}

        #endregion Members

        #region Constructors

        public TreeListCaseAdapter(Case newCase)
        {
            m_currentCase = newCase;
        }

        #endregion Constructors

        #region Methods

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            if (info.Node is TreeListCaseAdapter)
            {
                info.Children = ((TreeListCaseAdapter)info.Node).m_currentCase.Nodes;
            }
            else
            {
                info.Children = ((INode)info.Node).Nodes;
                
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(
        VirtualTreeGetCellValueInfo info)
        {
            if (info.Column.FieldName == GUIConstants.TREE_LIST_NAME_COLUMN)
            {
                info.CellData = ((INode)info.Node).NodeName;
            }
            else if (info.Column.FieldName == GUIConstants.TREE_LIST_ORIGINAL_NOTE_COLUMN)
            {
                info.CellData = (INode)info.Node;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
                ((INode)info.Node).NodeName = (string)info.NewCellData;
        }

        public void TreeListGetStateImage(object sender, GetStateImageEventArgs e)
        {
            INode nodeData = e.Node.GetValue(GUIConstants.TREE_LIST_ORIGINAL_NOTE_COLUMN) as INode;
            if (nodeData != null)
            {
                e.NodeImageIndex = nodeData.StateImageIndex;
            }

        }

        #endregion Methods
    }
}


