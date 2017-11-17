using System;
using System.Data;
using System.Collections.Generic;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 会员条款
	/// </summary>
	public partial class MemberClause
	{
		private readonly IMemberClause dal=DataAccess.CreateMemberClause();
		public MemberClause()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MemberClauseID)
		{
			return dal.Exists(MemberClauseID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.MemberClause model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberClause model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MemberClauseID)
		{
			
			return dal.Delete(MemberClauseID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MemberClauseIDlist )
		{
			return dal.DeleteList(MemberClauseIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberClause GetModel(int MemberClauseID)
		{
			
			return dal.GetModel(MemberClauseID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberClause GetModelByCache(int MemberClauseID)
		{
			
			string CacheKey = "MemberClauseModel-" + MemberClauseID;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MemberClauseID);
					if (objModel != null)
					{
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberClause)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberClause> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberClause> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberClause> modelList = new List<Edge.SVA.Model.MemberClause>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberClause model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberClause();
					if(dt.Rows[n]["MemberClauseID"]!=null && dt.Rows[n]["MemberClauseID"].ToString()!="")
					{
						model.MemberClauseID=int.Parse(dt.Rows[n]["MemberClauseID"].ToString());
					}
					if(dt.Rows[n]["ClauseTypeCode"]!=null && dt.Rows[n]["ClauseTypeCode"].ToString()!="")
					{
					model.ClauseTypeCode=dt.Rows[n]["ClauseTypeCode"].ToString();
					}
					if(dt.Rows[n]["ClauseSubCode"]!=null && dt.Rows[n]["ClauseSubCode"].ToString()!="")
					{
					model.ClauseSubCode=dt.Rows[n]["ClauseSubCode"].ToString();
					}
					if(dt.Rows[n]["ClauseName"]!=null && dt.Rows[n]["ClauseName"].ToString()!="")
					{
					model.ClauseName=dt.Rows[n]["ClauseName"].ToString();
					}
					if(dt.Rows[n]["MemberClauseDesc1"]!=null && dt.Rows[n]["MemberClauseDesc1"].ToString()!="")
					{
					model.MemberClauseDesc1=dt.Rows[n]["MemberClauseDesc1"].ToString();
					}
					if(dt.Rows[n]["MemberClauseDesc2"]!=null && dt.Rows[n]["MemberClauseDesc2"].ToString()!="")
					{
					model.MemberClauseDesc2=dt.Rows[n]["MemberClauseDesc2"].ToString();
					}
					if(dt.Rows[n]["MemberClauseDesc3"]!=null && dt.Rows[n]["MemberClauseDesc3"].ToString()!="")
					{
					model.MemberClauseDesc3=dt.Rows[n]["MemberClauseDesc3"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

