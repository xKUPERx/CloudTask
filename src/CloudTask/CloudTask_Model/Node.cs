using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace CloudTask_Model
{
    public class Node : INode
    {
        #region Members
        virtual public string ID { get; private set; }

        virtual public INode Parent { get; set; }

        virtual public string NodeName { get; set; }

        virtual public INodeCollection Nodes { get { return null; } }

        virtual public string TaskText { get; set; }

        virtual public bool IsDone { get; set; }

        virtual public System.DateTime StartDate { get; set; }

        virtual public System.DateTime FinishDate { get; set; }

        virtual public int StateImageIndex { get; set; }
        #endregion Members

        #region Constructors
        [JsonConstructor]
        public Node(INode parent, string taskName, string taskText, bool isDone, System.DateTime startDate, System.DateTime finishDate)
        {
            ID = Guid.NewGuid().ToString();
            Parent = parent;
            NodeName = taskName;
            TaskText = taskText;
            IsDone = isDone;
            StartDate = startDate;
            FinishDate = finishDate;
            StateImageIndex = ImageConstants.TREE_LIST_NOTE_INDEX;
        }

        public Node(INode parent)
            :this(parent,"New task", "", false, new DateTime(), new DateTime() )
        {}

        public Node()
            :this(null)
        {}
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
