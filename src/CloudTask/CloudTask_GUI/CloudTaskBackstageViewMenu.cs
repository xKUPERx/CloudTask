using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTask_GUI
{
    class CloudTaskBackstageViewMenu
    {
        #region Members
        private Controllers.MainMenuController controller;

        private DevExpress.XtraBars.Ribbon.RibbonControl m_ribbonControl;

        private DevExpress.XtraBars.Ribbon.BackstageViewControl m_backstageViewControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem m_backstageViewButtonNewCase;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem m_backstageViewButtonOpenCase;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem m_backstageViewButtonSettings;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator m_backstageViewItemSeparator;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem m_backstageViewButtonDeleteCurrentCase;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem m_backstageViewButtonExit;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl m_backstageViewClientControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem m_backstageViewTabSaveCase;
        private DevExpress.XtraEditors.SimpleButton m_TabSaveButtonSaveAs;
        private DevExpress.XtraEditors.XtraUserControl m_TabSaveXtraUserControl;
        private DevExpress.XtraEditors.SimpleButton m_TabSaveButtonSave;
        #endregion Members

        #region Constructors

        public CloudTaskBackstageViewMenu(System.Windows.Forms.Control form, DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl)
        {
            controller = new Controllers.MainMenuController();
            m_ribbonControl = ribbonControl;
            m_backstageViewControl = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            m_backstageViewClientControl = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            m_TabSaveButtonSave = new DevExpress.XtraEditors.SimpleButton();
            m_TabSaveButtonSaveAs = new DevExpress.XtraEditors.SimpleButton();
            m_TabSaveXtraUserControl = new DevExpress.XtraEditors.XtraUserControl();
            m_backstageViewButtonNewCase = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            m_backstageViewButtonOpenCase = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            m_backstageViewTabSaveCase = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            m_backstageViewButtonSettings = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            m_backstageViewItemSeparator = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            m_backstageViewButtonDeleteCurrentCase = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            m_backstageViewButtonExit = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();

            ((System.ComponentModel.ISupportInitialize)(m_backstageViewControl)).BeginInit();
            m_backstageViewControl.SuspendLayout();
            m_backstageViewClientControl.SuspendLayout();
            // 
            // backstageViewControl
            // 
            m_backstageViewControl.Appearance.BackColor = System.Drawing.Color.Black;
            m_backstageViewControl.Appearance.BackColor2 = System.Drawing.Color.Black;
            m_backstageViewControl.Appearance.BorderColor = System.Drawing.Color.Black;
            m_backstageViewControl.Appearance.Options.UseBackColor = true;
            m_backstageViewControl.Appearance.Options.UseBorderColor = true;
            m_backstageViewControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            m_backstageViewControl.Controls.Add(m_backstageViewClientControl);
            m_backstageViewControl.Items.Add(m_backstageViewButtonNewCase);
            m_backstageViewControl.Items.Add(m_backstageViewButtonOpenCase);
            m_backstageViewControl.Items.Add(m_backstageViewTabSaveCase);
            m_backstageViewControl.Items.Add(m_backstageViewButtonSettings);
            m_backstageViewControl.Items.Add(m_backstageViewItemSeparator);
            m_backstageViewControl.Items.Add(m_backstageViewButtonDeleteCurrentCase);
            m_backstageViewControl.Items.Add(m_backstageViewButtonExit);
            m_backstageViewControl.Location = new System.Drawing.Point(267, 150);
            m_backstageViewControl.Name = "backstageViewControl";
            m_backstageViewControl.Ribbon = ribbonControl;
            m_backstageViewControl.SelectedTab = m_backstageViewTabSaveCase;
            m_backstageViewControl.SelectedTabIndex = 2;
            m_backstageViewControl.Size = new System.Drawing.Size(759, 377);
            m_backstageViewControl.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013;
            m_backstageViewControl.TabIndex = 5;
            m_backstageViewControl.Text = "backstageViewControl1";
            // 
            // backstageViewClientControl
            // 
            m_backstageViewClientControl.Controls.Add(m_TabSaveButtonSave);
            m_backstageViewClientControl.Controls.Add(m_TabSaveButtonSaveAs);
            m_backstageViewClientControl.Controls.Add(m_TabSaveXtraUserControl);
            m_backstageViewClientControl.Location = new System.Drawing.Point(163, 63);
            m_backstageViewClientControl.Name = "backstageViewClientControl1";
            m_backstageViewClientControl.Size = new System.Drawing.Size(595, 313);
            m_backstageViewClientControl.TabIndex = 0;
            // 
            // simpleButtonSave
            // 
            m_TabSaveButtonSave.Image = global::CloudTask_GUI.Properties.Resources.save_32x32;
            m_TabSaveButtonSave.Location = new System.Drawing.Point(17, 94);
            m_TabSaveButtonSave.Name = "simpleButtonSave";
            m_TabSaveButtonSave.Size = new System.Drawing.Size(107, 37);
            m_TabSaveButtonSave.TabIndex = 2;
            m_TabSaveButtonSave.Text = "Save";
            // 
            // simpleButtonSaveAs
            // 
            m_TabSaveButtonSaveAs.Image = global::CloudTask_GUI.Properties.Resources.saveandnew_32x32;
            m_TabSaveButtonSaveAs.Location = new System.Drawing.Point(17, 51);
            m_TabSaveButtonSaveAs.Name = "simpleButtonSaveAs";
            m_TabSaveButtonSaveAs.Size = new System.Drawing.Size(107, 37);
            m_TabSaveButtonSaveAs.TabIndex = 1;
            m_TabSaveButtonSaveAs.Text = "Save as";
            // 
            // xtraUserControl2
            // 
            m_TabSaveXtraUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            m_TabSaveXtraUserControl.Location = new System.Drawing.Point(0, 0);
            m_TabSaveXtraUserControl.Name = "xtraUserControl2";
            m_TabSaveXtraUserControl.Size = new System.Drawing.Size(595, 313);
            m_TabSaveXtraUserControl.TabIndex = 0;
            // 
            // backstageViewButtonNewCase
            // 
            m_backstageViewButtonNewCase.Caption = "New Case";
            m_backstageViewButtonNewCase.Glyph = global::CloudTask_GUI.Properties.Resources.project_32x32;
            m_backstageViewButtonNewCase.Name = "backstageViewButtonNewCase";
            // 
            // backstageViewButtonOpenCase
            // 
            m_backstageViewButtonOpenCase.Caption = "Open Case";
            m_backstageViewButtonOpenCase.Glyph = global::CloudTask_GUI.Properties.Resources.loadfrom_32x32;
            m_backstageViewButtonOpenCase.Name = "backstageViewButtonOpenCase";
            // 
            // backstageViewTabSaveCase
            // 
            m_backstageViewTabSaveCase.Caption = "Save Case";
            m_backstageViewTabSaveCase.ContentControl = m_backstageViewClientControl;
            m_backstageViewTabSaveCase.Glyph = global::CloudTask_GUI.Properties.Resources.save_32x32;
            m_backstageViewTabSaveCase.Name = "backstageViewTabSaveCase";
            m_backstageViewTabSaveCase.Selected = false;
            // 
            // backstageViewButtonSettings
            // 
            m_backstageViewButtonSettings.Caption = "Settings";
            m_backstageViewButtonSettings.Glyph = global::CloudTask_GUI.Properties.Resources.technology_32x32;
            m_backstageViewButtonSettings.Name = "backstageViewButtonSettings";
            // 
            // backstageViewItemSeparator1
            // 
            m_backstageViewItemSeparator.Name = "backstageViewItemSeparator1";
            // 
            // backstageViewButtonDeleteCurrentCase
            // 
            m_backstageViewButtonDeleteCurrentCase.Caption = "Delete Current Case";
            m_backstageViewButtonDeleteCurrentCase.Glyph = global::CloudTask_GUI.Properties.Resources.clear_32x32;
            m_backstageViewButtonDeleteCurrentCase.Name = "backstageViewButtonDeleteCurrentCase";
            // 
            // backstageViewButtonExit
            // 
            m_backstageViewButtonExit.Caption = "Exit";
            m_backstageViewButtonExit.Glyph = global::CloudTask_GUI.Properties.Resources.bugreport_32x32;
            m_backstageViewButtonExit.Name = "backstageViewButtonExit";

            m_ribbonControl.ApplicationButtonDropDownControl = m_backstageViewControl;
            form.Controls.Add(m_backstageViewControl);
            ((System.ComponentModel.ISupportInitialize)(m_backstageViewControl)).EndInit();
            m_backstageViewControl.ResumeLayout(false);
            m_backstageViewClientControl.ResumeLayout(false);

            m_TabSaveButtonSaveAs.Click += new EventHandler(controller.OnCaseSaveAs);
            m_TabSaveButtonSave.Click += new EventHandler(controller.OnCaseSave);
            m_backstageViewButtonOpenCase.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(controller.OnOpenCase);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods
    }
}
