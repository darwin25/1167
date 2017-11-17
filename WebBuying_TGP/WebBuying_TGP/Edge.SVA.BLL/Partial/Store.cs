using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
    public partial class Store
    {
        private string SessionChangeBrandIDsStr(string strWhere)
        {
            string str = SessionInfo.BrandIDsStr;
            if (!String.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = " BrandID in " + str;
                }
                else
                {
                    string[] strs = SqlWhereUtil.SplitStringByOrderBy(strWhere);
                    if (strs.Length <= 1)
                    {
                        strWhere = strWhere + " and BrandID in " + str;
                    }
                    else
                    {
                        strWhere = strs[0] + " and BrandID in " + str + strs[1];
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = " 1=1 ";
                }
                else
                {
                    string[] strs = SqlWhereUtil.SplitStringByOrderBy(strWhere);
                    if (strs.Length <= 1)
                    {
                        strWhere = strWhere + " and 1=1 ";
                    }
                    else
                    {
                        strWhere = strs[0] + " and 1=1 " + strs[1];
                    }
                }
            }
            return strWhere;
        }

        /// <summary>
        /// 获取总页数不加权限
        /// </summary>
        public int GetCountUnlimited(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public Edge.SVA.Model.Store GetModelByCode(string storeCode)
        {
            List<SVA.Model.Store> stores = new SVA.BLL.Store().GetModelList(string.Format("StoreCode='{0}'", Common.WebCommon.No_SqlHack(storeCode)));
            if (stores == null || stores.Count <= 0) return null;

            return stores[0];
        }

        public DataSet GetStores(int brandID)
        {
            return dal.GetList(" BrandID = " + brandID);
        }

        public bool Exists(string storecode,int brandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Store");
            strSql.Append(" where StoreCode=@StoreCode and BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
                    new SqlParameter("@BrandID", SqlDbType.Int,4),
			};
            parameters[0].Value = storecode;
            parameters[1].Value = brandID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string storecode, int brandID,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Store");
            strSql.Append(" where StoreCode=@StoreCode and BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
                    new SqlParameter("@BrandID", SqlDbType.Int,4),
			};
            parameters[0].Value = storecode;
            parameters[1].Value = brandID;

            object id = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
            if (Convert.ToInt32(id) > 0)
            {
                return true;
            }
            return false;
        }

        public void OpenCloseTrigger(string strSql, SqlTransaction trans)
        {
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);//执行多个不同的DAL
        }

        public int ImportAdd(Edge.SVA.Model.Store model,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
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

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            //添加主表时需要返回主键ID
            object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

            return Convert.ToInt32(id);
        }

        public void ImportUpdate(Edge.SVA.Model.Store model,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
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
            strSql.Append(" where StoreCode=@StoreCode and BrandID=@BrandID");
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

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }

        public void ImportDelete(string StoreCode,int BrandID,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Store ");
            strSql.Append(" where StoreCode=@StoreCode and BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
                    new SqlParameter("@BrandID", SqlDbType.Int,4)
			};
            parameters[0].Value = StoreCode;
            parameters[1].Value = BrandID;

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }
    }
}
