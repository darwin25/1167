using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层天标志表
	/// </summary>
	public interface IBUY_DAYFLAG
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string DayFlagCode,int DayFlagID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Edge.SVA.Model.BUY_DAYFLAG model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.BUY_DAYFLAG model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int DayFlagID);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string DayFlagCode,int DayFlagID);
		bool DeleteList(string DayFlagIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.BUY_DAYFLAG GetModel(int DayFlagID);
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
