using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 会员消息服务账号
	/// </summary>
	public partial class MemberMessageAccount
	{
		private readonly IMemberMessageAccount dal=DataAccess.CreateMemberMessageAccount();
		public MemberMessageAccount()
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
		public bool Exists(int MessageAccountID)
		{
			return dal.Exists(MessageAccountID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.MemberMessageAccount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberMessageAccount model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MessageAccountID)
		{
			
			return dal.Delete(MessageAccountID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MessageAccountIDlist )
		{
			return dal.DeleteList(MessageAccountIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberMessageAccount GetModel(int MessageAccountID)
		{
			
			return dal.GetModel(MessageAccountID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberMessageAccount GetModelByCache(int MessageAccountID)
		{
			
			string CacheKey = "MemberMessageAccountModel-" + MessageAccountID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MessageAccountID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberMessageAccount)objModel;
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
		public List<Edge.SVA.Model.MemberMessageAccount> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberMessageAccount> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberMessageAccount> modelList = new List<Edge.SVA.Model.MemberMessageAccount>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberMessageAccount model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberMessageAccount();
					if(dt.Rows[n]["MessageAccountID"]!=null && dt.Rows[n]["MessageAccountID"].ToString()!="")
					{
						model.MessageAccountID=int.Parse(dt.Rows[n]["MessageAccountID"].ToString());
					}
					if(dt.Rows[n]["MemberID"]!=null && dt.Rows[n]["MemberID"].ToString()!="")
					{
						model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
					}
					if(dt.Rows[n]["MessageServiceTypeID"]!=null && dt.Rows[n]["MessageServiceTypeID"].ToString()!="")
					{
						model.MessageServiceTypeID=int.Parse(dt.Rows[n]["MessageServiceTypeID"].ToString());
					}
					if(dt.Rows[n]["AccountNumber"]!=null && dt.Rows[n]["AccountNumber"].ToString()!="")
					{
					model.AccountNumber=dt.Rows[n]["AccountNumber"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["IsPrefer"]!=null && dt.Rows[n]["IsPrefer"].ToString()!="")
					{
						model.IsPrefer=int.Parse(dt.Rows[n]["IsPrefer"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
						model.UpdatedBy=int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
					}
					if(dt.Rows[n]["TokenUID"]!=null && dt.Rows[n]["TokenUID"].ToString()!="")
					{
					model.TokenUID=dt.Rows[n]["TokenUID"].ToString();
					}
					if(dt.Rows[n]["TokenStr"]!=null && dt.Rows[n]["TokenStr"].ToString()!="")
					{
					model.TokenStr=dt.Rows[n]["TokenStr"].ToString();
					}
					if(dt.Rows[n]["TokenUpdateDate"]!=null && dt.Rows[n]["TokenUpdateDate"].ToString()!="")
					{
						model.TokenUpdateDate=DateTime.Parse(dt.Rows[n]["TokenUpdateDate"].ToString());
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

