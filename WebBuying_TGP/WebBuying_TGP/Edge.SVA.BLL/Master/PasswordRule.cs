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
	/// 密码规则
	/// </summary>
	public partial class PasswordRule
	{
		private readonly IPasswordRule dal=DataAccess.CreatePasswordRule();
		public PasswordRule()
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
		public bool Exists(int PasswordRuleID)
		{
			return dal.Exists(PasswordRuleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.PasswordRule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.PasswordRule model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PasswordRuleID)
		{
			
			return dal.Delete(PasswordRuleID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PasswordRuleIDlist )
		{
			return dal.DeleteList(PasswordRuleIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.PasswordRule GetModel(int PasswordRuleID)
		{
			
			return dal.GetModel(PasswordRuleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.PasswordRule GetModelByCache(int PasswordRuleID)
		{
			
			string CacheKey = "PasswordRuleModel-" + PasswordRuleID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PasswordRuleID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.PasswordRule)objModel;
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
		public List<Edge.SVA.Model.PasswordRule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.PasswordRule> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.PasswordRule> modelList = new List<Edge.SVA.Model.PasswordRule>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.PasswordRule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.PasswordRule();
					if(dt.Rows[n]["PasswordRuleID"]!=null && dt.Rows[n]["PasswordRuleID"].ToString()!="")
					{
						model.PasswordRuleID=int.Parse(dt.Rows[n]["PasswordRuleID"].ToString());
					}
					if(dt.Rows[n]["PWDMinLength"]!=null && dt.Rows[n]["PWDMinLength"].ToString()!="")
					{
						model.PWDMinLength=int.Parse(dt.Rows[n]["PWDMinLength"].ToString());
					}
					if(dt.Rows[n]["PWDMaxLength"]!=null && dt.Rows[n]["PWDMaxLength"].ToString()!="")
					{
						model.PWDMaxLength=int.Parse(dt.Rows[n]["PWDMaxLength"].ToString());
					}
					if(dt.Rows[n]["PWDSecurityLevel"]!=null && dt.Rows[n]["PWDSecurityLevel"].ToString()!="")
					{
						model.PWDSecurityLevel=int.Parse(dt.Rows[n]["PWDSecurityLevel"].ToString());
					}
					if(dt.Rows[n]["PWDStructure"]!=null && dt.Rows[n]["PWDStructure"].ToString()!="")
					{
						model.PWDStructure=int.Parse(dt.Rows[n]["PWDStructure"].ToString());
					}
					if(dt.Rows[n]["PWDValidDays"]!=null && dt.Rows[n]["PWDValidDays"].ToString()!="")
					{
						model.PWDValidDays=int.Parse(dt.Rows[n]["PWDValidDays"].ToString());
					}
					if(dt.Rows[n]["PWDValidDaysUnit"]!=null && dt.Rows[n]["PWDValidDaysUnit"].ToString()!="")
					{
						model.PWDValidDaysUnit=int.Parse(dt.Rows[n]["PWDValidDaysUnit"].ToString());
					}
					if(dt.Rows[n]["ResetPWDDays"]!=null && dt.Rows[n]["ResetPWDDays"].ToString()!="")
					{
						model.ResetPWDDays=int.Parse(dt.Rows[n]["ResetPWDDays"].ToString());
					}
					if(dt.Rows[n]["MemberPWDRule"]!=null && dt.Rows[n]["MemberPWDRule"].ToString()!="")
					{
						model.MemberPWDRule=int.Parse(dt.Rows[n]["MemberPWDRule"].ToString());
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
					if(dt.Rows[n]["PasswordRuleCode"]!=null && dt.Rows[n]["PasswordRuleCode"].ToString()!="")
					{
					model.PasswordRuleCode=dt.Rows[n]["PasswordRuleCode"].ToString();
					}
					if(dt.Rows[n]["Name1"]!=null && dt.Rows[n]["Name1"].ToString()!="")
					{
					model.Name1=dt.Rows[n]["Name1"].ToString();
					}
					if(dt.Rows[n]["Name2"]!=null && dt.Rows[n]["Name2"].ToString()!="")
					{
					model.Name2=dt.Rows[n]["Name2"].ToString();
					}
					if(dt.Rows[n]["Name3"]!=null && dt.Rows[n]["Name3"].ToString()!="")
					{
					model.Name3=dt.Rows[n]["Name3"].ToString();
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
        /// <summary>
        /// 获取分页总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

