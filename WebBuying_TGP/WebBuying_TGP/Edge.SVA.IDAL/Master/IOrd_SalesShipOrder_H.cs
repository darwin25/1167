﻿using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层发货单（面向订单的）。 @2016-05-20
    /// 创建人：Lisa
    /// 创建时间：2016-06-01
	/// </summary>
	public interface IOrd_SalesShipOrder_H
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string SalesShipOrderNumber);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.Ord_SalesShipOrder_H model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.Ord_SalesShipOrder_H model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string SalesShipOrderNumber);
		bool DeleteList(string SalesShipOrderNumberlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.Ord_SalesShipOrder_H GetModel(string SalesShipOrderNumber);
		Edge.SVA.Model.Ord_SalesShipOrder_H DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	} 
}
