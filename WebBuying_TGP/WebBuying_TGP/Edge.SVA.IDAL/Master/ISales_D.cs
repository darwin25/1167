using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层
    /// 创建人：Lisa
    /// 创建时间：2016-1-2
	/// </summary>
	public interface ISales_D
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        bool Exists(string SeqNo, string TransNum);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.Sales_D model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.Sales_D model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        bool Delete(string SeqNo, string TransNum);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Edge.SVA.Model.Sales_D GetModel(string SeqNo, string TransNum);
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
        DataSet GetSummary(string strWhere);
		#endregion  成员方法
	} 
}
