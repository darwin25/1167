using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Edge.Security.Manager;
using System.Xml;

namespace Edge.Web
{
    public partial class AdminConfig : PageBase
    {
        private Edge.Security.Manager.WebSet bll = new Edge.Security.Manager.WebSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadWebSet();
            }
        }

        public void LoadWebSet()
        {
            //赋值给对应的控件
            //txtWebName.Text = webset.WebName;
            txtWebUrl.Text = webset.WebUrl;
            txtWebTel.Text = webset.WebTel;
            txtWebFax.Text = webset.WebFax;
            txtWebEmail.Text = webset.WebEmail;
            txtWebCrod.Text = webset.WebCrod;
            txtWebKeywords.Text = webset.WebKeywords.ToString();
            txtWebDescription.Text = webset.WebDescription.ToString();
            txtWebCopyright.Text = webset.WebCopyright;

            txtWebPath.Text = webset.WebPath;
            txtWebManagePath.Text = webset.WebManagePath;
            txtWebFilePath.Text = webset.WebFilePath.ToString();
            txtWebFileType.Text = webset.WebFileType.ToString();
            txtWebFileSize.Text = webset.WebFileSize.ToString();
            rblWebLogStatus.SelectedValue = webset.WebLogStatus.ToString();
            txtWebKillKeywords.Text = webset.WebKillKeywords.ToString();

            txtContentPageNum.Text = webset.ContentPageNum.ToString();


            txtMaxShowNum.Text = webset.MaxShowNum.ToString();
            txtMaxSearchNum.Text = webset.MaxSearchNum.ToString();


            //优惠券状态设置
            cbgVoidStatus.SelectedValueArray = webset.CouponVoidStatusEnable.Split(',');
            cbgChangeStatus.SelectedValueArray = webset.CouponStatusChangeStatusEnable.Split(',');
            cbgExpiredStatus.SelectedValueArray = webset.CouponExpiryDateStatusEnable.Split(',');
            cbgChangeDenomination.SelectedValueArray = webset.CouponChangeDenominationEnable.Split(',');

            //撿貨單設置
            this.ddlCouponOrderPickingAllowSetting.SelectedValue = webset.CouponOrderPickingAllowSetting;

            //是否激活優惠券
            this.rblCouponShipmentConfirmationSwitch.SelectedValue = webset.CouponShipmentConfirmationSwitch.ToString();

            //InitCheckBoxGroupCheckedValues(webset.CouponVoidStatusEnable, this.cbgVoidStatus);
            //InitCheckBoxGroupCheckedValues(webset.CouponStatusChangeStatusEnable, this.cbgChangeStatus);
            //InitCheckBoxGroupCheckedValues(webset.CouponExpiryDateStatusEnable, this.cbgExpiredStatus);
            //this.mchkVoidStatus.SelectedValue = webset.CouponVoidStatusEnable;
            // this.mchkChangeStatus.SelectedValue = webset.CouponStatusChangeStatusEnable;
            // this.mchkExpiredStatus.SelectedValue = webset.CouponExpiryDateStatusEnable;

            //  ddlLanList.SelectedIndex = ddlLanList.Items.IndexOf(ddlLanList.Items.FindByValue(webset.SiteLanguage));

            this.tbUserDefaultPassword.Text = webset.UserDefaultPassword;


            //广告界面上传文件时的HardCode地址（Len）
            this.txtAttchFileServer.Text = webset.AttchFileServer;

            //图片格式限制(Len)
            this.txtWebImageType.Text = webset.WebImageType;
            //CardGrade界面的上传文件格式限制
            this.txtCardGradeFileType.Text = webset.CardGradeFileType;
            //CouponType界面的上传文件格式限制
            this.txtCouponTypeFileType.Text = webset.CouponTypeFileType;
            //DistributeTemplate界面的上传文件格式限制
            this.txtDistributeTemplateType.Text = webset.DistributeTemplateFileType;
            //Advertisement界面的上传文件格式限制
            this.txtAdvertisementFileType.Text = webset.DistributeTemplateFileType;
            //MemberInfo界面的上传文件格式限制
            this.txtMemberInfoFileType.Text = webset.MemberInfoFileType;
            //ImporBIFileType界面的上传文件格式限制
            this.txtImporBIFileType.Text = webset.ImporBIFileType;
            //CouponCreateFileType界面的上传文件格式限制
            this.txtCouponCreateFileType.Text = webset.CouponCreateFileType;

            //是否转换文本为大小写
            this.rblIsConvertToUpper.SelectedValue = Convert.ToInt32(webset.IsConvertToUpper).ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //赋值给MODEL
                Edge.Security.Model.WebSet model = new Edge.Security.Model.WebSet();
                model.WebName = txtWebName.Text;
                model.WebUrl = txtWebUrl.Text;
                model.WebTel = txtWebTel.Text;
                model.WebFax = txtWebFax.Text;
                model.WebEmail = txtWebEmail.Text;
                model.WebCrod = txtWebCrod.Text;
                model.WebCopyright = txtWebCopyright.Text;
                model.WebKeywords = txtWebKeywords.Text.Trim();
                model.WebDescription = txtWebDescription.Text.Trim();

                model.WebPath = txtWebPath.Text;
                model.WebManagePath = txtWebManagePath.Text;
                model.WebFilePath = txtWebFilePath.Text;
                model.WebFileType = txtWebFileType.Text;
                model.WebFileSize = Edge.Web.Tools.ConvertTool.ToInt(txtWebFileSize.Text.Trim());
                model.WebLogStatus = int.Parse(rblWebLogStatus.SelectedValue);
                model.WebKillKeywords = txtWebKillKeywords.Text.Trim();
                model.ContentPageNum = Edge.Web.Tools.ConvertTool.ToInt(txtContentPageNum.Text.Trim());

                model.MaxShowNum = Edge.Web.Tools.ConvertTool.ToInt(txtMaxShowNum.Text.Trim());
                model.MaxSearchNum = Edge.Web.Tools.ConvertTool.ToInt(txtMaxSearchNum.Text.Trim());

                //保证当前模板不丢失
                // model.TemplateSkin = webset.TemplateSkin;
                // model.SiteLanguage = ddlLanList.SelectedItem.Value.Trim();

                //优惠券状态设置
                //model.CouponVoidStatusEnable = this.mchkVoidStatus.SelectedValue;
                //model.CouponStatusChangeStatusEnable = this.mchkChangeStatus.SelectedValue;
                //model.CouponExpiryDateStatusEnable = this.mchkExpiredStatus.SelectedValue;

                model.CouponVoidStatusEnable =GetStringListByStringArray(cbgVoidStatus.SelectedValueArray);
                model.CouponStatusChangeStatusEnable = GetStringListByStringArray(cbgChangeStatus.SelectedValueArray);
                model.CouponExpiryDateStatusEnable = GetStringListByStringArray(cbgExpiredStatus.SelectedValueArray);
                model.CouponChangeDenominationEnable = GetStringListByStringArray(cbgChangeDenomination.SelectedValueArray);

                //撿貨單設置
                model.CouponOrderPickingAllowSetting = this.ddlCouponOrderPickingAllowSetting.SelectedValue;

                //是否激活優惠券
                model.CouponShipmentConfirmationSwitch = Tools.ConvertTool.ConverType<int>(this.rblCouponShipmentConfirmationSwitch.SelectedValue);

                model.UserDefaultPassword = this.tbUserDefaultPassword.Text.Trim();

                //广告界面上传文件时的HardCode地址（Len）
                model.AttchFileServer = txtAttchFileServer.Text;
                //图片格式限制(Len)
                model.WebImageType = txtWebImageType.Text;
                //CardGrade界面的上传文件格式限制
                webset.CardGradeFileType = this.txtCardGradeFileType.Text;
                //CouponType界面的上传文件格式限制
                webset.CouponTypeFileType = this.txtCouponTypeFileType.Text;
                //DistributeTemplate界面的上传文件格式限制
                webset.DistributeTemplateFileType = this.txtDistributeTemplateType.Text;
                //Advertisement界面的上传文件格式限制
                webset.DistributeTemplateFileType = this.txtAdvertisementFileType.Text;
                //MemberInfo界面的上传文件格式限制
                webset.MemberInfoFileType = this.txtMemberInfoFileType.Text;
                //ImporBIFileType界面的上传文件格式限制
                webset.ImporBIFileType = this.txtImporBIFileType.Text;
                //CouponCreateFileType界面的上传文件格式限制
                webset.CouponCreateFileType = this.txtCouponCreateFileType.Text;

                //是否转换文本为大小写
                model.IsConvertToUpper = Convert.ToBoolean(Convert.ToInt32(this.rblIsConvertToUpper.SelectedValue));

                ////修改配置信息
                bll.saveConifg(model, Server.MapPath(ConfigurationManager.AppSettings["Configpath"].ToString()));



                //保存日志
                // SaveLogs("[系统管理]修改系统配置文件");

                // RefreshParentPage();
                
                PermissionMapper.GetSingleton().SetWebVirtualPath(model.WebPath);
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath("~/XmlConfig/WebPages.config"));
                XmlNodeList xnl = doc.SelectNodes("//WebPages/PublicWebPages/Page");
                foreach (XmlNode item in xnl)
                {
                    string url = item.Attributes["Url"].Value;
                    if (url.Equals(string.Empty))
                    {
                        continue;
                    }
                    string permissionID = item.Attributes["PermissionID"].Value;
                    int id = -1;
                    if (int.TryParse(permissionID, out id))
                    {
                        PermissionMapper.GetSingleton().AddSpecialPage(url, id);
                    }
                    else
                    {
                        PermissionMapper.GetSingleton().AddSpecialPage(url, -1);
                    }
                }
                PermissionMapper.GetSingleton().Refresh();

                FineUI.Alert.ShowInTop("System Setting Success!",FineUI.MessageBoxIcon.Information);
               // FineUI.PageContext.Redirect("AdminCenter.aspx");
                //JscriptPrint("System Setting Success!", "AdminCenter.aspx", "Success");
            }
            catch
            {
                FineUI.Alert.ShowInTop("<b>Save Failed !</b>Please check write permissions, if not, please contact the administrator to open the permission to write to the file!",FineUI.MessageBoxIcon.Error);
                // JscriptPrint("<b>Save Failed !</b>Please check write permissions, if not, please contact the administrator to open the permission to write to the file!", "AdminCenter.aspx", "Error");
            }
        }

        private string GetStringListByStringArray(string[] stringArray)
        {
            string strReturn = "";
            foreach (string str in stringArray)
            {
                strReturn += str+",";
            
            }

            strReturn=strReturn.TrimEnd(',');

            return strReturn;
        }

    }
}
