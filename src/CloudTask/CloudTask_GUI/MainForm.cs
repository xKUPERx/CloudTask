using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using CloudTask_Model;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
//using DevExpress.XtraGrid.Columns;

namespace CloudTask_GUI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private string appPath = null;
        public MainForm()
        {
            InitializeComponent();
            appPath = Application.StartupPath;

            //string resxFile = @"F:\CloudTask\trunk\src\CloudTask\CloudTask_Model\Resources\HeaderResources_EN.resx";
            #region TestCase
            Case currentCase = new Case();
            Category first_lvl_category_1 = new Category(null,"First level category");
            Category second_lvl_category_1 = new Category(first_lvl_category_1, "Second level category");
            Category Third_lvl_category_1 = new Category(second_lvl_category_1, "Third level category");
            first_lvl_category_1.Nodes.Add(second_lvl_category_1);
            second_lvl_category_1.Nodes.Add(Third_lvl_category_1);

            first_lvl_category_1.Nodes.Add(new Node(first_lvl_category_1, "Test task 1 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));
            first_lvl_category_1.Nodes.Add(new Node(first_lvl_category_1, "Test task 2 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));
            first_lvl_category_1.Nodes.Add(new Node(first_lvl_category_1, "Test task 3 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));

            second_lvl_category_1.Nodes.Add(new Node(second_lvl_category_1, "Test task 1 level 2", "new", false, System.DateTime.Now, System.DateTime.Now));
            second_lvl_category_1.Nodes.Add(new Node(second_lvl_category_1, "Test task 2 level 2", "new", false, System.DateTime.Now, System.DateTime.Now));

            Third_lvl_category_1.Nodes.Add(new Node(Third_lvl_category_1, "Test task 1 level 3", "new", false, System.DateTime.Now, System.DateTime.Now));
            Third_lvl_category_1.Nodes.Add(new Node(Third_lvl_category_1, "Test task 2 level 3", "new", false, System.DateTime.Now, System.DateTime.Now));

            Category first_lvl_category_2 = new Category(null, "First level category");
            Category second_lvl_category_2 = new Category(first_lvl_category_2, "Second level category");
            Category Third_lvl_category_2 = new Category(second_lvl_category_2, "Third level category");
            first_lvl_category_2.Nodes.Add(second_lvl_category_2);
            second_lvl_category_2.Nodes.Add(Third_lvl_category_2);

            first_lvl_category_2.Nodes.Add(new Node(first_lvl_category_2, "Test task 1 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));
            first_lvl_category_2.Nodes.Add(new Node(first_lvl_category_2, "Test task 2 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));
            first_lvl_category_2.Nodes.Add(new Node(first_lvl_category_2, "Test task 3 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));

            second_lvl_category_2.Nodes.Add(new Node(second_lvl_category_2, "Test task 1 level 2", "new", false, System.DateTime.Now, System.DateTime.Now));
            second_lvl_category_2.Nodes.Add(new Node(second_lvl_category_2, "Test task 2 level 2", "new", false, System.DateTime.Now, System.DateTime.Now));

            Third_lvl_category_2.Nodes.Add(new Node(Third_lvl_category_2, "Test task 1 level 3", "new", false, System.DateTime.Now, System.DateTime.Now));
            Third_lvl_category_2.Nodes.Add(new Node(Third_lvl_category_2, "Test task 2 level 3", "new", false, System.DateTime.Now, System.DateTime.Now));

            currentCase.Nodes.Add(first_lvl_category_1);
            currentCase.Nodes.Add(first_lvl_category_2);            
            #endregion TestCase

            TreeListCaseAdapter treeListCaseAdapter = new TreeListCaseAdapter(currentCase);
            TreeListColumn noteNameColumn = new TreeListColumn();
            noteNameColumn.Caption = CloudTask_Model.Resources.Headers.ResourceManager.GetString("TreeListColumnName");           
            noteNameColumn.VisibleIndex = 0;          

            TreeListColumn originalNoteColumn = new TreeListColumn();
            originalNoteColumn.Caption = CloudTask_Model.Resources.Headers.ResourceManager.GetString("TreeListColumnOriginalNote"); 
            originalNoteColumn.Visible = false;

            treeList.Columns.AddRange(new TreeListColumn[] { noteNameColumn, originalNoteColumn });
            treeList.DataSource = treeListCaseAdapter;
            treeList.StateImageList = sharedTreeListImageCollection;
            treeList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(treeListCaseAdapter.TreeListGetStateImage);



            mainGridView.OptionsBehavior.AutoPopulateColumns = false;
            TableGridCaseAdapter tableGridCaseAdapter = new TableGridCaseAdapter(currentCase ,mainGridControl);
            treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(tableGridCaseAdapter.TreeListFocusedNodeChanged);
            
            //this.treeList.FocusedNodeChanged +=
//Transfer note to the table grid.
    //            private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
    ////... 
    //this.BeginInvoke(new MethodInvoker(delegate {
    //    treeList1.FocusedNode = myTargetNode;
    //}));
            
            //treeList1.StateImageList = IMAGES
            //using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            //{
            //    // Retrieve the string resource for the title.
            //    this.Text = resxSet.GetString("ApplicationTitle");
            //}
            //this.Text = CommanderControlLib.CommonProjectDefinitions.GetApplicationTitle;
        }
    }
}
