using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CloudTask_Model
{
    public abstract class BaseContainerNode : INode
    {
        //public void AddChild(IComponent child);
        //public void RemoveChild(IComponent child);
        //public bool isContainer { get; private set; }


        #region Members
        [DataMember]
        public string ID { get; private set; }

        [DataMember]
        public INode Parent { get; set; }

        [DataMember]
        public string Name { get; set; }

        #endregion Members

        #region Constructors

        public BaseContainerNode(INode parent = null, string ContainerName = "Default Container")
        {
            ID = Guid.NewGuid().ToString();
            Name = ContainerName;
            Parent = parent;
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
