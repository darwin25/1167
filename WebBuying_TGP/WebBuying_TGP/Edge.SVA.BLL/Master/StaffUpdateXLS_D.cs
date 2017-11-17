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
	public partial class StaffUpdateXLS_D
	{
		private readonly IStaffUpdateXLS_D dal=DataAccess.CreateStaffUpdateXLS_D();
		public StaffUpdateXLS_D()
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
		public int  Add(Edge.SVA.Model.StaffUpdateXLS_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.StaffUpdateXLS_D model)
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
		public Edge.SVA.Model.StaffUpdateXLS_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.StaffUpdateXLS_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "StaffUpdateXLS_DModel-" + KeyID;
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
			return (Edge.SVA.Model.StaffUpdateXLS_D)objModel;
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
		public List<Edge.SVA.Model.StaffUpdateXLS_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.StaffUpdateXLS_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.StaffUpdateXLS_D> modelList = new List<Edge.SVA.Model.StaffUpdateXLS_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.StaffUpdateXLS_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.StaffUpdateXLS_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["MasterKeyID"]!=null && dt.Rows[n]["MasterKeyID"].ToString()!="")
					{
						model.MasterKeyID=int.Parse(dt.Rows[n]["MasterKeyID"].ToString());
					}
					if(dt.Rows[n]["Action"]!=null && dt.Rows[n]["Action"].ToString()!="")
					{
					model.Action=dt.Rows[n]["Action"].ToString();
					}
					if(dt.Rows[n]["BIRTHDAYMONTH"]!=null && dt.Rows[n]["BIRTHDAYMONTH"].ToString()!="")
					{
					model.BIRTHDAYMONTH=dt.Rows[n]["BIRTHDAYMONTH"].ToString();
					}
					if(dt.Rows[n]["CARDID"]!=null && dt.Rows[n]["CARDID"].ToString()!="")
					{
					model.CARDID=dt.Rows[n]["CARDID"].ToString();
					}
					if(dt.Rows[n]["CARDSTATUS"]!=null && dt.Rows[n]["CARDSTATUS"].ToString()!="")
					{
					model.CARDSTATUS=dt.Rows[n]["CARDSTATUS"].ToString();
					}
					if(dt.Rows[n]["COMPANYCODE"]!=null && dt.Rows[n]["COMPANYCODE"].ToString()!="")
					{
					model.COMPANYCODE=dt.Rows[n]["COMPANYCODE"].ToString();
					}
					if(dt.Rows[n]["DEPTCODE"]!=null && dt.Rows[n]["DEPTCODE"].ToString()!="")
					{
					model.DEPTCODE=dt.Rows[n]["DEPTCODE"].ToString();
					}
					if(dt.Rows[n]["Entitlement"]!=null && dt.Rows[n]["Entitlement"].ToString()!="")
					{
					model.Entitlement=dt.Rows[n]["Entitlement"].ToString();
					}
					if(dt.Rows[n]["FAMILYNAME"]!=null && dt.Rows[n]["FAMILYNAME"].ToString()!="")
					{
					model.FAMILYNAME=dt.Rows[n]["FAMILYNAME"].ToString();
					}
					if(dt.Rows[n]["GIVENNAME"]!=null && dt.Rows[n]["GIVENNAME"].ToString()!="")
					{
					model.GIVENNAME=dt.Rows[n]["GIVENNAME"].ToString();
					}
					if(dt.Rows[n]["POSITIONID"]!=null && dt.Rows[n]["POSITIONID"].ToString()!="")
					{
					model.POSITIONID=dt.Rows[n]["POSITIONID"].ToString();
					}
					if(dt.Rows[n]["STAFFID"]!=null && dt.Rows[n]["STAFFID"].ToString()!="")
					{
					model.STAFFID=dt.Rows[n]["STAFFID"].ToString();
					}
					if(dt.Rows[n]["STORECODE"]!=null && dt.Rows[n]["STORECODE"].ToString()!="")
					{
					model.STORECODE=dt.Rows[n]["STORECODE"].ToString();
					}
					if(dt.Rows[n]["AMOUNT"]!=null && dt.Rows[n]["AMOUNT"].ToString()!="")
					{
						model.AMOUNT=decimal.Parse(dt.Rows[n]["AMOUNT"].ToString());
					}
					if(dt.Rows[n]["REMARK"]!=null && dt.Rows[n]["REMARK"].ToString()!="")
					{
					model.REMARK=dt.Rows[n]["REMARK"].ToString();
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

