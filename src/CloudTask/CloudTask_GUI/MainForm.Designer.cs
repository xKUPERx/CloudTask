using CloudTask_Model;
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
            this.sharedTreeListImageCollection = new DevExpress.Utils.SharedImageCollection(this.components);
            this.mainGridControl = new DevExpress.XtraGrid.GridControl();
            this.mainGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaskText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FinishDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsDone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedTreeListImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.xtraUserControl1.Appearance.Options.UseBackColor = true;
            this.xtraUserControl1.Location = new System.Drawing.Point(2, 106);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(1197, 571);
            this.xtraUserControl1.TabIndex = 0;
            // 
            // treeList
            // 
            this.treeList.Location = new System.Drawing.Point(32, 158);
            this.treeList.Name = "treeList";
            this.treeList.Size = new System.Drawing.Size(342, 470);
            this.treeList.TabIndex = 1;
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
            this.mainGridControl.Location = new System.Drawing.Point(397, 158);
            this.mainGridControl.MainView = this.mainGridView;
            this.mainGridControl.Name = "mainGridControl";
            this.mainGridControl.Size = new System.Drawing.Size(779, 432);
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
            // 
            // TaskText
            // 
            this.TaskText.Caption = "Task text";
            this.TaskText.FieldName = "TaskText";
            this.TaskText.Name = "TaskText";
            this.TaskText.Visible = true;
            this.TaskText.VisibleIndex = 1;
            // 
            // StartDate
            // 
            this.StartDate.Caption = "Start date";
            this.StartDate.FieldName = "StartDate";
            this.StartDate.Name = "StartDate";
            this.StartDate.Visible = true;
            this.StartDate.VisibleIndex = 2;
            // 
            // FinishDate
            // 
            this.FinishDate.Caption = "Finish date";
            this.FinishDate.FieldName = "FinishDate";
            this.FinishDate.Name = "FinishDate";
            this.FinishDate.Visible = true;
            this.FinishDate.VisibleIndex = 3;
            // 
            // IsDone
            // 
            this.IsDone.Caption = "Is done?";
            this.IsDone.FieldName = "IsDone";
            this.IsDone.Name = "IsDone";
            this.IsDone.Visible = true;
            this.IsDone.VisibleIndex = 4;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.mainGridControl);
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.xtraUserControl1);
            this.Name = "MainForm";
            this.Text = "CloudTask";
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedTreeListImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.ResumeLayout(false);

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



    }
}

