using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 优惠劵调整子表
	/// </summary>
    public partial class Ord_CouponAdjust_D
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetListWithCoupon(string strWhere)
        {
            return dal.GetListWithCoupon(strWhere);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public int GetCountWithCoupon(string strWhere)
        {
            return dal.GetCountWithCoupon(strWhere);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPageListWithCoupon(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageListWithCoupon(pageSize, currentPage, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public int GetCountWithCoupon_Movement(string strWhere)
        {
            return dal.GetCountWithCoupon_Movement(strWhere);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPageListWithCoupon_Movement(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageListWithCoupon_Movement(pageSize, currentPage, strWhere, filedOrder);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPageListWithCoupon_Movement1(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageListWithCoupon_Movement1(pageSize, currentPage, strWhere, filedOrder);

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public int GetCountWithCoupon_Movement1(string strWhere)
        {
            return dal.GetCountWithCoupon_Movement1(strWhere);
        }


        public decimal GetAllDenominationWithCoupon(string strWhere)
        {

            return dal.GetAllDenominationWithCoupon(strWhere);
        }

        public decimal GetAllDenominationWithOrd_CouponAdjust_D(string strWhere)
        {
            return dal.GetAllDenominationWithOrd_CouponAdjust_D(strWhere);  
        }

        public decimal GetAllDenominationWithCoupon_Movement(string strWhere)
        {
            return dal.GetAllDenominationWithCoupon_Movement(strWhere);  
        }

        public void GetAllDenominationWithCoupon_Movement(string strWhere, out decimal openBal, out decimal amount, out decimal closeBal)
        {
            dal.GetAllDenominationWithCoupon_Movement(strWhere, out openBal, out amount, out closeBal);
        }

    }
}

