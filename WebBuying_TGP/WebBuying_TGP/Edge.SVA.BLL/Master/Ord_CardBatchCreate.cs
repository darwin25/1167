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
	/// ?¨?úá?′′?¨
	/// </summary>
	public partial class Ord_CardBatchCreate
	{
		private readonly IOrd_CardBatchCreate dal=DataAccess.CreateOrd_CardBatchCreate();
		public Ord_CardBatchCreate()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CardCreateNumber)
		{
			return dal.Exists(CardCreateNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CardBatchCreate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_CardBatchCreate model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CardCreateNumber)
		{
			
			return dal.Delete(CardCreateNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CardCreateNumberlist )
		{
			return dal.DeleteList(CardCreateNumberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Ord_CardBatchCreate GetModel(string CardCreateNumber)
		{
			
			return dal.GetModel(CardCreateNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_CardBatchCreate GetModelByCache(string CardCreateNumber)
		{
			
			string CacheKey = "Ord_CardBatchCreateModel-" + CardCreateNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CardCreateNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Ord_CardBatchCreate)objModel;
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
		public List<Edge.SVA.Model.Ord_CardBatchCreate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_CardBatchCreate> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_CardBatchCreate> modelList = new List<Edge.SVA.Model.Ord_CardBatchCreate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_CardBatchCreate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_CardBatchCreate();
					if(dt.Rows[n]["CardCreateNumber"]!=null && dt.Rows[n]["CardCreateNumber"].ToString()!="")
					{
					model.CardCreateNumber=dt.Rows[n]["CardCreateNumber"].ToString();
					}
					if(dt.Rows[n]["CardGradeID"]!=null && dt.Rows[n]["CardGradeID"].ToString()!="")
					{
						model.CardGradeID=int.Parse(dt.Rows[n]["CardGradeID"].ToString());
					}
					if(dt.Rows[n]["CardCount"]!=null && dt.Rows[n]["CardCount"].ToString()!="")
					{
						model.CardCount=int.Parse(dt.Rows[n]["CardCount"].ToString());
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
					if(dt.Rows[n]["BatchCardID"]!=null && dt.Rows[n]["BatchCardID"].ToString()!="")
					{
						model.BatchCardID=int.Parse(dt.Rows[n]["BatchCardID"].ToString());
					}
					if(dt.Rows[n]["ApprovalCode"]!=null && dt.Rows[n]["ApprovalCode"].ToString()!="")
					{
					model.ApprovalCode=dt.Rows[n]["ApprovalCode"].ToString();
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
					if(dt.Rows[n]["CreatedBusDate"]!=null && dt.Rows[n]["CreatedBusDate"].ToString()!="")
					{
						model.CreatedBusDate=DateTime.Parse(dt.Rows[n]["CreatedBusDate"].ToString());
					}
					if(dt.Rows[n]["ApproveBusDate"]!=null && dt.Rows[n]["ApproveBusDate"].ToString()!="")
					{
						model.ApproveBusDate=DateTime.Parse(dt.Rows[n]["ApproveBusDate"].ToString());
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

