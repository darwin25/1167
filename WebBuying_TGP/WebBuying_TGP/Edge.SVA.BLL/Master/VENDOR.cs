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
	/// 实体卡绑定表
	/// </summary>
	public partial class VENDOR
	{
		private readonly IVENDOR dal=DataAccess.CreateVENDOR();
		public VENDOR()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.VENDOR model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.VENDOR model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.VENDOR GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.VENDOR GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "VENDORModel-" ;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.VENDOR)objModel;
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
		public List<Edge.SVA.Model.VENDOR> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.VENDOR> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.VENDOR> modelList = new List<Edge.SVA.Model.VENDOR>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.VENDOR model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.VENDOR();
					if(dt.Rows[n]["VendorCode"]!=null && dt.Rows[n]["VendorCode"].ToString()!="")
					{
					model.VendorCode=dt.Rows[n]["VendorCode"].ToString();
					}
					if(dt.Rows[n]["Area"]!=null && dt.Rows[n]["Area"].ToString()!="")
					{
					model.Area=dt.Rows[n]["Area"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["L_name"]!=null && dt.Rows[n]["L_name"].ToString()!="")
					{
					model.L_name=dt.Rows[n]["L_name"].ToString();
					}
					if(dt.Rows[n]["Address1"]!=null && dt.Rows[n]["Address1"].ToString()!="")
					{
					model.Address1=dt.Rows[n]["Address1"].ToString();
					}
					if(dt.Rows[n]["Address2"]!=null && dt.Rows[n]["Address2"].ToString()!="")
					{
					model.Address2=dt.Rows[n]["Address2"].ToString();
					}
					if(dt.Rows[n]["Address3"]!=null && dt.Rows[n]["Address3"].ToString()!="")
					{
					model.Address3=dt.Rows[n]["Address3"].ToString();
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["Position"]!=null && dt.Rows[n]["Position"].ToString()!="")
					{
					model.Position=dt.Rows[n]["Position"].ToString();
					}
					if(dt.Rows[n]["Tel"]!=null && dt.Rows[n]["Tel"].ToString()!="")
					{
					model.Tel=dt.Rows[n]["Tel"].ToString();
					}
					if(dt.Rows[n]["Fax"]!=null && dt.Rows[n]["Fax"].ToString()!="")
					{
					model.Fax=dt.Rows[n]["Fax"].ToString();
					}
					if(dt.Rows[n]["Telex"]!=null && dt.Rows[n]["Telex"].ToString()!="")
					{
					model.Telex=dt.Rows[n]["Telex"].ToString();
					}
					if(dt.Rows[n]["Cable"]!=null && dt.Rows[n]["Cable"].ToString()!="")
					{
					model.Cable=dt.Rows[n]["Cable"].ToString();
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
					if(dt.Rows[n]["Payterm"]!=null && dt.Rows[n]["Payterm"].ToString()!="")
					{
					model.Payterm=dt.Rows[n]["Payterm"].ToString();
					}
					if(dt.Rows[n]["Account_code"]!=null && dt.Rows[n]["Account_code"].ToString()!="")
					{
					model.Account_code=dt.Rows[n]["Account_code"].ToString();
					}
					if(dt.Rows[n]["Oversea"]!=null && dt.Rows[n]["Oversea"].ToString()!="")
					{
					model.Oversea=dt.Rows[n]["Oversea"].ToString();
					}
					if(dt.Rows[n]["In_tax"]!=null && dt.Rows[n]["In_tax"].ToString()!="")
					{
						model.In_tax=decimal.Parse(dt.Rows[n]["In_tax"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["Nonorder"]!=null && dt.Rows[n]["Nonorder"].ToString()!="")
					{
					model.Nonorder=dt.Rows[n]["Nonorder"].ToString();
					}
					if(dt.Rows[n]["Prepareby"]!=null && dt.Rows[n]["Prepareby"].ToString()!="")
					{
					model.Prepareby=dt.Rows[n]["Prepareby"].ToString();
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
					model.UpdatedBy=dt.Rows[n]["UpdatedBy"].ToString();
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

