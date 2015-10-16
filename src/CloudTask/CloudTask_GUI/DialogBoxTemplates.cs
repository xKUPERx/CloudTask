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
        public static DialogResult ShowErrorDialogBox(string message)
        {
            return MessageBox.Show(message, "Cloud Task",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
    }
}
