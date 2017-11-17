using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Edge.Web.Controllers;
using Edge.Web.Tools;
using System.Data;
using System.Text.RegularExpressions;
using Edge.SVA.Model.Domain.Surpport;
using System.Data.SqlClient;
using Edge.SVA.Model.Domain.WebInterfaces;
using FineUI;
using System.Windows.Forms;
using Edge.Messages.Manager;

namespace Edge.Web.PublicForms
{
    public partial class ImportForm : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnSaveClose2.OnClientClick = FineUI.Confirm.GetShowReference("确认要导入下架产品吗？", String.Empty, FineUI.MessageBoxIcon.Question, btnSaveClose2.GetPostBackEventReference(), String.Empty);
                if (Request["Menu"].ToLower() == "nosalesproduct")
                {
                    btnSaveClose.Hidden = true;
                    btnSaveClose2.Hidden = false;
                }
                else
                {
                    btnSaveClose.Hidden = false;
                    btnSaveClose2.Hidden = true;
                }
                btnSaveClose2.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnSaveClose2.ConfirmText = Resources.MessageTips.ConfirmNoProductModifyTemp;

                RegisterCloseEvent(btnClose);
            }
        }
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (ValidateFile())
            {
                if (Request["Menu"].ToLower() == "store")
                {
                    string pathFile = this.ImportFile.SaveToServer("Images/Store");
                    string path = Server.MapPath("~" + pathFile);
                    DataTable dt = ExcelTool.GetFirstSheet(path);
                    SVASessionInfo.ImportStorePath = path;
                }
                if (Request["Menu"].ToLower() == "product")
                {
                    string pathFile = this.ImportFile.SaveToServer("Images/Product");
                    string path = Server.MapPath("~" + pathFile);
                    DataTable dt = ExcelTool.GetFirstSheet(path);
                    SVASessionInfo.ImportIMP_PRODUCTPath = path;
                }
                //if (Request["Menu"].ToLower() == "nosalesproduct")
                //{
                //    string pathFile = this.ImportFile.SaveToServer("Images/NoSalesProduct");
                //    string path = Server.MapPath("~" + pathFile);
                //    DataTable dt = ExcelTool.GetFirstSheet(path);
                //    SVASessionInfo.ImportNoSalesProductTPath = path;

                //}
                if (Request["Menu"].ToLower() == "productmodifytemp")
                {
                    string pathFile = this.ImportFile.SaveToServer("Images/ProductModifyTemp");
                    string path = Server.MapPath("~" + pathFile);
                    DataTable dt = ExcelTool.GetFirstSheet(path);
                    SVASessionInfo.ProductModifyTempPath = path;
                }
                CloseAndPostBack();
            }
        }

        protected bool ValidateFile()
        {
            if (Request["Menu"].ToLower() == "store")
            {
                if (string.IsNullOrEmpty(this.ImportFile.ShortFileName))
                {
                    ShowWarning(Resources.MessageTips.NoData);
                    return false;
                }
                string filename = Path.GetExtension(this.ImportFile.ShortFileName).TrimStart('.');
                if (filename.ToLower() != "xls")
                {
                    ShowWarning(Resources.MessageTips.FileUpLoadFailed.Replace("{0}", "XLS"));
                    return false;
                }
            }
            return true;
        }
    }
}