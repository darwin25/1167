using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Edge.Common;
using System.Text.RegularExpressions;

namespace Edge.Web.Tools.SearchBox
{
    public class CommonState { 
        #region 搜索控件枚举
        /// <summary>
        /// 左括号
        /// </summary>
        public enum LeftBracket
        { 
            Left=0
        }
        /// <summary>
        /// 获取实际左括号
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string GetLeftBracket(LeftBracket m)
        {
            string str = string.Empty;
            switch (m)
            { 
                case LeftBracket.Left:
                    str = "(";
                    break;
                default:
                    str = "(";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 右括号
        /// </summary>
        public enum RightBracket
        {
            Right = 0
        }
        /// <summary>
        /// 获取实际右括号
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string GetRightBracket(RightBracket m)
        {
            string str = string.Empty;
            switch (m)
            {
                case RightBracket.Right:
                    str = ")";
                    break;
                default:
                    str = ")";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 逻辑
        /// </summary>
        public enum logic
        { 
            AND=0,
            OR=1
        }
        /// <summary>
        /// 获取实际逻辑
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string GetLogic(logic m)
        {
            string str = string.Empty;
            switch (m)
            {
                case logic.AND:
                    str = "and";
                    break;
                case logic.OR:
                    str = "or";
                    break;
                default:
                    str = "and";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 符号enum
        /// </summary>
        public enum Symbol
        {
            Contain = 0,
            Equal = 1,
            NotEqual=2,
            GreaterThan=3,
            GreaterThanAndEqual=4,
            LessThan=5,
            LessThanAndEqual=6
        }
        /// <summary>
        /// 根据符号枚举返回实际符号
        /// </summary>
        public static string GetSymbol(Symbol m)
        {
            string str=string.Empty;
            switch(m)
            {
                case Symbol.Contain:
                    str = "like";
                    break;
                case Symbol.Equal:
                    str = "=";
                    break;
                case Symbol.NotEqual:
                    str = "<>";
                    break;
                case Symbol.GreaterThan:
                    str = ">";
                    break;
                case Symbol.GreaterThanAndEqual:
                    str = ">=";
                    break;
                case Symbol.LessThan:
                    str = "<";
                    break;
                case Symbol.LessThanAndEqual:
                    str = "<=";
                    break;
                default :
                    str = "=";
                    break;
            }
            return str;
        }
        #endregion
    }


    /// <summary>
    /// 本项目公共方法
    /// </summary>
    public class PublicMethod
    {
        /// <summary>
        /// 返回字典中options
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static string GetDic(string parentName, string where)
        {
            StringBuilder str = new StringBuilder();

            return str.ToString();
        }
        /// <summary>
        /// 返回枚举options
        /// </summary>
        /// <returns></returns>
        public static string GetEnumType(Type t)
        {
            StringBuilder str = new StringBuilder();
            List<EnumObj> lst = EnumObj.GetList(t);
            if (null != lst && lst.Count > 0)
            {
                foreach (EnumObj m in lst)
                {
                    str.AppendFormat("<option value=\"{0}\">{1}</option>", m.Value, m.Text);
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 返回查询控件的查询语句
        /// </summary>
        /// <param name="param">Request.QueryString["where"]</param>
        /// <param name="fields">查询的字段，以防注入其它字段</param>
        /// <returns></returns>
        public static string GetSearchStrByUrl(string param, List<string> fields, out string msg)
        {
            StringBuilder strMsg = new StringBuilder();
            StringBuilder str = new StringBuilder();
            if (!string.IsNullOrEmpty(param))
            {
                string[] where = StringUtil.unescape(param).Split(',');
                for (int i = 0; i < where.Length; i++)
                {
                    string current = string.Empty;
                    string wStr = WebCommon.NoSqlAndHtml(where[i]);
                    if (wStr.Length > 0)
                    {
                        string[] s = wStr.Split('|');
                        if (s.Length == 7)
                        {
                            //0:左括号 1:字段 2:字段类型 3:符号 4:输入区 5:右括号 6:逻辑
                            int s0 = WebCommon.GetInt(s[0], -1);
                            string s1 = s[1];
                            string s2 = s[2];
                            int s3 = WebCommon.GetInt(s[3], -1);
                            string s4 = s[4];
                            int s5 = WebCommon.GetInt(s[5], -1);
                            int s6 = WebCommon.GetInt(s[6], -1);
                            //检测开始
                            if (s0 != -1 && !EnumObj.IsExistEnumValue(s0, typeof(CommonState.LeftBracket)))
                            {
                                //strMsg.Append("左括号有误；");
                                continue;
                            }
                            if (s1.Length == 0 || s1 == "-1" || !fields.Contains(s1))
                            {
                                //strMsg.Append("查询字段有误；");
                                continue;
                            }
                            if (!EnumObj.IsExistEnumValue(s3, typeof(CommonState.Symbol)))
                            {
                                //strMsg.Append("符号有误；");
                                continue;
                            }
                            if (s4.Length == 0)
                            {
                                //为空让它跳走
                                continue;
                            }
                            if (s5 != -1 && !EnumObj.IsExistEnumValue(s5, typeof(CommonState.RightBracket)))
                            {
                                //strMsg.Append("右括号有误；");
                                continue;
                            }
                            if (!EnumObj.IsExistEnumValue(s6, typeof(CommonState.logic)))
                            {
                                //strMsg.Append("逻辑符有误；");
                                continue;
                            }
                            //检测结束

                            current = string.Format(" {0} {1} {2} {3} {4} {5} ",
                                //s0==-1?"":CommonState.GetLeftBracket((SystemConfig.CommonState.LeftBracket)s0),
                                "(",
                                s1,
                                CommonState.GetSymbol((CommonState.Symbol)s3),
                                s2 == "number" ? Math.Round(WebCommon.GetDecimal(s4, -1), 2).ToString() : string.Format(" '{1}{0}{1}' ", WebCommon.No_SqlHack(StringUtil.unescape(s[4])), s3 == (int)CommonState.Symbol.Contain ? "%" : ""),
                                //s5 == -1 ? "" : CommonState.GetRightBracket((SystemConfig.CommonState.RightBracket)s5),
                                ")",
                                i == where.Length - 1 ? "" : CommonState.GetLogic((CommonState.logic)s6)//去掉最后一个"逻辑"
                                );
                            str.Append(current + " ");
                        }
                    }
                }
            }

            Regex reg = new Regex(@"^[^\(\)]*(((?<o>\()[^\(\)]*)+[^\(\)]*((?<-o>\))[^\(\)]*)+)*(?(o)(?!))$");
            if (str.Length > 0 && !reg.IsMatch(str.ToString()))
            {
                strMsg.Append("括号匹配不正确！");
                str.Remove(0, str.Length);
            }

            msg = strMsg.ToString();
            return str.ToString();
        }
    }



    /// <summary>
    /// 枚举操作类
    /// </summary>
    public class EnumObj
    {
        #region 将枚举转为list
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        public static List<EnumObj> GetList(Type type)
        {
            if (!type.IsEnum)
            {    //不是枚举的要报错
                throw new InvalidOperationException();
            }
            //建立列表
            List<EnumObj> list = new List<EnumObj>();
            //获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
            System.Reflection.FieldInfo[] fields = type.GetFields();
            //检索所有字段
            foreach (FieldInfo field in fields)
            {
                //过滤掉一个不是枚举值的，记录的是枚举的源类型
                if (field.FieldType.IsEnum)
                {
                    EnumObj obj = new EnumObj();
                    // 通过字段的名字得到枚举的值
                    // 枚举的值如果是long的话，ToChar会有问题，但这个不在本文的讨论范围之内
                    obj.Value = ((int)type.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    obj.Text = field.Name;
                    list.Add(obj);
                }
            }
            return list;
        }

        /// <summary>
        /// 判断数字是否属于该枚举
        /// </summary>
        public static bool IsExistEnumValue(int v, Type type)
        {
            bool flag = false;
            List<EnumObj> lst = GetList(type);
            foreach (EnumObj m in lst)
            {
                if (m.Value == v.ToString())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        #endregion
    }

}
