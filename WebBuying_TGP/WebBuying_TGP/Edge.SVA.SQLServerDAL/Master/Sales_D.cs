using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Sales_D
    /// 创建人：Lisa
    /// 创建时间：2016-1-2
	/// </summary>
	public partial class Sales_D:ISales_D
	{
		public Sales_D(){}

        #region Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SeqNo,string TransNum)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sales_D");
			strSql.Append(" where SeqNo=@SeqNo and TransNum=@TransNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)			};
			parameters[0].Value = SeqNo;
			parameters[1].Value = TransNum;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Sales_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sales_D(");
			strSql.Append("SeqNo,TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,ProdCode,ProdDesc,DepartCode,Qty,OrgPrice,UnitPrice,NetPrice,OrgAmount,UnitAmount,NetAmount,TotalQty,DiscountPrice,DiscountAmount,POPrice,ExtraPrice,POReasonCode,Additional1,Additional2,Additional3,RPriceTypeCode,IsBOM,IsCoupon,IsBuyBack,IsService,SerialNoStockFlag,SerialNoType,SerialNo,IMEI,StockTypeCode,Collected,ReservedDate,PickupLocation,PickupStaff,PickupDate,DeliveryDate,DeliveryBy,ActPrice,ActAmount,OrgTransNum,OrgSeqNo,Remark,RefGUID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@SeqNo,@TransNum,@TransType,@StoreCode,@RegisterCode,@BusDate,@TxnDate,@ProdCode,@ProdDesc,@DepartCode,@Qty,@OrgPrice,@UnitPrice,@NetPrice,@OrgAmount,@UnitAmount,@NetAmount,@TotalQty,@DiscountPrice,@DiscountAmount,@POPrice,@ExtraPrice,@POReasonCode,@Additional1,@Additional2,@Additional3,@RPriceTypeCode,@IsBOM,@IsCoupon,@IsBuyBack,@IsService,@SerialNoStockFlag,@SerialNoType,@SerialNo,@IMEI,@StockTypeCode,@Collected,@ReservedDate,@PickupLocation,@PickupStaff,@PickupDate,@DeliveryDate,@DeliveryBy,@ActPrice,@ActAmount,@OrgTransNum,@OrgSeqNo,@Remark,@RefGUID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@SeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64),
					new SqlParameter("@TransType", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,64),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@OrgPrice", SqlDbType.Decimal,9),
					new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@NetPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrgAmount", SqlDbType.Decimal,9),
					new SqlParameter("@UnitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@NetAmount", SqlDbType.Decimal,9),
					new SqlParameter("@TotalQty", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountAmount", SqlDbType.Decimal,9),
					new SqlParameter("@POPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExtraPrice", SqlDbType.Decimal,9),
					new SqlParameter("@POReasonCode", SqlDbType.VarChar,512),
					new SqlParameter("@Additional1", SqlDbType.VarChar,512),
					new SqlParameter("@Additional2", SqlDbType.VarChar,512),
					new SqlParameter("@Additional3", SqlDbType.VarChar,512),
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@IsBOM", SqlDbType.Int,4),
					new SqlParameter("@IsCoupon", SqlDbType.Int,4),
					new SqlParameter("@IsBuyBack", SqlDbType.Int,4),
					new SqlParameter("@IsService", SqlDbType.Int,4),
					new SqlParameter("@SerialNoStockFlag", SqlDbType.Int,4),
					new SqlParameter("@SerialNoType", SqlDbType.Int,4),
					new SqlParameter("@SerialNo", SqlDbType.VarChar,64),
					new SqlParameter("@IMEI", SqlDbType.VarChar,64),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@Collected", SqlDbType.Int,4),
					new SqlParameter("@ReservedDate", SqlDbType.DateTime),
					new SqlParameter("@PickupLocation", SqlDbType.VarChar,64),
					new SqlParameter("@PickupStaff", SqlDbType.VarChar,64),
					new SqlParameter("@PickupDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryBy", SqlDbType.Int,4),
					new SqlParameter("@ActPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ActAmount", SqlDbType.Decimal,9),
					new SqlParameter("@OrgTransNum", SqlDbType.VarChar,64),
					new SqlParameter("@OrgSeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@RefGUID", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.SeqNo;
			parameters[1].Value = model.TransNum;
			parameters[2].Value = model.TransType;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.RegisterCode;
			parameters[5].Value = model.BusDate;
			parameters[6].Value = model.TxnDate;
			parameters[7].Value = model.ProdCode;
			parameters[8].Value = model.ProdDesc;
			parameters[9].Value = model.DepartCode;
			parameters[10].Value = model.Qty;
			parameters[11].Value = model.OrgPrice;
			parameters[12].Value = model.UnitPrice;
			parameters[13].Value = model.NetPrice;
			parameters[14].Value = model.OrgAmount;
			parameters[15].Value = model.UnitAmount;
			parameters[16].Value = model.NetAmount;
			parameters[17].Value = model.TotalQty;
			parameters[18].Value = model.DiscountPrice;
			parameters[19].Value = model.DiscountAmount;
			parameters[20].Value = model.POPrice;
			parameters[21].Value = model.ExtraPrice;
			parameters[22].Value = model.POReasonCode;
			parameters[23].Value = model.Additional1;
			parameters[24].Value = model.Additional2;
			parameters[25].Value = model.Additional3;
			parameters[26].Value = model.RPriceTypeCode;
			parameters[27].Value = model.IsBOM;
			parameters[28].Value = model.IsCoupon;
			parameters[29].Value = model.IsBuyBack;
			parameters[30].Value = model.IsService;
			parameters[31].Value = model.SerialNoStockFlag;
			parameters[32].Value = model.SerialNoType;
			parameters[33].Value = model.SerialNo;
			parameters[34].Value = model.IMEI;
			parameters[35].Value = model.StockTypeCode;
			parameters[36].Value = model.Collected;
			parameters[37].Value = model.ReservedDate;
			parameters[38].Value = model.PickupLocation;
			parameters[39].Value = model.PickupStaff;
			parameters[40].Value = model.PickupDate;
			parameters[41].Value = model.DeliveryDate;
			parameters[42].Value = model.DeliveryBy;
			parameters[43].Value = model.ActPrice;
			parameters[44].Value = model.ActAmount;
			parameters[45].Value = model.OrgTransNum;
			parameters[46].Value = model.OrgSeqNo;
			parameters[47].Value = model.Remark;
			parameters[48].Value = model.RefGUID;
			parameters[49].Value = model.CreatedOn;
			parameters[50].Value = model.CreatedBy;
			parameters[51].Value = model.UpdatedOn;
			parameters[52].Value = model.UpdatedBy;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Sales_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sales_D set ");
			strSql.Append("TransType=@TransType,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("RegisterCode=@RegisterCode,");
			strSql.Append("BusDate=@BusDate,");
			strSql.Append("TxnDate=@TxnDate,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("ProdDesc=@ProdDesc,");
			strSql.Append("DepartCode=@DepartCode,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("OrgPrice=@OrgPrice,");
			strSql.Append("UnitPrice=@UnitPrice,");
			strSql.Append("NetPrice=@NetPrice,");
			strSql.Append("OrgAmount=@OrgAmount,");
			strSql.Append("UnitAmount=@UnitAmount,");
			strSql.Append("NetAmount=@NetAmount,");
			strSql.Append("TotalQty=@TotalQty,");
			strSql.Append("DiscountPrice=@DiscountPrice,");
			strSql.Append("DiscountAmount=@DiscountAmount,");
			strSql.Append("POPrice=@POPrice,");
			strSql.Append("ExtraPrice=@ExtraPrice,");
			strSql.Append("POReasonCode=@POReasonCode,");
			strSql.Append("Additional1=@Additional1,");
			strSql.Append("Additional2=@Additional2,");
			strSql.Append("Additional3=@Additional3,");
			strSql.Append("RPriceTypeCode=@RPriceTypeCode,");
			strSql.Append("IsBOM=@IsBOM,");
			strSql.Append("IsCoupon=@IsCoupon,");
			strSql.Append("IsBuyBack=@IsBuyBack,");
			strSql.Append("IsService=@IsService,");
			strSql.Append("SerialNoStockFlag=@SerialNoStockFlag,");
			strSql.Append("SerialNoType=@SerialNoType,");
			strSql.Append("SerialNo=@SerialNo,");
			strSql.Append("IMEI=@IMEI,");
			strSql.Append("StockTypeCode=@StockTypeCode,");
			strSql.Append("Collected=@Collected,");
			strSql.Append("ReservedDate=@ReservedDate,");
			strSql.Append("PickupLocation=@PickupLocation,");
			strSql.Append("PickupStaff=@PickupStaff,");
			strSql.Append("PickupDate=@PickupDate,");
			strSql.Append("DeliveryDate=@DeliveryDate,");
			strSql.Append("DeliveryBy=@DeliveryBy,");
			strSql.Append("ActPrice=@ActPrice,");
			strSql.Append("ActAmount=@ActAmount,");
			strSql.Append("OrgTransNum=@OrgTransNum,");
			strSql.Append("OrgSeqNo=@OrgSeqNo,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("RefGUID=@RefGUID,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where SeqNo=@SeqNo and TransNum=@TransNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@TransType", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,64),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@OrgPrice", SqlDbType.Decimal,9),
					new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@NetPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrgAmount", SqlDbType.Decimal,9),
					new SqlParameter("@UnitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@NetAmount", SqlDbType.Decimal,9),
					new SqlParameter("@TotalQty", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountAmount", SqlDbType.Decimal,9),
					new SqlParameter("@POPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExtraPrice", SqlDbType.Decimal,9),
					new SqlParameter("@POReasonCode", SqlDbType.VarChar,512),
					new SqlParameter("@Additional1", SqlDbType.VarChar,512),
					new SqlParameter("@Additional2", SqlDbType.VarChar,512),
					new SqlParameter("@Additional3", SqlDbType.VarChar,512),
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@IsBOM", SqlDbType.Int,4),
					new SqlParameter("@IsCoupon", SqlDbType.Int,4),
					new SqlParameter("@IsBuyBack", SqlDbType.Int,4),
					new SqlParameter("@IsService", SqlDbType.Int,4),
					new SqlParameter("@SerialNoStockFlag", SqlDbType.Int,4),
					new SqlParameter("@SerialNoType", SqlDbType.Int,4),
					new SqlParameter("@SerialNo", SqlDbType.VarChar,64),
					new SqlParameter("@IMEI", SqlDbType.VarChar,64),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@Collected", SqlDbType.Int,4),
					new SqlParameter("@ReservedDate", SqlDbType.DateTime),
					new SqlParameter("@PickupLocation", SqlDbType.VarChar,64),
					new SqlParameter("@PickupStaff", SqlDbType.VarChar,64),
					new SqlParameter("@PickupDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryBy", SqlDbType.Int,4),
					new SqlParameter("@ActPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ActAmount", SqlDbType.Decimal,9),
					new SqlParameter("@OrgTransNum", SqlDbType.VarChar,64),
					new SqlParameter("@OrgSeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@RefGUID", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@SeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)};
			parameters[0].Value = model.TransType;
			parameters[1].Value = model.StoreCode;
			parameters[2].Value = model.RegisterCode;
			parameters[3].Value = model.BusDate;
			parameters[4].Value = model.TxnDate;
			parameters[5].Value = model.ProdCode;
			parameters[6].Value = model.ProdDesc;
			parameters[7].Value = model.DepartCode;
			parameters[8].Value = model.Qty;
			parameters[9].Value = model.OrgPrice;
			parameters[10].Value = model.UnitPrice;
			parameters[11].Value = model.NetPrice;
			parameters[12].Value = model.OrgAmount;
			parameters[13].Value = model.UnitAmount;
			parameters[14].Value = model.NetAmount;
			parameters[15].Value = model.TotalQty;
			parameters[16].Value = model.DiscountPrice;
			parameters[17].Value = model.DiscountAmount;
			parameters[18].Value = model.POPrice;
			parameters[19].Value = model.ExtraPrice;
			parameters[20].Value = model.POReasonCode;
			parameters[21].Value = model.Additional1;
			parameters[22].Value = model.Additional2;
			parameters[23].Value = model.Additional3;
			parameters[24].Value = model.RPriceTypeCode;
			parameters[25].Value = model.IsBOM;
			parameters[26].Value = model.IsCoupon;
			parameters[27].Value = model.IsBuyBack;
			parameters[28].Value = model.IsService;
			parameters[29].Value = model.SerialNoStockFlag;
			parameters[30].Value = model.SerialNoType;
			parameters[31].Value = model.SerialNo;
			parameters[32].Value = model.IMEI;
			parameters[33].Value = model.StockTypeCode;
			parameters[34].Value = model.Collected;
			parameters[35].Value = model.ReservedDate;
			parameters[36].Value = model.PickupLocation;
			parameters[37].Value = model.PickupStaff;
			parameters[38].Value = model.PickupDate;
			parameters[39].Value = model.DeliveryDate;
			parameters[40].Value = model.DeliveryBy;
			parameters[41].Value = model.ActPrice;
			parameters[42].Value = model.ActAmount;
			parameters[43].Value = model.OrgTransNum;
			parameters[44].Value = model.OrgSeqNo;
			parameters[45].Value = model.Remark;
			parameters[46].Value = model.RefGUID;
			parameters[47].Value = model.CreatedOn;
			parameters[48].Value = model.CreatedBy;
			parameters[49].Value = model.UpdatedOn;
			parameters[50].Value = model.UpdatedBy;
			parameters[51].Value = model.SeqNo;
			parameters[52].Value = model.TransNum;

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
		public bool Delete(string SeqNo,string TransNum)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sales_D ");
			strSql.Append(" where SeqNo=@SeqNo and TransNum=@TransNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)			};
			parameters[0].Value = SeqNo;
			parameters[1].Value = TransNum;

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Sales_D GetModel(string SeqNo,string TransNum)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SeqNo,TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,ProdCode,ProdDesc,DepartCode,Qty,OrgPrice,UnitPrice,NetPrice,OrgAmount,UnitAmount,NetAmount,TotalQty,DiscountPrice,DiscountAmount,POPrice,ExtraPrice,POReasonCode,Additional1,Additional2,Additional3,RPriceTypeCode,IsBOM,IsCoupon,IsBuyBack,IsService,SerialNoStockFlag,SerialNoType,SerialNo,IMEI,StockTypeCode,Collected,ReservedDate,PickupLocation,PickupStaff,PickupDate,DeliveryDate,DeliveryBy,ActPrice,ActAmount,OrgTransNum,OrgSeqNo,Remark,RefGUID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Sales_D ");
			strSql.Append(" where SeqNo=@SeqNo and TransNum=@TransNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@SeqNo", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)			};
			parameters[0].Value = SeqNo;
			parameters[1].Value = TransNum;

			Edge.SVA.Model.Sales_D model=new Edge.SVA.Model.Sales_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Sales_D DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.Sales_D model=new Edge.SVA.Model.Sales_D();
			if (row != null)
			{
				if(row["SeqNo"]!=null)
				{
					model.SeqNo=row["SeqNo"].ToString();
				}
				if(row["TransNum"]!=null)
				{
					model.TransNum=row["TransNum"].ToString();
				}
				if(row["TransType"]!=null && row["TransType"].ToString()!="")
				{
					model.TransType=int.Parse(row["TransType"].ToString());
				}
				if(row["StoreCode"]!=null)
				{
					model.StoreCode=row["StoreCode"].ToString();
				}
				if(row["RegisterCode"]!=null)
				{
					model.RegisterCode=row["RegisterCode"].ToString();
				}
				if(row["BusDate"]!=null && row["BusDate"].ToString()!="")
				{
					model.BusDate=DateTime.Parse(row["BusDate"].ToString());
				}
				if(row["TxnDate"]!=null && row["TxnDate"].ToString()!="")
				{
					model.TxnDate=DateTime.Parse(row["TxnDate"].ToString());
				}
				if(row["ProdCode"]!=null)
				{
					model.ProdCode=row["ProdCode"].ToString();
				}
				if(row["ProdDesc"]!=null)
				{
					model.ProdDesc=row["ProdDesc"].ToString();
				}
				if(row["DepartCode"]!=null)
				{
					model.DepartCode=row["DepartCode"].ToString();
				}
				if(row["Qty"]!=null && row["Qty"].ToString()!="")
				{
					model.Qty=decimal.Parse(row["Qty"].ToString());
				}
				if(row["OrgPrice"]!=null && row["OrgPrice"].ToString()!="")
				{
					model.OrgPrice=decimal.Parse(row["OrgPrice"].ToString());
				}
				if(row["UnitPrice"]!=null && row["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(row["UnitPrice"].ToString());
				}
				if(row["NetPrice"]!=null && row["NetPrice"].ToString()!="")
				{
					model.NetPrice=decimal.Parse(row["NetPrice"].ToString());
				}
				if(row["OrgAmount"]!=null && row["OrgAmount"].ToString()!="")
				{
					model.OrgAmount=decimal.Parse(row["OrgAmount"].ToString());
				}
				if(row["UnitAmount"]!=null && row["UnitAmount"].ToString()!="")
				{
					model.UnitAmount=decimal.Parse(row["UnitAmount"].ToString());
				}
				if(row["NetAmount"]!=null && row["NetAmount"].ToString()!="")
				{
					model.NetAmount=decimal.Parse(row["NetAmount"].ToString());
				}
				if(row["TotalQty"]!=null && row["TotalQty"].ToString()!="")
				{
					model.TotalQty=decimal.Parse(row["TotalQty"].ToString());
				}
				if(row["DiscountPrice"]!=null && row["DiscountPrice"].ToString()!="")
				{
					model.DiscountPrice=decimal.Parse(row["DiscountPrice"].ToString());
				}
				if(row["DiscountAmount"]!=null && row["DiscountAmount"].ToString()!="")
				{
					model.DiscountAmount=decimal.Parse(row["DiscountAmount"].ToString());
				}
				if(row["POPrice"]!=null && row["POPrice"].ToString()!="")
				{
					model.POPrice=decimal.Parse(row["POPrice"].ToString());
				}
				if(row["ExtraPrice"]!=null && row["ExtraPrice"].ToString()!="")
				{
					model.ExtraPrice=decimal.Parse(row["ExtraPrice"].ToString());
				}
				if(row["POReasonCode"]!=null)
				{
					model.POReasonCode=row["POReasonCode"].ToString();
				}
				if(row["Additional1"]!=null)
				{
					model.Additional1=row["Additional1"].ToString();
				}
				if(row["Additional2"]!=null)
				{
					model.Additional2=row["Additional2"].ToString();
				}
				if(row["Additional3"]!=null)
				{
					model.Additional3=row["Additional3"].ToString();
				}
				if(row["RPriceTypeCode"]!=null)
				{
					model.RPriceTypeCode=row["RPriceTypeCode"].ToString();
				}
				if(row["IsBOM"]!=null && row["IsBOM"].ToString()!="")
				{
					model.IsBOM=int.Parse(row["IsBOM"].ToString());
				}
				if(row["IsCoupon"]!=null && row["IsCoupon"].ToString()!="")
				{
					model.IsCoupon=int.Parse(row["IsCoupon"].ToString());
				}
				if(row["IsBuyBack"]!=null && row["IsBuyBack"].ToString()!="")
				{
					model.IsBuyBack=int.Parse(row["IsBuyBack"].ToString());
				}
				if(row["IsService"]!=null && row["IsService"].ToString()!="")
				{
					model.IsService=int.Parse(row["IsService"].ToString());
				}
				if(row["SerialNoStockFlag"]!=null && row["SerialNoStockFlag"].ToString()!="")
				{
					model.SerialNoStockFlag=int.Parse(row["SerialNoStockFlag"].ToString());
				}
				if(row["SerialNoType"]!=null && row["SerialNoType"].ToString()!="")
				{
					model.SerialNoType=int.Parse(row["SerialNoType"].ToString());
				}
				if(row["SerialNo"]!=null)
				{
					model.SerialNo=row["SerialNo"].ToString();
				}
				if(row["IMEI"]!=null)
				{
					model.IMEI=row["IMEI"].ToString();
				}
				if(row["StockTypeCode"]!=null)
				{
					model.StockTypeCode=row["StockTypeCode"].ToString();
				}
				if(row["Collected"]!=null && row["Collected"].ToString()!="")
				{
					model.Collected=int.Parse(row["Collected"].ToString());
				}
				if(row["ReservedDate"]!=null && row["ReservedDate"].ToString()!="")
				{
					model.ReservedDate=DateTime.Parse(row["ReservedDate"].ToString());
				}
				if(row["PickupLocation"]!=null)
				{
					model.PickupLocation=row["PickupLocation"].ToString();
				}
				if(row["PickupStaff"]!=null)
				{
					model.PickupStaff=row["PickupStaff"].ToString();
				}
				if(row["PickupDate"]!=null && row["PickupDate"].ToString()!="")
				{
					model.PickupDate=DateTime.Parse(row["PickupDate"].ToString());
				}
				if(row["DeliveryDate"]!=null && row["DeliveryDate"].ToString()!="")
				{
					model.DeliveryDate=DateTime.Parse(row["DeliveryDate"].ToString());
				}
				if(row["DeliveryBy"]!=null && row["DeliveryBy"].ToString()!="")
				{
					model.DeliveryBy=int.Parse(row["DeliveryBy"].ToString());
				}
				if(row["ActPrice"]!=null && row["ActPrice"].ToString()!="")
				{
					model.ActPrice=decimal.Parse(row["ActPrice"].ToString());
				}
				if(row["ActAmount"]!=null && row["ActAmount"].ToString()!="")
				{
					model.ActAmount=decimal.Parse(row["ActAmount"].ToString());
				}
				if(row["OrgTransNum"]!=null)
				{
					model.OrgTransNum=row["OrgTransNum"].ToString();
				}
				if(row["OrgSeqNo"]!=null)
				{
					model.OrgSeqNo=row["OrgSeqNo"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["RefGUID"]!=null)
				{
					model.RefGUID=row["RefGUID"].ToString();
				}
				if(row["CreatedOn"]!=null && row["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(row["CreatedOn"].ToString());
				}
				if(row["CreatedBy"]!=null && row["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(row["CreatedBy"].ToString());
				}
				if(row["UpdatedOn"]!=null && row["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(row["UpdatedOn"].ToString());
				}
				if(row["UpdatedBy"]!=null && row["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(row["UpdatedBy"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SeqNo,TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,ProdCode,ProdDesc,DepartCode,Qty,OrgPrice,UnitPrice,NetPrice,OrgAmount,UnitAmount,NetAmount,TotalQty,DiscountPrice,DiscountAmount,POPrice,ExtraPrice,POReasonCode,Additional1,Additional2,Additional3,RPriceTypeCode,IsBOM,IsCoupon,IsBuyBack,IsService,SerialNoStockFlag,SerialNoType,SerialNo,IMEI,StockTypeCode,Collected,ReservedDate,PickupLocation,PickupStaff,PickupDate,DeliveryDate,DeliveryBy,ActPrice,ActAmount,OrgTransNum,OrgSeqNo,Remark,RefGUID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Sales_D ");
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
			strSql.Append(" SeqNo,TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,ProdCode,ProdDesc,DepartCode,Qty,OrgPrice,UnitPrice,NetPrice,OrgAmount,UnitAmount,NetAmount,TotalQty,DiscountPrice,DiscountAmount,POPrice,ExtraPrice,POReasonCode,Additional1,Additional2,Additional3,RPriceTypeCode,IsBOM,IsCoupon,IsBuyBack,IsService,SerialNoStockFlag,SerialNoType,SerialNo,IMEI,StockTypeCode,Collected,ReservedDate,PickupLocation,PickupStaff,PickupDate,DeliveryDate,DeliveryBy,ActPrice,ActAmount,OrgTransNum,OrgSeqNo,Remark,RefGUID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Sales_D ");
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
			strSql.Append("select count(1) FROM Sales_D ");
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
				strSql.Append("order by T.TransNum desc");
			}
			strSql.Append(")AS Row, T.*  from Sales_D T ");
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
			parameters[0].Value = "Sales_D";
			parameters[1].Value = "TransNum";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// 求总库存数量
        /// 创建人：Lisa
        /// 创建时间：2016-03-28
        /// </summary>
        /// <returns></returns>
        public DataSet GetSummary(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Qty) as Qty");
            strSql.Append(" FROM Sales_D ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  BasicMethod
	}
}

