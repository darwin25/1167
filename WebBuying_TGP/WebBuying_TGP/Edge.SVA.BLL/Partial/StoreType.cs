using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Edge.SVA.BLL
{
   public partial class StoreType
    {
        /// <summary>
        /// 根据StoreType判断是否存在此StoreType,存在则返回StoreTypeID
        /// </summary>
        public int ExistsStoreType(string StoreTypeName)
        {
            if (!string.IsNullOrEmpty(StoreTypeName))
            {
                StoreType bll = new BLL.StoreType();
                DataTable dt = bll.GetList("StoreTypeName1='" + StoreTypeName + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["StoreTypeID"]);
                }
            }
            return 0;
        }
    }
}
