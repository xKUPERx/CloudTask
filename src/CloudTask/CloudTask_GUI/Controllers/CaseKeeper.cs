using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTask_Model;

namespace CloudTask_GUI.Controllers
{
    static class CaseKeeper
    {
        public static Case CurrentCase { get; set; }
        public static string CurrentCasePath { get; set; }
        public static string AppPath { get; set; }
    }
}
