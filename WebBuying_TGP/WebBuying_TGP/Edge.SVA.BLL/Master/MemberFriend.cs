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
	/// 好友表
	/// </summary>
	public partial class MemberFriend
	{
		private readonly IMemberFriend dal=DataAccess.CreateMemberFriend();
		public MemberFriend()
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
		public bool Exists(int MemberFriendID)
		{
			return dal.Exists(MemberFriendID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.MemberFriend model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberFriend model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MemberFriendID)
		{
			
			return dal.Delete(MemberFriendID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MemberFriendIDlist )
		{
			return dal.DeleteList(MemberFriendIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberFriend GetModel(int MemberFriendID)
		{
			
			return dal.GetModel(MemberFriendID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberFriend GetModelByCache(int MemberFriendID)
		{
			
			string CacheKey = "MemberFriendModel-" + MemberFriendID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MemberFriendID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberFriend)objModel;
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
		public List<Edge.SVA.Model.MemberFriend> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberFriend> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberFriend> modelList = new List<Edge.SVA.Model.MemberFriend>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberFriend model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberFriend();
					if(dt.Rows[n]["MemberFriendID"]!=null && dt.Rows[n]["MemberFriendID"].ToString()!="")
					{
						model.MemberFriendID=int.Parse(dt.Rows[n]["MemberFriendID"].ToString());
					}
					if(dt.Rows[n]["MemberID"]!=null && dt.Rows[n]["MemberID"].ToString()!="")
					{
						model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
					}
					if(dt.Rows[n]["FriendMemberID"]!=null && dt.Rows[n]["FriendMemberID"].ToString()!="")
					{
						model.FriendMemberID=int.Parse(dt.Rows[n]["FriendMemberID"].ToString());
					}
					if(dt.Rows[n]["FriendName"]!=null && dt.Rows[n]["FriendName"].ToString()!="")
					{
					model.FriendName=dt.Rows[n]["FriendName"].ToString();
					}
					if(dt.Rows[n]["MobileNumber"]!=null && dt.Rows[n]["MobileNumber"].ToString()!="")
					{
					model.MobileNumber=dt.Rows[n]["MobileNumber"].ToString();
					}
					if(dt.Rows[n]["EMail"]!=null && dt.Rows[n]["EMail"].ToString()!="")
					{
					model.EMail=dt.Rows[n]["EMail"].ToString();
					}
					if(dt.Rows[n]["SNSTypeID"]!=null && dt.Rows[n]["SNSTypeID"].ToString()!="")
					{
						model.SNSTypeID=int.Parse(dt.Rows[n]["SNSTypeID"].ToString());
					}
					if(dt.Rows[n]["SNSAccountNo"]!=null && dt.Rows[n]["SNSAccountNo"].ToString()!="")
					{
					model.SNSAccountNo=dt.Rows[n]["SNSAccountNo"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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

