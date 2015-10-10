using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Log
{
    public static class Logger
    {
        #region Members

        private static NLog.Logger log = LogManager.GetCurrentClassLogger(); 

        #endregion Members

        #region Methods

        public static void WriteTraceMessage(string message)
        {
            log.Trace(message);
        }

        public static void WriteDebugMessage(string message)
        {
            log.Debug(message);
        }

        public static void WriteInfoMessage(string message)
        {
            log.Info(message);
        }

        public static void WriteErrorMessage(string message)
        {
            log.Error(message);
        }
        #endregion Methods
    }
}
