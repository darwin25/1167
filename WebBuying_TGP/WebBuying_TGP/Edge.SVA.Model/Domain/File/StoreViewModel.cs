using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
    public class StoreViewModel
    {
        Store mainTable = new Store();

        public Store MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
