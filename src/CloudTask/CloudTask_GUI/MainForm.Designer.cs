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
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
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
            // treeList1
            // 
            this.treeList1.Location = new System.Drawing.Point(32, 158);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(342, 470);
            this.treeList1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.xtraUserControl1);
            this.Name = "MainForm";
            this.Text = "CloudTask";
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;



    }
}

