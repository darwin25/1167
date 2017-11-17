using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Edge.Web.Tools
{
    public static class StringBuilderExtentions
    {
        public static void Clear(this StringBuilder sb)
        {
            if (sb!=null&&sb.Length>=1)
            {
                sb.Remove(0, sb.Length);
            }
        }
    }
}