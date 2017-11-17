using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层货品划分。（辅助表。 货品和其他表配合
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	public interface IBUY_ProductClassify
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string ProdCode,int ForeignkeyID,string ForeignTable);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.BUY_ProductClassify model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.BUY_ProductClassify model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ProdCode,int ForeignkeyID,string ForeignTable);
      
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.BUY_ProductClassify GetModel(string ProdCode,int ForeignkeyID,string ForeignTable);
        Edge.SVA.Model.BUY_ProductClassify GetProductClassify(string ProdCode, string ForeignTable);
		Edge.SVA.Model.BUY_ProductClassify DataRowToModel(DataRow row);
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
