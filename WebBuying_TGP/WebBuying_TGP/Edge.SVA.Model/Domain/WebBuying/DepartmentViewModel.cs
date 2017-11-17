using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class DepartmentViewModel
    {
        BUY_DEPARTMENT mainTable = new BUY_DEPARTMENT();

        public BUY_DEPARTMENT MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
