using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class PromotionViewModel
    {
        BUY_PROMO_H mainTable = new BUY_PROMO_H();

        public BUY_PROMO_H MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        List<BUY_PROMO_D> modellist = new List<BUY_PROMO_D>();

        public List<BUY_PROMO_D> Modellist
        {
            get { return modellist; }
            set { modellist = value; }
        }

        List<BUY_PROMO_D> newmodellist = new List<BUY_PROMO_D>();

        public List<BUY_PROMO_D> NewModellist
        {
            get { return newmodellist; }
            set { newmodellist = value; }
        }

        DataTable subTable = new DataTable();

        public DataTable SubTable
        {
            get { return subTable; }
            set { subTable = value; }
        }

        private string dayCode;

        public string DayCode
        {
            get { return dayCode; }
            set { dayCode = value; }
        }

        private string monthCode;

        public string MonthCode
        {
            get { return monthCode; }
            set { monthCode = value; }
        }

        private string weekCode;

        public string WeekCode
        {
            get { return weekCode; }
            set { weekCode = value; }
        }
    }
}
