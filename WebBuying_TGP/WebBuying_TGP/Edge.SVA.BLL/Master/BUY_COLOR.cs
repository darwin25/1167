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
	/// 颜色表
	/// </summary>
	public partial class BUY_COLOR
	{
		private readonly IBUY_COLOR dal=DataAccess.CreateBUY_COLOR();
		public BUY_COLOR()
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
		public bool Exists(string ColorCode,int ColorID)
		{
			return dal.Exists(ColorCode,ColorID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_COLOR model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_COLOR model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ColorID)
		{
			
			return dal.Delete(ColorID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ColorCode,int ColorID)
		{
			
			return dal.Delete(ColorCode,ColorID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ColorIDlist )
		{
			return dal.DeleteList(ColorIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_COLOR GetModel(int ColorID)
		{
			
			return dal.GetModel(ColorID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_COLOR GetModelByCache(int ColorID)
		{
			
			string CacheKey = "BUY_COLORModel-" + ColorID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ColorID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_COLOR)objModel;
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
		public List<Edge.SVA.Model.BUY_COLOR> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_COLOR> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_COLOR> modelList = new List<Edge.SVA.Model.BUY_COLOR>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_COLOR model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_COLOR();
					if(dt.Rows[n]["ColorID"]!=null && dt.Rows[n]["ColorID"].ToString()!="")
					{
						model.ColorID=int.Parse(dt.Rows[n]["ColorID"].ToString());
					}
					if(dt.Rows[n]["ColorCode"]!=null && dt.Rows[n]["ColorCode"].ToString()!="")
					{
					model.ColorCode=dt.Rows[n]["ColorCode"].ToString();
					}
					if(dt.Rows[n]["ColorName1"]!=null && dt.Rows[n]["ColorName1"].ToString()!="")
					{
					model.ColorName1=dt.Rows[n]["ColorName1"].ToString();
					}
					if(dt.Rows[n]["ColorName2"]!=null && dt.Rows[n]["ColorName2"].ToString()!="")
					{
					model.ColorName2=dt.Rows[n]["ColorName2"].ToString();
					}
					if(dt.Rows[n]["ColorName3"]!=null && dt.Rows[n]["ColorName3"].ToString()!="")
					{
					model.ColorName3=dt.Rows[n]["ColorName3"].ToString();
					}
					if(dt.Rows[n]["ColorPicFile"]!=null && dt.Rows[n]["ColorPicFile"].ToString()!="")
					{
					model.ColorPicFile=dt.Rows[n]["ColorPicFile"].ToString();
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

