using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using System.Web.UI.WebControls;
using Edge.Security.Manager;
using System.Web.Security;
using System.Web.UI;

namespace Edge.Web.Tools
{
    /// <summary>
    /// 设置页面值(根据MVC模式)
    /// </summary>
    /// <typeparam name="bll">页面相关的业务逻辑类</typeparam>
    /// <typeparam name="Moele">页面相关的Model类</typeparam>
    public class BasePage<BLLClass, ModelClass> : PageBase
        where BLLClass : new()
        where ModelClass : class, new()
    {
        private ModelClass model = default(ModelClass);

        public ModelClass Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// 加载完成时设置控件值，若需要修改控件值，在子类重写OnLoadComplete在加载完基本后
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!this.IsPostBack)
            {
                if (hasRight)
                {
                    try
                    {
                    string id = Request.Params["id"];
                    if (string.IsNullOrEmpty(id)) return;
                    this.Model = GetObject(id) as ModelClass;
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                    DoAfterModelSet();
                    SetObject();
                }
                else
                {
                    this.Model = new ModelClass();
                }
            }
        }
        protected virtual void DoAfterModelSet()
        {

        }

        #region 获取、设置控件的值
        /// <summary>
        /// 当新增自定义控件时，请修改此函数(同时修改设置控件函数)
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private string GetControlText(System.Web.UI.Control con)
        {
            if (con is FineUI.Label)
            {
                FineUI.Label lbl = con as FineUI.Label;
                return lbl.Text;
            }
            else if (con is FineUI.TextBox)
            {
                FineUI.TextBox txt = con as FineUI.TextBox;
                return txt.Text;
            }
            else if (con is FineUI.DropDownList)
            {
                FineUI.DropDownList ddl = con as FineUI.DropDownList;
                return ddl.SelectedValue;
            }
            else if (con is FineUI.RadioButtonList)
            {
                FineUI.RadioButtonList rbl = con as FineUI.RadioButtonList;
                return rbl.SelectedValue;
            }
            else if (con is FineUI.HiddenField)
            {
                FineUI.HiddenField hf = con as FineUI.HiddenField;
                return hf.Text;
            }
            else if (con is FineUI.NumberBox)
            {
                FineUI.NumberBox nb = con as FineUI.NumberBox;
                return nb.Text;
            }
            else if (con is FineUI.DatePicker)
            {
                FineUI.DatePicker dp = con as FineUI.DatePicker;
                return dp.Text;
            }
            else if (con is FineUI.TimePicker)//add by len
            {
                FineUI.TimePicker tp = con as FineUI.TimePicker;
                return tp.Text;
            }
            else if (con is FineUI.HtmlEditor) //add by len
            {
                FineUI.HtmlEditor he = con as FineUI.HtmlEditor;
                return he.Text;
            }


            return "";
        }

        /// <summary>
        /// 当新增自定义控件时，请修改此函数(同时修改获取控件函数)
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private void SetControlText(string value, System.Web.UI.Control con)
        {
            if (con is FineUI.Label)
            {
                FineUI.Label lbl = con as FineUI.Label;
                lbl.Text = value == null ? "" : RemainVal(value);
            }
            else if (con is FineUI.TextBox)
            {
                FineUI.TextBox txt = con as FineUI.TextBox;
                txt.Text = value == null ? "" : RemainVal(value);           
            }
            else if (con is FineUI.DropDownList)
            {
                FineUI.DropDownList ddl = con as FineUI.DropDownList;
                ddl.SelectedValue = value == null ? "" : value;
            }
            else if (con is FineUI.RadioButtonList)
            {
                FineUI.RadioButtonList rbl = con as FineUI.RadioButtonList;
                rbl.SelectedValue = value == null ? "" : value;
            }
            else if (con is FineUI.HiddenField)
            {
                FineUI.HiddenField hf = con as FineUI.HiddenField;
                hf.Text = value == null ? "" : value;
            }
            else if (con is FineUI.NumberBox)
            {
                FineUI.NumberBox nb = con as FineUI.NumberBox;
                value=value.Replace(",",string.Empty);
                nb.Text = value == null ? "" : value;
                //int val = 0;
                //if (int.TryParse(value,out val))
                //{
                //    nb.Text = val.ToString();
                //} 
                //else
                //{
                //    nb.Text = string.Empty;
                //}
            }
            else if (con is FineUI.DatePicker)
            {
                FineUI.DatePicker dp = con as FineUI.DatePicker;
                dp.Text = value == null ? "" : value;
            }
            else if (con is FineUI.TimePicker) //add by len
            {
                FineUI.TimePicker tp = con as FineUI.TimePicker;
                tp.Text = value == null ? "" : value;
            }
            else if (con is FineUI.HtmlEditor)
            {
                FineUI.HtmlEditor tp = con as FineUI.HtmlEditor;
                tp.Text = value == null ? "" : RemainVal(value);
            }
        }

        #endregion

        #region 获取、设置对象的值
        /// <summary>
        /// 设置Form下Control的值
        /// </summary>
        /// <param name="obj"></param>

        public void GetControls(Control con,ref List<Control> list)
        {
            foreach (Control item in con.Controls)
            {
                if (item.Controls.Count>=1)
                {
                    GetControls(item, ref list);
                }
                else
                {
                    list.Add(item);
                }
            }
        }
        public void SetObject(object obj, System.Collections.IEnumerator enumerator)
        {
            if (obj == null) return;
            //foreach (PropertyInfo p in this.Properties)
            //{
            //    enumerator.Reset();
            //    while (enumerator.MoveNext())
            //    {
            //        System.Web.UI.Control con = enumerator.Current as System.Web.UI.Control;
            //        if (con is FineUI.SimpleForm) SetObject(obj, con.Controls.GetEnumerator());
            //        if (con is FineUI.Form) SetObject(obj, con.Controls.GetEnumerator());
            //        if (con is FineUI.FormRow) SetObject(obj, con.Controls.GetEnumerator());
            //        if (con is FineUI.GroupPanel) SetObject(obj, con.Controls.GetEnumerator());
            //        if (con == null || con.ID != p.Name) continue;

            //        object value = p.GetValue(obj, null);
            //        string text = GetTextByType(value);
            //        SetControlText(text, con);
            //        break;
            //    }
            //}

            List<Control> list = new List<Control>();
            GetControls(this.Form, ref list);
            foreach (Control item in list)
            {
                if (!string.IsNullOrEmpty(item.ID))
                {
                    PropertyInfo pi = obj.GetType().GetProperty(item.ID);
                    if (pi != null)
                    {
                        object value = pi.GetValue(obj, null);
                        string text = GetTextByType(value);
                        SetControlText(text, item);
                    }
                }               
            }
        }

        protected ModelClass GetDataObject()
        {
            if (string.IsNullOrEmpty(Request.Params["id"]))
                  return null;
            else
                return DALTool.GetObject<BLLClass>(Request.Params["id"]) as ModelClass;
        }

        protected ModelClass GetUpdateObject()
        {
            if (string.IsNullOrEmpty(Request.Params["id"])) return default(ModelClass);

            return GetUpdateObject(Request.Params["id"]);
        }

        protected ModelClass GetUpdateObject(object id)
        {
            ModelClass obj=null;
            try
            {
                obj = this.GetObject(id);
            }
            catch (System.Exception ex)
            {
            	
            }
            if (obj == null) obj= new ModelClass();

            return GetPageObject(obj);
        }

        protected ModelClass GetAddObject()
        {
            ModelClass m = new ModelClass();
            return GetPageObject(m);
        }

        protected ModelClass GetPageObject(ModelClass obj, System.Collections.IEnumerator enumerator)
        {
            //foreach (PropertyInfo p in this.Properties)
            //{
            //    enumerator.Reset();

            //    while (enumerator.MoveNext())
            //    {
            //        System.Web.UI.Control con = enumerator.Current as System.Web.UI.Control;
                  
            //        if (con is FineUI.SimpleForm) GetPageObject(obj, con.Controls.GetEnumerator());
            //        if (con is FineUI.Form) GetPageObject(obj, con.Controls.GetEnumerator());
            //        if (con is FineUI.FormRow) GetPageObject(obj, con.Controls.GetEnumerator());
            //        if (con is FineUI.GroupPanel) GetPageObject(obj, con.Controls.GetEnumerator());
                    
            //        if (con.ID != p.Name) continue;
            //        string text = GetControlText(con);
            //        try
            //        {
                        
            //        object objValue = GetValue(p, text);
                    
            //         p.SetValue(obj, objValue, null);
            //        }
            //        catch (Exception e)
            //        {
                        
            //            throw e;
            //        }
            //        break;
            //    }

            //}

            List<Control> list = new List<Control>();
            GetControls(this.Form, ref list);
            foreach (Control item in list)
            {
                if (!string.IsNullOrEmpty(item.ID))
                {
                    PropertyInfo pi = obj.GetType().GetProperty(item.ID);
                    if (pi != null)
                    {

                        string text = GetControlText(item);
                        try
                        {

                            object objValue = GetValue(pi, text);

                            pi.SetValue(obj, objValue, null);
                        }
                        catch (Exception e)
                        {

                            throw e;
                        }
                    }
                }
            }
            return obj as ModelClass;
        }

        protected virtual ModelClass GetPageObject(ModelClass obj)
        {
            return this.GetPageObject(obj, this.Form.Controls.GetEnumerator());
        }

        protected virtual void SetObject()
        {            
            this.SetObject(this.Model, this.Form.Controls.GetEnumerator());
        }

        #endregion

        #region Common 私有辅助函数

        private ModelClass GetObject(object id)
        {
            return DALTool.GetObject<BLLClass>(id) as ModelClass;
        }

        private string GetTextByType(object value)
        {
            if (value == null) return "";

            Type type = value.GetType();

            if (type.FullName == "System.String")
            {
                return value.ToString();
            }
            else if (type.FullName == "System.DateTime")
            {
                DateTime dt = (DateTime)value;
                return dt.ToString("yyyy-MM-dd");
            }
            else if (type.FullName == "System.Decimal")
            {
                decimal num = (decimal)value;
                return num.ToString("N");
            }
            else if (type.FullName == "System.Single")
            {
                Single num = (Single)value;
                return num.ToString("N");
            }
            else if (type.FullName == "System.Double")
            {
                Double num = (Double)value;
                return num.ToString("N");
            }
            else if (type.FullName == "System.Int32")
            {
                int num = (int)value;
                return num.ToString("N00");
            }

            return value.ToString();
        }

        private object GetValue(PropertyInfo pi, string value)          //todo:必填字段，页面没加验证。这里要判断
        {
            if (pi.PropertyType.Name == "Nullable`1")             //如int? DateTime?
            {
                if (string.IsNullOrEmpty(value)) return null;
                PropertyInfo pValue = pi.PropertyType.GetProperty("Value");
                return GetValue(pValue, value);
            }
            if (pi.PropertyType.FullName == "System.Int32")
            {
                value = value.Replace(",", "");
            }

            return ConvertTool.ChangeType(pi.PropertyType, value);
        }

        private System.Reflection.PropertyInfo[] properties = null;
        private System.Reflection.PropertyInfo[] Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = typeof(ModelClass).GetProperties();
                }
                return properties == null ? new System.Reflection.PropertyInfo[0] : properties;
            }
        }
        #endregion

        #region text改变为大写
        protected virtual void ConvertTextboxToUpperText(object sender, EventArgs e)
        {
            FineUI.RealTextField tf=sender as FineUI.RealTextField;            
            if (tf!=null)
            {
                tf.Text=tf.Text.ToUpper();
            }
        }

        protected virtual void ConvertTextBoxToUpperByConfig()
        {
            List<Control> list = new List<Control>();
            GetControls(this.Form, ref list);
            foreach (Control item in list)
            {
                if (item is FineUI.TextBox)
                {
                    if (!string.IsNullOrEmpty(item.UniqueID))
                    {            
                        //界面示例：listeners:{change:function(){__doPostBack('SimpleForm1$BankName1','');}}
                        string script = "listeners:{change:function(){__doPostBack('" + item.UniqueID + "','');}}";
                        FineUI.PageContext.RegisterStartupScript(script);                        
                    }
                }
            }
            if (webset.IsConvertToUpper)
            {
 
            }
        }
        #endregion
    }
}
