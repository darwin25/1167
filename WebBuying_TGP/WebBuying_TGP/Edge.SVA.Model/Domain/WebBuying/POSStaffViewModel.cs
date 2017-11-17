using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class POSStaffViewModel
    {
        POSSTAFF mainTable = new POSSTAFF();

        public POSSTAFF MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        DataTable storeTable = new DataTable();

        public DataTable StoreTable
        {
            get { return storeTable; }
            set { storeTable = value; }
        }
    }
}
