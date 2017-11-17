using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Edge.Web.Controls
{
    public partial class UploadFileBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string value = string.Format("SingleUpload('{0}','{1}','{2}','{3}','{4}')", this.UploadText.ClientID,this.UploadValue.ClientID,
                this.Files.UniqueID, SubSaveFilePath, Page.ResolveClientUrl("~/Ashx/SingleUpload.ashx"));
            this.Files.Attributes.Add("onchange", value);

            if (FileType == FileBoxType.pictures)               //图片模式
            {
                this.fileUpload.Attributes["class"] = "pictures";
                this.delete.Attributes["onclick"] = string.Format("javacript:$('#{0},#{1}').val('');", this.UploadText.ClientID,this.UploadValue.ClientID);
            }
            else if (FileType == FileBoxType.files)             //文件上传模式
            {
                this.fileUpload.Attributes["class"] = "files";
                this.preview.Visible = false;
                this.delete.Attributes["onclick"] = string.Format("javacript:$('#{0},#{1}').val('');", this.UploadText.ClientID, this.UploadValue.ClientID);
            }
            else if (FileType == FileBoxType.preview)          //预览图片模式
            {
                this.fileUpload.Attributes["class"] = "pictures";
                this.UploadText.Enabled = false;
                this.fileUpload.Visible = false;
                this.delete.Visible = false;
            }

        }

        [Browsable(true)]               //该项属性是否会显示在控件的“属性”窗口中  
        public string SubSaveFilePath
        {
            get;
            set;
        }

        [Browsable(true)]
        public string Text
        {
            get
            {
                return this.UploadValue.Value;
            }
            set
            {
                this.UploadText.Text = value;
                this.UploadValue.Value = value;
            }
        }

        private FileBoxType fileType = FileBoxType.pictures;

        [Browsable(true)]
        public FileBoxType FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        [Browsable(true)]
        public string HintTitle
        {
            set
            {
                this.UploadText.Attributes["HintTitle"] = value;
            }
        }

        [Browsable(true)]
        public string HintInfo
        {
            set
            {
                this.UploadText.Attributes["HintInfo"] = value;
            }
        }

        public string FullName
        {
            get
            {
                string fileName = this.UploadValue.Value;
                if (HttpContext.Current.Request.ApplicationPath != "/")
                {
                    fileName = HttpContext.Current.Request.ApplicationPath + fileName;
                }

                if (string.IsNullOrEmpty(fileName)) return "";

                if (!System.IO.File.Exists(Server.MapPath(fileName))) return "";

                return Server.MapPath(fileName);
            }
        }

        public string FileName
        {
            get
            {
                return this.UploadValue.Value;
            }
        }

    }


    public enum FileBoxType
    {
        /// <summary>
        /// 文件上传模式
        /// </summary>
        files = 0,
        /// <summary>
        /// 图片上传模式
        /// </summary>
        pictures = 1,
        /// <summary>
        /// 图片预览模式
        /// </summary>
        preview = 2
    }
}