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
        virtual public string ID { get; private set; }

        [DataMember]
        virtual public INode Parent { get; set; }

        [DataMember]
        virtual public string Name { get; set; }      

        [DataMember]
        virtual public INodeCollection Nodes { get { return null; } }

        [DataMember]
        virtual public string TaskText { get; set; }

        [DataMember]
        virtual public bool IsDone { get; set; }

        [DataMember]
        virtual public System.DateTime StartDate { get; set; }

        [DataMember]
        virtual public System.DateTime FinishDate { get; set; }

        [DataMember]
        virtual public int StateImageIndex { get; set; }

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
            StateImageIndex = Constants.TREE_LIST_NOTE_INDEX;
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
