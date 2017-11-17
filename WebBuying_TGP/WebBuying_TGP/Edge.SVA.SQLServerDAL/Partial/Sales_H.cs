using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Sales_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "Sales_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Sales_H.CreatedOn";
        }
    }
}
