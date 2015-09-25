﻿using System;
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
        virtual public string ID { get; private set; }

        [DataMember]
        virtual public INode Parent { get; set; }

        [DataMember]
        virtual public string Name { get; set; }

        [DataMember]
        virtual public int StateImageIndex { get; set; }

        [DataMember]
        virtual public INodeCollection Nodes { get; private set; }
        #endregion Members

        #region Constructors

        public BaseContainerNode(INode parent = null, string ContainerName = "Default Container")
        {
            ID = Guid.NewGuid().ToString();
            Name = ContainerName;
            Parent = parent;
            Nodes = new INodeCollection();
            StateImageIndex = Constants.TREE_LIST_BASE_CONTAINER_INDEX;
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
