using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Edge.SVA.BLL
{
    public partial class BUY_REASON
    {
        /// <summary>
        /// 根据StoreType判断是否存在此BUY_REASON,存在则返回ReasonID
        /// </summary>
        public int ExistsReason(string ReasonCode)
        {
            if (!string.IsNullOrEmpty(ReasonCode))
            {
                BUY_REASON bll = new BLL.BUY_REASON();
                DataTable dt = bll.GetList("ReasonCode='" + ReasonCode + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["ReasonID"]);
                }
            }
            return 0;
        }
    }
}
