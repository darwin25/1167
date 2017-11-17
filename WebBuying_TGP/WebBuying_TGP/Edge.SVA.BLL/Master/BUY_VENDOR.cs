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
	/// 供应商表
	/// </summary>
	public partial class BUY_VENDOR
	{
		private readonly IBUY_VENDOR dal=DataAccess.CreateBUY_VENDOR();
		public BUY_VENDOR()
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
		public bool Exists(string VendorCode,int VendorID)
		{
			return dal.Exists(VendorCode,VendorID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_VENDOR model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_VENDOR model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int VendorID)
		{
			
			return dal.Delete(VendorID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string VendorCode,int VendorID)
		{
			
			return dal.Delete(VendorCode,VendorID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string VendorIDlist )
		{
			return dal.DeleteList(VendorIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_VENDOR GetModel(int VendorID)
		{
			
			return dal.GetModel(VendorID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_VENDOR GetModelByCache(int VendorID)
		{
			
			string CacheKey = "BUY_VENDORModel-" + VendorID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(VendorID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_VENDOR)objModel;
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
		public List<Edge.SVA.Model.BUY_VENDOR> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_VENDOR> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_VENDOR> modelList = new List<Edge.SVA.Model.BUY_VENDOR>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_VENDOR model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_VENDOR();
					if(dt.Rows[n]["VendorID"]!=null && dt.Rows[n]["VendorID"].ToString()!="")
					{
						model.VendorID=int.Parse(dt.Rows[n]["VendorID"].ToString());
					}
					if(dt.Rows[n]["VendorCode"]!=null && dt.Rows[n]["VendorCode"].ToString()!="")
					{
					model.VendorCode=dt.Rows[n]["VendorCode"].ToString();
					}
					if(dt.Rows[n]["VendorName1"]!=null && dt.Rows[n]["VendorName1"].ToString()!="")
					{
					model.VendorName1=dt.Rows[n]["VendorName1"].ToString();
					}
					if(dt.Rows[n]["VendorName2"]!=null && dt.Rows[n]["VendorName2"].ToString()!="")
					{
					model.VendorName2=dt.Rows[n]["VendorName2"].ToString();
					}
					if(dt.Rows[n]["VendorName3"]!=null && dt.Rows[n]["VendorName3"].ToString()!="")
					{
					model.VendorName3=dt.Rows[n]["VendorName3"].ToString();
					}
					if(dt.Rows[n]["VendorAddress1"]!=null && dt.Rows[n]["VendorAddress1"].ToString()!="")
					{
					model.VendorAddress1=dt.Rows[n]["VendorAddress1"].ToString();
					}
					if(dt.Rows[n]["VendorAddress2"]!=null && dt.Rows[n]["VendorAddress2"].ToString()!="")
					{
					model.VendorAddress2=dt.Rows[n]["VendorAddress2"].ToString();
					}
					if(dt.Rows[n]["VendorAddress3"]!=null && dt.Rows[n]["VendorAddress3"].ToString()!="")
					{
					model.VendorAddress3=dt.Rows[n]["VendorAddress3"].ToString();
					}
					if(dt.Rows[n]["VendorNote"]!=null && dt.Rows[n]["VendorNote"].ToString()!="")
					{
					model.VendorNote=dt.Rows[n]["VendorNote"].ToString();
					}
					if(dt.Rows[n]["PreferFlag"]!=null && dt.Rows[n]["PreferFlag"].ToString()!="")
					{
						model.PreferFlag=int.Parse(dt.Rows[n]["PreferFlag"].ToString());
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["ContactPosition"]!=null && dt.Rows[n]["ContactPosition"].ToString()!="")
					{
					model.ContactPosition=dt.Rows[n]["ContactPosition"].ToString();
					}
					if(dt.Rows[n]["ContactTel"]!=null && dt.Rows[n]["ContactTel"].ToString()!="")
					{
					model.ContactTel=dt.Rows[n]["ContactTel"].ToString();
					}
					if(dt.Rows[n]["ContactFax"]!=null && dt.Rows[n]["ContactFax"].ToString()!="")
					{
					model.ContactFax=dt.Rows[n]["ContactFax"].ToString();
					}
					if(dt.Rows[n]["ContactMobile"]!=null && dt.Rows[n]["ContactMobile"].ToString()!="")
					{
					model.ContactMobile=dt.Rows[n]["ContactMobile"].ToString();
					}
					if(dt.Rows[n]["ContactEmail"]!=null && dt.Rows[n]["ContactEmail"].ToString()!="")
					{
					model.ContactEmail=dt.Rows[n]["ContactEmail"].ToString();
					}
					if(dt.Rows[n]["Terms"]!=null && dt.Rows[n]["Terms"].ToString()!="")
					{
						model.Terms=int.Parse(dt.Rows[n]["Terms"].ToString());
					}
					if(dt.Rows[n]["Limit"]!=null && dt.Rows[n]["Limit"].ToString()!="")
					{
						model.Limit=decimal.Parse(dt.Rows[n]["Limit"].ToString());
					}
					if(dt.Rows[n]["Shipment"]!=null && dt.Rows[n]["Shipment"].ToString()!="")
					{
					model.Shipment=dt.Rows[n]["Shipment"].ToString();
					}
					if(dt.Rows[n]["PayTerm"]!=null && dt.Rows[n]["PayTerm"].ToString()!="")
					{
					model.PayTerm=dt.Rows[n]["PayTerm"].ToString();
					}
					if(dt.Rows[n]["AccountCode"]!=null && dt.Rows[n]["AccountCode"].ToString()!="")
					{
					model.AccountCode=dt.Rows[n]["AccountCode"].ToString();
					}
					if(dt.Rows[n]["Oversea"]!=null && dt.Rows[n]["Oversea"].ToString()!="")
					{
						model.Oversea=int.Parse(dt.Rows[n]["Oversea"].ToString());
					}
					if(dt.Rows[n]["InTax"]!=null && dt.Rows[n]["InTax"].ToString()!="")
					{
						model.InTax=decimal.Parse(dt.Rows[n]["InTax"].ToString());
					}
					if(dt.Rows[n]["NonOrder"]!=null && dt.Rows[n]["NonOrder"].ToString()!="")
					{
						model.NonOrder=int.Parse(dt.Rows[n]["NonOrder"].ToString());
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

