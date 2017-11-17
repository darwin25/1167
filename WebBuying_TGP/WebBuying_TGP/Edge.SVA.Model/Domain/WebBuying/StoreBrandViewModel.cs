using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class StoreBrandViewModel
    {
        Brand mainTable = new Brand();

        public Brand MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
