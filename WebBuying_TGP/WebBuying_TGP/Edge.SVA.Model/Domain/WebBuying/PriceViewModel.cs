using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class PriceViewModel
    {
        BUY_RPRICE_H mainTable = new BUY_RPRICE_H();

        public BUY_RPRICE_H MainTable
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

        List<BUY_RPRICE_D> modellist = new List<BUY_RPRICE_D>();

        public List<BUY_RPRICE_D> Modellist
        {
            get { return modellist; }
            set { modellist = value; }
        }

        List<BUY_RPRICE_D> newmodellist = new List<BUY_RPRICE_D>();
        public List<BUY_RPRICE_D> NewModellist
        {
            get { return newmodellist; }
            set { newmodellist = value; }
        }
    }
}
