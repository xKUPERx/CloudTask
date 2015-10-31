namespace CloudTask_GUI
{
    partial class NewCaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCaseForm));
            this.textEditNewCaseName = new DevExpress.XtraEditors.TextEdit();
            this.labelControlNewCaseName = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewCaseName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditNewCaseName
            // 
            this.textEditNewCaseName.Location = new System.Drawing.Point(75, 9);
            this.textEditNewCaseName.Name = "textEditNewCaseName";
            this.textEditNewCaseName.Size = new System.Drawing.Size(244, 20);
            this.textEditNewCaseName.TabIndex = 0;
            // 
            // labelControlNewCaseName
            // 
            this.labelControlNewCaseName.Location = new System.Drawing.Point(12, 12);
            this.labelControlNewCaseName.Name = "labelControlNewCaseName";
            this.labelControlNewCaseName.Size = new System.Drawing.Size(57, 13);
            this.labelControlNewCaseName.TabIndex = 1;
            this.labelControlNewCaseName.Text = "Case name:";
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(195, 45);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(59, 25);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "Ok";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(260, 45);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(59, 25);
            this.simpleButtonCancel.TabIndex = 3;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // NewCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 82);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.labelControlNewCaseName);
            this.Controls.Add(this.textEditNewCaseName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCaseForm";
            this.Text = "NewCaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewCaseName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit textEditNewCaseName;
        public DevExpress.XtraEditors.LabelControl labelControlNewCaseName;
        public DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        public DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
    }
}