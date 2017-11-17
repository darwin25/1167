using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_STORE
	/// </summary>
	public partial class BUY_STORE:IBUY_STORE
	{
		public BUY_STORE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StoreID", "BUY_STORE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StoreCode,int StoreID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_STORE");
			strSql.Append(" where StoreCode=@StoreCode and StoreID=@StoreID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreID", SqlDbType.Int,4)			};
			parameters[0].Value = StoreCode;
			parameters[1].Value = StoreID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public int GetStoreIDByUser(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StoreID  from RelationUserStore");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64)
						};
            parameters[0].Value = UserName;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_STORE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_STORE(");
            strSql.Append("StoreCode,Status,StoreName1,StoreName2,StoreName3,StoreTypeID,BankCode,StoreBrandCode,StoreCountry,StoreProvince,StoreCity,StoreDistrict,StoreAddressDetail1,StoreAddressDetail2,StoreAddressDetail3,StoreFullDetail1,StoreFullDetail2,StoreFullDetail3,StoreTel,StoreFax,StoreEmail,Contact,ContactPhone,StoreLongitude,StoreLatitude,StorePicFile,MapsPicFile,MapsPicShadowFile,LocationCode,StoreNote,StoreOpenTime,StoreCloseTime,Comparable,GLCode,RegionCode,OrgCode,StoreIP,SubInvCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
            strSql.Append("@StoreCode,@Status,@StoreName1,@StoreName2,@StoreName3,@StoreTypeID,@BankCode,@StoreBrandCode,@StoreCountry,@StoreProvince,@StoreCity,@StoreDistrict,@StoreAddressDetail1,@StoreAddressDetail2,@StoreAddressDetail3,@StoreFullDetail1,@StoreFullDetail2,@StoreFullDetail3,@StoreTel,@StoreFax,@StoreEmail,@Contact,@ContactPhone,@StoreLongitude,@StoreLatitude,@StorePicFile,@MapsPicFile,@MapsPicShadowFile,@LocationCode,@StoreNote,@StoreOpenTime,@StoreCloseTime,@Comparable,@GLCode,@RegionCode,@OrgCode,@StoreIP,@SubInvCode,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StoreName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4),
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCountry", SqlDbType.VarChar,64),
					new SqlParameter("@StoreProvince", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCity", SqlDbType.VarChar,64),
					new SqlParameter("@StoreDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@StoreAddressDetail1", SqlDbType.VarChar,512),
					new SqlParameter("@StoreAddressDetail2", SqlDbType.VarChar,512),
					new SqlParameter("@StoreAddressDetail3", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFullDetail1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreFullDetail2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreFullDetail3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTel", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFax", SqlDbType.VarChar,512),
					new SqlParameter("@StoreEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreLongitude", SqlDbType.VarChar,512),
					new SqlParameter("@StoreLatitude", SqlDbType.VarChar,512),
					new SqlParameter("@StorePicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicShadowFile", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationCode", SqlDbType.Int,4),
					new SqlParameter("@StoreNote", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreOpenTime", SqlDbType.VarChar,512),
					new SqlParameter("@StoreCloseTime", SqlDbType.VarChar,512),
					new SqlParameter("@Comparable", SqlDbType.Int,4),
					new SqlParameter("@GLCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegionCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrgCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreIP", SqlDbType.VarChar,64),
					new SqlParameter("@SubInvCode", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.Status;
			parameters[2].Value = model.StoreName1;
			parameters[3].Value = model.StoreName2;
			parameters[4].Value = model.StoreName3;
			parameters[5].Value = model.StoreTypeID;
			parameters[6].Value = model.BankCode;
			parameters[7].Value = model.StoreBrandCode;
			parameters[8].Value = model.StoreCountry;
			parameters[9].Value = model.StoreProvince;
			parameters[10].Value = model.StoreCity;
			parameters[11].Value = model.StoreDistrict;
			parameters[12].Value = model.StoreAddressDetail1;
			parameters[13].Value = model.StoreAddressDetail2;
			parameters[14].Value = model.StoreAddressDetail3;
			parameters[15].Value = model.StoreFullDetail1;
			parameters[16].Value = model.StoreFullDetail2;
			parameters[17].Value = model.StoreFullDetail3;
			parameters[18].Value = model.StoreTel;
			parameters[19].Value = model.StoreFax;
			parameters[20].Value = model.StoreEmail;
			parameters[21].Value = model.Contact;
			parameters[22].Value = model.ContactPhone;
			parameters[23].Value = model.StoreLongitude;
			parameters[24].Value = model.StoreLatitude;
			parameters[25].Value = model.StorePicFile;
			parameters[26].Value = model.MapsPicFile;
			parameters[27].Value = model.MapsPicShadowFile;
			parameters[28].Value = model.LocationCode;
			parameters[29].Value = model.StoreNote;
			parameters[30].Value = model.StoreOpenTime;
			parameters[31].Value = model.StoreCloseTime;
			parameters[32].Value = model.Comparable;
			parameters[33].Value = model.GLCode;
			parameters[34].Value = model.RegionCode;
			parameters[35].Value = model.OrgCode;
			parameters[36].Value = model.StoreIP;
			parameters[37].Value = model.SubInvCode;
			parameters[38].Value = model.CreatedOn;
			parameters[39].Value = model.CreatedBy;
			parameters[40].Value = model.UpdatedOn;
			parameters[41].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_STORE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_STORE set ");
			strSql.Append("Status=@Status,");
			strSql.Append("StoreName1=@StoreName1,");
			strSql.Append("StoreName2=@StoreName2,");
			strSql.Append("StoreName3=@StoreName3,");
			strSql.Append("StoreTypeID=@StoreTypeID,");
			strSql.Append("BankCode=@BankCode,");
            strSql.Append("StoreBrandCode=@StoreBrandCode,");
			strSql.Append("StoreCountry=@StoreCountry,");
			strSql.Append("StoreProvince=@StoreProvince,");
			strSql.Append("StoreCity=@StoreCity,");
			strSql.Append("StoreDistrict=@StoreDistrict,");
			strSql.Append("StoreAddressDetail1=@StoreAddressDetail1,");
			strSql.Append("StoreAddressDetail2=@StoreAddressDetail2,");
			strSql.Append("StoreAddressDetail3=@StoreAddressDetail3,");
			strSql.Append("StoreFullDetail1=@StoreFullDetail1,");
			strSql.Append("StoreFullDetail2=@StoreFullDetail2,");
			strSql.Append("StoreFullDetail3=@StoreFullDetail3,");
			strSql.Append("StoreTel=@StoreTel,");
			strSql.Append("StoreFax=@StoreFax,");
			strSql.Append("StoreEmail=@StoreEmail,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("ContactPhone=@ContactPhone,");
			strSql.Append("StoreLongitude=@StoreLongitude,");
			strSql.Append("StoreLatitude=@StoreLatitude,");
			strSql.Append("StorePicFile=@StorePicFile,");
			strSql.Append("MapsPicFile=@MapsPicFile,");
			strSql.Append("MapsPicShadowFile=@MapsPicShadowFile,");
			strSql.Append("LocationCode=@LocationCode,");
			strSql.Append("StoreNote=@StoreNote,");
			strSql.Append("StoreOpenTime=@StoreOpenTime,");
			strSql.Append("StoreCloseTime=@StoreCloseTime,");
			strSql.Append("Comparable=@Comparable,");
			strSql.Append("GLCode=@GLCode,");
			strSql.Append("RegionCode=@RegionCode,");
			strSql.Append("OrgCode=@OrgCode,");
			strSql.Append("StoreIP=@StoreIP,");
			strSql.Append("SubInvCode=@SubInvCode,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StoreID=@StoreID");
			SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StoreName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreName3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4),
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCountry", SqlDbType.VarChar,64),
					new SqlParameter("@StoreProvince", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCity", SqlDbType.VarChar,64),
					new SqlParameter("@StoreDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@StoreAddressDetail1", SqlDbType.VarChar,512),
					new SqlParameter("@StoreAddressDetail2", SqlDbType.VarChar,512),
					new SqlParameter("@StoreAddressDetail3", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFullDetail1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreFullDetail2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreFullDetail3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTel", SqlDbType.VarChar,512),
					new SqlParameter("@StoreFax", SqlDbType.VarChar,512),
					new SqlParameter("@StoreEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreLongitude", SqlDbType.VarChar,512),
					new SqlParameter("@StoreLatitude", SqlDbType.VarChar,512),
					new SqlParameter("@StorePicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MapsPicShadowFile", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationCode", SqlDbType.Int,4),
					new SqlParameter("@StoreNote", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreOpenTime", SqlDbType.VarChar,512),
					new SqlParameter("@StoreCloseTime", SqlDbType.VarChar,512),
					new SqlParameter("@Comparable", SqlDbType.Int,4),
					new SqlParameter("@GLCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegionCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrgCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreIP", SqlDbType.VarChar,64),
					new SqlParameter("@SubInvCode", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Status;
			parameters[1].Value = model.StoreName1;
			parameters[2].Value = model.StoreName2;
			parameters[3].Value = model.StoreName3;
			parameters[4].Value = model.StoreTypeID;
			parameters[5].Value = model.BankCode;
			parameters[6].Value = model.StoreBrandCode;
			parameters[7].Value = model.StoreCountry;
			parameters[8].Value = model.StoreProvince;
			parameters[9].Value = model.StoreCity;
			parameters[10].Value = model.StoreDistrict;
			parameters[11].Value = model.StoreAddressDetail1;
			parameters[12].Value = model.StoreAddressDetail2;
			parameters[13].Value = model.StoreAddressDetail3;
			parameters[14].Value = model.StoreFullDetail1;
			parameters[15].Value = model.StoreFullDetail2;
			parameters[16].Value = model.StoreFullDetail3;
			parameters[17].Value = model.StoreTel;
			parameters[18].Value = model.StoreFax;
			parameters[19].Value = model.StoreEmail;
			parameters[20].Value = model.Contact;
			parameters[21].Value = model.ContactPhone;
			parameters[22].Value = model.StoreLongitude;
			parameters[23].Value = model.StoreLatitude;
			parameters[24].Value = model.StorePicFile;
			parameters[25].Value = model.MapsPicFile;
			parameters[26].Value = model.MapsPicShadowFile;
			parameters[27].Value = model.LocationCode;
			parameters[28].Value = model.StoreNote;
			parameters[29].Value = model.StoreOpenTime;
			parameters[30].Value = model.StoreCloseTime;
			parameters[31].Value = model.Comparable;
			parameters[32].Value = model.GLCode;
			parameters[33].Value = model.RegionCode;
			parameters[34].Value = model.OrgCode;
			parameters[35].Value = model.StoreIP;
			parameters[36].Value = model.SubInvCode;
			parameters[37].Value = model.CreatedOn;
			parameters[38].Value = model.CreatedBy;
			parameters[39].Value = model.UpdatedOn;
			parameters[40].Value = model.UpdatedBy;
			parameters[41].Value = model.StoreID;
			parameters[42].Value = model.StoreCode;

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
			strSql.Append("delete from BUY_STORE ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StoreCode,int StoreID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STORE ");
			strSql.Append(" where StoreCode=@StoreCode and StoreID=@StoreID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreID", SqlDbType.Int,4)			};
			parameters[0].Value = StoreCode;
			parameters[1].Value = StoreID;

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
			strSql.Append("delete from BUY_STORE ");
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
		public Edge.SVA.Model.BUY_STORE GetModel(int StoreID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 StoreID,StoreCode,Status,StoreName1,StoreName2,StoreName3,StoreTypeID,BankCode,StoreBrandCode,StoreCountry,StoreProvince,StoreCity,StoreDistrict,StoreAddressDetail1,StoreAddressDetail2,StoreAddressDetail3,StoreFullDetail1,StoreFullDetail2,StoreFullDetail3,StoreTel,StoreFax,StoreEmail,Contact,ContactPhone,StoreLongitude,StoreLatitude,StorePicFile,MapsPicFile,MapsPicShadowFile,LocationCode,StoreNote,StoreOpenTime,StoreCloseTime,Comparable,GLCode,RegionCode,OrgCode,StoreIP,SubInvCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_STORE ");
			strSql.Append(" where StoreID=@StoreID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreID;

			Edge.SVA.Model.BUY_STORE model=new Edge.SVA.Model.BUY_STORE();
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
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
				if(ds.Tables[0].Rows[0]["BankCode"]!=null && ds.Tables[0].Rows[0]["BankCode"].ToString()!="")
				{
					model.BankCode=ds.Tables[0].Rows[0]["BankCode"].ToString();
				}
                if (ds.Tables[0].Rows[0]["StoreBrandCode"] != null && ds.Tables[0].Rows[0]["StoreBrandCode"].ToString() != "")
				{
                    model.StoreBrandCode = ds.Tables[0].Rows[0]["StoreBrandCode"].ToString();
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
				if(ds.Tables[0].Rows[0]["StoreDistrict"]!=null && ds.Tables[0].Rows[0]["StoreDistrict"].ToString()!="")
				{
					model.StoreDistrict=ds.Tables[0].Rows[0]["StoreDistrict"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreAddressDetail1"]!=null && ds.Tables[0].Rows[0]["StoreAddressDetail1"].ToString()!="")
				{
					model.StoreAddressDetail1=ds.Tables[0].Rows[0]["StoreAddressDetail1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreAddressDetail2"]!=null && ds.Tables[0].Rows[0]["StoreAddressDetail2"].ToString()!="")
				{
					model.StoreAddressDetail2=ds.Tables[0].Rows[0]["StoreAddressDetail2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreAddressDetail3"]!=null && ds.Tables[0].Rows[0]["StoreAddressDetail3"].ToString()!="")
				{
					model.StoreAddressDetail3=ds.Tables[0].Rows[0]["StoreAddressDetail3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFullDetail1"]!=null && ds.Tables[0].Rows[0]["StoreFullDetail1"].ToString()!="")
				{
					model.StoreFullDetail1=ds.Tables[0].Rows[0]["StoreFullDetail1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFullDetail2"]!=null && ds.Tables[0].Rows[0]["StoreFullDetail2"].ToString()!="")
				{
					model.StoreFullDetail2=ds.Tables[0].Rows[0]["StoreFullDetail2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFullDetail3"]!=null && ds.Tables[0].Rows[0]["StoreFullDetail3"].ToString()!="")
				{
					model.StoreFullDetail3=ds.Tables[0].Rows[0]["StoreFullDetail3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreTel"]!=null && ds.Tables[0].Rows[0]["StoreTel"].ToString()!="")
				{
					model.StoreTel=ds.Tables[0].Rows[0]["StoreTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreFax"]!=null && ds.Tables[0].Rows[0]["StoreFax"].ToString()!="")
				{
					model.StoreFax=ds.Tables[0].Rows[0]["StoreFax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreEmail"]!=null && ds.Tables[0].Rows[0]["StoreEmail"].ToString()!="")
				{
					model.StoreEmail=ds.Tables[0].Rows[0]["StoreEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactPhone"]!=null && ds.Tables[0].Rows[0]["ContactPhone"].ToString()!="")
				{
					model.ContactPhone=ds.Tables[0].Rows[0]["ContactPhone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreLongitude"]!=null && ds.Tables[0].Rows[0]["StoreLongitude"].ToString()!="")
				{
					model.StoreLongitude=ds.Tables[0].Rows[0]["StoreLongitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreLatitude"]!=null && ds.Tables[0].Rows[0]["StoreLatitude"].ToString()!="")
				{
					model.StoreLatitude=ds.Tables[0].Rows[0]["StoreLatitude"].ToString();
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
				if(ds.Tables[0].Rows[0]["LocationCode"]!=null && ds.Tables[0].Rows[0]["LocationCode"].ToString()!="")
				{
					model.LocationCode=int.Parse(ds.Tables[0].Rows[0]["LocationCode"].ToString());
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
				if(ds.Tables[0].Rows[0]["Comparable"]!=null && ds.Tables[0].Rows[0]["Comparable"].ToString()!="")
				{
					model.Comparable=int.Parse(ds.Tables[0].Rows[0]["Comparable"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GLCode"]!=null && ds.Tables[0].Rows[0]["GLCode"].ToString()!="")
				{
					model.GLCode=ds.Tables[0].Rows[0]["GLCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegionCode"]!=null && ds.Tables[0].Rows[0]["RegionCode"].ToString()!="")
				{
					model.RegionCode=ds.Tables[0].Rows[0]["RegionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrgCode"]!=null && ds.Tables[0].Rows[0]["OrgCode"].ToString()!="")
				{
					model.OrgCode=ds.Tables[0].Rows[0]["OrgCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreIP"]!=null && ds.Tables[0].Rows[0]["StoreIP"].ToString()!="")
				{
					model.StoreIP=ds.Tables[0].Rows[0]["StoreIP"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SubInvCode"]!=null && ds.Tables[0].Rows[0]["SubInvCode"].ToString()!="")
				{
					model.SubInvCode=ds.Tables[0].Rows[0]["SubInvCode"].ToString();
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
				return model;
			}
			else
			{
				return null;
			}
		}
       
        /// <summary>
        /// 根据编号得到名字
        /// 创建人:LISA
        /// 创建时间：201-06-02
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Edge.SVA.Model.BUY_STORE GetStoreByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreID,StoreCode,Status,StoreName1,StoreName2,StoreName3,StoreTypeID,BankCode,StoreBrandCode,StoreCountry,StoreProvince,StoreCity,StoreDistrict,StoreAddressDetail1,StoreAddressDetail2,StoreAddressDetail3,StoreFullDetail1,StoreFullDetail2,StoreFullDetail3,StoreTel,StoreFax,StoreEmail,Contact,ContactPhone,StoreLongitude,StoreLatitude,StorePicFile,MapsPicFile,MapsPicShadowFile,LocationCode,StoreNote,StoreOpenTime,StoreCloseTime,Comparable,GLCode,RegionCode,OrgCode,StoreIP,SubInvCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_STORE ");
            strSql.Append(" where StoreCode=@StoreCode");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64)
			};
            parameters[0].Value = code;

            Edge.SVA.Model.BUY_STORE model = new Edge.SVA.Model.BUY_STORE();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StoreID"] != null && ds.Tables[0].Rows[0]["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreCode"] != null && ds.Tables[0].Rows[0]["StoreCode"].ToString() != "")
                {
                    model.StoreCode = ds.Tables[0].Rows[0]["StoreCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreName1"] != null && ds.Tables[0].Rows[0]["StoreName1"].ToString() != "")
                {
                    model.StoreName1 = ds.Tables[0].Rows[0]["StoreName1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreName2"] != null && ds.Tables[0].Rows[0]["StoreName2"].ToString() != "")
                {
                    model.StoreName2 = ds.Tables[0].Rows[0]["StoreName2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreName3"] != null && ds.Tables[0].Rows[0]["StoreName3"].ToString() != "")
                {
                    model.StoreName3 = ds.Tables[0].Rows[0]["StoreName3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreTypeID"] != null && ds.Tables[0].Rows[0]["StoreTypeID"].ToString() != "")
                {
                    model.StoreTypeID = int.Parse(ds.Tables[0].Rows[0]["StoreTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankCode"] != null && ds.Tables[0].Rows[0]["BankCode"].ToString() != "")
                {
                    model.BankCode = ds.Tables[0].Rows[0]["BankCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreBrandCode"] != null && ds.Tables[0].Rows[0]["StoreBrandCode"].ToString() != "")
                {
                    model.StoreBrandCode = ds.Tables[0].Rows[0]["StoreBrandCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreCountry"] != null && ds.Tables[0].Rows[0]["StoreCountry"].ToString() != "")
                {
                    model.StoreCountry = ds.Tables[0].Rows[0]["StoreCountry"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreProvince"] != null && ds.Tables[0].Rows[0]["StoreProvince"].ToString() != "")
                {
                    model.StoreProvince = ds.Tables[0].Rows[0]["StoreProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreCity"] != null && ds.Tables[0].Rows[0]["StoreCity"].ToString() != "")
                {
                    model.StoreCity = ds.Tables[0].Rows[0]["StoreCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreDistrict"] != null && ds.Tables[0].Rows[0]["StoreDistrict"].ToString() != "")
                {
                    model.StoreDistrict = ds.Tables[0].Rows[0]["StoreDistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreAddressDetail1"] != null && ds.Tables[0].Rows[0]["StoreAddressDetail1"].ToString() != "")
                {
                    model.StoreAddressDetail1 = ds.Tables[0].Rows[0]["StoreAddressDetail1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreAddressDetail2"] != null && ds.Tables[0].Rows[0]["StoreAddressDetail2"].ToString() != "")
                {
                    model.StoreAddressDetail2 = ds.Tables[0].Rows[0]["StoreAddressDetail2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreAddressDetail3"] != null && ds.Tables[0].Rows[0]["StoreAddressDetail3"].ToString() != "")
                {
                    model.StoreAddressDetail3 = ds.Tables[0].Rows[0]["StoreAddressDetail3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreFullDetail1"] != null && ds.Tables[0].Rows[0]["StoreFullDetail1"].ToString() != "")
                {
                    model.StoreFullDetail1 = ds.Tables[0].Rows[0]["StoreFullDetail1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreFullDetail2"] != null && ds.Tables[0].Rows[0]["StoreFullDetail2"].ToString() != "")
                {
                    model.StoreFullDetail2 = ds.Tables[0].Rows[0]["StoreFullDetail2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreFullDetail3"] != null && ds.Tables[0].Rows[0]["StoreFullDetail3"].ToString() != "")
                {
                    model.StoreFullDetail3 = ds.Tables[0].Rows[0]["StoreFullDetail3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreTel"] != null && ds.Tables[0].Rows[0]["StoreTel"].ToString() != "")
                {
                    model.StoreTel = ds.Tables[0].Rows[0]["StoreTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreFax"] != null && ds.Tables[0].Rows[0]["StoreFax"].ToString() != "")
                {
                    model.StoreFax = ds.Tables[0].Rows[0]["StoreFax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreEmail"] != null && ds.Tables[0].Rows[0]["StoreEmail"].ToString() != "")
                {
                    model.StoreEmail = ds.Tables[0].Rows[0]["StoreEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contact"] != null && ds.Tables[0].Rows[0]["Contact"].ToString() != "")
                {
                    model.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContactPhone"] != null && ds.Tables[0].Rows[0]["ContactPhone"].ToString() != "")
                {
                    model.ContactPhone = ds.Tables[0].Rows[0]["ContactPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreLongitude"] != null && ds.Tables[0].Rows[0]["StoreLongitude"].ToString() != "")
                {
                    model.StoreLongitude = ds.Tables[0].Rows[0]["StoreLongitude"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreLatitude"] != null && ds.Tables[0].Rows[0]["StoreLatitude"].ToString() != "")
                {
                    model.StoreLatitude = ds.Tables[0].Rows[0]["StoreLatitude"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StorePicFile"] != null && ds.Tables[0].Rows[0]["StorePicFile"].ToString() != "")
                {
                    model.StorePicFile = ds.Tables[0].Rows[0]["StorePicFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MapsPicFile"] != null && ds.Tables[0].Rows[0]["MapsPicFile"].ToString() != "")
                {
                    model.MapsPicFile = ds.Tables[0].Rows[0]["MapsPicFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MapsPicShadowFile"] != null && ds.Tables[0].Rows[0]["MapsPicShadowFile"].ToString() != "")
                {
                    model.MapsPicShadowFile = ds.Tables[0].Rows[0]["MapsPicShadowFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LocationCode"] != null && ds.Tables[0].Rows[0]["LocationCode"].ToString() != "")
                {
                    model.LocationCode = int.Parse(ds.Tables[0].Rows[0]["LocationCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreNote"] != null && ds.Tables[0].Rows[0]["StoreNote"].ToString() != "")
                {
                    model.StoreNote = ds.Tables[0].Rows[0]["StoreNote"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreOpenTime"] != null && ds.Tables[0].Rows[0]["StoreOpenTime"].ToString() != "")
                {
                    model.StoreOpenTime = ds.Tables[0].Rows[0]["StoreOpenTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreCloseTime"] != null && ds.Tables[0].Rows[0]["StoreCloseTime"].ToString() != "")
                {
                    model.StoreCloseTime = ds.Tables[0].Rows[0]["StoreCloseTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Comparable"] != null && ds.Tables[0].Rows[0]["Comparable"].ToString() != "")
                {
                    model.Comparable = int.Parse(ds.Tables[0].Rows[0]["Comparable"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GLCode"] != null && ds.Tables[0].Rows[0]["GLCode"].ToString() != "")
                {
                    model.GLCode = ds.Tables[0].Rows[0]["GLCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegionCode"] != null && ds.Tables[0].Rows[0]["RegionCode"].ToString() != "")
                {
                    model.RegionCode = ds.Tables[0].Rows[0]["RegionCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrgCode"] != null && ds.Tables[0].Rows[0]["OrgCode"].ToString() != "")
                {
                    model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreIP"] != null && ds.Tables[0].Rows[0]["StoreIP"].ToString() != "")
                {
                    model.StoreIP = ds.Tables[0].Rows[0]["StoreIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SubInvCode"] != null && ds.Tables[0].Rows[0]["SubInvCode"].ToString() != "")
                {
                    model.SubInvCode = ds.Tables[0].Rows[0]["SubInvCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedOn"] != null && ds.Tables[0].Rows[0]["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBy"] != null && ds.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedOn"] != null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedBy"] != null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
            strSql.Append("select StoreID,StoreCode,Status,StoreName1,StoreName2,StoreName3,StoreTypeID,BankCode,StoreBrandCode,StoreCountry,StoreProvince,StoreCity,StoreDistrict,StoreAddressDetail1,StoreAddressDetail2,StoreAddressDetail3,StoreFullDetail1,StoreFullDetail2,StoreFullDetail3,StoreTel,StoreFax,StoreEmail,Contact,ContactPhone,StoreLongitude,StoreLatitude,StorePicFile,MapsPicFile,MapsPicShadowFile,LocationCode,StoreNote,StoreOpenTime,StoreCloseTime,Comparable,GLCode,RegionCode,OrgCode,StoreIP,SubInvCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");            
			strSql.Append(" FROM BUY_STORE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
                //strSql.Append(" where StoreTypeID=1 order by StoreCode");
                
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
            strSql.Append(" StoreID,StoreCode,Status,StoreName1,StoreName2,StoreName3,StoreTypeID,BankCode,StoreBrandCode,StoreCountry,StoreProvince,StoreCity,StoreDistrict,StoreAddressDetail1,StoreAddressDetail2,StoreAddressDetail3,StoreFullDetail1,StoreFullDetail2,StoreFullDetail3,StoreTel,StoreFax,StoreEmail,Contact,ContactPhone,StoreLongitude,StoreLatitude,StorePicFile,MapsPicFile,MapsPicShadowFile,LocationCode,StoreNote,StoreOpenTime,StoreCloseTime,Comparable,GLCode,RegionCode,OrgCode,StoreIP,SubInvCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");            
			strSql.Append(" FROM BUY_STORE ");
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
			strSql.Append("select count(1) FROM BUY_STORE ");
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
			strSql.Append(")AS Row, T.*  from BUY_STORE T ");
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
			parameters[0].Value = "BUY_STORE";
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

