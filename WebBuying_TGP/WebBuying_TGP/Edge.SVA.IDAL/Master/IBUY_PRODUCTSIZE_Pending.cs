﻿using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层产品尺寸属性。
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public interface IBUY_PRODUCTSIZE_Pending
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string ProductSizeCode,int ProductSizeID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ProductSizeID);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ProductSizeCode,int ProductSizeID);
		bool DeleteList(string ProductSizeIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.BUY_PRODUCTSIZE_Pending GetModel(int ProductSizeID);
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
