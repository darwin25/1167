using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using log4net;
using System.Text;

namespace Edge.Web.Tools
{
    public class Logger
    {
        public static readonly Logger Instance = new Logger();
        public Logger()
        {

        }

        public void WriteExportLog(string functionName, string fileName, DateTime start, int records, string error)
        {
            System.Text.StringBuilder log = new System.Text.StringBuilder();

            if (string.IsNullOrEmpty(error))
            {
                log.Append("Export Result: Success.\r\n");
                log.AppendFormat("Export {0} records successfully.\r\n\r\n", records.ToString("N00"));
            }
            else
            {
                log.Append("Export Result: Fail.\r\n");
                log.AppendFormat("Export {0} records failed.\r\n\r\n", records.ToString("N00"));
                log.AppendFormat("Reason:\r\n{0}\r\n", error);
            }

            log.AppendFormat("Start Datetime: {0}\r\n", start.ToString("yyyy-MM-dd HH:mm:ss"));
            log.AppendFormat("End Datetime: {0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            log.AppendFormat("Export File Name: {0}\r\n", fileName);
            log.AppendFormat("Export Function: {0}\r\n", functionName);
            log.AppendFormat("User: {0}\r\n", DALTool.GetCurrentUser().UserName);

            ExportLogger.Info(log.ToString());
        }

        public void WriteImportLog(string functionName, string fileName, DateTime start, int records, List<string> errors)
        {
            System.Text.StringBuilder log = new System.Text.StringBuilder();

            if (errors.Count <= 0)
            {
                log.Append("Import Result: Success.\r\n");
                log.AppendFormat("Import {0} records successfully.\r\n\r\n", records.ToString("N00"));
            }
            else
            {
                log.Append("Import Result: Fail.\r\n");
                log.AppendFormat("Import {0} records failed.\r\n", records.ToString("N00"));
                log.Append("Reason:\r\n");
                for (int i = 0; i < errors.Count; i++)
                {
                    log.Append(errors[i]);
                }
                log.Append("\r\n");
            }

            log.AppendFormat("Start Datetime: {0}\r\n", start.ToString("yyyy-MM-dd HH:mm:ss"));
            log.AppendFormat("End Datetime: {0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            log.AppendFormat("Import File Name: {0}\r\n", fileName);
            log.AppendFormat("Import Function: {0}\r\n", functionName);
            log.AppendFormat("User: {0}\r\n", DALTool.GetCurrentUser().UserName);

            ImportLogger.Info(log.ToString());
        }

        public void WriteOperationLog(string functionName, string msg)
        {
            StringBuilder sb = new StringBuilder();
            Edge.Security.Manager.User user = SVASessionInfo.CurrentUser;

            if (user != null)
            {
                sb.Append(" User ");
                sb.Append(DALTool.GetCurrentUser().UserName);
                sb.Append(",");
            }
            sb.Append("functionName:");
            sb.Append(functionName);
            sb.Append(",msg:");
            sb.Append(msg);
            SystemLogger.Info(sb.ToString());
        }
        public void WriteErrorLog(string functionName, string msg)
        {
            StringBuilder sb = new StringBuilder();
            Edge.Security.Manager.User user = SVASessionInfo.CurrentUser;

            if (user != null)
            {
                sb.Append(" User ");
                sb.Append(user.UserName);
                sb.Append(",");
            }
            sb.Append("functionName:");
            sb.Append(functionName);
            sb.Append(",msg:");
            sb.Append(msg);
            SystemLogger.Error(sb.ToString());
        }
        
        public void WriteErrorLog(string functionName, string msg, Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            Edge.Security.Manager.User user = SVASessionInfo.CurrentUser;

            if (user != null)
            {
                sb.Append(" User ");
                sb.Append(user.UserName);
                sb.Append(",");
            }
            sb.Append("functionName:");
            sb.Append(functionName);
            if (!string.IsNullOrEmpty(msg))
            {
                sb.Append(",msg:");
                sb.Append(msg);
            }
            sb.Append(",Error Message:");
            SystemLogger.Error(sb.ToString(), ex);
        }
        readonly ILog SystemLogger = log4net.LogManager.GetLogger("SystemOpeartionLogger");
        //public readonly ILog CouponLogger = log4net.LogManager.GetLogger("CouponOpeartionLogger");
        //public readonly ILog DebugLogger = log4net.LogManager.GetLogger("DebugOpeartionLogger");
        public readonly ILog ExportLogger = log4net.LogManager.GetLogger("ExportLogger");
        public readonly ILog ImportLogger = log4net.LogManager.GetLogger("ImportLogger");
    }
}
