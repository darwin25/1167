using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class BauhausProductViewModel
    {
        BUY_PRODUCT_ADD_BAU mainTable = new BUY_PRODUCT_ADD_BAU();

        public BUY_PRODUCT_ADD_BAU MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        BUY_PRODUCT_ADD_BAU_Pending mainTablePeding = new BUY_PRODUCT_ADD_BAU_Pending();
        public BUY_PRODUCT_ADD_BAU_Pending MainTablePeding
        {
            get { return mainTablePeding; }
            set { mainTablePeding = value; }
        }
        DataTable _dtSUPPROD = new DataTable();

        public DataTable dtSUPPROD
        {
            get { return _dtSUPPROD; }
            set { _dtSUPPROD = value; }
        }

    }
}
