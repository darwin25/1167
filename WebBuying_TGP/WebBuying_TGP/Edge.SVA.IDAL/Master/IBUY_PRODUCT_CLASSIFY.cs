
using System;
using System.Data;
namespace Edge.IDAL
{
	/// <summary>
	/// 接口层货品划分。（辅助表。 货品和其他表配合
	/// </summary>
	public interface IBUY_PRODUCT_CLASSIFY
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
		bool Add(Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ProdCode,int ForeignkeyID,string ForeignTable);
        bool Delete(string ProdCode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.BUY_PRODUCT_CLASSIFY GetModel(string ProdCode,int ForeignkeyID,string ForeignTable);
        Edge.SVA.Model.BUY_PRODUCT_CLASSIFY GetPRODUCT_CLASSIFY(string ProdCode, string ForeignTable);
		Edge.SVA.Model.BUY_PRODUCT_CLASSIFY DataRowToModel(DataRow row);
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
