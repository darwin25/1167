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
	/// 销售单主表（字段暂定）
	///表中会员部分
	/// </summary>
	public partial class StaffUpdateXLS_M
	{
		private readonly IStaffUpdateXLS_M dal=DataAccess.CreateStaffUpdateXLS_M();
		public StaffUpdateXLS_M()
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
		public bool Exists(int KeyID)
		{
			return dal.Exists(KeyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.StaffUpdateXLS_M model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.StaffUpdateXLS_M model)
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
		public bool DeleteList(string KeyIDlist )
		{
			return dal.DeleteList(KeyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.StaffUpdateXLS_M GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.StaffUpdateXLS_M GetModelByCache(int KeyID)
		{
			
			string CacheKey = "StaffUpdateXLS_MModel-" + KeyID;
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
			return (Edge.SVA.Model.StaffUpdateXLS_M)objModel;
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
		public List<Edge.SVA.Model.StaffUpdateXLS_M> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.StaffUpdateXLS_M> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.StaffUpdateXLS_M> modelList = new List<Edge.SVA.Model.StaffUpdateXLS_M>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.StaffUpdateXLS_M model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.StaffUpdateXLS_M();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["Operation"]!=null && dt.Rows[n]["Operation"].ToString()!="")
					{
						model.Operation=int.Parse(dt.Rows[n]["Operation"].ToString());
					}
					if(dt.Rows[n]["ExcelFileName"]!=null && dt.Rows[n]["ExcelFileName"].ToString()!="")
					{
					model.ExcelFileName=dt.Rows[n]["ExcelFileName"].ToString();
					}
					if(dt.Rows[n]["SheetName"]!=null && dt.Rows[n]["SheetName"].ToString()!="")
					{
					model.SheetName=dt.Rows[n]["SheetName"].ToString();
					}
					if(dt.Rows[n]["ActionResult"]!=null && dt.Rows[n]["ActionResult"].ToString()!="")
					{
						model.ActionResult=int.Parse(dt.Rows[n]["ActionResult"].ToString());
					}
					if(dt.Rows[n]["ResultRemark"]!=null && dt.Rows[n]["ResultRemark"].ToString()!="")
					{
					model.ResultRemark=dt.Rows[n]["ResultRemark"].ToString();
					}
					if(dt.Rows[n]["CreatedDate"]!=null && dt.Rows[n]["CreatedDate"].ToString()!="")
					{
						model.CreatedDate=DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
					}
					if(dt.Rows[n]["UpdatedDate"]!=null && dt.Rows[n]["UpdatedDate"].ToString()!="")
					{
						model.UpdatedDate=DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
					model.CreatedBy=dt.Rows[n]["CreatedBy"].ToString();
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

