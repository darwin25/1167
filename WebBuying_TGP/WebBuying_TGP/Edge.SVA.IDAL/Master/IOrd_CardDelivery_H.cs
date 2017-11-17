using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层卡送货单主表。（从批核后的拣货单复制过来
	/// </summary>
	public interface IOrd_CardDelivery_H
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string CardDeliveryNumber);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.Ord_CardDelivery_H model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.Ord_CardDelivery_H model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string CardDeliveryNumber);
		bool DeleteList(string CardDeliveryNumberlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.Ord_CardDelivery_H GetModel(string CardDeliveryNumber);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder);
        /// <summary>
        /// 获取总页数
        /// </summary>
        int GetCount(string strWhere);
		#endregion  成员方法
	} 
}
