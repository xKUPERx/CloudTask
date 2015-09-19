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
    public class Node : INode
    {
        #region Members
        [DataMember]
        public string ID { get; private set; }

        [DataMember]
        public INode Parent { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public INodeCollection Nodes { get { return null; } }

        [DataMember]
        public string TaskText { get; set; }

        [DataMember]
        public bool IsDone{ get; set; }

        [DataMember]
        public System.DateTime StartDate{ get; set;}

        [DataMember]
        public System.DateTime FinishDate { get; set; }

        #endregion Members

        #region Constructors

        public Node(INode parent, string taskName, string taskText, bool isDone, System.DateTime startDate, System.DateTime finishDate)
        {
            ID = Guid.NewGuid().ToString();
            Parent = parent;
            Name = taskName;
            TaskText = taskText;
            IsDone = isDone;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        #endregion Constructors

        #region Methods

        public virtual bool IsContainer
        {
            get
            {
                return false;
            }
        }


        #endregion Methods
    }
}
