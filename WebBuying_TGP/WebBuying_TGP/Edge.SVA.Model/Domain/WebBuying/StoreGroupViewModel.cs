using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class StoreGroupViewModel
    {
        BUY_STOREGROUP mainTable = new BUY_STOREGROUP();

        public BUY_STOREGROUP MainTable
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
