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
	/// 优惠劵批量创建表
	/// </summary>
	public partial class Ord_CouponBatchCreate
	{
		private readonly IOrd_CouponBatchCreate dal=DataAccess.CreateOrd_CouponBatchCreate();
		public Ord_CouponBatchCreate()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CouponCreateNumber)
		{
			return dal.Exists(CouponCreateNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Ord_CouponBatchCreate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_CouponBatchCreate model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CouponCreateNumber)
		{
			
			return dal.Delete(CouponCreateNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BatchCouponIDlist )
		{
			return dal.DeleteList(BatchCouponIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Edge.SVA.Model.Ord_CouponBatchCreate GetModel(string CouponCreateNumber)
		{
			
			return dal.GetModel(CouponCreateNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Edge.SVA.Model.Ord_CouponBatchCreate GetModelByCache(string CouponCreateNumber)
		{
			
			string CacheKey = "Ord_CouponBatchCreateModel-" + CouponCreateNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CouponCreateNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Ord_CouponBatchCreate)objModel;
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
		public List<Edge.SVA.Model.Ord_CouponBatchCreate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_CouponBatchCreate> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_CouponBatchCreate> modelList = new List<Edge.SVA.Model.Ord_CouponBatchCreate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_CouponBatchCreate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_CouponBatchCreate();
					if(dt.Rows[n]["CouponCreateNumber"]!=null && dt.Rows[n]["CouponCreateNumber"].ToString()!="")
					{
					model.CouponCreateNumber=dt.Rows[n]["CouponCreateNumber"].ToString();
					}
					if(dt.Rows[n]["CouponTypeID"]!=null && dt.Rows[n]["CouponTypeID"].ToString()!="")
					{
						model.CouponTypeID=int.Parse(dt.Rows[n]["CouponTypeID"].ToString());
					}
					if(dt.Rows[n]["CouponCount"]!=null && dt.Rows[n]["CouponCount"].ToString()!="")
					{
						model.CouponCount=int.Parse(dt.Rows[n]["CouponCount"].ToString());
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["IssuedDate"]!=null && dt.Rows[n]["IssuedDate"].ToString()!="")
					{
						model.IssuedDate=DateTime.Parse(dt.Rows[n]["IssuedDate"].ToString());
					}
					if(dt.Rows[n]["ExpiryDate"]!=null && dt.Rows[n]["ExpiryDate"].ToString()!="")
					{
						model.ExpiryDate=DateTime.Parse(dt.Rows[n]["ExpiryDate"].ToString());
					}
					if(dt.Rows[n]["InitAmount"]!=null && dt.Rows[n]["InitAmount"].ToString()!="")
					{
						model.InitAmount=decimal.Parse(dt.Rows[n]["InitAmount"].ToString());
					}
					if(dt.Rows[n]["InitPoints"]!=null && dt.Rows[n]["InitPoints"].ToString()!="")
					{
						model.InitPoints=int.Parse(dt.Rows[n]["InitPoints"].ToString());
					}
					if(dt.Rows[n]["RandomPWD"]!=null && dt.Rows[n]["RandomPWD"].ToString()!="")
					{
						model.RandomPWD=int.Parse(dt.Rows[n]["RandomPWD"].ToString());
					}
					if(dt.Rows[n]["InitPassword"]!=null && dt.Rows[n]["InitPassword"].ToString()!="")
					{
					model.InitPassword=dt.Rows[n]["InitPassword"].ToString();
					}
					if(dt.Rows[n]["ApproveStatus"]!=null && dt.Rows[n]["ApproveStatus"].ToString()!="")
					{
					model.ApproveStatus=dt.Rows[n]["ApproveStatus"].ToString();
					}
					if(dt.Rows[n]["BatchCouponID"]!=null && dt.Rows[n]["BatchCouponID"].ToString()!="")
					{
						model.BatchCouponID=int.Parse(dt.Rows[n]["BatchCouponID"].ToString());
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
					if(dt.Rows[n]["CreatedBusDate"]!=null && dt.Rows[n]["CreatedBusDate"].ToString()!="")
					{
						model.CreatedBusDate=DateTime.Parse(dt.Rows[n]["CreatedBusDate"].ToString());
					}
					if(dt.Rows[n]["ApproveBusDate"]!=null && dt.Rows[n]["ApproveBusDate"].ToString()!="")
					{
						model.ApproveBusDate=DateTime.Parse(dt.Rows[n]["ApproveBusDate"].ToString());
					}
					if(dt.Rows[n]["ApprovalCode"]!=null && dt.Rows[n]["ApprovalCode"].ToString()!="")
					{
					model.ApprovalCode=dt.Rows[n]["ApprovalCode"].ToString();
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

