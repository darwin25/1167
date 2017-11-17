using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层Promotion_H的子表。 促销命中条件表
    //（多个货品固定搭配的情况
	/// </summary>
	public interface IPromotion_Hit
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string PromotionCode,int HitSeq);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.Promotion_Hit model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.Promotion_Hit model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string PromotionCode,int HitSeq);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.Promotion_Hit GetModel(string PromotionCode,int HitSeq);
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
