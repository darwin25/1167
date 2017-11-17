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
	/// 支付分期表
	/// </summary>
	public partial class BUY_INSTALLMENT
	{
		private readonly IBUY_INSTALLMENT dal=DataAccess.CreateBUY_INSTALLMENT();
		public BUY_INSTALLMENT()
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
		public bool Exists(string InstallmentCode,int InstallmentID)
		{
			return dal.Exists(InstallmentCode,InstallmentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_INSTALLMENT model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_INSTALLMENT model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int InstallmentID)
		{
			
			return dal.Delete(InstallmentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string InstallmentCode,int InstallmentID)
		{
			
			return dal.Delete(InstallmentCode,InstallmentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string InstallmentIDlist )
		{
			return dal.DeleteList(InstallmentIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_INSTALLMENT GetModel(int InstallmentID)
		{
			
			return dal.GetModel(InstallmentID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_INSTALLMENT GetModelByCache(int InstallmentID)
		{
			
			string CacheKey = "BUY_INSTALLMENTModel-" + InstallmentID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(InstallmentID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_INSTALLMENT)objModel;
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
		public List<Edge.SVA.Model.BUY_INSTALLMENT> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_INSTALLMENT> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_INSTALLMENT> modelList = new List<Edge.SVA.Model.BUY_INSTALLMENT>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_INSTALLMENT model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_INSTALLMENT();
					if(dt.Rows[n]["InstallmentID"]!=null && dt.Rows[n]["InstallmentID"].ToString()!="")
					{
						model.InstallmentID=int.Parse(dt.Rows[n]["InstallmentID"].ToString());
					}
					if(dt.Rows[n]["InstallmentCode"]!=null && dt.Rows[n]["InstallmentCode"].ToString()!="")
					{
					model.InstallmentCode=dt.Rows[n]["InstallmentCode"].ToString();
					}
					if(dt.Rows[n]["BankID"]!=null && dt.Rows[n]["BankID"].ToString()!="")
					{
						model.BankID=int.Parse(dt.Rows[n]["BankID"].ToString());
					}
					if(dt.Rows[n]["InstallmentName1"]!=null && dt.Rows[n]["InstallmentName1"].ToString()!="")
					{
					model.InstallmentName1=dt.Rows[n]["InstallmentName1"].ToString();
					}
					if(dt.Rows[n]["InstallmentName2"]!=null && dt.Rows[n]["InstallmentName2"].ToString()!="")
					{
					model.InstallmentName2=dt.Rows[n]["InstallmentName2"].ToString();
					}
					if(dt.Rows[n]["InstallmentName3"]!=null && dt.Rows[n]["InstallmentName3"].ToString()!="")
					{
					model.InstallmentName3=dt.Rows[n]["InstallmentName3"].ToString();
					}
					if(dt.Rows[n]["NoOfLast"]!=null && dt.Rows[n]["NoOfLast"].ToString()!="")
					{
						model.NoOfLast=int.Parse(dt.Rows[n]["NoOfLast"].ToString());
					}
					if(dt.Rows[n]["PAInterest"]!=null && dt.Rows[n]["PAInterest"].ToString()!="")
					{
						model.PAInterest=decimal.Parse(dt.Rows[n]["PAInterest"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
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

