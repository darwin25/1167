using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Store
	/// </summary>
	public partial class Store:IStore
	{
		public Store()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StoreID", "Store"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Store");
			strSql.Append(" where StoreID=@StoreID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Store(");
			strSql.Append("StoreCode,StoreName1,StoreName2,StoreName3,StoreTypeID,StoreGroupID,BankID,StoreCountry,StoreProvince,StoreCity,StoreAddressDetail,StoreTel,StoreFax,StoreLongitude,StoreLatitude,LocationID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreNote,StoreOpenTime,StoreCloseTime,BrandID,StorePicFile,MapsPicFile,MapsPicShadowFile,Email,Contact,ContactPhone,StoreDistrict,StoreFullDetail,StoreAddressDetail2,StoreFullDetail2,StoreAddressDetail3,StoreFullDetail3,Status)");
			strSql.Append(" values (");
			strSql.Append("@StoreCode,@StoreName1,@StoreName2,@StoreName3,@StoreTypeID,@StoreGroupID,@BankID,@StoreCountry,@StoreProvince,@StoreCity,@StoreAddressDetail,@StoreTel,@StoreFax,@StoreLongitude,@StoreLatitude,@LocationID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@StoreNote,@StoreOpenTime,@StoreCloseTime,@BrandID,@StorePicFile,@MapsPicFile,@MapsPicShadowFile,@Email,@Contact,@ContactPhone,@StoreDistrict,@StoreFullDetail,@StoreAddressDetail2,@StoreFullDetail2,@StoreAddressDetail3,@StoreFullDetail3,@Status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,512),
					new SqlParameter("@StoreName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@StoreCountry", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreProvince", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreCity", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreAddressDetail", SqlDbType.VarChar,512),
					new SqlParameter("@StoreTel", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFax", SqlDbType.VarChar,512),
					new SqlParameter("@StoreLongitude", SqlDbType.VarChar,512),
					new SqlParameter("@StoreLatitude", SqlDbType.VarChar,512),
					new SqlParameter("@LocationID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreNote", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreOpenTime", SqlDbType.VarChar,512),
					new SqlParameter("@StoreCloseTime", SqlDbType.VarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@StorePicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicShadowFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Email", SqlDbType.NVarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@StoreFullDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreAddressDetail2", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFullDetail2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreAddressDetail3", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFullDetail3", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.StoreName1;
			parameters[2].Value = model.StoreName2;
			parameters[3].Value = model.StoreName3;
			parameters[4].Value = model.StoreTypeID;
			parameters[5].Value = model.StoreGroupID;
			parameters[6].Value = model.BankID;
			parameters[7].Value = model.StoreCountry;
			parameters[8].Value = model.StoreProvince;
			parameters[9].Value = model.StoreCity;
			parameters[10].Value = model.StoreAddressDetail;
			parameters[11].Value = model.StoreTel;
			parameters[12].Value = model.StoreFax;
			parameters[13].Value = model.StoreLongitude;
			parameters[14].Value = model.StoreLatitude;
			parameters[15].Value = model.LocationID;
			parameters[16].Value = model.CreatedOn;
			parameters[17].Value = model.CreatedBy;
			parameters[18].Value = model.UpdatedOn;
			parameters[19].Value = model.UpdatedBy;
			parameters[20].Value = model.StoreNote;
			parameters[21].Value = model.StoreOpenTime;
			parameters[22].Value = model.StoreCloseTime;
			parameters[23].Value = model.BrandID;
			parameters[24].Value = model.StorePicFile;
			parameters[25].Value = model.MapsPicFile;
			parameters[26].Value = model.MapsPicShadowFile;
			parameters[27].Value = model.Email;
			parameters[28].Value = model.Contact;
			parameters[29].Value = model.ContactPhone;
			parameters[30].Value = model.StoreDistrict;
			parameters[31].Value = model.StoreFullDetail;
			parameters[32].Value = model.StoreAddressDetail2;
			parameters[33].Value = model.StoreFullDetail2;
			parameters[34].Value = model.StoreAddressDetail3;
			parameters[35].Value = model.StoreFullDetail3;
			parameters[36].Value = model.Status;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Store set ");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("StoreName1=@StoreName1,");
			strSql.Append("StoreName2=@StoreName2,");
			strSql.Append("StoreName3=@StoreName3,");
			strSql.Append("StoreTypeID=@StoreTypeID,");
			strSql.Append("StoreGroupID=@StoreGroupID,");
			strSql.Append("BankID=@BankID,");
			strSql.Append("StoreCountry=@StoreCountry,");
			strSql.Append("StoreProvince=@StoreProvince,");
			strSql.Append("StoreCity=@StoreCity,");
			strSql.Append("StoreAddressDetail=@StoreAddressDetail,");
			strSql.Append("StoreTel=@StoreTel,");
			strSql.Append("StoreFax=@StoreFax,");
			strSql.Append("StoreLongitude=@StoreLongitude,");
			strSql.Append("StoreLatitude=@StoreLatitude,");
			strSql.Append("LocationID=@LocationID,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("StoreNote=@StoreNote,");
			strSql.Append("StoreOpenTime=@StoreOpenTime,");
			strSql.Append("StoreCloseTime=@StoreCloseTime,");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("StorePicFile=@StorePicFile,");
			strSql.Append("MapsPicFile=@MapsPicFile,");
			strSql.Append("MapsPicShadowFile=@MapsPicShadowFile,");
			strSql.Append("Email=@Email,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("ContactPhone=@ContactPhone,");
			strSql.Append("StoreDistrict=@StoreDistrict,");
			strSql.Append("StoreFullDetail=@StoreFullDetail,");
			strSql.Append("StoreAddressDetail2=@StoreAddressDetail2,");
			strSql.Append("StoreFullDetail2=@StoreFullDetail2,");
			strSql.Append("StoreAddressDetail3=@StoreAddressDetail3,");
			strSql.Append("StoreFullDetail3=@StoreFullDetail3,");
			strSql.Append("Status=@Status");
			strSql.Append(" where StoreID=@StoreID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,512),
					new SqlParameter("@StoreName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@StoreCountry", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreProvince", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreCity", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreAddressDetail", SqlDbType.VarChar,512),
					new SqlParameter("@StoreTel", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFax", SqlDbType.VarChar,512),
					new SqlParameter("@StoreLongitude", SqlDbType.VarChar,512),
					new SqlParameter("@StoreLatitude", SqlDbType.VarChar,512),
					new SqlParameter("@LocationID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreNote", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreOpenTime", SqlDbType.VarChar,512),
					new SqlParameter("@StoreCloseTime", SqlDbType.VarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@StorePicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicShadowFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Email", SqlDbType.NVarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@StoreFullDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreAddressDetail2", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFullDetail2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreAddressDetail3", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFullDetail3", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.StoreName1;
			parameters[2].Value = model.StoreName2;
			parameters[3].Value = model.StoreName3;
			parameters[4].Value = model.StoreTypeID;
			parameters[5].Value = model.StoreGroupID;
			parameters[6].Value = model.BankID;
			parameters[7].Value = model.StoreCountry;
			parameters[8].Value = model.StoreProvince;
			parameters[9].Value = model.StoreCity;
			parameters[10].Value = model.StoreAddressDetail;
			parameters[11].Value = model.StoreTel;
			parameters[12].Value = model.StoreFax;
			parameters[13].Value = model.StoreLongitude;
			parameters[14].Value = model.StoreLatitude;
			parameters[15].Value = model.LocationID;
			parameters[16].Value = model.CreatedOn;
			parameters[17].Value = model.CreatedBy;
			parameters[18].Value = model.UpdatedOn;
			parameters[19].Value = model.UpdatedBy;
			parameters[20].Value = model.StoreNote;
			parameters[21].Value = model.StoreOpenTime;
			parameters[22].Value = model.StoreCloseTime;
			parameters[23].Value = model.BrandID;
			parameters[24].Value = model.StorePicFile;
			parameters[25].Value = model.MapsPicFile;
			parameters[26].Value = model.MapsPicShadowFile;
			parameters[27].Value = model.Email;
			parameters[28].Value = model.Contact;
			parameters[29].Value = model.ContactPhone;
			parameters[30].Value = model.StoreDistrict;
			parameters[31].Value = model.StoreFullDetail;
			parameters[32].Value = model.StoreAddressDetail2;
			parameters[33].Value = model.StoreFullDetail2;
			parameters[34].Value = model.StoreAddressDetail3;
			parameters[35].Value = model.StoreFullDetail3;
			parameters[36].Value = model.Status;
			parameters[37].Value = model.StoreID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Store ");
			strSql.Append(" where StoreID=@StoreID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string StoreIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Store ");
			strSql.Append(" where StoreID in ("+StoreIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Store GetModel(int StoreID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreID,StoreCode,StoreName1,StoreName2,StoreName3,StoreTypeID,StoreGroupID,BankID,StoreCountry,StoreProvince,StoreCity,StoreAddressDetail,StoreTel,StoreFax,StoreLongitude,StoreLatitude,LocationID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreNote,StoreOpenTime,StoreCloseTime,BrandID,StorePicFile,MapsPicFile,MapsPicShadowFile,Email,Contact,ContactPhone,StoreDistrict,StoreFullDetail,StoreAddressDetail2,StoreFullDetail2,StoreAddressDetail3,StoreFullDetail3,Status from Store ");
			strSql.Append(" where StoreID=@StoreID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreID;

			Edge.SVA.Model.Store model=new Edge.SVA.Model.Store();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreID"]!=null && ds.Tables[0].Rows[0]["StoreID"].ToString()!="")
				{
					model.StoreID=int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreName1"]!=null && ds.Tables[0].Rows[0]["StoreName1"].ToString()!="")
				{
					model.StoreName1=ds.Tables[0].Rows[0]["StoreName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreName2"]!=null && ds.Tables[0].Rows[0]["StoreName2"].ToString()!="")
				{
					model.StoreName2=ds.Tables[0].Rows[0]["StoreName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreName3"]!=null && ds.Tables[0].Rows[0]["StoreName3"].ToString()!="")
				{
					model.StoreName3=ds.Tables[0].Rows[0]["StoreName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreTypeID"]!=null && ds.Tables[0].Rows[0]["StoreTypeID"].ToString()!="")
				{
					model.StoreTypeID=int.Parse(ds.Tables[0].Rows[0]["StoreTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreGroupID"]!=null && ds.Tables[0].Rows[0]["StoreGroupID"].ToString()!="")
				{
					model.StoreGroupID=int.Parse(ds.Tables[0].Rows[0]["StoreGroupID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankID"]!=null && ds.Tables[0].Rows[0]["BankID"].ToString()!="")
				{
					model.BankID=int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreCountry"]!=null && ds.Tables[0].Rows[0]["StoreCountry"].ToString()!="")
				{
					model.StoreCountry=ds.Tables[0].Rows[0]["StoreCountry"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreProvince"]!=null && ds.Tables[0].Rows[0]["StoreProvince"].ToString()!="")
				{
					model.StoreProvince=ds.Tables[0].Rows[0]["StoreProvince"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCity"]!=null && ds.Tables[0].Rows[0]["StoreCity"].ToString()!="")
				{
					model.StoreCity=ds.Tables[0].Rows[0]["StoreCity"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreAddressDetail"]!=null && ds.Tables[0].Rows[0]["StoreAddressDetail"].ToString()!="")
				{
					model.StoreAddressDetail=ds.Tables[0].Rows[0]["StoreAddressDetail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreTel"]!=null && ds.Tables[0].Rows[0]["StoreTel"].ToString()!="")
				{
					model.StoreTel=ds.Tables[0].Rows[0]["StoreTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFax"]!=null && ds.Tables[0].Rows[0]["StoreFax"].ToString()!="")
				{
					model.StoreFax=ds.Tables[0].Rows[0]["StoreFax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreLongitude"]!=null && ds.Tables[0].Rows[0]["StoreLongitude"].ToString()!="")
				{
					model.StoreLongitude=ds.Tables[0].Rows[0]["StoreLongitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreLatitude"]!=null && ds.Tables[0].Rows[0]["StoreLatitude"].ToString()!="")
				{
					model.StoreLatitude=ds.Tables[0].Rows[0]["StoreLatitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LocationID"]!=null && ds.Tables[0].Rows[0]["LocationID"].ToString()!="")
				{
					model.LocationID=int.Parse(ds.Tables[0].Rows[0]["LocationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreNote"]!=null && ds.Tables[0].Rows[0]["StoreNote"].ToString()!="")
				{
					model.StoreNote=ds.Tables[0].Rows[0]["StoreNote"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreOpenTime"]!=null && ds.Tables[0].Rows[0]["StoreOpenTime"].ToString()!="")
				{
					model.StoreOpenTime=ds.Tables[0].Rows[0]["StoreOpenTime"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCloseTime"]!=null && ds.Tables[0].Rows[0]["StoreCloseTime"].ToString()!="")
				{
					model.StoreCloseTime=ds.Tables[0].Rows[0]["StoreCloseTime"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StorePicFile"]!=null && ds.Tables[0].Rows[0]["StorePicFile"].ToString()!="")
				{
					model.StorePicFile=ds.Tables[0].Rows[0]["StorePicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MapsPicFile"]!=null && ds.Tables[0].Rows[0]["MapsPicFile"].ToString()!="")
				{
					model.MapsPicFile=ds.Tables[0].Rows[0]["MapsPicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MapsPicShadowFile"]!=null && ds.Tables[0].Rows[0]["MapsPicShadowFile"].ToString()!="")
				{
					model.MapsPicShadowFile=ds.Tables[0].Rows[0]["MapsPicShadowFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactPhone"]!=null && ds.Tables[0].Rows[0]["ContactPhone"].ToString()!="")
				{
					model.ContactPhone=ds.Tables[0].Rows[0]["ContactPhone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreDistrict"]!=null && ds.Tables[0].Rows[0]["StoreDistrict"].ToString()!="")
				{
					model.StoreDistrict=ds.Tables[0].Rows[0]["StoreDistrict"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFullDetail"]!=null && ds.Tables[0].Rows[0]["StoreFullDetail"].ToString()!="")
				{
					model.StoreFullDetail=ds.Tables[0].Rows[0]["StoreFullDetail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreAddressDetail2"]!=null && ds.Tables[0].Rows[0]["StoreAddressDetail2"].ToString()!="")
				{
					model.StoreAddressDetail2=ds.Tables[0].Rows[0]["StoreAddressDetail2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFullDetail2"]!=null && ds.Tables[0].Rows[0]["StoreFullDetail2"].ToString()!="")
				{
					model.StoreFullDetail2=ds.Tables[0].Rows[0]["StoreFullDetail2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreAddressDetail3"]!=null && ds.Tables[0].Rows[0]["StoreAddressDetail3"].ToString()!="")
				{
					model.StoreAddressDetail3=ds.Tables[0].Rows[0]["StoreAddressDetail3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFullDetail3"]!=null && ds.Tables[0].Rows[0]["StoreFullDetail3"].ToString()!="")
				{
					model.StoreFullDetail3=ds.Tables[0].Rows[0]["StoreFullDetail3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreID,StoreCode,StoreName1,StoreName2,StoreName3,StoreTypeID,StoreGroupID,BankID,StoreCountry,StoreProvince,StoreCity,StoreAddressDetail,StoreTel,StoreFax,StoreLongitude,StoreLatitude,LocationID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreNote,StoreOpenTime,StoreCloseTime,BrandID,StorePicFile,MapsPicFile,MapsPicShadowFile,Email,Contact,ContactPhone,StoreDistrict,StoreFullDetail,StoreAddressDetail2,StoreFullDetail2,StoreAddressDetail3,StoreFullDetail3,Status ");
			strSql.Append(" FROM Store ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" StoreID,StoreCode,StoreName1,StoreName2,StoreName3,StoreTypeID,StoreGroupID,BankID,StoreCountry,StoreProvince,StoreCity,StoreAddressDetail,StoreTel,StoreFax,StoreLongitude,StoreLatitude,LocationID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreNote,StoreOpenTime,StoreCloseTime,BrandID,StorePicFile,MapsPicFile,MapsPicShadowFile,Email,Contact,ContactPhone,StoreDistrict,StoreFullDetail,StoreAddressDetail2,StoreFullDetail2,StoreAddressDetail3,StoreFullDetail3,Status ");
			strSql.Append(" FROM Store ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Store ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StoreID desc");
			}
			strSql.Append(")AS Row, T.*  from Store T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Store";
			parameters[1].Value = "StoreID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

