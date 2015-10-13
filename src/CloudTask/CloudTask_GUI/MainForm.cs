﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using CloudTask_Model;

//using DevExpress.XtraGrid.Columns;

namespace CloudTask_GUI
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string m_appPath {get; private set;}
        public Case m_currentCase = new Case();

        public MainForm()
        {
            InitializeComponent();
            
            
            m_appPath = Application.StartupPath;

            #region tests
            FillTestCase();
            TestJsonParser();
            #endregion tests

            TreeListCaseAdapter treeListCaseAdapter = new TreeListCaseAdapter(m_currentCase, treeList);
            treeList.StateImageList = sharedTreeListImageCollection;

            mainGridView.OptionsBehavior.AutoPopulateColumns = false;
            //mainGridView.Images = sharedTreeListImageCollection;
            //mainGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(tableGridCaseAdapter.gridView_CustomUnboundColumnData); image in grid
            TableGridCaseAdapter tableGridCaseAdapter = new TableGridCaseAdapter(m_currentCase ,mainGridControl);
            
            treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(tableGridCaseAdapter.TreeListFocusedNodeChanged);

            xtraTabControlCaseAdapter propertiesControlCaseAdapter = new CloudTask_GUI.xtraTabControlCaseAdapter(xtraTabControlNodesProperties);
            propertiesControlCaseAdapter.SetupControls();
            mainGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(propertiesControlCaseAdapter.gridView_FocusedRowChanged);
            treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(propertiesControlCaseAdapter.TreeListFocusedNodeChanged);

            tableGridPopupMenu = new TableGridPopupMenu(this, tableGridCaseAdapter); //Create popup menu
            
        }

        private void FillTestCase()
        {         
            Category first_lvl_category_1 = new Category(null, "First level category");
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

            Category first_lvl_category_2 = new Category(null, "A");
            Category second_lvl_category_2 = new Category(first_lvl_category_2, "B");
            Category Third_lvl_category_2 = new Category(second_lvl_category_2, "C");
            first_lvl_category_2.Nodes.Add(second_lvl_category_2);
            second_lvl_category_2.Nodes.Add(Third_lvl_category_2);

            first_lvl_category_2.Nodes.Add(new Node(first_lvl_category_2, "Test task 1 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));
            first_lvl_category_2.Nodes.Add(new Node(first_lvl_category_2, "Test task 2 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));
            first_lvl_category_2.Nodes.Add(new Node(first_lvl_category_2, "Test task 3 level 1", "new", false, System.DateTime.Now, System.DateTime.Now));

            second_lvl_category_2.Nodes.Add(new Node(second_lvl_category_2, "Test task 1 level 2", "new", false, System.DateTime.Now, System.DateTime.Now));
            second_lvl_category_2.Nodes.Add(new Node(second_lvl_category_2, "Test task 2 level 2", "new", false, System.DateTime.Now, System.DateTime.Now));

            Third_lvl_category_2.Nodes.Add(new Node(Third_lvl_category_2, "Test task 1 level 3", "new", false, System.DateTime.Now, System.DateTime.Now));
            Third_lvl_category_2.Nodes.Add(new Node(Third_lvl_category_2, "Test task 2 level 3", "new", false, System.DateTime.Now, System.DateTime.Now));

            m_currentCase.Nodes.Add(first_lvl_category_1);
            m_currentCase.Nodes.Add(first_lvl_category_2);           
        }

        private void TestJsonParser()
        {
            JsonParser jsonparser = new JsonParser();
            jsonparser.SaveCaseToFile(m_currentCase);
            m_currentCase = null;
            jsonparser.LoadCaseFromFile(out m_currentCase);
        }


    }
}
