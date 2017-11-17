using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.BLL
{
    public partial class RelationRoleIssuer
    {
        /// <summary>
        /// 得到cardissuer的所属
        /// </summary>
        /// <param name="roleIDList"></param>
        /// <returns></returns>
        public string GetCardIssuersStr(IList<int> roleIDList)
        {
            string rtn = string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (int item in roleIDList)
            {
                sb.Append(",");
                sb.Append(item.ToString());
            }
            if (!sb.ToString().Equals(string.Empty))
            {
                List<int> list = new List<int>();
                DataSet ds = GetList(" RoleID in (" + sb.ToString().Substring(1) + ")");
                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    int id = Convert.ToInt32(item["CardIssuerID"].ToString());
                    if (!list.Contains(id))
                    {
                        list.Add(id);
                    }
                }
                StringBuilder sb1 = new StringBuilder();
                foreach (int item in list)
                {
                    sb1.Append(",");
                    sb1.Append(item);
                }
                if (sb1.Length >= 1)
                {
                    rtn = "(" + sb1.ToString().Substring(1) + ")";
                }
            }
            return rtn;
        }
    }
}
