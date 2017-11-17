using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class LogisticsPrice : BaseDAL
    {
        protected override string TableName
        {
            get { return "LogisticsPrice"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "LogisticsPrice.KeyID";
        }
    }
}
