using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using CloudTask_Model;
using System.Drawing;

namespace CloudTask_GUI.Controllers
{
    public class TreeListCaseAdapter : TreeList.IVirtualTreeListData
    {
        #region Members

        public DevExpress.XtraTreeList.TreeList m_treeList { get; private set; }

        #endregion Members

        #region Constructors

        public TreeListCaseAdapter(DevExpress.XtraTreeList.TreeList treeList)
        {
            m_treeList = treeList;
            m_treeList.DataSource = this;
            CaseKeeper.CaseUpdate += new CaseKeeper.CaseUpdateEventHandler(this.OnCaseUpdate);
            m_treeList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.TreeListGetStateImage);
            m_treeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList1_DragDrop);
            m_treeList.DragNodesMode = TreeListDragNodesMode.Advanced;
            m_treeList.OptionsBehavior.DragNodes = true;      
        }

        ~TreeListCaseAdapter()
        {
            CaseKeeper.CaseUpdate -= new CaseKeeper.CaseUpdateEventHandler(this.OnCaseUpdate);
        }
        #endregion Constructors

        #region Methods

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            if (info.Node is TreeListCaseAdapter)
            {
                info.Children = CaseKeeper.CurrentCase.Nodes;
            }
            else
            {
                info.Children = ((INode)info.Node).Nodes;
                
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(
        VirtualTreeGetCellValueInfo info)
        {
            if (info.Column.FieldName == GUIConstants.TreeListNameColumn)
            {
                info.CellData = ((INode)info.Node).NodeName;
            }
            else if (info.Column.FieldName == GUIConstants.TreeListOriginalNoteColumnName)
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
            INode nodeData = e.Node.GetValue(GUIConstants.TreeListOriginalNoteColumnName) as INode;
            if (nodeData != null)
            {
                e.NodeImageIndex = nodeData.StateImageIndex;
            }

        }

        private void OnCaseUpdate(object sender)
        {          
            m_treeList.RefreshDataSource();
        }

        private void treeList1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                TreeListNode dragNode, targetNode;
                INode IdragNode, ItargetNode;
                TreeList treeList = sender as TreeList;

                Point p = treeList.PointToClient(new Point(e.X, e.Y));

                dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
                targetNode = treeList.CalcHitInfo(p).Node;

                IdragNode = (e.Data.GetData(typeof(TreeListNode)) as TreeListNode).GetValue(GUIConstants.TreeListOriginalNoteColumnName) as INode;
                ItargetNode = (treeList.CalcHitInfo(p).Node).GetValue(GUIConstants.TreeListOriginalNoteColumnName) as INode;

                if (IdragNode != null && ItargetNode != null && ItargetNode is BaseContainerNode)
                {

                    IdragNode.Parent.Nodes.Remove(IdragNode);
                    ItargetNode.Nodes.Add(IdragNode);
                    IdragNode.Parent = ItargetNode;
                    treeList.SetNodeIndex(dragNode, treeList.GetNodeIndex(targetNode));
                    e.Effect = System.Windows.Forms.DragDropEffects.None;
                    CaseKeeper.OnCaseUpdate();
                }

            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("DragandDrop exception in TreeListCaseAdapter, exception:\n\t{0}", ex.ToString()));
            }
        }
        #endregion Methods
    }
}


