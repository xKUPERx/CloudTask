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
   public class Case
   {
       #region Members

       [DataMember]
       public string CaseName { get; set; }

       [DataMember]
       public List<Category> Categories { get; set; }

       [DataMember]
       public List<Node> Nodes { get; set; }

       #endregion Members

       #region Constructors

       public Case(string caseName = "Default Case")
       {
           CaseName = caseName;
           Categories = new List<Category>();
           Nodes = new List<Node>();
       }

       #endregion Constructors
   }
}
