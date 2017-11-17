using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Controllers;
using Edge.Utils.Tools;
using System.Text;
using Edge.SVA.Model.Domain.SVA;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain.WebService.Request;
using Edge.SVA.Model.Domain.WebService.Response;
using System.Collections;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP;

namespace Edge.Web.Tools
{
    /// <summary>
    /// 封装控件相关操作
    /// </summary>
    public class ControlTool
    {

        /// <summary>
        /// 根据当前语言绑定数据源到DropdownList
        /// </summary>
        /// <param name="ddl">要绑定的DropdownList</param>
        /// <param name="source">数据源</param>
        /// <param name="keyValue">DropdownList Value的值</param>
        /// <param name="keyText1">英文-> 数据库名字1</param>
        /// <param name="keyText2">简体中文-> 数据库名字2</param>
        /// <param name="keyText3">繁体中文-> 数据库名字3</param>
        public static void BindDataSet(DropDownList ddl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3)
        {
            ddl.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);

                foreach (DataRow dr in source.Tables[0].Rows)
                {

                    ListItem li = new ListItem() { Value = dr[keyValue].ToString().Trim(), Text = dr[key].ToString().Trim() };
                    li.Attributes["title"] = dr[key].ToString().Trim();
                    ddl.Items.Add(li);
                }
            }

            ddl.Items.Insert(0, new ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }



        /// <summary>
        /// 根据当前语言绑定数据源到DropdownList
        /// </summary>
        /// <param name="ddl">要绑定的DropdownList</param>
        /// <param name="source">数据源</param>
        /// <param name="keyValue">DropdownList Value的值</param>
        /// <param name="keyText1">英文-> 数据库名字1</param>
        /// <param name="keyText2">简体中文-> 数据库名字2</param>
        /// <param name="keyText3">繁体中文-> 数据库名字3</param>
        public static void BindDataSet(FineUI.DropDownList ddl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3)
        {
            ddl.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);

                foreach (DataRow dr in source.Tables[0].Rows)
                {

                    FineUI.ListItem li = new FineUI.ListItem() { Value = dr[keyValue].ToString().Trim(), Text = dr[key].ToString().Trim() };
                    //li.Attributes["title"] = dr[key].ToString().Trim();
                    ddl.Items.Add(li);
                }
            }

            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });//Add by Nathan for All dropdownlist default value.
        }

        /// <summary>
        /// 根据当前语言绑定数据源到DropdownList
        /// </summary>
        /// <param name="ddl">要绑定的DropdownList</param>
        /// <param name="source">数据源</param>
        /// <param name="keyValue">DropdownList Value的值</param>
        /// <param name="keyText1">英文-> 数据库名字1</param>
        /// <param name="keyText2">简体中文-> 数据库名字2</param>
        /// <param name="keyText3">繁体中文-> 数据库名字3</param>
        public static void BindDataSet(DropDownList ddl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3, string code)
        {
            ddl.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    string text = GetDropdownListText(dr[key].ToString().Trim(), dr[code].ToString().Trim());
                    ListItem li = new ListItem() { Value = dr[keyValue].ToString().Trim(), Text = text };
                    li.Attributes.Add("title", text);

                    ddl.Items.Add(li);
                }
            }

            ddl.Items.Insert(0, new ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }


        /// <summary>
        /// 根据当前语言绑定数据源到DropdownList
        /// </summary>
        /// <param name="ddl">要绑定的DropdownList</param>
        /// <param name="source">数据源</param>
        /// <param name="keyValue">DropdownList Value的值</param>
        /// <param name="keyText1">英文-> 数据库名字1</param>
        /// <param name="keyText2">简体中文-> 数据库名字2</param>
        /// <param name="keyText3">繁体中文-> 数据库名字3</param>
        public static void BindDataSet(FineUI.DropDownList ddl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3, string code)
        {
            ddl.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    string text = GetDropdownListText(dr[key].ToString().Trim(), dr[code].ToString().Trim());
                    FineUI.ListItem li = new FineUI.ListItem() { Value = dr[keyValue].ToString().Trim(), Text = text };
                    //li.Attributes.Add("title", text);
                    ddl.Items.Add(li);
                }
            }

            //if (!ddl.Required)
            //{
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });//Add by Nathan for All dropdownlist default value.
            //}
        }



        public static string GetDropdownListText(string text, string code)
        {
            return string.Format("{0} - {1}", code, text);
        }

        public static void AddTitle(DropDownList ddl)
        {
            if (ddl == null) return;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                ddl.Items[i].Attributes.Add("title", ddl.Items[i].Text);
            }
        }


        public static void BindDictionaryValueKey(DropDownList ddl, Dictionary<string, string> source)
        {
            ddl.Items.Clear();
            foreach (KeyValuePair<string, string> keyValue in source)
            {
                ListItem li = new ListItem() { Value = keyValue.Value, Text = keyValue.Key };
                li.Attributes["title"] = keyValue.Key;
                ddl.Items.Add(li);
            }

            ddl.Items.Insert(0, new ListItem() { Text = "", Value = "" });//Add by Nathan for All dropdownlist default value.
        }

        public static void BindDictionaryValueKey(FineUI.DropDownList ddl, Dictionary<string, string> source)
        {
            ddl.Items.Clear();
            foreach (KeyValuePair<string, string> keyValue in source)
            {
                FineUI.ListItem li = new FineUI.ListItem() { Value = keyValue.Value, Text = keyValue.Key };
                // li.Attributes["title"] = keyValue.Key;
                ddl.Items.Add(li);
            }

            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }
        /// <summary>
        /// 根据当前语言绑定数据源到CheckBoxList
        /// </summary>
        /// <param name="ddl">要绑定的CheckBoxList</param>
        /// <param name="source">数据源</param>
        /// <param name="keyValue">CheckBoxList Value的值</param>
        /// <param name="keyText1">英文-> 数据库名字1</param>
        /// <param name="keyText2">简体中文-> 数据库名字2</param>
        /// <param name="keyText3">繁体中文-> 数据库名字3</param>
        public static void BindDataSet(CheckBoxList ckbList, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3)
        {
            ckbList.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    ckbList.Items.Add(new ListItem() { Value = dr[keyValue].ToString().Trim(), Text = dr[key].ToString().Trim() });
                }
            }
        }

        public static void BindDataSet(FineUI.CheckBoxList ckbList, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3)
        {
            ckbList.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    ckbList.Items.Add(new FineUI.CheckItem() { Value = dr[keyValue].ToString().Trim(), Text = dr[key].ToString().Trim() });
                }
            }
        }

        public static void BindDataSetCheckboxList(CheckBoxList cbl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3)
        {
            if (source == null || source.Tables == null || source.Tables.Count <= 0) return;
            cbl.Items.Clear();
            string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);
            cbl.DataSource = source.Tables[0].DefaultView;
            cbl.DataTextField = key;
            cbl.DataValueField = keyValue;
            cbl.DataBind();
        }

        public static void BindDataSetCheckboxList(CheckBoxList cbl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3, List<string> keyValueList)
        {
            if (source == null || source.Tables == null || source.Tables.Count <= 0) return;
            cbl.Items.Clear();

            string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);

            foreach (DataRow dr in source.Tables[0].Rows)
            {
                dr["BrandName1"] = dr["BrandCode"] + "-" + dr["BrandName1"];
                dr["BrandName2"] = dr["BrandCode"] + "-" + dr["BrandName2"];
                dr["BrandName3"] = dr["BrandCode"] + "-" + dr["BrandName3"];
            }

            cbl.DataSource = source.Tables[0].DefaultView;
            cbl.DataTextField = key;
            cbl.DataValueField = keyValue;
            cbl.DataBind();

            foreach (ListItem item in cbl.Items)
            {
                if (keyValueList.Exists(i => i.Equals(item.Value)))
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
        public static void BindDataSetCheckboxList(FineUI.CheckBoxList cbl, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3, List<string> keyValueList)
        {
            if (source == null || source.Tables == null || source.Tables.Count <= 0) return;
            cbl.Items.Clear();

            string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);

            foreach (DataRow dr in source.Tables[0].Rows)
            {
                dr["BrandName1"] = dr["BrandCode"] + "-" + dr["BrandName1"];
                dr["BrandName2"] = dr["BrandCode"] + "-" + dr["BrandName2"];
                dr["BrandName3"] = dr["BrandCode"] + "-" + dr["BrandName3"];
            }

            cbl.DataSource = source.Tables[0].DefaultView;
            cbl.DataTextField = key;
            cbl.DataValueField = keyValue;
            cbl.DataBind();

            foreach (FineUI.CheckItem item in cbl.Items)
            {
                if (keyValueList.Exists(i => i.Equals(item.Value)))
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
       
      
        /// <summary>
        /// 绑定所有品牌
        /// </summary>
        /// <param name="ddl">品牌DropdownList</param>
        public static void BindStoreBrand(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.Brand().GetList("1 = 1 order by StoreBrandCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "StoreBrandCode", "StoreBrandName1", "StoreBrandName2", "StoreBrandName3", "StoreBrandCode");
        }

        /// <summary>
        /// 绑定主档Store中的品牌
        /// </summary>
        /// <param name="ddl">品牌DropdownList</param>
        public static void BindBrandOfMasterStore(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.Brand().GetAllRecordList();
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "StoreBrandID", "StoreBrandName1", "StoreBrandName2", "StoreBrandName3", "StoreBrandCode");
        }
      
        public static void BindKeyValueList(FineUI.DropDownList ddl, List<KeyValue> list)
        {
            ddl.Items.Clear();
            ddl.DataSource = list;
            ddl.DataTextField = "Value";
            ddl.DataValueField = "Key";
            ddl.DataBind();
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });
        }
        /// <summary>
        /// 绑定所有联系方式类型
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindSNSType(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.SNSType().GetAllList();
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "SNSTypeID", "SNSTypeName1", "SNSTypeName2", "SNSTypeName3");
        }

        /// <summary>
        /// 绑定店铺类型
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindStoreType(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.StoreType().GetList("1 = 1 order by StoreTypeCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "StoreTypeID", "StoreTypeName1", "StoreTypeName2", "StoreTypeName3", "StoreTypeCode");
        }

        /// <summary>
        /// 绑定店铺类型
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindStoreType(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.StoreType().GetList("1 = 1 order by StoreTypeCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "StoreTypeID", "StoreTypeName1", "StoreTypeName2", "StoreTypeName3", "StoreTypeCode");
        }


        /// <summary>
        /// 绑定原因
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindReasonType(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.BUY_REASON().GetList("1 = 1 order by ReasonCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "ReasonID", "Description1", "Description2", "Description3", "ReasonCode");
        }

        /// <summary>
        /// 绑定原因
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindReasonType(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.BUY_REASON().GetList("1 = 1 order by ReasonCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "ReasonID", "Description1", "Description2", "Description3", "ReasonCode");
        }


        /// <summary>
        /// 绑定语言列表
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindLanguageMap(DropDownList ddl)
        {
            DataSet ds = new Edge.SVA.BLL.LanguageMap().GetAllList();
            ddl.Items.Clear();

            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                ddl.DataTextField = "LanguageDesc";
                ddl.DataValueField = "KeyID";
                ddl.DataSource = ds;
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }



        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStore(DropDownList dll)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + "1 = 1 order by StoreCode");
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }


        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStore(DropDownList dll, int brandID)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + string.Format(" BrandID = {0} order by StoreCode", brandID));
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }

        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStore(FineUI.DropDownList dll, int brandID)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + string.Format(" BrandID = {0} order by StoreCode", brandID));
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }
        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStore(FineUI.DropDownList ddl)
        {
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }

        public static void BindStoreNew(FineUI.DropDownList ddl)
        {
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }


        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStoreCodeWithBrand(DropDownList dll, int brandID)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + string.Format(" BrandID = {0} order by StoreCode", brandID));
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }

        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStoreCodeWithBrand(FineUI.DropDownList dll, int brandID)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + string.Format(" BrandID = {0} order by StoreCode", brandID));
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }

        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStoreWithBrand(DropDownList dll, int brandID)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + string.Format(" BrandID = {0} order by StoreCode", brandID));
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }
        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindAllStoreWithBrand(FineUI.DropDownList ddl, int brandID)
        {
            ddl.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 and ";
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new Edge.SVA.BLL.Store().GetList(strWhere + string.Format(" BrandID = {0} order by StoreCode", brandID));
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }
        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStoreWithBrand(FineUI.DropDownList ddl, int brandID)
        {
            ddl.Items.Clear();
            //DataSet ds = new Edge.SVA.BLL.Store().GetList(string.Format(" BrandID = {0} order by StoreCode", brandID));
            //Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
            BrandInfo bi = SVASessionInfo.CurrentUser.BrandInfoList.Find(m => m.Key == brandID.ToString());
            if (bi != null)
            {

                ddl.DataSource = bi.StoreInfos;
                ddl.DataTextField = "Value";
                ddl.DataValueField = "Key";
                ddl.DataBind();
            }
            //if (ddl.Items.Count == 1 && ddl.Required)
            //{

            //}
            //else
            //{
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });
            //}
        }

        /// <summary>
        /// 绑定所有季节
        /// 创建人：Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindSEASON(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            List<Edge.SVA.Model.SEASON> modelList = DALTool.GetAllSEASON();
            foreach (Edge.SVA.Model.SEASON model in modelList)
            {
                int value = model.SeasonID;
                string text = model.SeasonName1;
                ddl.Items.Add(text, value.ToString());
            }
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });
        }

        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStore(CheckBoxList ckbList, int storeTypeID, int brandID, string name, int top)
        {
            ckbList.Items.Clear();
            StringBuilder sbWhere = new StringBuilder();
            if (storeTypeID > 0)
            {
                sbWhere.Append(string.Format(" StoreTypeID = {0}", storeTypeID));
            }

            if (brandID > 0)
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and BrandID = {0}", brandID));
                }
                else
                {
                    sbWhere.Append(string.Format("  BrandID = {0}", brandID));
                }
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and (StoreName1 like '%{0}%' or StoreName2 like '%{0}%' or StoreName3 like '%{0}%')", name));
                }
                else
                {
                    sbWhere.Append(string.Format(" (StoreName1 like '%{0}%' or StoreName2 like '%{0}%' or StoreName3 like '%{0}%')", name));
                }
            }
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 ";
            }
            else
            {
                strWhere = " storeid in " + stores;
            }
            if (sbWhere.Length > 0)
            {
                strWhere = strWhere + " and ";
            }
            //End
            DataSet ds = new DataSet();
            if (top > 0)
            {
                ds = new Edge.SVA.BLL.Store().GetList(top, strWhere + sbWhere.ToString(), "StoreCode");
            }
            else
            {

                ds = new Edge.SVA.BLL.Store().GetList(strWhere + sbWhere.ToString());
            }

            Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3");

        }

        public static void BindStore(FineUI.CheckBoxList ckbList, int storeTypeID, int brandID, string name, int top)
        {
            ckbList.Items.Clear();
            StringBuilder sbWhere = new StringBuilder();
            if (storeTypeID > 0)
            {
                sbWhere.Append(string.Format(" StoreTypeID = {0}", storeTypeID));
            }

            if (brandID > 0)
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and BrandID = {0}", brandID));
                }
                else
                {
                    sbWhere.Append(string.Format("  BrandID = {0}", brandID));
                }
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and (StoreName1 like '%{0}%' or StoreName2 like '%{0}%' or StoreName3 like '%{0}%')", name));
                }
                else
                {
                    sbWhere.Append(string.Format(" (StoreName1 like '%{0}%' or StoreName2 like '%{0}%' or StoreName3 like '%{0}%')", name));
                }
            }
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 ";
            }
            else
            {
                strWhere = " storeid in " + stores;
            }
            if (sbWhere.Length > 0)
            {
                strWhere = strWhere + " and ";
            }
            //End
            DataSet ds = new DataSet();
            if (top > 0)
            {
                ds = new Edge.SVA.BLL.Store().GetList(top, strWhere + sbWhere.ToString(), "StoreCode");
            }
            else
            {

                ds = new Edge.SVA.BLL.Store().GetList(strWhere + sbWhere.ToString());
            }

            //Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3");

            Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }

        /// <summary>
        /// FineUI.CheckBoxList
        /// </summary>
        /// <param name="ddl">FineUI.CheckBoxList</param>
        public static void BindStore(FineUI.CheckBoxList ckbList, int storeTypeID, int brandID, string storeCode, string name, int top)
        {
            ckbList.Items.Clear();
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append(" 1=1 ");
            if (storeTypeID > 0)
            {
                sbWhere.Append(string.Format(" and StoreTypeID = {0}", storeTypeID));
            }
            if (brandID > 0)
            {
                sbWhere.Append(string.Format(" and BrandID = {0}", brandID));
            }
            if (!string.IsNullOrEmpty(name))
            {
                sbWhere.Append(string.Format(" and (StoreName1 like '%{0}%' or StoreName2 like '%{0}%' or StoreName3 like '%{0}%')", name));
            }
            if (!string.IsNullOrEmpty(storeCode))
            {
                sbWhere.Append(string.Format(" and StoreCode = '{0}'", storeCode));
            }
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " 1=1 ";
            }
            else
            {
                strWhere = " storeid in " + stores;
            }
            if (sbWhere.Length > 0)
            {
                strWhere = strWhere + " and ";
            }
            //End
            DataSet ds = new DataSet();
            if (top > 0)
            {
                ds = new Edge.SVA.BLL.Store().GetList(top, strWhere + sbWhere.ToString(), "StoreCode");
            }
            else
            {

                ds = new Edge.SVA.BLL.Store().GetList(strWhere + sbWhere.ToString());
            }

            Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }

        /// <summary>
        /// 根据当前语言绑定数据源到CheckBoxList FineUI
        /// </summary>
        /// <param name="ddl">要绑定的CheckBoxList</param>
        /// <param name="source">数据源</param>
        /// <param name="keyValue">CheckBoxList Value的值</param>
        /// <param name="keyText1">英文-> 数据库名字1</param>
        /// <param name="keyText2">简体中文-> 数据库名字2</param>
        /// <param name="keyText3">繁体中文-> 数据库名字3</param>
        public static void BindDataSet(FineUI.CheckBoxList ckbList, DataSet source, string keyValue, string keyText1, string keyText2, string keyText3, string code)
        {
            ckbList.Items.Clear();

            if (source != null && source.Tables != null && source.Tables.Count > 0)
            {
                string key = DALTool.GetStringByCulture(keyText1, keyText2, keyText3);
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    string text = GetDropdownListText(dr[key].ToString().Trim(), dr[code].ToString().Trim());
                    ckbList.Items.Add(new FineUI.CheckItem() { Value = dr[keyValue].ToString().Trim(), Text = text });
                }
            }
        }

        /// <summary>
        /// 绑定所有品牌
        /// </summary>
        /// <param name="ddl">品牌CheckBoxList</param>
        public static void BindBrand(CheckBoxList ckbList, string name, int top)
        {
            ckbList.Items.Clear();
            StringBuilder sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(name))
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and (BrandName1 like '%{0}%' or BrandName2 like '%{0}%' or BrandName3 like '%{0}%')", name));
                }
                else
                {
                    sbWhere.Append(string.Format(" (BrandName1 like '%{0}%' or BrandName2 like '%{0}%' or BrandName3 like '%{0}%')", name));
                }
            }
            DataSet ds = new DataSet();
            if (top > 0)
            {
                ds = new Edge.SVA.BLL.Brand().GetList(top, sbWhere.ToString(), "BrandID");
            }
            else
            {

                ds = new Edge.SVA.BLL.Brand().GetList(sbWhere.ToString());
            }
            Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "BrandID", "BrandName1", "BrandName2", "BrandName3");

        }

        public static void BindBrand(FineUI.CheckBoxList ckbList, string name, int top)
        {
            ckbList.Items.Clear();
            StringBuilder sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(name))
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and (BrandName1 like '%{0}%' or BrandName2 like '%{0}%' or BrandName3 like '%{0}%')", name));
                }
                else
                {
                    sbWhere.Append(string.Format(" (BrandName1 like '%{0}%' or BrandName2 like '%{0}%' or BrandName3 like '%{0}%')", name));
                }
            }
            DataSet ds = new DataSet();
            if (top > 0)
            {
                ds = new Edge.SVA.BLL.Brand().GetList(top, sbWhere.ToString(), "BrandID");
            }
            else
            {

                ds = new Edge.SVA.BLL.Brand().GetList(sbWhere.ToString());
            }

            //Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "BrandID", "BrandName1", "BrandName2", "BrandName3");
            Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "BrandID", "BrandName1", "BrandName2", "BrandName3", "BrandCode");
        }
        /// <summary>
        /// 绑定所有区域
        /// </summary>
        /// <param name="ddl">区域CheckBoxList</param>
        public static void BindLocation(CheckBoxList ckbList, string name, int top)
        {
            ckbList.Items.Clear();
            StringBuilder sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(name))
            {
                if (sbWhere.Length > 0)
                {
                    sbWhere.Append(string.Format(" and (StoreGroupName1 like '%{0}%' or StoreGroupName2 like '%{0}%' or StoreGroupName3 like '%{0}%')", name));
                }
                else
                {
                    sbWhere.Append(string.Format(" (StoreGroupName1 like '%{0}%' or StoreGroupName2 like '%{0}%' or StoreGroupName3 like '%{0}%')", name));
                }
            }
            DataSet ds = new DataSet();
            if (top > 0)
            {
                ds = new Edge.SVA.BLL.StoreGroup().GetList(top, sbWhere.ToString(), "StoreGroupID");
            }
            else
            {

                ds = new Edge.SVA.BLL.StoreGroup().GetList(sbWhere.ToString());
            }
            Edge.Web.Tools.ControlTool.BindDataSet(ckbList, ds, "StoreGroupID", "StoreGroupName1", "StoreGroupName2", "StoreGroupName3");
        }
        public static void BindLogisticsProvider(FineUI.DropDownList ddl, string strWhere)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.LogisticsProvider().GetList(strWhere);
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "LogisticsProviderID", "LogisticsProviderCode", "ProviderName1", "ProviderName2", "ProviderName3");
        }
        /// <summary>
        /// 绑定所有季节
        /// 创建人：Lisa
        /// 创建时间：2016-02-28
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindMATERIAL_IN(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.MATERIAL_IN bll = new SVA.BLL.MATERIAL_IN();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "MATERIALCode", "MATERIALName1", "MATERIALName2", "MATERIALName3", "MATERIALCode");
        }

        /// <summary>
        /// 绑定所有季节
        /// 创建人：Lisa
        /// 创建时间：2016-02-28
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindMATERIAL_OUT(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.MATERIAL_OUT bll = new SVA.BLL.MATERIAL_OUT();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "MATERIALCode", "MATERIALName1", "MATERIALName2", "MATERIALName3", "MATERIALCode");
        }

        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStoreWithStoreCode(DropDownList dll)
        {
            dll.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.Store().GetList("1 = 1 order by StoreCode");
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }

        /// <summary>
        /// 绑定所有店铺
        /// </summary>
        /// <param name="ddl">店铺CheckBoxList</param>
        public static void BindStoreWithStoreCode(FineUI.DropDownList dll)
        {
            dll.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.Store().GetList("1 = 1 order by StoreCode");
            Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");

        }

        public static void BindPasswordRule(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.PasswordRule().GetList("1 = 1 order by PasswordRuleCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "PasswordRuleID", "Name1", "Name2", "Name3", "PasswordRuleCode");
        }
        public static void BindPasswordRule(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.PasswordRule().GetList("1 = 1 order by PasswordRuleCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "PasswordRuleID", "Name1", "Name2", "Name3", "PasswordRuleCode");
        }
      
        /// <summary>
        /// 绑定所有公司
        /// 创建人：Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindCompany(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            List<Edge.SVA.Model.Company> modelList = DALTool.GetAllCompany();
            foreach (Edge.SVA.Model.Company model in modelList)
            {
                int value = model.CompanyID;
                string text = model.CompanyName;
                ddl.Items.Add(text, value.ToString());
            }
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });
        }

        /// <summary>
        /// 绑定所有国家
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindCountry(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.Country().GetList("1 = 1 order by CountryCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "CountryCode", "CountryName1", "CountryName2", "CountryName3");
        }

        /// <summary>
        /// 绑定所有省份
        /// </summary>
        /// <param name="ddl"></param>

        public static void BindProvince(FineUI.DropDownList ddl)
        {
            List<Edge.SVA.Model.Province> modelList = DALTool.GetAllProvice();
            foreach (Edge.SVA.Model.Province model in modelList)
            {
                string value = model.ProvinceCode;
                string text = model.ProvinceName1;
                ddl.Items.Add(text, value.ToString());
            }
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });

        }
        public static void BindREPLENFORMULA(FineUI.DropDownList ddl)
        {
            List<Edge.SVA.Model.BUY_REPLENFORMULA> modelList = DALTool.GetAllREPLENFORMULA();
             foreach (Edge.SVA.Model.BUY_REPLENFORMULA model in modelList)
            {
                string  value = model.ReplenFormulaID.ToString();
                string text = model.ReplenFormulaCode;
                ddl.Items.Add(text, value.ToString());
            }
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "0" });
        }
        public static void BindProvince(FineUI.DropDownList ddl, string CountryCode)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.Province().GetList("CountryCode = '" + CountryCode + "' order by ProvinceCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "ProvinceCode", "ProvinceName1", "ProvinceName2", "ProvinceName3");
        }

        /// <summary>
        /// 绑定所有城市
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindCity(FineUI.DropDownList ddl, string ProvinceCode)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.City().GetList("ProvinceCode = '" + ProvinceCode + "' order by CityCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "CityCode", "CityName1", "CityName2", "CityName3");
        }



        /// <summary>
        /// 绑定所有区域
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindDistrict(FineUI.DropDownList ddl, string CityCode)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.District().GetList("CityCode = '" + CityCode + "' order by DistrictCode");
            Edge.Web.Tools.ControlTool.BindDataSet(ddl, ds, "DistrictCode", "DistrictName1", "DistrictName2", "DistrictName3");
        }

        //获取SVA信息用于绑定下拉框
        public static void BindCardTypeFromSVA(FineUI.DropDownList ddl)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            CardTypeInfoRequest request = new CardTypeInfoRequest();
            request.ConditionStr = "";
            CardTypes[] ris = rpu.GetCardTypeInfo(request, SVASessionInfo.SiteLanguage);
            List<KeyValue> list = new List<KeyValue>();
            foreach (var item in ris)
            {
                list.Add(new KeyValue() { Key = item.CardTypeCode, Value = item.CardTypeName });
            }
            BindKeyValueList(ddl, list);
        }

        public static void BindCardGradeFromSVA(FineUI.DropDownList ddl, string CardTypeCode)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            CardGradeInfoRequest request = new CardGradeInfoRequest();
            request.ConditionStr = "CardTypeCode='" + CardTypeCode + "'";
            CardGrades[] ris = rpu.GetCardGradeInfo(request, SVASessionInfo.SiteLanguage);
            List<KeyValue> list = new List<KeyValue>();
            foreach (var item in ris)
            {
                list.Add(new KeyValue() { Key = item.CardGradeCode, Value = item.CardGradeName });
            }
            BindKeyValueList(ddl, list);
        }

        public static void BindCardTypeIDFromSVA(FineUI.DropDownList ddl)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            CardTypeInfoRequest request = new CardTypeInfoRequest();
            request.ConditionStr = "";
            CardTypes[] ris = rpu.GetCardTypeInfo(request, SVASessionInfo.SiteLanguage);
            List<KeyValue> list = new List<KeyValue>();
            foreach (var item in ris)
            {
                list.Add(new KeyValue() { Key = item.CardTypeID, Value = item.CardTypeName });
            }
            BindKeyValueList(ddl, list);
        }

        public static void BindCardGradeIDFromSVA(FineUI.DropDownList ddl, string CardTypeID)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            CardGradeInfoRequest request = new CardGradeInfoRequest();
            request.ConditionStr = "CardTypeID='" + CardTypeID + "'";
            CardGrades[] ris = rpu.GetCardGradeInfo(request, SVASessionInfo.SiteLanguage);
            List<KeyValue> list = new List<KeyValue>();
            foreach (var item in ris)
            {
                list.Add(new KeyValue() { Key = item.CardGradeID, Value = item.CardGradeName });
            }
            BindKeyValueList(ddl, list);
        }

        public static MemberCard BindMemberNameFromSVA(string cardNumber)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            MemberCardInfoRequest request = new MemberCardInfoRequest();
            request.ConditionStr = "";
            MemberCard ris = rpu.GetMemberCardInfo(request, cardNumber, SVASessionInfo.SiteLanguage);
            //foreach (var item in ris)
            //{
            //    string a = item.NickName;
            //}
            return ris;
        }

        public static MemberInfoResponse BindMember(string LoginAccountNumber, int LoginAccountType, int NoPassword, string MemberPassword, int BrandID, int OSType, string DeviceID)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            MemberInfoRequest request = new MemberInfoRequest();
            MemberInfoResponse ris = rpu.GetMemberInfo(request, LoginAccountNumber, LoginAccountType, NoPassword, MemberPassword, BrandID, OSType, DeviceID);
            return ris;
        }

        public static List<GetMemberTxn> GetMemberTxnList(string TxnNo)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            GetMemberTxnListRequest request = new GetMemberTxnListRequest();
            request.ConditionStr = "";
            List<GetMemberTxn> ris = rpu.GetMemberTxnList(request, TxnNo);
            return ris;
        }

        public static List<GetSalesTByTxnNo> GetSalesTByTxnNo(string TxnNo)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            GetSalesTByTxnNoRequest request = new GetSalesTByTxnNoRequest();
            List<GetSalesTByTxnNo> ris = rpu.GetSalesTByTxnNo(request, TxnNo);
            return ris;
        }

        /// <summary>
        /// 绑定所有供应商
        /// </summary>
        /// <param name="ddl">供应商CheckBoxList</param>
        public static void BindAllSupplier(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            List<Edge.SVA.Model.BUY_VENDOR> modelList = DALTool.GetAllSupplier();
            foreach (Edge.SVA.Model.BUY_VENDOR model in modelList)
            {
                int value = model.VendorID;
                string text = model.VendorName1;
                ddl.Items.Add(text, value.ToString());
            }
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });
        }

        /// <summary>
        /// 绑定所有物流供应商
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindAllLogisticsProvider(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            List<Edge.SVA.Model.LogisticsProvider> modelList = DALTool.GetAllLogisticsProvider();
            foreach (Edge.SVA.Model.LogisticsProvider model in modelList)
            {
                int value = model.LogisticsProviderID;
                string text = model.ProviderName1;
                ddl.Items.Add(text, value.ToString());
            }
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "-1" });
        }

        /// <summary>
        /// 绑定所有店铺根据店铺类型
        /// </summary>
        /// <param name="ddl">店铺FineUI.DropDownList</param>
        public static void BindStoreWithType(FineUI.DropDownList dll, int StoreType)
        {
            BuyingStoreGroupController c = new BuyingStoreGroupController();

            string username = Tools.DALTool.GetCurrentUser().UserName;
            int storeid = c.GetStoreIDByUser(username);

            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                strWhere = " "; //1=1 and ";

                //strWhere = " and ";
                
            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            DataSet ds = new DataSet();
            if (StoreType == 0)
            {
                if (username.ToUpper() == "ADMIN")
                {
                    ds = new Edge.SVA.BLL.BUY_STORE().GetList(strWhere + " StoreTypeID>=" + StoreType + " order by StoreCode");
                }
                else
                {
                     ds = new Edge.SVA.BLL.BUY_STORE().GetList(strWhere + " StoreID = " + storeid + "AND StoreTypeID>=" + StoreType + " order by StoreCode");
                }
                Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
            }
            else
            {
                ds = new Edge.SVA.BLL.BUY_STORE().GetList(strWhere + " StoreTypeID=" + StoreType + " order by StoreCode");
                Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
            }


        }

        public static void BindStoreWithType2(FineUI.DropDownList dll, int StoreType)
        {
            dll.Items.Clear();
            //Add By Robin 2014-07-31 过滤用户可用店铺列表
            string strWhere = "";
            string stores = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(stores))
            {
                //strWhere = " 1=1 and ";

                strWhere = " ";

            }
            else
            {
                strWhere = " storeid in " + stores + " and ";
            }
            //End
            if (StoreType == 0)
            {
                DataSet ds = new Edge.SVA.BLL.BUY_STORE().GetList(strWhere + " StoreTypeID>=" + StoreType + " order by StoreCode");
                Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
            }
            else
            {
                DataSet ds = new Edge.SVA.BLL.BUY_STORE().GetList(strWhere + " StoreTypeID=" + StoreType + " order by StoreCode");
                Edge.Web.Tools.ControlTool.BindDataSet(dll, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
            }


        }


        /// <summary>
        /// 绑定年份
        /// 创建者：Lisa
        /// 创建时间：2016-02-24
        /// </summary>
        /// <param name="ddl">年份</param>
        public static void BindYear(FineUI.DropDownList ddl)
        {
            List<string> strList = new List<string>();
            strList.Add("----------");
            strList.Add("2006");
            strList.Add("2007");
            strList.Add("2008");
            strList.Add("2009");
            strList.Add("2010");
            strList.Add("2011");
            strList.Add("2012");
            strList.Add("2013");
            strList.Add("2014");
            strList.Add("2015");
            strList.Add("2016");
            strList.Add("2017");
            ddl.DataSource = strList;
            ddl.DataBind();

        }
        public static void BindBrandStoreDepart(FineUI.DropDownList ddl, string strWhere)
        {
            Edge.SVA.BLL.BUY_DEPARTMENT bll = new SVA.BLL.BUY_DEPARTMENT();
            DataSet ds = bll.GetList(strWhere);
            ControlTool.BindDataSet(ddl, ds, "DepartCode", "DepartName1", "DepartName2", "DepartName3", "DepartCode");
        }
        public static void BindBrandStore(FineUI.DropDownList ddl, string strWhere)
        {
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            DataSet ds = bll.GetList(strWhere);
            ControlTool.BindDataSet(ddl, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }
    }
}
