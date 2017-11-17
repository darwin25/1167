using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class MnmViewModel
    {
        BUY_MNM_H mainTable = new BUY_MNM_H();

        public BUY_MNM_H MainTable
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
