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

        public INodeCollection m_currentCases {get; set;}

        #endregion Members

        #region Constructors

        public TreeListCaseAdapter(Case newCase)
        {
            m_currentCases = new INodeCollection();
            m_currentCases.Add(newCase);
        }

        #endregion Constructors

        #region Methods

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(
        VirtualTreeGetChildNodesInfo info)
        {
            if (info.Node is TreeListCaseAdapter)
            {
                info.Children = ((TreeListCaseAdapter)info.Node).m_currentCases;
            }
            else
            {
                info.Children = ((INode)info.Node).Nodes;
                
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(
        VirtualTreeGetCellValueInfo info)
        {
            if (info.Column.FieldName == CloudTask_Model.Resources.Headers.ResourceManager.GetString("TreeListColumnName"))
            {
                info.CellData = ((INode)info.Node).Name;
            }
            else if (info.Column.FieldName == CloudTask_Model.Resources.Headers.ResourceManager.GetString("TreeListColumnOriginalNote"))
            {
                info.CellData = (INode)info.Node;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
                ((INode)info.Node).Name = (string)info.NewCellData;
        }

        public void TreeListGetStateImage(object sender, GetStateImageEventArgs e)
        {
            INode nodeData = e.Node.GetValue(CloudTask_Model.Resources.Headers.ResourceManager.GetString("TreeListColumnOriginalNote")) as INode;
            if (nodeData != null)
            {
                e.NodeImageIndex = nodeData.StateImageIndex;
            }

        }

        #endregion Methods
    }
}


