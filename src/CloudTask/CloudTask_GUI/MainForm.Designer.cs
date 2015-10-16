using CloudTask_Model;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
namespace CloudTask_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.noteNameColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.originalNoteColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sharedTreeListImageCollection = new DevExpress.Utils.SharedImageCollection(this.components);
            this.mainGridControl = new DevExpress.XtraGrid.GridControl();
            this.mainGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaskText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FinishDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsDone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlNodesProperties = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageTaskText = new DevExpress.XtraTab.XtraTabPage();
            this.memoEditTaskText = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPageNodesProperties = new DevExpress.XtraTab.XtraTabPage();
            this.checkEditIsDone = new DevExpress.XtraEditors.CheckEdit();
            this.dateEditFinishDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStartDate = new DevExpress.XtraEditors.DateEdit();
            this.textEditTaskName = new DevExpress.XtraEditors.TextEdit();
            this.labelIsDone = new DevExpress.XtraEditors.LabelControl();
            this.labelFinishDate = new DevExpress.XtraEditors.LabelControl();
            this.labelStartDate = new DevExpress.XtraEditors.LabelControl();
            this.labelTaskName = new DevExpress.XtraEditors.LabelControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedTreeListImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedTreeListImageCollection.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlNodesProperties)).BeginInit();
            this.xtraTabControlNodesProperties.SuspendLayout();
            this.xtraTabPageTaskText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditTaskText.Properties)).BeginInit();
            this.xtraTabPageNodesProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsDone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFinishDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFinishDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.xtraUserControl1.Appearance.Options.UseBackColor = true;
            this.xtraUserControl1.Location = new System.Drawing.Point(0, 148);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(1197, 571);
            this.xtraUserControl1.TabIndex = 0;
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.noteNameColumn,
            this.originalNoteColumn});
            this.treeList.Location = new System.Drawing.Point(0, 148);
            this.treeList.Name = "treeList";
            this.treeList.Size = new System.Drawing.Size(342, 566);
            this.treeList.TabIndex = 1;
            // 
            // noteNameColumn
            // 
            this.noteNameColumn.Caption = "Name";
            this.noteNameColumn.FieldName = "Name";
            this.noteNameColumn.Name = "noteNameColumn";
            this.noteNameColumn.Visible = true;
            this.noteNameColumn.VisibleIndex = 0;
            // 
            // originalNoteColumn
            // 
            this.originalNoteColumn.Caption = "Original Note";
            this.originalNoteColumn.FieldName = "Original Note";
            this.originalNoteColumn.Name = "originalNoteColumn";
            // 
            // sharedTreeListImageCollection
            // 
            // 
            // 
            // 
            this.sharedTreeListImageCollection.ImageSource.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("sharedTreeListImageCollection.ImageSource.ImageStream")));
            this.sharedTreeListImageCollection.ImageSource.Images.SetKeyName(0, "TreeListСaseIcon.ico");
            this.sharedTreeListImageCollection.ImageSource.Images.SetKeyName(1, "TreeListCategoryIcon.ico");
            this.sharedTreeListImageCollection.ImageSource.Images.SetKeyName(2, "TreeListNoteIcon.ico");
            this.sharedTreeListImageCollection.ParentControl = this;
            // 
            // mainGridControl
            // 
            this.mainGridControl.Location = new System.Drawing.Point(347, 148);
            this.mainGridControl.MainView = this.mainGridView;
            this.mainGridControl.Name = "mainGridControl";
            this.mainGridControl.Size = new System.Drawing.Size(844, 402);
            this.mainGridControl.TabIndex = 2;
            this.mainGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainGridView});
            // 
            // mainGridView
            // 
            this.mainGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NodeName,
            this.TaskText,
            this.StartDate,
            this.FinishDate,
            this.IsDone});
            this.mainGridView.GridControl = this.mainGridControl;
            this.mainGridView.Name = "mainGridView";
            // 
            // NodeName
            // 
            this.NodeName.Caption = "Task name";
            this.NodeName.FieldName = "NodeName";
            this.NodeName.Name = "NodeName";
            this.NodeName.Visible = true;
            this.NodeName.VisibleIndex = 0;
            this.NodeName.Width = 165;
            // 
            // TaskText
            // 
            this.TaskText.Caption = "Task text";
            this.TaskText.FieldName = "TaskText";
            this.TaskText.Name = "TaskText";
            this.TaskText.Visible = true;
            this.TaskText.VisibleIndex = 1;
            this.TaskText.Width = 166;
            // 
            // StartDate
            // 
            this.StartDate.Caption = "Start date";
            this.StartDate.FieldName = "StartDate";
            this.StartDate.Name = "StartDate";
            this.StartDate.Visible = true;
            this.StartDate.VisibleIndex = 2;
            this.StartDate.Width = 164;
            // 
            // FinishDate
            // 
            this.FinishDate.Caption = "Finish date";
            this.FinishDate.FieldName = "FinishDate";
            this.FinishDate.Name = "FinishDate";
            this.FinishDate.Visible = true;
            this.FinishDate.VisibleIndex = 3;
            this.FinishDate.Width = 164;
            // 
            // IsDone
            // 
            this.IsDone.Caption = "Is done?";
            this.IsDone.FieldName = "IsDone";
            this.IsDone.Name = "IsDone";
            this.IsDone.Visible = true;
            this.IsDone.VisibleIndex = 4;
            this.IsDone.Width = 167;
            // 
            // xtraTabControlNodesProperties
            // 
            this.xtraTabControlNodesProperties.Location = new System.Drawing.Point(347, 556);
            this.xtraTabControlNodesProperties.Name = "xtraTabControlNodesProperties";
            this.xtraTabControlNodesProperties.SelectedTabPage = this.xtraTabPageNodesProperties;
            this.xtraTabControlNodesProperties.Size = new System.Drawing.Size(849, 163);
            this.xtraTabControlNodesProperties.TabIndex = 3;
            this.xtraTabControlNodesProperties.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageNodesProperties,
            this.xtraTabPageTaskText});
            // 
            // xtraTabPageTaskText
            // 
            this.xtraTabPageTaskText.Controls.Add(this.memoEditTaskText);
            this.xtraTabPageTaskText.Controls.Add(this.xtraUserControl1);
            this.xtraTabPageTaskText.Name = "xtraTabPageTaskText";
            this.xtraTabPageTaskText.Size = new System.Drawing.Size(843, 135);
            this.xtraTabPageTaskText.Text = "PageTaskText";
            // 
            // memoEditTaskText
            // 
            this.memoEditTaskText.Location = new System.Drawing.Point(0, 0);
            this.memoEditTaskText.Name = "memoEditTaskText";
            this.memoEditTaskText.Size = new System.Drawing.Size(851, 132);
            this.memoEditTaskText.TabIndex = 0;
            // 
            // xtraTabPageNodesProperties
            // 
            this.xtraTabPageNodesProperties.Controls.Add(this.checkEditIsDone);
            this.xtraTabPageNodesProperties.Controls.Add(this.dateEditFinishDate);
            this.xtraTabPageNodesProperties.Controls.Add(this.dateEditStartDate);
            this.xtraTabPageNodesProperties.Controls.Add(this.textEditTaskName);
            this.xtraTabPageNodesProperties.Controls.Add(this.labelIsDone);
            this.xtraTabPageNodesProperties.Controls.Add(this.labelFinishDate);
            this.xtraTabPageNodesProperties.Controls.Add(this.labelStartDate);
            this.xtraTabPageNodesProperties.Controls.Add(this.labelTaskName);
            this.xtraTabPageNodesProperties.Name = "xtraTabPageNodesProperties";
            this.xtraTabPageNodesProperties.Size = new System.Drawing.Size(843, 135);
            this.xtraTabPageNodesProperties.Text = "NodesProperties";
            // 
            // checkEditIsDone
            // 
            this.checkEditIsDone.Location = new System.Drawing.Point(113, 104);
            this.checkEditIsDone.Name = "checkEditIsDone";
            this.checkEditIsDone.Properties.Caption = "is done?";
            this.checkEditIsDone.Size = new System.Drawing.Size(16, 19);
            this.checkEditIsDone.TabIndex = 8;
            // 
            // dateEditFinishDate
            // 
            this.dateEditFinishDate.EditValue = null;
            this.dateEditFinishDate.Location = new System.Drawing.Point(113, 78);
            this.dateEditFinishDate.Name = "dateEditFinishDate";
            this.dateEditFinishDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFinishDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFinishDate.Size = new System.Drawing.Size(180, 20);
            this.dateEditFinishDate.TabIndex = 7;
            // 
            // dateEditStartDate
            // 
            this.dateEditStartDate.EditValue = null;
            this.dateEditStartDate.Location = new System.Drawing.Point(113, 52);
            this.dateEditStartDate.Name = "dateEditStartDate";
            this.dateEditStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartDate.Size = new System.Drawing.Size(180, 20);
            this.dateEditStartDate.TabIndex = 6;
            // 
            // textEditTaskName
            // 
            this.textEditTaskName.Location = new System.Drawing.Point(113, 26);
            this.textEditTaskName.Name = "textEditTaskName";
            this.textEditTaskName.Size = new System.Drawing.Size(181, 20);
            this.textEditTaskName.TabIndex = 5;
            // 
            // labelIsDone
            // 
            this.labelIsDone.Location = new System.Drawing.Point(15, 107);
            this.labelIsDone.Name = "labelIsDone";
            this.labelIsDone.Size = new System.Drawing.Size(42, 13);
            this.labelIsDone.TabIndex = 3;
            this.labelIsDone.Text = "is done? ";
            // 
            // labelFinishDate
            // 
            this.labelFinishDate.Location = new System.Drawing.Point(15, 81);
            this.labelFinishDate.Name = "labelFinishDate";
            this.labelFinishDate.Size = new System.Drawing.Size(59, 13);
            this.labelFinishDate.TabIndex = 2;
            this.labelFinishDate.Text = "Finish date: ";
            // 
            // labelStartDate
            // 
            this.labelStartDate.Location = new System.Drawing.Point(15, 55);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(56, 13);
            this.labelStartDate.TabIndex = 1;
            this.labelStartDate.Text = "Start date: ";
            // 
            // labelTaskName
            // 
            this.labelTaskName.Location = new System.Drawing.Point(15, 29);
            this.labelTaskName.Name = "labelTaskName";
            this.labelTaskName.Size = new System.Drawing.Size(58, 13);
            this.labelTaskName.TabIndex = 0;
            this.labelTaskName.Text = "Task name: ";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.Size = new System.Drawing.Size(1200, 144);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "delete";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 0);
            this.barDockControlBottom.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(0, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 722);
            this.Controls.Add(this.xtraTabControlNodesProperties);
            this.Controls.Add(this.mainGridControl);
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "CloudTask";
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedTreeListImageCollection.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedTreeListImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlNodesProperties)).EndInit();
            this.xtraTabControlNodesProperties.ResumeLayout(false);
            this.xtraTabPageTaskText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditTaskText.Properties)).EndInit();
            this.xtraTabPageNodesProperties.ResumeLayout(false);
            this.xtraTabPageNodesProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsDone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFinishDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFinishDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.Utils.SharedImageCollection sharedTreeListImageCollection;
        private DevExpress.XtraGrid.GridControl mainGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView mainGridView;
        private DevExpress.XtraGrid.Columns.GridColumn NodeName;
        private DevExpress.XtraGrid.Columns.GridColumn TaskText;
        private DevExpress.XtraGrid.Columns.GridColumn StartDate;
        private DevExpress.XtraGrid.Columns.GridColumn FinishDate;
        private DevExpress.XtraGrid.Columns.GridColumn IsDone;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlNodesProperties;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTaskText;
        private DevExpress.XtraEditors.MemoEdit memoEditTaskText;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageNodesProperties;
        private DevExpress.XtraEditors.CheckEdit checkEditIsDone;
        private DevExpress.XtraEditors.DateEdit dateEditFinishDate;
        private DevExpress.XtraEditors.DateEdit dateEditStartDate;
        private DevExpress.XtraEditors.TextEdit textEditTaskName;
        private DevExpress.XtraEditors.LabelControl labelIsDone;
        private DevExpress.XtraEditors.LabelControl labelFinishDate;
        private DevExpress.XtraEditors.LabelControl labelStartDate;
        private DevExpress.XtraEditors.LabelControl labelTaskName;
        private TreeListColumn noteNameColumn;
        private TreeListColumn originalNoteColumn;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;

        private TableGridPopupMenu tableGridPopupMenu;
        private TreeListPopupMenu treeListPopupMenu;
        private CloudTaskBackstageViewMenu cloudTaskBackstageViewMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;




    }
}

