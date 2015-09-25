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
        //public event GetStateImageEventHandler GetStateImage;

      
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
                e.NodeImageIndex = nodeData.StateImageIndex;
          
        }
    }
}


