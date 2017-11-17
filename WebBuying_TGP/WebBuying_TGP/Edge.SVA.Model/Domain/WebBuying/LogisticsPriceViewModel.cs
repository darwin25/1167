using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
    /// <summary>
    /// 运费设置View操作类
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public class LogisticsPriceViewModel
    {
        LogisticsPrice mainTable = new LogisticsPrice();
        public LogisticsPrice MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
