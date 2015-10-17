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
        public delegate void CaseUpdateEventHandler(object sender);
        public static event CaseUpdateEventHandler CaseUpdate = delegate {};

        public static Case CurrentCase 
        {
            get { return currentCase; }
            set {
                    currentCase = value;
                    CurrentCasePath = "";
                    OnCaseUpdate();
                } 
        }
        public static MainForm AppMainForm { get; set; }
        public static string CurrentCasePath { get; set; }
        public static string AppPath { get; set; }

        private static Case currentCase = null;
        public static void OnCaseUpdate()
       {
           if (CaseUpdate != null)
           {
               CaseUpdate(CurrentCase);
           }
       }
    }
}
