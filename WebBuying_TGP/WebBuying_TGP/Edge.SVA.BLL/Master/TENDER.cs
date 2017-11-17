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
	/// 支付类型表
	/// </summary>
	public partial class TENDER
	{
		private readonly ITENDER dal=DataAccess.CreateTENDER();
		public TENDER()
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
		public bool Exists(string TenderCode,int TenderID)
		{
			return dal.Exists(TenderCode,TenderID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.TENDER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.TENDER model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TenderID)
		{
			
			return dal.Delete(TenderID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string TenderCode,int TenderID)
		{
			
			return dal.Delete(TenderCode,TenderID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TenderIDlist )
		{
			return dal.DeleteList(TenderIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.TENDER GetModel(int TenderID)
		{
			
			return dal.GetModel(TenderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.TENDER GetModelByCache(int TenderID)
		{
			
			string CacheKey = "TENDERModel-" + TenderID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TenderID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.TENDER)objModel;
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
		public List<Edge.SVA.Model.TENDER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.TENDER> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.TENDER> modelList = new List<Edge.SVA.Model.TENDER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.TENDER model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.TENDER();
					if(dt.Rows[n]["TenderID"]!=null && dt.Rows[n]["TenderID"].ToString()!="")
					{
						model.TenderID=int.Parse(dt.Rows[n]["TenderID"].ToString());
					}
					if(dt.Rows[n]["TenderCode"]!=null && dt.Rows[n]["TenderCode"].ToString()!="")
					{
					model.TenderCode=dt.Rows[n]["TenderCode"].ToString();
					}
					if(dt.Rows[n]["TenderTyep"]!=null && dt.Rows[n]["TenderTyep"].ToString()!="")
					{
						model.TenderTyep=int.Parse(dt.Rows[n]["TenderTyep"].ToString());
					}
					if(dt.Rows[n]["TenderName1"]!=null && dt.Rows[n]["TenderName1"].ToString()!="")
					{
					model.TenderName1=dt.Rows[n]["TenderName1"].ToString();
					}
					if(dt.Rows[n]["TenderName2"]!=null && dt.Rows[n]["TenderName2"].ToString()!="")
					{
					model.TenderName2=dt.Rows[n]["TenderName2"].ToString();
					}
					if(dt.Rows[n]["TenderName3"]!=null && dt.Rows[n]["TenderName3"].ToString()!="")
					{
					model.TenderName3=dt.Rows[n]["TenderName3"].ToString();
					}
					if(dt.Rows[n]["CashSale"]!=null && dt.Rows[n]["CashSale"].ToString()!="")
					{
						model.CashSale=int.Parse(dt.Rows[n]["CashSale"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Base"]!=null && dt.Rows[n]["Base"].ToString()!="")
					{
						model.Base=decimal.Parse(dt.Rows[n]["Base"].ToString());
					}
					if(dt.Rows[n]["Rate"]!=null && dt.Rows[n]["Rate"].ToString()!="")
					{
						model.Rate=decimal.Parse(dt.Rows[n]["Rate"].ToString());
					}
					if(dt.Rows[n]["MinAmount"]!=null && dt.Rows[n]["MinAmount"].ToString()!="")
					{
						model.MinAmount=decimal.Parse(dt.Rows[n]["MinAmount"].ToString());
					}
					if(dt.Rows[n]["MaxAmount"]!=null && dt.Rows[n]["MaxAmount"].ToString()!="")
					{
						model.MaxAmount=decimal.Parse(dt.Rows[n]["MaxAmount"].ToString());
					}
					if(dt.Rows[n]["CardBegin"]!=null && dt.Rows[n]["CardBegin"].ToString()!="")
					{
					model.CardBegin=dt.Rows[n]["CardBegin"].ToString();
					}
					if(dt.Rows[n]["CardEnd"]!=null && dt.Rows[n]["CardEnd"].ToString()!="")
					{
					model.CardEnd=dt.Rows[n]["CardEnd"].ToString();
					}
					if(dt.Rows[n]["CardLen"]!=null && dt.Rows[n]["CardLen"].ToString()!="")
					{
						model.CardLen=int.Parse(dt.Rows[n]["CardLen"].ToString());
					}
					if(dt.Rows[n]["Additional"]!=null && dt.Rows[n]["Additional"].ToString()!="")
					{
					model.Additional=dt.Rows[n]["Additional"].ToString();
					}
					if(dt.Rows[n]["BankID"]!=null && dt.Rows[n]["BankID"].ToString()!="")
					{
						model.BankID=int.Parse(dt.Rows[n]["BankID"].ToString());
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

