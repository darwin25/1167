using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class CPriceViewModel
    {
        BUY_CPRICE_H mainTable = new BUY_CPRICE_H();

        public BUY_CPRICE_H MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        DataTable subTable = new DataTable();

        public DataTable SubTable
        {
            get { return subTable; }
            set { subTable = value; }
        }
    }
}
