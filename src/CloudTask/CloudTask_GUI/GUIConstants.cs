using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTask_GUI
{
    public static class GUIConstants
    {
        public const string TreeListName = "treeList";
        public const string TreeListNameColumn = "Name";
        public const string TreeListOriginalNoteColumnName = "Original Note";

        public const string GridNoteNameColumnFieldName = "Name";
        public const string GridNoteNameColumnName = "noteNameColumn";
        public const string GridOriginalNoteColumnFieldName = "Original Note";
        public const string GridOriginalNoteColumnName = "originalNoteColumn";

        public static string BarButtonAddNewTaskCaption { get {return CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonAddNewTask_Caption"); } }
        public static string BarButtonDeleteNodeCaption { get { return CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonDelete_Caption"); } }
        public static string BarButtonAddNewCategoryCaption { get { return CloudTask_GUI.Properties.Resources.ResourceManager.GetString("barButtonAddNewCategory_Caption"); } }
        

    }
}
