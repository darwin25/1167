using System;
using System.Data;
using System.Collections.Generic;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
using System.Text;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// RelationRoleIssuer
	/// </summary>
	public partial class RelationRoleIssuer
	{
		private readonly IRelationRoleIssuer dal=DataAccess.CreateRelationRoleIssuer();
		public RelationRoleIssuer()
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
		public bool Exists(int RoleID,int CardIssuerID)
		{
			return dal.Exists(RoleID,CardIssuerID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.RelationRoleIssuer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.RelationRoleIssuer model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleID,int CardIssuerID)
		{
			
			return dal.Delete(RoleID,CardIssuerID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.RelationRoleIssuer GetModel(int RoleID,int CardIssuerID)
		{
			
			return dal.GetModel(RoleID,CardIssuerID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.RelationRoleIssuer GetModelByCache(int RoleID,int CardIssuerID)
		{
			
			string CacheKey = "RelationRoleIssuerModel-" + RoleID+CardIssuerID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleID,CardIssuerID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.RelationRoleIssuer)objModel;
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
		public List<Edge.SVA.Model.RelationRoleIssuer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.RelationRoleIssuer> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.RelationRoleIssuer> modelList = new List<Edge.SVA.Model.RelationRoleIssuer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.RelationRoleIssuer model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.RelationRoleIssuer();
					if(dt.Rows[n]["RoleID"]!=null && dt.Rows[n]["RoleID"].ToString()!="")
					{
						model.RoleID=int.Parse(dt.Rows[n]["RoleID"].ToString());
					}
					if(dt.Rows[n]["CardIssuerID"]!=null && dt.Rows[n]["CardIssuerID"].ToString()!="")
					{
						model.CardIssuerID=int.Parse(dt.Rows[n]["CardIssuerID"].ToString());
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

