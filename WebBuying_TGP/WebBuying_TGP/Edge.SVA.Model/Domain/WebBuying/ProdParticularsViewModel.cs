using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ProdParticularsViewModel
    {
        BUY_ProductParticulars mainTable = new BUY_ProductParticulars();

        public BUY_ProductParticulars MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
