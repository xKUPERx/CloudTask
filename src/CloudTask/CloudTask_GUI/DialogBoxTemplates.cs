using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudTask_GUI
{
    static class DialogBoxTemplates
    {
        public static DialogResult ShowErrorDialogBox(DevExpress.XtraEditors.XtraForm parentForm, string message)
        {
            return MessageBox.Show(parentForm, message, "Cloud Task",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public static DialogResult ShowYesNoCancelDialogBox(DevExpress.XtraEditors.XtraForm parentForm, string message)
        {
            return MessageBox.Show(parentForm, message, "Cloud Task",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }

        public static DialogResult ShowYesNoWarningDialogBox(DevExpress.XtraEditors.XtraForm parentForm, string message)
        {
            return MessageBox.Show(parentForm, message, "Cloud Task",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
