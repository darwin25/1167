using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class BUY_REPLENViewModel
    {
        BUY_REPLEN_H mainTable = new BUY_REPLEN_H();

        public BUY_REPLEN_H MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        DataTable detailTable = new DataTable();

        public DataTable DetailTable
        {
            get { return detailTable; }
            set { detailTable = value; }
        }
    }
}
