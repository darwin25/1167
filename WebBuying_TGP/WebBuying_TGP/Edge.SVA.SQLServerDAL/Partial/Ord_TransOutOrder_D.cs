using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_TransOutOrder_D: BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_TransOutOrder_D"; }
        }
        protected override void Initialization()
        {
            base.Initialization();
            this.Order = "Ord_TransOutOrder_D.KeyID";
        }
    }
}
