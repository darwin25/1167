using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Ord_TransInOrder_H
    /// </summary>
    public partial class Ord_TransInOrder_H : IOrd_TransInOrder_H
    {
        public Ord_TransInOrder_H()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TransInOrderNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ord_TransInOrder_H");
            strSql.Append(" where TransInOrderNumber=@TransInOrderNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransInOrderNumber", SqlDbType.VarChar,64)};
            parameters[0].Value = TransInOrderNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.Ord_TransInOrder_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ord_TransInOrder_H(");
            strSql.Append("TransInOrderNumber,ReferenceNo,FromStoreID,FromContactName,FromContactPhone,FromMobile,FromEmail,FromAddress,StoreID,StoreContactName,StoreContactPhone,StoreContactEmail,StoreMobile,StoreAddress,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
            strSql.Append(" values (");
            strSql.Append("@TransInOrderNumber,@ReferenceNo,@FromStoreID,@FromContactName,@FromContactPhone,@FromMobile,@FromEmail,@FromAddress,@StoreID,@StoreContactName,@StoreContactPhone,@StoreContactEmail,@StoreMobile,@StoreAddress,@Remark,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
            SqlParameter[] parameters = {
					new SqlParameter("@TransInOrderNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@FromStoreID", SqlDbType.Int,4),
					new SqlParameter("@FromContactName", SqlDbType.VarChar,100),
					new SqlParameter("@FromContactPhone", SqlDbType.VarChar,100),
					new SqlParameter("@FromMobile", SqlDbType.VarChar,100),
					new SqlParameter("@FromEmail", SqlDbType.VarChar,100),
					new SqlParameter("@FromAddress", SqlDbType.VarChar,512),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StoreContactName", SqlDbType.VarChar,100),
					new SqlParameter("@StoreContactPhone", SqlDbType.VarChar,100),
					new SqlParameter("@StoreContactEmail", SqlDbType.VarChar,100),
					new SqlParameter("@StoreMobile", SqlDbType.VarChar,100),
					new SqlParameter("@StoreAddress", SqlDbType.VarChar,512),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
            parameters[0].Value = model.TransInOrderNumber;
            parameters[1].Value = model.ReferenceNo;
            parameters[2].Value = model.FromStoreID;
            parameters[3].Value = model.FromContactName;
            parameters[4].Value = model.FromContactPhone;
            parameters[5].Value = model.FromMobile;
            parameters[6].Value = model.FromEmail;
            parameters[7].Value = model.FromAddress;
            parameters[8].Value = model.StoreID;
            parameters[9].Value = model.StoreContactName;
            parameters[10].Value = model.StoreContactPhone;
            parameters[11].Value = model.StoreContactEmail;
            parameters[12].Value = model.StoreMobile;
            parameters[13].Value = model.StoreAddress;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.CreatedBusDate;
            parameters[16].Value = model.ApproveBusDate;
            parameters[17].Value = model.ApprovalCode;
            parameters[18].Value = model.ApproveStatus;
            parameters[19].Value = model.ApproveOn;
            parameters[20].Value = model.ApproveBy;
            parameters[21].Value = model.CreatedOn;
            parameters[22].Value = model.CreatedBy;
            parameters[23].Value = model.UpdatedOn;
            parameters[24].Value = model.UpdatedBy;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.Ord_TransInOrder_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ord_TransInOrder_H set ");
            strSql.Append("ReferenceNo=@ReferenceNo,");
            strSql.Append("FromStoreID=@FromStoreID,");
            strSql.Append("FromContactName=@FromContactName,");
            strSql.Append("FromContactPhone=@FromContactPhone,");
            strSql.Append("FromMobile=@FromMobile,");
            strSql.Append("FromEmail=@FromEmail,");
            strSql.Append("FromAddress=@FromAddress,");
            strSql.Append("StoreID=@StoreID,");
            strSql.Append("StoreContactName=@StoreContactName,");
            strSql.Append("StoreContactPhone=@StoreContactPhone,");
            strSql.Append("StoreContactEmail=@StoreContactEmail,");
            strSql.Append("StoreMobile=@StoreMobile,");
            strSql.Append("StoreAddress=@StoreAddress,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreatedBusDate=@CreatedBusDate,");
            strSql.Append("ApproveBusDate=@ApproveBusDate,");
            strSql.Append("ApprovalCode=@ApprovalCode,");
            strSql.Append("ApproveStatus=@ApproveStatus,");
            strSql.Append("ApproveOn=@ApproveOn,");
            strSql.Append("ApproveBy=@ApproveBy,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy");
            strSql.Append(" where TransInOrderNumber=@TransInOrderNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@FromStoreID", SqlDbType.Int,4),
					new SqlParameter("@FromContactName", SqlDbType.VarChar,100),
					new SqlParameter("@FromContactPhone", SqlDbType.VarChar,100),
					new SqlParameter("@FromMobile", SqlDbType.VarChar,100),
					new SqlParameter("@FromEmail", SqlDbType.VarChar,100),
					new SqlParameter("@FromAddress", SqlDbType.VarChar,512),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StoreContactName", SqlDbType.VarChar,100),
					new SqlParameter("@StoreContactPhone", SqlDbType.VarChar,100),
					new SqlParameter("@StoreContactEmail", SqlDbType.VarChar,100),
					new SqlParameter("@StoreMobile", SqlDbType.VarChar,100),
					new SqlParameter("@StoreAddress", SqlDbType.VarChar,512),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@TransInOrderNumber", SqlDbType.VarChar,64)};
            parameters[0].Value = model.ReferenceNo;
            parameters[1].Value = model.FromStoreID;
            parameters[2].Value = model.FromContactName;
            parameters[3].Value = model.FromContactPhone;
            parameters[4].Value = model.FromMobile;
            parameters[5].Value = model.FromEmail;
            parameters[6].Value = model.FromAddress;
            parameters[7].Value = model.StoreID;
            parameters[8].Value = model.StoreContactName;
            parameters[9].Value = model.StoreContactPhone;
            parameters[10].Value = model.StoreContactEmail;
            parameters[11].Value = model.StoreMobile;
            parameters[12].Value = model.StoreAddress;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.CreatedBusDate;
            parameters[15].Value = model.ApproveBusDate;
            parameters[16].Value = model.ApprovalCode;
            parameters[17].Value = model.ApproveStatus;
            parameters[18].Value = model.ApproveOn;
            parameters[19].Value = model.ApproveBy;
            parameters[20].Value = model.CreatedOn;
            parameters[21].Value = model.CreatedBy;
            parameters[22].Value = model.UpdatedOn;
            parameters[23].Value = model.UpdatedBy;
            parameters[24].Value = model.TransInOrderNumber;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string TransInOrderNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ord_TransInOrder_H ");
            strSql.Append(" where TransInOrderNumber=@TransInOrderNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransInOrderNumber", SqlDbType.VarChar,64)};
            parameters[0].Value = TransInOrderNumber;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string TransInOrderNumberlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ord_TransInOrder_H ");
            strSql.Append(" where TransInOrderNumber in (" + TransInOrderNumberlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.Ord_TransInOrder_H GetModel(string TransInOrderNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TransInOrderNumber,ReferenceNo,FromStoreID,FromContactName,FromContactPhone,FromMobile,FromEmail,FromAddress,StoreID,StoreContactName,StoreContactPhone,StoreContactEmail,StoreMobile,StoreAddress,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Ord_TransInOrder_H ");
            strSql.Append(" where TransInOrderNumber=@TransInOrderNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransInOrderNumber", SqlDbType.VarChar,64)			};
            parameters[0].Value = TransInOrderNumber;

            Edge.SVA.Model.Ord_TransInOrder_H model = new Edge.SVA.Model.Ord_TransInOrder_H();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TransInOrderNumber"] != null && ds.Tables[0].Rows[0]["TransInOrderNumber"].ToString() != "")
                {
                    model.TransInOrderNumber = ds.Tables[0].Rows[0]["TransInOrderNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReferenceNo"] != null && ds.Tables[0].Rows[0]["ReferenceNo"].ToString() != "")
                {
                    model.ReferenceNo = ds.Tables[0].Rows[0]["ReferenceNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromStoreID"] != null && ds.Tables[0].Rows[0]["FromStoreID"].ToString() != "")
                {
                    model.FromStoreID = int.Parse(ds.Tables[0].Rows[0]["FromStoreID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FromContactName"] != null && ds.Tables[0].Rows[0]["FromContactName"].ToString() != "")
                {
                    model.FromContactName = ds.Tables[0].Rows[0]["FromContactName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromContactPhone"] != null && ds.Tables[0].Rows[0]["FromContactPhone"].ToString() != "")
                {
                    model.FromContactPhone = ds.Tables[0].Rows[0]["FromContactPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromMobile"] != null && ds.Tables[0].Rows[0]["FromMobile"].ToString() != "")
                {
                    model.FromMobile = ds.Tables[0].Rows[0]["FromMobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromEmail"] != null && ds.Tables[0].Rows[0]["FromEmail"].ToString() != "")
                {
                    model.FromEmail = ds.Tables[0].Rows[0]["FromEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromAddress"] != null && ds.Tables[0].Rows[0]["FromAddress"].ToString() != "")
                {
                    model.FromAddress = ds.Tables[0].Rows[0]["FromAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreID"] != null && ds.Tables[0].Rows[0]["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreContactName"] != null && ds.Tables[0].Rows[0]["StoreContactName"].ToString() != "")
                {
                    model.StoreContactName = ds.Tables[0].Rows[0]["StoreContactName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreContactPhone"] != null && ds.Tables[0].Rows[0]["StoreContactPhone"].ToString() != "")
                {
                    model.StoreContactPhone = ds.Tables[0].Rows[0]["StoreContactPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreContactEmail"] != null && ds.Tables[0].Rows[0]["StoreContactEmail"].ToString() != "")
                {
                    model.StoreContactEmail = ds.Tables[0].Rows[0]["StoreContactEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreMobile"] != null && ds.Tables[0].Rows[0]["StoreMobile"].ToString() != "")
                {
                    model.StoreMobile = ds.Tables[0].Rows[0]["StoreMobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StoreAddress"] != null && ds.Tables[0].Rows[0]["StoreAddress"].ToString() != "")
                {
                    model.StoreAddress = ds.Tables[0].Rows[0]["StoreAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedBusDate"] != null && ds.Tables[0].Rows[0]["CreatedBusDate"].ToString() != "")
                {
                    model.CreatedBusDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedBusDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApproveBusDate"] != null && ds.Tables[0].Rows[0]["ApproveBusDate"].ToString() != "")
                {
                    model.ApproveBusDate = DateTime.Parse(ds.Tables[0].Rows[0]["ApproveBusDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApprovalCode"] != null && ds.Tables[0].Rows[0]["ApprovalCode"].ToString() != "")
                {
                    model.ApprovalCode = ds.Tables[0].Rows[0]["ApprovalCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApproveStatus"] != null && ds.Tables[0].Rows[0]["ApproveStatus"].ToString() != "")
                {
                    model.ApproveStatus = ds.Tables[0].Rows[0]["ApproveStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApproveOn"] != null && ds.Tables[0].Rows[0]["ApproveOn"].ToString() != "")
                {
                    model.ApproveOn = DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApproveBy"] != null && ds.Tables[0].Rows[0]["ApproveBy"].ToString() != "")
                {
                    model.ApproveBy = int.Parse(ds.Tables[0].Rows[0]["ApproveBy"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TransInOrderNumber , ReferenceNo , FromStoreID , FromContactName , FromContactPhone , FromMobile , FromEmail , FromAddress , StoreID , StoreContactName , StoreContactPhone , StoreContactEmail , StoreMobile , StoreAddress  , Remark , CreatedBusDate , ApproveBusDate , ApprovalCode , ApproveStatus , ApproveOn , ApproveBy , CreatedOn , CreatedBy , UpdatedOn , UpdatedBy ");
            strSql.Append(" FROM Ord_TransInOrder_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" TransInOrderNumber , ReferenceNo , FromStoreID , FromContactName , FromContactPhone , FromMobile , FromEmail , FromAddress , StoreID , StoreContactName , StoreContactPhone , StoreContactEmail , StoreMobile , StoreAddress  , Remark , CreatedBusDate , ApproveBusDate , ApprovalCode , ApproveStatus , ApproveOn , ApproveBy , CreatedOn , CreatedBy , UpdatedOn , UpdatedBy ");
            strSql.Append(" FROM Ord_TransInOrder_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Ord_TransInOrder_H";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 1;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2016-03-29
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @WebSiteName nvarchar(20) ");
            strSql.AppendFormat(" set @WebSiteName='{0}'", webSiteName);
            strSql.Append("select Ord_TransInOrder_H.TransInOrderNumber,ReferenceNo,FromStoreID,FromContactName,FromContactPhone,");
            strSql.Append("FromMobile, FromEmail,FromAddress,Ord_TransInOrder_H.StoreID,StoreContactName,StoreContactPhone,");
            strSql.Append("StoreContactEmail,StoreMobile,StoreAddress, Ord_TransInOrder_H.Remark,");
            strSql.Append("Convert(varchar(10),CreatedBusDate,120)as CreatedBusDate ,Convert(varchar(10),ApproveBusDate,120)as ApproveBusDate,");
            strSql.Append("ApprovalCode,ApproveStatus,case ApproveStatus when 'P' then 'PENDING' when 'A' then 'APPROVED' else  'VOID' end as ApproveStatusName,");
            strSql.Append("Convert(varchar(10),Ord_TransInOrder_H.ApproveOn,120)as ApproveOn,ApproveBy,u1.UserName as ApproveName,");
            strSql.Append("Convert(varchar(10),Ord_TransInOrder_H.CreatedOn,120)as CreatedOn,Ord_TransInOrder_H.CreatedBy,");
            strSql.Append("Accounts_Users.UserName as CreatedName,Convert(varchar(10),Ord_TransInOrder_H.UpdatedOn,120)as UpdatedOn,");
            strSql.Append("Ord_TransInOrder_H.UpdatedBy,u.UserName as UpdatedName,Ord_TransInOrder_D.ProdCode,Ord_TransInOrder_D.TransInQty,");
            strSql.Append("BUY_STORE.StoreName1 as SEnglishStoreName ,BUY_STORE.StoreName2 as SSimplifiedStoreName,");
            strSql.Append("BUY_STORE.StoreName3 as STraditionalStoreName,BUY_STORE.StoreAddressDetail1,");
            strSql.Append("BUY_STORE.Contact,BUY_STORE.ContactPhone,store1.StoreName1 as FEnglishStoreName,");
            strSql.Append("store1.StoreName2 as FSimplifiedStoreName,store1.StoreName3 as FTraditionalStoreName,");
            strSql.Append("BUY_PRODUCT.ProdDesc1,BUY_PRODUCT.ProdDesc2,BUY_PRODUCT.ProdDesc3,@WebSiteName as WebSiteName,");
            strSql.Append(" Ord_TransInOrder_D.ReasonID ");
            strSql.Append("from Ord_TransInOrder_H ");
            strSql.Append("left join Ord_TransInOrder_D on Ord_TransInOrder_H.TransInOrderNumber=Ord_TransInOrder_D.TransInOrderNumber ");
            strSql.Append("left join Accounts_Users on Ord_TransInOrder_H.CreatedBy=Accounts_Users.UserID ");
            strSql.Append("left join Accounts_Users as u  on Ord_TransInOrder_H.UpdatedBy=u.UserID ");
            strSql.Append("left join Accounts_Users as u1  on Ord_TransInOrder_H.ApproveBy=u1.UserID ");
            strSql.Append("left join BUY_PRODUCT on Ord_TransInOrder_D.ProdCode=BUY_PRODUCT.ProdCode ");
            strSql.Append("left join BUY_STORE on Ord_TransInOrder_H.StoreID=BUY_STORE.StoreID ");
            strSql.Append("left join BUY_STORE store1 on Ord_TransInOrder_H.FromStoreID=store1.StoreID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_TransInOrder_H ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Ord_TransInOrder_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.TransInOrderNumber desc");
            }
            strSql.Append(")AS Row, T.*  from Ord_TransInOrder_H T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method
    }
}

