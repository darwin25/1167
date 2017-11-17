using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.DBUtility;//Please add references
using System.Data.SqlClient;
using System.Globalization;
using Edge.SVA.Model.Domain.WebBuying;
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public class IMP_PRODUCTController
    {
        protected IMP_PRODUCTViewModel viewModel = new IMP_PRODUCTViewModel();

        public IMP_PRODUCTViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string ProdCode)
        {
            Edge.SVA.BLL.IMP_PRODUCT bll = new Edge.SVA.BLL.IMP_PRODUCT();
            Edge.SVA.Model.IMP_PRODUCT model = bll.GetModel(ProdCode);
            viewModel.MainTable = model;

            Edge.SVA.BLL.BUY_SUPPROD bllSUPPROD = new SVA.BLL.BUY_SUPPROD();
            viewModel.dtSUPPROD = bllSUPPROD.GetList("ProdCode='" + ProdCode + "'").Tables[0];
        }

        public DataSet GetTransactionList(string strWhere, int startIndex, int endIndex, out int recodeCount, string filedOrder)
        {
            //获取总条数首句
            string sqlcount = "select count(*) from ";
            //获取分页数据首句
            string sqlquery = "select * from ";

            StringBuilder strSql = new StringBuilder();
            if (string.IsNullOrEmpty(filedOrder))
            {
                filedOrder = "INTERNAL_PRODUCT_CODE";
            }
            else
            {
                filedOrder = "IMP_PRODUCT." + filedOrder;
            }
            strSql.AppendFormat("(SELECT ROW_NUMBER() OVER(order by {0}) as Row,", filedOrder);
            strSql.Append(" INTERNAL_PRODUCT_CODE,COMPANY_ID,BARCODE,SUPPLIER_PRODUCT_CODE,BRAND,YEAR,SEASON,ARTICLE,SEX, ");
            strSql.Append("MODEL,COLOR,PSIZE,CLASS,DESCRIPTION,REORDER_LEVEL,RETIRED,RETIRE_DATE,LAST_UPDATE_DATE,LAST_UPDATE_USER,");
            strSql.Append("DESCRIPTION2,SUPPLIER,STANDARD_COST,SIZE_RANGE,HS_CODE,EXPORT_COST,LOCAL_DESCRIPTION,COO,MATERIAL_1,MATERIAL_2,");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,SKU,AVG_COST,PRICE,FINAL_DISCOUNT_PRICE,ShortDescription1,ShortDescription2,");
            strSql.Append("ShortDescription3,Material1,Material2,Material3,Detailed1,Detailed2,Detailed3,Design1,Design2,Design3,");
            strSql.Append("ProductName1,ProductName2,ProductName3,IsOnlineSKU,OuterLayerMaterials,InnerLayerMaterials,SizeCategory,");
            strSql.Append("Video,[360Photos],Photos1,Photos2,Photos4,Photos5,Photos6,Photos7,Photos10,Photos8,Photos3,Photos9,SizeM1,");
            strSql.Append("SizeM2,SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 from IMP_PRODUCT");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");

            //获取总条数
            object obj = DBUtility.DbHelperSQL.GetSingle(sqlcount + strSql.ToString());
            if (obj == null)
            {
                recodeCount = 0;
            }
            else
            {
                recodeCount = Convert.ToInt32(obj);
            }

            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            //获取分页数据
            DataSet ds = DBUtility.DbHelperSQL.Query(sqlquery + strSql.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                Tools.DataTool.AddBuyingIMP_ProdName(ds.Tables[0], "ProductName", "INTERNAL_PRODUCT_CODE");
            }
            return ds;
        }

        //#region 导出数据处理
        //public string UpLoadFileToServer(DataSet ds)
        //{
        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        string UploadFilePath = string.Empty;

        //        UploadFilePath = System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/IMP_PRODUCTInfos/");

        //        if (!System.IO.Directory.Exists(UploadFilePath))
        //        {
        //            System.IO.Directory.CreateDirectory(UploadFilePath);
        //        }

        //        string fileName = System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/IMP_PRODUCTInfos/" + "IMP_PRODUCTInfo" + DateTime.Now.ToString("yyyy-MM-ddTHHmmss") + ".xls");

        //        System.IO.FileStream fs = null;
        //        try
        //        {
        //            StringBuilder text = new StringBuilder(1000);
        //            fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

        //            #region Write To File
        //            text.Append(" INTERNAL_PRODUCT_CODE");
        //            text.Append(" INTERNAL_PRODUCT_CODE\tCOMPANY_ID\tBARCODE\tSUPPLIER_PRODUCT_CODE\tBRAND\tYEAR\tSEASON\tARTICLE\tSEX");
        //            text.Append("\tMODEL\tCOLOR\tPSIZE\tCLASS\tDESCRIPTION\tREORDER_LEVEL\tRETIRED\tRETIRE_DATE\tLAST_UPDATE_DATE\tLAST_UPDATE_USER");
        //            text.Append("\tDESCRIPTION2\tSUPPLIER\tSTANDARD_COST\tSIZE_RANGE\tHS_CODE\tEXPORT_COST\tLOCAL_DESCRIPTION\tCOO\tMATERIAL_1\tMATERIAL_2");
        //            text.Append("\tDESIGNER\tBUYER\tMERCHANDISER\tSKU\tAVG_COST\tPRICE\tFINAL_DISCOUNT_PRICE");
        //            text.Append("\tShortDescription1\tShortDescription2\tShortDescription3\tMaterial1\tMaterial2\tMaterial3\tDetailed1\tDetailed2\tDetailed3\tDesign1\tDesign2\tDesign3\tProductName1\tProductName2\tProductName3");
        //            text.Append("\tIsOnlineSKU\tOuterLayerMaterials\tInnerLayerMaterials\tSizeCategory");
        //            text.Append("\tVideo\t360Photos\tPhotos1\tPhotos2\tPhotos3\tPhotos4\tPhotos5\tPhotos6\tPhotos7\tPhotos8\tPhotos9\tPhotos10\tSizeM1");
        //            text.Append("\tSizeM2\tSizeM3\tSizeM4\tSizeM5\tSizeM6\tSizeM7\tSizeM8 ");
        //            text.Append("\r\n");
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                DataRow dr = ds.Tables[0].Rows[i];
        //                text.AppendFormat("{0}\t", dr["INTERNAL_PRODUCT_CODE"].ToString());
        //                text.AppendFormat("{0}\t", dr["COMPANY_ID"].ToString());
        //                text.AppendFormat("{0}\t", dr["BARCODE"].ToString());
        //                text.AppendFormat("{0}\t", dr["SUPPLIER_PRODUCT_CODE"].ToString());
        //                text.AppendFormat("{0}\t", dr["BRAND"].ToString());
        //                text.AppendFormat("{0}\t", dr["YEAR"].ToString());
        //                text.AppendFormat("{0}\t", dr["SEASON"].ToString());
        //                text.AppendFormat("{0}\t", dr["ARTICLE"].ToString());
        //                text.AppendFormat("{0}\t", dr["SEX"].ToString());
        //                text.AppendFormat("{0}\t", dr["MODEL"].ToString());
        //                text.AppendFormat("{0}\t", dr["COLOR"].ToString());
        //                text.AppendFormat("{0}\t", dr["PSIZE"].ToString());
        //                text.AppendFormat("{0}\t", dr["CLASS"].ToString());
        //                text.AppendFormat("{0}\t", dr["DESCRIPTION"].ToString());
        //                text.AppendFormat("{0}\t", dr["REORDER_LEVEL"].ToString());
        //                text.AppendFormat("{0}\t", dr["RETIRED"].ToString());
        //                text.AppendFormat("{0}\t", string.IsNullOrEmpty(dr["RETIRE_DATE"].ToString()) ? "" : Convert.ToDateTime(dr["RETIRE_DATE"].ToString()).ToString("yyyy-MM-dd"));
        //                text.AppendFormat("{0}\t", string.IsNullOrEmpty(dr["LAST_UPDATE_DATE"].ToString()) ? "" : Convert.ToDateTime(dr["LAST_UPDATE_DATE"].ToString()).ToString("yyyy-MM-dd"));
        //                text.AppendFormat("{0}\t", dr["LAST_UPDATE_USER"].ToString());
        //                text.AppendFormat("{0}\t", dr["DESCRIPTION2"].ToString());
        //                text.AppendFormat("{0}\t", dr["SUPPLIER"].ToString());
        //                text.AppendFormat("{0}\t", dr["STANDARD_COST"].ToString());
        //                text.AppendFormat("{0}\t", dr["SIZE_RANGE"].ToString());
        //                text.AppendFormat("{0}\t", dr["HS_CODE"].ToString());
        //                text.AppendFormat("{0}\t", dr["EXPORT_COST"].ToString());
        //                text.AppendFormat("{0}\t", dr["LOCAL_DESCRIPTION"].ToString());
        //                text.AppendFormat("{0}\t", dr["COO"].ToString());
        //                text.AppendFormat("{0}\t", dr["MATERIAL_1"].ToString());
        //                text.AppendFormat("{0}\t", dr["MATERIAL_2"].ToString());
        //                text.AppendFormat("{0}\t", dr["DESIGNER"].ToString());
        //                text.AppendFormat("{0}\t", dr["BUYER"].ToString());
        //                text.AppendFormat("{0}\t", dr["MERCHANDISER"].ToString());
        //                text.AppendFormat("{0}\t", dr["SKU"].ToString());
        //                text.AppendFormat("{0}\t", dr["AVG_COST"].ToString());
        //                text.AppendFormat("{0}\t", dr["PRICE"].ToString());
        //                text.AppendFormat("{0}\t", dr["FINAL_DISCOUNT_PRICE"].ToString());
        //                text.AppendFormat("{0}\t", dr["ShortDescription1"].ToString());
        //                text.AppendFormat("{0}\t", dr["ShortDescription2"].ToString());
        //                text.AppendFormat("{0}\t", dr["ShortDescription3"].ToString());
        //                text.AppendFormat("{0}\t", dr["Material1"].ToString());
        //                text.AppendFormat("{0}\t", dr["Material2"].ToString());
        //                text.AppendFormat("{0}\t", dr["Material3"].ToString());
        //                text.AppendFormat("{0}\t", dr["Detailed1"].ToString());
        //                text.AppendFormat("{0}\t", dr["Detailed2"].ToString());
        //                text.AppendFormat("{0}\t", dr["Detailed3"].ToString());
        //                text.AppendFormat("{0}\t", dr["Design1"].ToString());
        //                text.AppendFormat("{0}\t", dr["Design2"].ToString());
        //                text.AppendFormat("{0}\t", dr["Design3"].ToString());
        //                text.AppendFormat("{0}\t", dr["ProductName1"].ToString());
        //                text.AppendFormat("{0}\t", dr["ProductName2"].ToString());
        //                text.AppendFormat("{0}\t", dr["ProductName3"].ToString());
        //                text.AppendFormat("{0}\t", dr["IsOnlineSKU"].ToString());
        //                text.AppendFormat("{0}\t", dr["OuterLayerMaterials"].ToString());
        //                text.AppendFormat("{0}\t", dr["InnerLayerMaterials"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeCategory"].ToString());
        //                if (!string.IsNullOrEmpty(dr["Video"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Video"].ToString().Substring(dr["Video"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["360Photos"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["360Photos"].ToString().Substring(dr["360Photos"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos1"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos1"].ToString().Substring(dr["Photos1"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos2"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos2"].ToString().Substring(dr["Photos2"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos3"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos3"].ToString().Substring(dr["Photos3"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos4"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos4"].ToString().Substring(dr["Photos4"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos5"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos5"].ToString().Substring(dr["Photos5"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos6"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos6"].ToString().Substring(dr["Photos6"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos7"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos7"].ToString().Substring(dr["Photos7"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos8"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos8"].ToString().Substring(dr["Photos8"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos9"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos9"].ToString().Substring(dr["Photos9"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                if (!string.IsNullOrEmpty(dr["Photos10"].ToString()))
        //                {
        //                    text.AppendFormat("{0}\t", dr["Photos10"].ToString().Substring(dr["Photos10"].ToString().LastIndexOf("/") + 1));
        //                }
        //                else
        //                {
        //                    text.AppendFormat("{0}\t", "");
        //                }
        //                text.AppendFormat("{0}\t", dr["SizeM1"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM2"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM3"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM4"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM5"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM6"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM7"].ToString());
        //                text.AppendFormat("{0}\t", dr["SizeM8"].ToString());
        //                text.Append("\r\n");
        //                if (text.Length >= 10000)
        //                {

        //                    byte[] buffer = System.Text.Encoding.GetEncoding("gb2312").GetBytes(text.ToString());
        //                    fs.Write(buffer, 0, buffer.Length);
        //                    text.Remove(0, text.Length);
        //                }
        //            }

        //            if (text.Length > 0)
        //            {
        //                byte[] buffer = System.Text.Encoding.GetEncoding("gb2312").GetBytes(text.ToString());
        //                fs.Write(buffer, 0, buffer.Length);
        //            }
        //            #endregion
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            if (fs != null) fs.Close();
        //        }
        //        return fileName;
        //    }
        //    return "";
        //}
        //#endregion

        #region 导出数据处理
        public string UpLoadFileToServer(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                string UploadFilePath = string.Empty;

                UploadFilePath = System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/IMP_PRODUCTInfos/");

                if (!System.IO.Directory.Exists(UploadFilePath))
                {
                    System.IO.Directory.CreateDirectory(UploadFilePath);
                }

                string fileName = System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/IMP_PRODUCTInfos/" + "IMP_PRODUCTInfo" + DateTime.Now.ToString("yyyy-MM-ddTHHmmss") + ".xls");

                System.IO.FileStream fs = null;
                try
                {
                    StringBuilder strSql = new StringBuilder(1000);
                    fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                    #region Write To File
                    strSql.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");
                    strSql.Append("<tr>");
                    strSql.Append("<td>INTERNAL_PRODUCT_CODE</td><td>COMPANY_ID</td><td>BARCODE</td><td>SUPPLIER_PRODUCT_CODE</td>");
                    strSql.Append("<td>BRAND</td><td>YEAR</td><td>SEASON</td><td>ARTICLE</td><td>SEX</td>");
                    strSql.Append("<td>MODEL</td><td>COLOR</td><td>PSIZE</td><td>CLASS</td>");
                    strSql.Append("<td>DESCRIPTION</td><td>REORDER_LEVEL</td><td>RETIRED</td><td>RETIRE_DATE</td>");
                    strSql.Append("<td>LAST_UPDATE_DATE</td><td>LAST_UPDATE_USER</td><td>DESCRIPTION2</td><td>SUPPLIER</td>");
                    strSql.Append("<td>STANDARD_COST</td><td>SIZE_RANGE</td><td>HS_CODE</td><td>EXPORT_COST</td><td>LOCAL_DESCRIPTION</td>");
                    strSql.Append("<td>COO</td><td>MATERIAL_1</td><td>MATERIAL_2</td><td>DESIGNER</td><td>BUYER</td><td>MERCHANDISER</td>");
                    strSql.Append("<td>SKU</td><td>AVG_COST</td><td>PRICE</td><td>FINAL_DISCOUNT_PRICE</td><td>ShortDescription1</td>");
                    strSql.Append("<td>ShortDescription2</td><td>ShortDescription3</td><td>Material1</td><td>Material2</td><td>Material3</td>");
                    strSql.Append("<td>Detailed1</td><td>Detailed2</td><td>Detailed3</td><td>Design1</td><td>Design2</td><td>Design3</td>");
                    strSql.Append("<td>ProductName1</td><td>ProductName2</td><td>ProductName3</td><td>IsOnlineSKU</td><td>OuterLayerMaterials</td>");
                    strSql.Append("<td>InnerLayerMaterials</td><td>SizeCategory</td><td>Video</td><td>360Photos</td><td>Photos1</td><td>Photos2</td>");
                    strSql.Append("<td>Photos4</td><td>Photos5</td><td>Photos6</td><td>Photos7</td><td>Photos10</td><td>Photos8</td><td>Photos3</td>");
                    strSql.Append("<td>Photos9</td><td>SizeM1</td><td>SizeM2</td><td>SizeM3</td><td>SizeM4</td><td>SizeM5</td>");
                    strSql.Append("<td>SizeM6</td><td>SizeM7</td><td>SizeM8</td>");
                    strSql.Append("</tr>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        strSql.Append("<tr>");
                        strSql.Append("<td>" + dr["INTERNAL_PRODUCT_CODE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["COMPANY_ID"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["BARCODE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SUPPLIER_PRODUCT_CODE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["BRAND"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["YEAR"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SEASON"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["ARTICLE"] + "</td>");
                        strSql.Append("<td>" + dr["SEX"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["MODEL"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["COLOR"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["PSIZE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["CLASS"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["DESCRIPTION"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["REORDER_LEVEL"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["RETIRED"].ToString() + "</td>");
                        strSql.Append("<td>");
                        strSql.Append(string.IsNullOrEmpty(dr["RETIRE_DATE"].ToString()) ? "" : Convert.ToDateTime(dr["RETIRE_DATE"].ToString()).ToString("yyyy-MM-dd"));
                        strSql.Append("</td>");
                        strSql.Append("<td>");
                        strSql.Append(string.IsNullOrEmpty(dr["LAST_UPDATE_DATE"].ToString()) ? "" : Convert.ToDateTime(dr["LAST_UPDATE_DATE"].ToString()).ToString("yyyy-MM-dd"));
                        strSql.Append("</td>");
                        strSql.Append("<td>" + dr["LAST_UPDATE_USER"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["DESCRIPTION2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SUPPLIER"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["STANDARD_COST"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SIZE_RANGE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["HS_CODE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["EXPORT_COST"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["LOCAL_DESCRIPTION"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["COO"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["MATERIAL_1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["MATERIAL_2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["DESIGNER"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["BUYER"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["MERCHANDISER"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SKU"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["AVG_COST"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["PRICE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["FINAL_DISCOUNT_PRICE"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["ShortDescription1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["ShortDescription2"] + "</td>");
                        strSql.Append("<td>" + dr["ShortDescription3"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Material1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Material2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Material3"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Detailed1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Detailed2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Detailed3"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Design1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Design2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["Design3"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["ProductName1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["ProductName2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["ProductName3"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["IsOnlineSKU"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["OuterLayerMaterials"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["InnerLayerMaterials"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeCategory"].ToString() + "</td>");
                        if (!string.IsNullOrEmpty(dr["Video"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Video"].ToString().Substring(dr["Video"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["360Photos"].ToString()))
                        {
                            strSql.Append("<td>" + dr["360Photos"].ToString().Substring(dr["360Photos"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos1"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos1"].ToString().Substring(dr["Photos1"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos2"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos2"].ToString().Substring(dr["Photos2"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos3"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos3"].ToString().Substring(dr["Photos3"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos4"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos4"].ToString().Substring(dr["Photos4"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos5"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos5"].ToString().Substring(dr["Photos5"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos6"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos6"].ToString().Substring(dr["Photos6"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos7"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos7"].ToString().Substring(dr["Photos7"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos8"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos8"].ToString().Substring(dr["Photos8"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos9"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos9"].ToString().Substring(dr["Photos9"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        if (!string.IsNullOrEmpty(dr["Photos10"].ToString()))
                        {
                            strSql.Append("<td>" + dr["Photos10"].ToString().Substring(dr["Photos10"].ToString().LastIndexOf("/") + 1) + "</td>");
                        }
                        else
                        {
                            strSql.Append("<td></td>");
                        }
                        strSql.Append("<td>" + dr["SizeM1"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM2"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM3"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM4"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM5"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM6"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM7"].ToString() + "</td>");
                        strSql.Append("<td>" + dr["SizeM8"].ToString() + "</td>");
                        strSql.Append("</tr>");
                        if (strSql.Length >= 10000)
                        {

                            //byte[] buffer = System.Text.Encoding.GetEncoding("gb2312").GetBytes(strSql.ToString());
                            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strSql.ToString());
                            fs.Write(buffer, 0, buffer.Length);
                            strSql.Remove(0, strSql.Length);
                        }

                    }

                    if (strSql.Length > 0)
                    {
                        //byte[] buffer = System.Text.Encoding.GetEncoding("gb2312").GetBytes(strSql.ToString());
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strSql.ToString());
                        fs.Write(buffer, 0, buffer.Length);
                    }
                    strSql.Append("</table>");
                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
                return fileName;
            }
            return "";
        }
        #endregion

        #region 导入数据处理
        public ImportModelList list = new ImportModelList();
        #endregion

        public StringBuilder GetHtml(DateTime begin)
        {
            StringBuilder html = new StringBuilder(200);

            html.Append("<table class='msgtable' width='100%'  align='center'>");

            html.AppendFormat("<tr><td align='right'>{0}</td><td style='color:{1};font-weight:bold;font-size:x-large;'>{2}</td></tr>", "Import Result:", this.list.Success ? "green" : "red", this.list.Success ? "Success." : " Fail.");
            if (this.list.Error.Count > 0)
            {
                html.AppendFormat("<tr><td align='right' valign='top'>{0}</td>", "Reason:");
                html.AppendFormat("<td><table valign='top'>");
                for (int i = 0; i < this.list.Error.Count; i++)
                {
                    string error = this.list.Error[i].Replace("\r\n", "");
                    html.AppendFormat("<tr><td align='right'></td><td>{0}</td></tr>", error);
                }
                html.AppendFormat("</table></td></tr>");
            }
            else
            {
                html.AppendFormat("<tr><td align='right'></td><td>Add {0} records {1}.</td></tr>", this.list.Addrecords, "successfully");
                html.AppendFormat("<tr><td align='right'></td><td>Update {0} records {1}.</td></tr>", this.list.Updaterecords, "successfully");
                html.AppendFormat("<tr><td align='right'></td><td>Delete {0} records {1}.</td></tr>", this.list.Deletedrecords, "successfully");
            }
            html.AppendFormat("<tr><td align='right'>{0}</td><td>{1}</td></tr>", "Start Datetime:", begin.ToString("yyyy-MM-dd HH:mm:ss"));
            html.AppendFormat("<tr><td align='right'>{0}</td><td>{1}</td></tr>", "End Datetime:", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            html.AppendFormat("<tr><td align='right' nowrap='nowrap'>{0}</td><td>{1}</td></tr>", "Import Function:", "Import Stores");
            html.Append("</table>");

            SVASessionInfo.MessageHTML = html.ToString();

            this.list.Addrecords = 0;
            this.list.Updaterecords = 0;
            this.list.Deletedrecords = 0;
            this.list.Error.Clear();

            return html;
        }

        //public int ImportData(DataTable dt)
        //{
        //    int count = 0;
        //    Edge.SVA.Model.IMP_PRODUCT_TEMP model = new Edge.SVA.Model.IMP_PRODUCT_TEMP();
        //    Edge.SVA.BLL.IMP_PRODUCT_TEMP SQLIMP_Product = new Edge.SVA.BLL.IMP_PRODUCT_TEMP();
        //    if (dt != null)
        //        foreach (DataRow row in dt.Rows)
        //        {

        //            try
        //            {
        //                if (row != null)
        //                {
        //                    if (dt.Columns.Contains("INTERNAL_PRODUCT_CODE"))
        //                    {
        //                        if (row["INTERNAL_PRODUCT_CODE"] != null)
        //                        {
        //                            model.INTERNAL_PRODUCT_CODE = row["INTERNAL_PRODUCT_CODE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("COMPANY_ID"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["COMPANY_ID"].ToString()))
        //                        {
        //                            model.COMPANY_ID = row["COMPANY_ID"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("BARCODE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["BARCODE"].ToString()))
        //                        {
        //                            model.BARCODE = row["BARCODE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("SUPPLIER_PRODUCT_CODE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["SUPPLIER_PRODUCT_CODE"].ToString()))
        //                        {
        //                            model.SUPPLIER_PRODUCT_CODE = row["SUPPLIER_PRODUCT_CODE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("BRAND"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["BRAND"].ToString()))
        //                        {
        //                            model.BRAND = row["BRAND"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("YEAR"))
        //                    {
        //                        if (row["YEAR"] != null && row["YEAR"].ToString() != "")
        //                        {
        //                            model.YEAR = int.Parse(row["YEAR"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("SEASON"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["SEASON"].ToString()))
        //                        {
        //                            model.SEASON = row["SEASON"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ARTICLE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ARTICLE"].ToString()))
        //                        {
        //                            model.ARTICLE = row["ARTICLE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("SEX"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["SEX"].ToString()))
        //                        {
        //                            model.SEX = int.Parse(row["SEX"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("MODEL"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["MODEL"].ToString()))
        //                        {
        //                            model.MODEL = row["MODEL"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("COLOR"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["COLOR"].ToString()))
        //                        {
        //                            model.COLOR = row["COLOR"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("PSIZE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["PSIZE"].ToString()))
        //                        {
        //                            model.PSIZE = row["PSIZE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("CLASS"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["CLASS"].ToString()))
        //                        {
        //                            model.CLASS = row["CLASS"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("DESCRIPTION"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["DESCRIPTION"].ToString()))
        //                        {
        //                            model.DESCRIPTION = row["DESCRIPTION"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("REORDER_LEVEL"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["REORDER_LEVEL"].ToString()))
        //                        {
        //                            model.REORDER_LEVEL = row["REORDER_LEVEL"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("RETIRED"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["RETIRED"].ToString()))
        //                        {
        //                            model.RETIRED = row["RETIRED"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("RETIRE_DATE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["RETIRE_DATE"].ToString()))
        //                        {
        //                            model.RETIRE_DATE = DateTime.Parse(row["RETIRE_DATE"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("LAST_UPDATE_DATE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["LAST_UPDATE_DATE"].ToString()))
        //                        {
        //                            string newStr = Convert.ToDateTime(row["LAST_UPDATE_DATE"]).ToString("dd-MM-yyyy");
        //                            model.LAST_UPDATE_DATE = DateTime.Parse(row["LAST_UPDATE_DATE"].ToString(), new CultureInfo("zh-HK"));
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("LAST_UPDATE_USER"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["LAST_UPDATE_USER"].ToString()))
        //                        {
        //                            model.LAST_UPDATE_USER = row["LAST_UPDATE_USER"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("DESCRIPTION2"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["DESCRIPTION2"].ToString()))
        //                        {
        //                            model.DESCRIPTION2 = row["DESCRIPTION2"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("SUPPLIER"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["SUPPLIER"].ToString()))
        //                        {
        //                            model.SUPPLIER = row["SUPPLIER"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("STANDARD_COST"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["STANDARD_COST"].ToString()))
        //                        {
        //                            model.STANDARD_COST = decimal.Parse(row["STANDARD_COST"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("SIZE_RANGE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["SIZE_RANGE"].ToString()))
        //                        {
        //                            model.SIZE_RANGE = row["SIZE_RANGE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("HS_CODE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["HS_CODE"].ToString()))
        //                        {
        //                            model.HS_CODE = row["HS_CODE"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("EXPORT_COST"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["EXPORT_COST"].ToString()))
        //                        {
        //                            model.EXPORT_COST = decimal.Parse(row["EXPORT_COST"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("LOCAL_DESCRIPTION"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["LOCAL_DESCRIPTION"].ToString()))
        //                        {
        //                            model.LOCAL_DESCRIPTION = row["LOCAL_DESCRIPTION"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("COO"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["COO"].ToString()))
        //                        {
        //                            model.COO = row["COO"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("MATERIAL_1"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["MATERIAL_1"].ToString()))
        //                        {
        //                            model.MATERIAL_1 = row["MATERIAL_1"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("MATERIAL_2"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["MATERIAL_2"].ToString()))
        //                        {
        //                            model.MATERIAL_2 = row["MATERIAL_2"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("DESIGNER"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["DESIGNER"].ToString()))
        //                        {
        //                            model.DESIGNER = row["DESIGNER"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("BUYER"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["BUYER"].ToString()))
        //                        {
        //                            model.BUYER = row["BUYER"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("MERCHANDISER"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["MERCHANDISER"].ToString()))
        //                        {
        //                            model.MERCHANDISER = row["MERCHANDISER"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("SKU"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["SKU"].ToString()))
        //                        {
        //                            model.SKU = row["SKU"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("AVG_COST"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["AVG_COST"].ToString()))
        //                        {
        //                            model.AVG_COST = decimal.Parse(row["AVG_COST"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("PRICE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["PRICE"].ToString()))
        //                        {
        //                            model.PRICE = decimal.Parse(row["PRICE"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("FINAL_DISCOUNT_PRICE"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["FINAL_DISCOUNT_PRICE"].ToString()))
        //                        {
        //                            model.FINAL_DISCOUNT_PRICE = decimal.Parse(row["FINAL_DISCOUNT_PRICE"].ToString());
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ShortDescription1"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ShortDescription1"].ToString()))
        //                        {
        //                            model.ShortDescription1 = row["ShortDescription1"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ShortDescription2"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ShortDescription2"].ToString()))
        //                        {
        //                            model.ShortDescription2 = row["ShortDescription2"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ShortDescription3"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ShortDescription3"].ToString()))
        //                        {
        //                            model.ShortDescription3 = row["ShortDescription3"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("DetailedDescription1"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["DetailedDescription1"].ToString()))
        //                        {
        //                            model.DetailedDescription1 = row["DetailedDescription1"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("DetailedDescription2"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["DetailedDescription2"].ToString()))
        //                        {
        //                            model.DetailedDescription2 = row["DetailedDescription2"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("DetailedDescription3"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["DetailedDescription3"].ToString()))
        //                        {
        //                            model.DetailedDescription3 = row["DetailedDescription3"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("BrandCode"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["BrandCode"].ToString()))
        //                        {
        //                            model.BrandCode = row["BrandCode"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("BrandName"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["BrandName"].ToString()))
        //                        {
        //                            model.BrandName = row["BrandName"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ProductName1"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ProductName1"].ToString()))
        //                        {
        //                            model.ProductName1 = row["ProductName1"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ProductName2"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ProductName2"].ToString()))
        //                        {
        //                            model.ProductName2 = row["ProductName2"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("ProductName3"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["ProductName3"].ToString()))
        //                        {
        //                            model.ProductName3 = row["ProductName3"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("CatNameEn"))
        //                    {

        //                        if (!string.IsNullOrEmpty(row["CatNameEn"].ToString()))
        //                        {
        //                            model.CatNameEn = row["CatNameEn"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("CatNameTC"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["CatNameTC"].ToString()))
        //                        {
        //                            model.CatNameTC = row["CatNameTC"].ToString();
        //                        }
        //                    }
        //                    if (dt.Columns.Contains("CatNameSC"))
        //                    {
        //                        if (!string.IsNullOrEmpty(row["CatNameSC"].ToString()))
        //                        {
        //                            model.CatNameSC = row["CatNameSC"].ToString();
        //                        }
        //                    }
        //                    SQLIMP_Product.Add(model);
        //                    count = ImportProcedure();

        //                }


        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Instance.WriteOperationLog("import", ex.Message);
        //            }
        //        }
        //    return count;

        //}


        public void InsetData(DataTable dt)
        {

            string strConnection = PubConstant.ConnectionString;
            //获取或设置包含该应用程序的目录的名
            string url = @"/UploadFiles/ProdPic/";
            try
            {

                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConnection))
                {
                    bcp.BatchSize = 100;//每次传输的行数 
                    bcp.NotifyAfter = 100;//进度提示的行数 
                    bcp.DestinationTableName = "IMP_PRODUCT";//需要导入的数据库表名
                    //excel表头与数据库列对应关系
                    bcp.ColumnMappings.Add("INTERNAL_PRODUCT_CODE", "INTERNAL_PRODUCT_CODE");
                    bcp.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
                    bcp.ColumnMappings.Add("BARCODE", "BARCODE");
                    bcp.ColumnMappings.Add("SUPPLIER_PRODUCT_CODE", "SUPPLIER_PRODUCT_CODE");
                    bcp.ColumnMappings.Add("BRAND", "BRAND");
                    bcp.ColumnMappings.Add("YEAR", "YEAR");
                    bcp.ColumnMappings.Add("SEASON", "SEASON");
                    bcp.ColumnMappings.Add("ARTICLE", "ARTICLE");
                    bcp.ColumnMappings.Add("SEX", "SEX");
                    bcp.ColumnMappings.Add("MODEL", "MODEL");
                    bcp.ColumnMappings.Add("COLOR", "COLOR");
                    bcp.ColumnMappings.Add("PSIZE", "PSIZE");
                    bcp.ColumnMappings.Add("CLASS", "CLASS");
                    bcp.ColumnMappings.Add("DESCRIPTION", "DESCRIPTION");
                    bcp.ColumnMappings.Add("REORDER_LEVEL", "REORDER_LEVEL");
                    bcp.ColumnMappings.Add("RETIRED", "RETIRED");
                    bcp.ColumnMappings.Add("RETIRE_DATE", "RETIRE_DATE");
                    bcp.ColumnMappings.Add("LAST_UPDATE_DATE", "LAST_UPDATE_DATE");
                    bcp.ColumnMappings.Add("LAST_UPDATE_USER", "LAST_UPDATE_USER");
                    bcp.ColumnMappings.Add("DESCRIPTION2", "DESCRIPTION2");
                    bcp.ColumnMappings.Add("SUPPLIER", "SUPPLIER");
                    bcp.ColumnMappings.Add("STANDARD_COST", "STANDARD_COST");
                    bcp.ColumnMappings.Add("SIZE_RANGE", "SIZE_RANGE");
                    bcp.ColumnMappings.Add("HS_CODE", "HS_CODE");
                    bcp.ColumnMappings.Add("EXPORT_COST", "EXPORT_COST");
                    bcp.ColumnMappings.Add("LOCAL_DESCRIPTION", "LOCAL_DESCRIPTION");
                    bcp.ColumnMappings.Add("COO", "COO");
                    bcp.ColumnMappings.Add("MATERIAL_1", "MATERIAL_1");
                    bcp.ColumnMappings.Add("MATERIAL_2", "MATERIAL_2");
                    bcp.ColumnMappings.Add("DESIGNER", "DESIGNER");
                    bcp.ColumnMappings.Add("BUYER", "BUYER");
                    bcp.ColumnMappings.Add("MERCHANDISER", "MERCHANDISER");
                    bcp.ColumnMappings.Add("SKU", "SKU");
                    bcp.ColumnMappings.Add("AVG_COST", "AVG_COST");
                    bcp.ColumnMappings.Add("PRICE", "PRICE");
                    bcp.ColumnMappings.Add("FINAL_DISCOUNT_PRICE", "FINAL_DISCOUNT_PRICE");
                    bcp.ColumnMappings.Add("ShortDescription1", "ShortDescription1");
                    bcp.ColumnMappings.Add("ShortDescription2", "ShortDescription2");
                    bcp.ColumnMappings.Add("ShortDescription3", "ShortDescription3");
                    bcp.ColumnMappings.Add("Material1", "Material1");
                    bcp.ColumnMappings.Add("Material2", "Material2");
                    bcp.ColumnMappings.Add("Material3", "Material3");
                    bcp.ColumnMappings.Add("Detailed1", "Detailed1");
                    bcp.ColumnMappings.Add("Detailed2", "Detailed2");
                    bcp.ColumnMappings.Add("Detailed3", "Detailed3");
                    bcp.ColumnMappings.Add("Design1", "Design1");
                    bcp.ColumnMappings.Add("Design2", "Design2");
                    bcp.ColumnMappings.Add("Design3", "Design3");
                    bcp.ColumnMappings.Add("ProductName1", "ProductName1");
                    bcp.ColumnMappings.Add("ProductName2", "ProductName2");
                    bcp.ColumnMappings.Add("ProductName3", "ProductName3");
                    bcp.ColumnMappings.Add("OuterLayerMaterials", "OuterLayerMaterials");
                    bcp.ColumnMappings.Add("InnerLayerMaterials", "InnerLayerMaterials");
                    bcp.ColumnMappings.Add("SizeCategory", "SizeCategory");
                    bcp.ColumnMappings.Add("Video", "Video");
                    bcp.ColumnMappings.Add("360Photos", "360Photos");
                    bcp.ColumnMappings.Add("Photos1", "Photos1");
                    bcp.ColumnMappings.Add("Photos2", "Photos2");
                    bcp.ColumnMappings.Add("Photos3", "Photos3");
                    bcp.ColumnMappings.Add("Photos4", "Photos4");
                    bcp.ColumnMappings.Add("Photos5", "Photos5");
                    bcp.ColumnMappings.Add("Photos6", "Photos6");
                    bcp.ColumnMappings.Add("Photos7", "Photos7");
                    bcp.ColumnMappings.Add("Photos8", "Photos8");
                    bcp.ColumnMappings.Add("Photos9", "Photos9");
                    bcp.ColumnMappings.Add("Photos10", "Photos10");
                    bcp.ColumnMappings.Add("SizeM1", "SizeM1");
                    bcp.ColumnMappings.Add("SizeM2", "SizeM2");
                    bcp.ColumnMappings.Add("SizeM3", "SizeM3");
                    bcp.ColumnMappings.Add("SizeM4", "SizeM4");
                    bcp.ColumnMappings.Add("SizeM5", "SizeM5");
                    bcp.ColumnMappings.Add("SizeM6", "SizeM6");
                    bcp.ColumnMappings.Add("SizeM7", "SizeM7");
                    bcp.ColumnMappings.Add("SizeM8", "SizeM8");
                    bcp.WriteToServer(dt);
                }
                //修改IsOnlineSKU值为1
                Edge.SVA.Model.IMP_PRODUCT temp = new SVA.Model.IMP_PRODUCT();
                Edge.SVA.BLL.IMP_PRODUCT bll = new SVA.BLL.IMP_PRODUCT();

                DataSet ds = bll.GetList("");
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        temp.IsOnlineSKU = 1;
                        if (!string.IsNullOrEmpty(item["Video"].ToString()))
                        {
                            temp.Video = url + item["Video"];
                        }
                        if (!string.IsNullOrEmpty(item["360Photos"].ToString()))
                        {
                            temp._360photos1 = url + item["360Photos"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos1"].ToString()))
                        {
                            temp.Photos1 = url + item["Photos1"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos2"].ToString()))
                        {
                            temp.Photos2 = url + item["Photos2"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos3"].ToString()))
                        {
                            temp.Photos3 = url + item["Photos3"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos4"].ToString()))
                        {
                            temp.Photos4 = url + item["Photos4"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos5"].ToString()))
                        {
                            temp.Photos5 = url + item["Photos5"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos6"].ToString()))
                        {
                            temp.Photos6 = url + item["Photos6"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos7"].ToString()))
                        {
                            temp.Photos7 = url + item["Photos7"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos8"].ToString()))
                        {
                            temp.Photos8 = url + item["Photos8"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos9"].ToString()))
                        {
                            temp.Photos9 = url + item["Photos9"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos10"].ToString()))
                        {
                            temp.Photos10 = url + item["Photos10"];
                        }
                        if (!string.IsNullOrEmpty(item["BARCODE"].ToString()))
                        {
                            temp.BARCODE = item["BARCODE"].ToString();
                        }
                        bll.UpdateTemp(temp);
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsetDataTEMP(DataTable dt)
        {

            string strConnection = PubConstant.ConnectionString;
            //获取或设置包含该应用程序的目录的名
            string url = @"/UploadFiles/ProdPic/";
            try
            {

                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConnection))
                {
                    bcp.BatchSize = 100;//每次传输的行数 
                    bcp.NotifyAfter = 100;//进度提示的行数 
                    bcp.DestinationTableName = "IMP_PRODUCT_TEMP";//需要导入的数据库表名
                    //excel表头与数据库列对应关系
                    bcp.ColumnMappings.Add("INTERNAL_PRODUCT_CODE", "INTERNAL_PRODUCT_CODE");
                    bcp.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
                    bcp.ColumnMappings.Add("BARCODE", "BARCODE");
                    bcp.ColumnMappings.Add("SUPPLIER_PRODUCT_CODE", "SUPPLIER_PRODUCT_CODE");
                    bcp.ColumnMappings.Add("BRAND", "BRAND");
                    bcp.ColumnMappings.Add("YEAR", "YEAR");
                    bcp.ColumnMappings.Add("SEASON", "SEASON");
                    bcp.ColumnMappings.Add("ARTICLE", "ARTICLE");
                    bcp.ColumnMappings.Add("SEX", "SEX");
                    bcp.ColumnMappings.Add("MODEL", "MODEL");
                    bcp.ColumnMappings.Add("COLOR", "COLOR");
                    bcp.ColumnMappings.Add("PSIZE", "PSIZE");
                    bcp.ColumnMappings.Add("CLASS", "CLASS");
                    bcp.ColumnMappings.Add("DESCRIPTION", "DESCRIPTION");
                    bcp.ColumnMappings.Add("REORDER_LEVEL", "REORDER_LEVEL");
                    bcp.ColumnMappings.Add("RETIRED", "RETIRED");
                    bcp.ColumnMappings.Add("RETIRE_DATE", "RETIRE_DATE");
                    bcp.ColumnMappings.Add("LAST_UPDATE_DATE", "LAST_UPDATE_DATE");
                    bcp.ColumnMappings.Add("LAST_UPDATE_USER", "LAST_UPDATE_USER");
                    bcp.ColumnMappings.Add("DESCRIPTION2", "DESCRIPTION2");
                    bcp.ColumnMappings.Add("SUPPLIER", "SUPPLIER");
                    bcp.ColumnMappings.Add("STANDARD_COST", "STANDARD_COST");
                    bcp.ColumnMappings.Add("SIZE_RANGE", "SIZE_RANGE");
                    bcp.ColumnMappings.Add("HS_CODE", "HS_CODE");
                    bcp.ColumnMappings.Add("EXPORT_COST", "EXPORT_COST");
                    bcp.ColumnMappings.Add("LOCAL_DESCRIPTION", "LOCAL_DESCRIPTION");
                    bcp.ColumnMappings.Add("COO", "COO");
                    bcp.ColumnMappings.Add("MATERIAL_1", "MATERIAL_1");
                    bcp.ColumnMappings.Add("MATERIAL_2", "MATERIAL_2");
                    bcp.ColumnMappings.Add("DESIGNER", "DESIGNER");
                    bcp.ColumnMappings.Add("BUYER", "BUYER");
                    bcp.ColumnMappings.Add("MERCHANDISER", "MERCHANDISER");
                    bcp.ColumnMappings.Add("SKU", "SKU");
                    bcp.ColumnMappings.Add("AVG_COST", "AVG_COST");
                    bcp.ColumnMappings.Add("PRICE", "PRICE");
                    bcp.ColumnMappings.Add("FINAL_DISCOUNT_PRICE", "FINAL_DISCOUNT_PRICE");
                    bcp.ColumnMappings.Add("ShortDescription1", "ShortDescription1");
                    bcp.ColumnMappings.Add("ShortDescription2", "ShortDescription2");
                    bcp.ColumnMappings.Add("ShortDescription3", "ShortDescription3");
                    bcp.ColumnMappings.Add("Material1", "Material1");
                    bcp.ColumnMappings.Add("Material2", "Material2");
                    bcp.ColumnMappings.Add("Material3", "Material3");
                    bcp.ColumnMappings.Add("Detailed1", "Detailed1");
                    bcp.ColumnMappings.Add("Detailed2", "Detailed2");
                    bcp.ColumnMappings.Add("Detailed3", "Detailed3");
                    bcp.ColumnMappings.Add("Design1", "Design1");
                    bcp.ColumnMappings.Add("Design2", "Design2");
                    bcp.ColumnMappings.Add("Design3", "Design3");
                    bcp.ColumnMappings.Add("ProductName1", "ProductName1");
                    bcp.ColumnMappings.Add("ProductName2", "ProductName2");
                    bcp.ColumnMappings.Add("ProductName3", "ProductName3");
                    bcp.ColumnMappings.Add("OuterLayerMaterials", "OuterLayerMaterials");
                    bcp.ColumnMappings.Add("InnerLayerMaterials", "InnerLayerMaterials");
                    bcp.ColumnMappings.Add("SizeCategory", "SizeCategory");
                    bcp.ColumnMappings.Add("Video", "Video");
                    bcp.ColumnMappings.Add("360Photos", "360Photos");
                    bcp.ColumnMappings.Add("Photos1", "Photos1");
                    bcp.ColumnMappings.Add("Photos2", "Photos2");
                    bcp.ColumnMappings.Add("Photos3", "Photos3");
                    bcp.ColumnMappings.Add("Photos4", "Photos4");
                    bcp.ColumnMappings.Add("Photos5", "Photos5");
                    bcp.ColumnMappings.Add("Photos6", "Photos6");
                    bcp.ColumnMappings.Add("Photos7", "Photos7");
                    bcp.ColumnMappings.Add("Photos8", "Photos8");
                    bcp.ColumnMappings.Add("Photos9", "Photos9");
                    bcp.ColumnMappings.Add("Photos10", "Photos10");
                    bcp.ColumnMappings.Add("SizeM1", "SizeM1");
                    bcp.ColumnMappings.Add("SizeM2", "SizeM2");
                    bcp.ColumnMappings.Add("SizeM3", "SizeM3");
                    bcp.ColumnMappings.Add("SizeM4", "SizeM4");
                    bcp.ColumnMappings.Add("SizeM5", "SizeM5");
                    bcp.ColumnMappings.Add("SizeM6", "SizeM6");
                    bcp.ColumnMappings.Add("SizeM7", "SizeM7");
                    bcp.ColumnMappings.Add("SizeM8", "SizeM8");
                    bcp.WriteToServer(dt);
                }

                //修改IsOnlineSKU值为1
                Edge.SVA.Model.IMP_PRODUCT_TEMP temp = new SVA.Model.IMP_PRODUCT_TEMP();
                Edge.SVA.BLL.IMP_PRODUCT_TEMP bll = new SVA.BLL.IMP_PRODUCT_TEMP();

                DataSet ds = bll.GetList("");
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        temp.IsOnlineSKU = 1;
                        if (!string.IsNullOrEmpty(item["Video"].ToString()))
                        {
                            temp.Video = url + item["Video"];
                        }
                        if (!string.IsNullOrEmpty(item["360Photos"].ToString()))
                        {
                            temp._360photos1 = url + item["360Photos"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos1"].ToString()))
                        {
                            temp.Photos1 = url + item["Photos1"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos2"].ToString()))
                        {
                            temp.Photos2 = url + item["Photos2"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos3"].ToString()))
                        {
                            temp.Photos3 = url + item["Photos3"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos4"].ToString()))
                        {
                            temp.Photos4 = url + item["Photos4"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos5"].ToString()))
                        {
                            temp.Photos5 = url + item["Photos5"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos6"].ToString()))
                        {
                            temp.Photos6 = url + item["Photos6"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos7"].ToString()))
                        {
                            temp.Photos7 = url + item["Photos7"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos8"].ToString()))
                        {
                            temp.Photos8 = url + item["Photos8"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos9"].ToString()))
                        {
                            temp.Photos9 = url + item["Photos9"];
                        }
                        if (!string.IsNullOrEmpty(item["Photos10"].ToString()))
                        {
                            temp.Photos10 = url + item["Photos10"];
                        }
                        if (!string.IsNullOrEmpty(item["BARCODE"].ToString()))
                        {
                            temp.BARCODE = item["BARCODE"].ToString();
                        }
                        bll.UpdateTemp(temp);
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ImportProcedure()
        {
            int i = 0;
            SqlDataReader sqlDataReader = DbHelperSQL.RunProcedure("DoImportProduct_Bauhaus");
            i++;
            sqlDataReader.Close();
            return i;
        }
        public string StrReverse(string str)
        {
            char[] chars = str.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append(chars[chars.Length - 1 - i]);
            }
            return sb.ToString();
        }
    }
    public class ImportModelList
    {
        private List<string> error = new List<string>();
        public List<string> Error { get { return error; } }
        public int Addrecords { get; set; }
        public int Updaterecords { get; set; }
        public int Deletedrecords { get; set; }
        public bool Success
        {
            get
            {
                if (this.Error.Count > 0)
                {
                    return false;
                }
                if (Addrecords == 0 && Updaterecords == 0 && Deletedrecords == 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}