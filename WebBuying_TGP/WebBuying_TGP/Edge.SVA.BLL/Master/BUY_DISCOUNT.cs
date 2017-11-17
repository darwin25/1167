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
	/// 折扣设置表. （手动
	/// </summary>
	public partial class BUY_DISCOUNT
	{
		private readonly IBUY_DISCOUNT dal=DataAccess.CreateBUY_DISCOUNT();
		public BUY_DISCOUNT()
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
		public bool Exists(string DiscountCode,int KeyID)
		{
			return dal.Exists(DiscountCode,KeyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_DISCOUNT model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_DISCOUNT model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int KeyID)
		{
			
			return dal.Delete(KeyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DiscountCode,int KeyID)
		{
			
			return dal.Delete(DiscountCode,KeyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string KeyIDlist )
		{
			return dal.DeleteList(KeyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_DISCOUNT GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_DISCOUNT GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_DISCOUNTModel-" + KeyID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(KeyID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_DISCOUNT)objModel;
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
		public List<Edge.SVA.Model.BUY_DISCOUNT> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_DISCOUNT> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_DISCOUNT> modelList = new List<Edge.SVA.Model.BUY_DISCOUNT>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_DISCOUNT model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_DISCOUNT();
                    if (dt.Rows[n]["DiscountID"] != null && dt.Rows[n]["DiscountID"].ToString() != "")
					{
                        model.DiscountId = int.Parse(dt.Rows[n]["DiscountID"].ToString());
					}
					if(dt.Rows[n]["DiscountCode"]!=null && dt.Rows[n]["DiscountCode"].ToString()!="")
					{
					model.DiscountCode=dt.Rows[n]["DiscountCode"].ToString();
					}
					if(dt.Rows[n]["ReasonCode"]!=null && dt.Rows[n]["ReasonCode"].ToString()!="")
					{
					model.ReasonCode=dt.Rows[n]["ReasonCode"].ToString();
					}
					if(dt.Rows[n]["Description1"]!=null && dt.Rows[n]["Description1"].ToString()!="")
					{
					model.Description1=dt.Rows[n]["Description1"].ToString();
					}
					if(dt.Rows[n]["Description2"]!=null && dt.Rows[n]["Description2"].ToString()!="")
					{
					model.Description2=dt.Rows[n]["Description2"].ToString();
					}
					if(dt.Rows[n]["Description3"]!=null && dt.Rows[n]["Description3"].ToString()!="")
					{
					model.Description3=dt.Rows[n]["Description3"].ToString();
					}
					if(dt.Rows[n]["DiscType"]!=null && dt.Rows[n]["DiscType"].ToString()!="")
					{
						model.DiscType=int.Parse(dt.Rows[n]["DiscType"].ToString());
					}
					if(dt.Rows[n]["SalesDiscLevel"]!=null && dt.Rows[n]["SalesDiscLevel"].ToString()!="")
					{
						model.SalesDiscLevel=int.Parse(dt.Rows[n]["SalesDiscLevel"].ToString());
					}
					if(dt.Rows[n]["DiscPrice"]!=null && dt.Rows[n]["DiscPrice"].ToString()!="")
					{
						model.DiscPrice=decimal.Parse(dt.Rows[n]["DiscPrice"].ToString());
					}
					if(dt.Rows[n]["AuthLevel"]!=null && dt.Rows[n]["AuthLevel"].ToString()!="")
					{
						model.AuthLevel=int.Parse(dt.Rows[n]["AuthLevel"].ToString());
					}
					if(dt.Rows[n]["AllowDiscOnDisc"]!=null && dt.Rows[n]["AllowDiscOnDisc"].ToString()!="")
					{
						model.AllowDiscOnDisc=int.Parse(dt.Rows[n]["AllowDiscOnDisc"].ToString());
					}
					if(dt.Rows[n]["AllowChgDisc"]!=null && dt.Rows[n]["AllowChgDisc"].ToString()!="")
					{
						model.AllowChgDisc=int.Parse(dt.Rows[n]["AllowChgDisc"].ToString());
					}
					if(dt.Rows[n]["TransDiscControl"]!=null && dt.Rows[n]["TransDiscControl"].ToString()!="")
					{
						model.TransDiscControl=int.Parse(dt.Rows[n]["TransDiscControl"].ToString());
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

