using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层POSstaff 和 store
	/// </summary>
	public interface ISTAFFSTOREMAP
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int StaffID,int StoreID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.STAFFSTOREMAP model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.STAFFSTOREMAP model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int StaffID,int StoreID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.STAFFSTOREMAP GetModel(int StaffID,int StoreID);
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
