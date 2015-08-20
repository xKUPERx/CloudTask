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
    public class Category
    {
        #region Members
        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public List<Node> Nodes { get; set; }
        #endregion Members

        #region Constructors
        public Category()
        {
            Nodes = new List<Node>();
        }

        public Category(string categoryName)
            :this()
        {
            CategoryName = categoryName;
        }
        #endregion Constructors
    }
}
