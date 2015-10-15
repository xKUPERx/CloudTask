using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using CloudTask_Model;

namespace CloudTask_Model
{
    public class Category : BaseContainerNode
    {
        #region Members

        override public int StateImageIndex { get; set; }

        #endregion Members

        #region Constructors
        [JsonConstructor]
        public Category(INode parent, string CategoryName)
            : base(parent, CategoryName)
        {
            StateImageIndex = ImageConstants.TREE_LIST_CATEGORY_INDEX;
        }

        public Category()
            : this(null, "Default Category")
        { }
        #endregion Constructors      
    }
}
