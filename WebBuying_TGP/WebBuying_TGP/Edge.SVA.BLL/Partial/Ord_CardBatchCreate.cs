using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_CardBatchCreate : BaseBLL
    {
        public string ExportCSV(int batchID, int cardCount)
        {
            return dal.ExportCSV(batchID, cardCount);
        }


        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_CardBatchCreate() as IDAL.IBaseDAL; }
        }
    }
}
