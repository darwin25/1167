using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;

namespace Edge.Web.Tools
{
    public class HiddenFormInfo
    {
        public MessageBoxIcon MessageBoxIcon { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string OkScript { get; set; }
        public string CancelScript { get; set; }
        public bool ExecSuccess { get; set; }
        public string ExecMessage { get; set; }
    }
}