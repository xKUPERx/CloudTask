using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace CloudTask_Model
{
   public class Case : INode
   {
       #region Members
       public delegate void CaseUpdateEventHandler(object sender);
       public event CaseUpdateEventHandler CaseUpdate;

       public string ID { get; private set; }

       public INode Parent { get; set; }

       public string NodeName { get; set; }

       public INodeCollection Nodes { get; set; }

       virtual public int StateImageIndex { get; set; }

       #endregion Members

       #region Constructors

       public Case(string caseName = "Default Case")
       {
           ID = Guid.NewGuid().ToString();
           Parent = null;
           NodeName = caseName;
           Nodes = new INodeCollection();
           StateImageIndex = ImageConstants.TREE_LIST_CASE_INDEX;
       }

       #endregion Constructors

       #region Methods
       public virtual bool IsContainer
       {
           get
           {
               return true;
           }
       }

       public void CopyDelegate(Case newCase)
       {
           if (this.CaseUpdate != null)
           {
               newCase.CaseUpdate = (CaseUpdateEventHandler)this.CaseUpdate.Clone();
           }
       }


       public void OnCaseUpdate()
       {
           if (CaseUpdate != null)
           {
               CaseUpdate(this);
           }
       }
       #endregion Methods



   }
}
