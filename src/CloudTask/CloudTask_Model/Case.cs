using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CloudTask_Model
{
   [DataContract]
   public class Case : INode
   {
       #region Members

       [DataMember]
       public string ID { get; private set; }

       [DataMember]
       public INode Parent { get; set; }

       [DataMember]
       public string NodeName { get; set; }

       [DataMember]
       public INodeCollection Nodes { get; private set; }

       [DataMember]
       virtual public int StateImageIndex { get; set; }
       #endregion Members

       #region Constructors

       public Case(string caseName = "Default Case")
       {
           ID = Guid.NewGuid().ToString();
           Parent = null;
           NodeName = caseName;         
           Nodes = new INodeCollection();
           StateImageIndex = Constants.TREE_LIST_CASE_INDEX;
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
       #endregion Methods
   }
}
