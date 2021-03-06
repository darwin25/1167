﻿using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层卡消费赚积分规则表
	/// </summary>
	public interface IPOSSalesData
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string SN);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.POSSalesData model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.POSSalesData model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string SN);
		bool DeleteList(string SNlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.POSSalesData GetModel(string SN);
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
