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
    class Category
    {
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public List<Node> Nodes { get; set; }

        public Category()
        {
            Nodes = new List<Node>();
        }
    }
}
