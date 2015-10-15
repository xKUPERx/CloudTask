using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTask_GUI
{
    public static class GUIConstants
    {
        public const string TREE_LIST_NAME = "treeList";
        public const string TREE_LIST_NAME_COLUMN = "Name";
        public const string TREE_LIST_ORIGINAL_NOTE_COLUMN = "Original Note";

        public const string GRID_NOTE_NAME_COLUMN_FIELD_NAME = "Name";
        public const string GRID_NOTE_NAME_COLUMN_NAME = "noteNameColumn";
        public const string GRID_ORIGINAL_NOTE_COLUMN_FIELD_NAME = "Original Note";
        public const string GRID_ORIGINAL_NOTE_COLUMN_NAME = "originalNoteColumn";

        public static string BAR_BUTTON_ADD_NEW_TASK_CAPTION { get {return CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonAddNewTask_Caption"); } }
        public static string BAR_BUTTON_DELETE_NODE_CAPTION { get { return CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonDelete_Caption"); } }
        public static string BAR_BUTTON_ADD_NEW_CATEGORY_CAPTION { get { return CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonAddNewCategory_Caption"); } }
        

    }
}
