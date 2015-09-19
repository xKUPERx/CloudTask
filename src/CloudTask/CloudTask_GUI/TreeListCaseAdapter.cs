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
    // Represents a sample Business Object 

        public Case m_currentCase;
        private INodeCollection Cases;
        public TreeListCaseAdapter(Case newCase)
        {
            m_currentCase = newCase;
            Cases = new INodeCollection();
            Cases.Add(m_currentCase);
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(
        VirtualTreeGetChildNodesInfo info)
        {
            if (info.Node is TreeListCaseAdapter)
            {
                info.Children = ((TreeListCaseAdapter)info.Node).Cases;
            }
            else
            {
                info.Children = ((INode)info.Node).Nodes;
            }
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(
        VirtualTreeGetCellValueInfo info)
        {
            info.CellData = ((INode)info.Node).Name;
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
                ((INode)info.Node).Name = (string)info.NewCellData;
        }
    }
}


