using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
    public class StoreNatureViewModel
    {
        StoreType mainTable = new StoreType();

        public StoreType MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
