using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTask_Model;

namespace CloudTask_GUI.Controllers
{
    class PopupMenuController
    {
        #region Methods
        public void AddNewNodeClicked<T>(INode m_currentNode) where T : INode, new()
        {
            try
            {
                T itemToAdd = new T();
                if (m_currentNode == null && CaseKeeper.CurrentCase != null)
                {
                    itemToAdd.Parent = CaseKeeper.CurrentCase;
                    CaseKeeper.CurrentCase.Nodes.Add(itemToAdd);
                }
                else if (m_currentNode is BaseContainerNode || m_currentNode is Case)
                {
                    itemToAdd.Parent = m_currentNode;
                    m_currentNode.Nodes.Add(itemToAdd);
                }
                else
                {
                    itemToAdd.Parent = m_currentNode.Parent;
                    m_currentNode.Parent.Nodes.Add(itemToAdd);
                }
                CaseKeeper.CurrentCase.OnCaseUpdate();
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Error during proccesing TableGridPopupMenu click, exception:\n\t{0}", ex.ToString()));
            }
        }

        public void DeleteNode(INode m_currentNode)
        {
            try
            {
                m_currentNode.Parent.Nodes.Remove(m_currentNode);
                CaseKeeper.CurrentCase.OnCaseUpdate();
            }
            catch (System.Exception ex)
            {
                Log.Logger.WriteErrorMessage(string.Format("Error during proccesing TableGridPopupMenu click, exception:\n\t{0}", ex.ToString()));
            }
        }
        #endregion Methods
    }
}
