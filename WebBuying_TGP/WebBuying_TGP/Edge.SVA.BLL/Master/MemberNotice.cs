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
	/// 会员通知发送设置表
	/// </summary>
	public partial class MemberNotice
	{
		private readonly IMemberNotice dal=DataAccess.CreateMemberNotice();
		public MemberNotice()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string NoticeNumber)
		{
			return dal.Exists(NoticeNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.MemberNotice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberNotice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string NoticeNumber)
		{
			
			return dal.Delete(NoticeNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NoticeNumberlist )
		{
			return dal.DeleteList(NoticeNumberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberNotice GetModel(string NoticeNumber)
		{
			
			return dal.GetModel(NoticeNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberNotice GetModelByCache(string NoticeNumber)
		{
			
			string CacheKey = "MemberNoticeModel-" + NoticeNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NoticeNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberNotice)objModel;
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
		public List<Edge.SVA.Model.MemberNotice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberNotice> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberNotice> modelList = new List<Edge.SVA.Model.MemberNotice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberNotice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberNotice();
					if(dt.Rows[n]["NoticeNumber"]!=null && dt.Rows[n]["NoticeNumber"].ToString()!="")
					{
					model.NoticeNumber=dt.Rows[n]["NoticeNumber"].ToString();
					}
					if(dt.Rows[n]["NoticeDesc"]!=null && dt.Rows[n]["NoticeDesc"].ToString()!="")
					{
					model.NoticeDesc=dt.Rows[n]["NoticeDesc"].ToString();
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["ApproveStatus"]!=null && dt.Rows[n]["ApproveStatus"].ToString()!="")
					{
					model.ApproveStatus=dt.Rows[n]["ApproveStatus"].ToString();
					}
					if(dt.Rows[n]["ApproveOn"]!=null && dt.Rows[n]["ApproveOn"].ToString()!="")
					{
						model.ApproveOn=DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
					}
					if(dt.Rows[n]["ApproveBy"]!=null && dt.Rows[n]["ApproveBy"].ToString()!="")
					{
						model.ApproveBy=int.Parse(dt.Rows[n]["ApproveBy"].ToString());
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

