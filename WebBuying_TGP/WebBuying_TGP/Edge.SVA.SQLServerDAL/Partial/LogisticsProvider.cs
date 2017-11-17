using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL.Partial
{
    public partial class LogisticsProvider : BaseDAL
    {
        protected override string TableName
        {
            get { return "LogisticsProvider"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "LogisticsProvider.LogisticsProviderID";
        }
    }
}
