using System;
//using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CloudTask_Model
{
    public abstract class BaseContainerNode : INode
    {
        #region Members

        virtual public string ID { get; private set; }

        virtual public INode Parent { get; set; }

        virtual public string NodeName { get; set; }

        virtual public int StateImageIndex { get; set; }

        virtual public INodeCollection Nodes { get; set; }
        #endregion Members

        #region Constructors

        public BaseContainerNode(INode parent = null, string ContainerName = "Default Container")
        {
            ID = Guid.NewGuid().ToString();
            NodeName = ContainerName;
            Parent = parent;
            Nodes = new INodeCollection();
            StateImageIndex = ImageConstants.TREE_LIST_BASE_CONTAINER_INDEX;
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
