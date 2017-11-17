using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Edge.SVA.BLL
{
    class SqlWhereUtil
    {
        public static string[] SplitStringByOrderBy(string where)
        {
            string[] strs=new string[0];
            strs = Regex.Split(where, " order by ", RegexOptions.IgnoreCase);
            if (strs.Length>=2)
            {
                strs[1] = " order by " + strs[1];
            }
            return strs;
        }
    }
}
