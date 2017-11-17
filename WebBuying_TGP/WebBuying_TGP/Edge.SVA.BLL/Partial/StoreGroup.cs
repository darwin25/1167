using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Edge.SVA.BLL
{
    public partial class StoreGroup
    {
        /// <summary>
        /// 根据StoreGroup判断是否存在此StoreGroup,存在则返回StoreGroupID
        /// </summary>
        public int ExistsStoreGroup(string StoreGroupName)
        {
            if (!string.IsNullOrEmpty(StoreGroupName))
            {
                StoreGroup bll = new BLL.StoreGroup();
                DataTable dt = bll.GetList("StoreGroupName1='" + StoreGroupName + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["StoreGroupID"]);
                }
            }
            return 0;
        }
    }
}
