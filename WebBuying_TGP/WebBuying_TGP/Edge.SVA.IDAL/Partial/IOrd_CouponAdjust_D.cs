using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层优惠劵调整子表
	/// </summary>
	public partial interface IOrd_CouponAdjust_D
	{
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetListWithCoupon(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        int GetCountWithCoupon(string strWhere);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetPageListWithCoupon(int pageSize, int currentPage, string strWhere, string filedOrder);

              /// <summary>
        /// 获得前几行数据
        /// </summary>
        int GetCountWithCoupon_Movement(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetPageListWithCoupon_Movement(int pageSize, int currentPage, string strWhere, string filedOrder);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetPageListWithCoupon_Movement1(int pageSize, int currentPage, string strWhere, string filedOrder);

        int GetCountWithCoupon_Movement1(string strWhere);

        decimal GetAllDenominationWithCoupon(string strWhere);

        decimal GetAllDenominationWithOrd_CouponAdjust_D(string strWhere);

        decimal GetAllDenominationWithCoupon_Movement(string strWhere);

        void GetAllDenominationWithCoupon_Movement(string strWhere, out decimal openBal, out decimal amount, out decimal closeBal);
	} 
}
