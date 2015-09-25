using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTask_Model;


namespace CloudTask_GUI
{
    class TableGridCaseAdapter
    {
        #region Members

        public INodeCollection m_currentCases { get; set; }

        #endregion Members

        #region Constructors

        public TableGridCaseAdapter(INode newCase)
        {
            m_currentCases = new INodeCollection();
            m_currentCases.Add(newCase);
        }

        public TableGridCaseAdapter()
        {
            m_currentCases = null;
        }

        #endregion Constructors

        #region Methods


        #endregion Methods
    }
}
