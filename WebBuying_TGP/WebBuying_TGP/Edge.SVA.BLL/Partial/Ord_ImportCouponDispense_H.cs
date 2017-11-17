using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_ImportCouponDispense_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get
            {
                return DALFactory.DataAccess.CreateOrd_ImportCouponDispense_H() as IDAL.IBaseDAL;
            }
           
        }

  
        public List<string> GetCardNumbers(List<int> cardTypes, List<int> members)
        {
            return dal.GetCardNumbers(cardTypes, members);
        }

        public string ExportCSV(Edge.SVA.Model.Ord_ImportCouponDispense_H model)
        {
            return dal.ExportCSV(model);
        }
    }
}
