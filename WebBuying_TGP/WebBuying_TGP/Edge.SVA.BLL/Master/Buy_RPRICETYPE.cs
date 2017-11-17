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
	/// 零售价类型表
	/// </summary>
	public partial class BUY_RPRICETYPE
	{
		private readonly IBUY_RPRICETYPE dal=DataAccess.CreateBUY_RPRICETYPE();
		public BUY_RPRICETYPE()
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
		public bool Exists(string RPriceTypeCode,int RPriceTypeID)
		{
			return dal.Exists(RPriceTypeCode,RPriceTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_RPRICETYPE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_RPRICETYPE model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RPriceTypeID)
		{
			
			return dal.Delete(RPriceTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string RPriceTypeCode,int RPriceTypeID)
		{
			
			return dal.Delete(RPriceTypeCode,RPriceTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RPriceTypeIDlist )
		{
			return dal.DeleteList(RPriceTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_RPRICETYPE GetModel(int RPriceTypeID)
		{
			
			return dal.GetModel(RPriceTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_RPRICETYPE GetModelByCache(int RPriceTypeID)
		{
			
			string CacheKey = "BUY_RPRICETYPEModel-" + RPriceTypeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RPriceTypeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_RPRICETYPE)objModel;
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
		public List<Edge.SVA.Model.BUY_RPRICETYPE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_RPRICETYPE> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_RPRICETYPE> modelList = new List<Edge.SVA.Model.BUY_RPRICETYPE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_RPRICETYPE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_RPRICETYPE();
					if(dt.Rows[n]["RPriceTypeID"]!=null && dt.Rows[n]["RPriceTypeID"].ToString()!="")
					{
						model.RPriceTypeID=int.Parse(dt.Rows[n]["RPriceTypeID"].ToString());
					}
					if(dt.Rows[n]["RPriceTypeCode"]!=null && dt.Rows[n]["RPriceTypeCode"].ToString()!="")
					{
					model.RPriceTypeCode=dt.Rows[n]["RPriceTypeCode"].ToString();
					}
					if(dt.Rows[n]["RPriceTypeName1"]!=null && dt.Rows[n]["RPriceTypeName1"].ToString()!="")
					{
					model.RPriceTypeName1=dt.Rows[n]["RPriceTypeName1"].ToString();
					}
					if(dt.Rows[n]["RPriceTypeName2"]!=null && dt.Rows[n]["RPriceTypeName2"].ToString()!="")
					{
					model.RPriceTypeName2=dt.Rows[n]["RPriceTypeName2"].ToString();
					}
					if(dt.Rows[n]["RPriceTypeName3"]!=null && dt.Rows[n]["RPriceTypeName3"].ToString()!="")
					{
					model.RPriceTypeName3=dt.Rows[n]["RPriceTypeName3"].ToString();
					}
					if(dt.Rows[n]["AdditionalType"]!=null && dt.Rows[n]["AdditionalType"].ToString()!="")
					{
						model.AdditionalType=int.Parse(dt.Rows[n]["AdditionalType"].ToString());
					}
					if(dt.Rows[n]["Supervisor"]!=null && dt.Rows[n]["Supervisor"].ToString()!="")
					{
						model.Supervisor=int.Parse(dt.Rows[n]["Supervisor"].ToString());
					}
					if(dt.Rows[n]["SerialNo"]!=null && dt.Rows[n]["SerialNo"].ToString()!="")
					{
						model.SerialNo=int.Parse(dt.Rows[n]["SerialNo"].ToString());
					}
					if(dt.Rows[n]["Discount"]!=null && dt.Rows[n]["Discount"].ToString()!="")
					{
						model.Discount=int.Parse(dt.Rows[n]["Discount"].ToString());
					}
					if(dt.Rows[n]["TypeLevel"]!=null && dt.Rows[n]["TypeLevel"].ToString()!="")
					{
						model.TypeLevel=int.Parse(dt.Rows[n]["TypeLevel"].ToString());
					}
					if(dt.Rows[n]["MemberShip"]!=null && dt.Rows[n]["MemberShip"].ToString()!="")
					{
						model.MemberShip=int.Parse(dt.Rows[n]["MemberShip"].ToString());
					}
					if(dt.Rows[n]["StockTypeCode"]!=null && dt.Rows[n]["StockTypeCode"].ToString()!="")
					{
					model.StockTypeCode=dt.Rows[n]["StockTypeCode"].ToString();
					}
					if(dt.Rows[n]["RANOnly"]!=null && dt.Rows[n]["RANOnly"].ToString()!="")
					{
						model.RANOnly=int.Parse(dt.Rows[n]["RANOnly"].ToString());
					}
					if(dt.Rows[n]["DAMOnly"]!=null && dt.Rows[n]["DAMOnly"].ToString()!="")
					{
						model.DAMOnly=int.Parse(dt.Rows[n]["DAMOnly"].ToString());
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

