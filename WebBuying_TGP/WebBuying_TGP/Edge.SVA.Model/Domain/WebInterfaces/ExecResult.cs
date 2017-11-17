using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebInterfaces
{
    public class ExecResult
    {
        private ExecResult() { }
        public static ExecResult CreateExecResult()
        {
            return new ExecResult();
        }
        bool success = true;

        public bool Success
        {
            get { return success; }
        }
        Exception ex = null;

        public Exception Ex
        {
            get { return ex; }
            set
            {
                success = false; 
                ex = value;
            }
        }

        private string message = "";

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                if (message != string.Empty)
                {
                    success = false;
                }
            }
        }
    }
}
