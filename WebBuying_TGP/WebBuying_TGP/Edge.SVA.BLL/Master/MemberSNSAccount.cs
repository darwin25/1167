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
	/// 交友系统账号
	/// </summary>
	public partial class MemberSNSAccount
	{
		private readonly IMemberSNSAccount dal=DataAccess.CreateMemberSNSAccount();
		public MemberSNSAccount()
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
		public bool Exists(int SNSAccountID)
		{
			return dal.Exists(SNSAccountID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.MemberSNSAccount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberSNSAccount model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SNSAccountID)
		{
			
			return dal.Delete(SNSAccountID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SNSAccountIDlist )
		{
			return dal.DeleteList(SNSAccountIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberSNSAccount GetModel(int SNSAccountID)
		{
			
			return dal.GetModel(SNSAccountID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberSNSAccount GetModelByCache(int SNSAccountID)
		{
			
			string CacheKey = "MemberSNSAccountModel-" + SNSAccountID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SNSAccountID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberSNSAccount)objModel;
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
		public List<Edge.SVA.Model.MemberSNSAccount> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberSNSAccount> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberSNSAccount> modelList = new List<Edge.SVA.Model.MemberSNSAccount>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberSNSAccount model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberSNSAccount();
					if(dt.Rows[n]["SNSAccountID"]!=null && dt.Rows[n]["SNSAccountID"].ToString()!="")
					{
						model.SNSAccountID=int.Parse(dt.Rows[n]["SNSAccountID"].ToString());
					}
					if(dt.Rows[n]["MemberID"]!=null && dt.Rows[n]["MemberID"].ToString()!="")
					{
						model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
					}
					if(dt.Rows[n]["SNSTypeID"]!=null && dt.Rows[n]["SNSTypeID"].ToString()!="")
					{
						model.SNSTypeID=int.Parse(dt.Rows[n]["SNSTypeID"].ToString());
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

