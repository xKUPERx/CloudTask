using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CloudTask_Model
{
    public class Category : BaseContainerNode
    {
        #region Members

        override public int StateImageIndex { get; set; }

        #endregion Members

        #region Constructors

        public Category(INode parent = null, string CategoryName = "Default Category")
            : base(parent, CategoryName)
        {
            StateImageIndex = ImageConstants.TREE_LIST_CATEGORY_INDEX;
        }

        #endregion Constructors      
    }
}
