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
	/// 货品部门表
	/// </summary>
	public partial class Department
	{
		private readonly IDepartment dal=DataAccess.CreateDepartment();
		public Department()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DepartCode)
		{
			return dal.Exists(DepartCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Department model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Department model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DepartCode)
		{
			
			return dal.Delete(DepartCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DepartCodelist )
		{
			return dal.DeleteList(DepartCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Department GetModel(string DepartCode)
		{
			
			return dal.GetModel(DepartCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Department GetModelByCache(string DepartCode)
		{
			
			string CacheKey = "DepartmentModel-" + DepartCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DepartCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Department)objModel;
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
		public List<Edge.SVA.Model.Department> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Department> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Department> modelList = new List<Edge.SVA.Model.Department>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Department model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Department();
					if(dt.Rows[n]["DepartCode"]!=null && dt.Rows[n]["DepartCode"].ToString()!="")
					{
					model.DepartCode=dt.Rows[n]["DepartCode"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["DepartName1"]!=null && dt.Rows[n]["DepartName1"].ToString()!="")
					{
					model.DepartName1=dt.Rows[n]["DepartName1"].ToString();
					}
					if(dt.Rows[n]["DepartName2"]!=null && dt.Rows[n]["DepartName2"].ToString()!="")
					{
					model.DepartName2=dt.Rows[n]["DepartName2"].ToString();
					}
					if(dt.Rows[n]["DepartName3"]!=null && dt.Rows[n]["DepartName3"].ToString()!="")
					{
					model.DepartName3=dt.Rows[n]["DepartName3"].ToString();
					}
					if(dt.Rows[n]["DepartPicFile"]!=null && dt.Rows[n]["DepartPicFile"].ToString()!="")
					{
					model.DepartPicFile=dt.Rows[n]["DepartPicFile"].ToString();
					}
					if(dt.Rows[n]["DepartNote"]!=null && dt.Rows[n]["DepartNote"].ToString()!="")
					{
					model.DepartNote=dt.Rows[n]["DepartNote"].ToString();
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
					if(dt.Rows[n]["DepartPicFile2"]!=null && dt.Rows[n]["DepartPicFile2"].ToString()!="")
					{
					model.DepartPicFile2=dt.Rows[n]["DepartPicFile2"].ToString();
					}
					if(dt.Rows[n]["DepartPicFile3"]!=null && dt.Rows[n]["DepartPicFile3"].ToString()!="")
					{
					model.DepartPicFile3=dt.Rows[n]["DepartPicFile3"].ToString();
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

