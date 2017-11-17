using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.SQLServerDAL
{
    public partial class BUY_PO_D : BaseDAL
    {
        protected override string TableName
        {
            get { return "BUY_PO_D"; }
        }
        protected override void Initialization()
        {
            base.Initialization();
            this.Order = "BUY_PO_D.KeyID";
        }
    }
}
