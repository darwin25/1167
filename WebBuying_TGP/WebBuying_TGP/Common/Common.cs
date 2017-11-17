using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Edge.Common
{
    /// <summary>
    ///公用类
    /// </summary>
    public class WebCommon
    {
        #region IP地址处理相关


        /// <summary>
        /// 检查当前IP是否是受限IP
        /// </summary>
        /// <param name="LimitedIP">受限的IP，如:192.168.1.110|212.235.*.*</param>
        /// <returns>返回true表示IP未受到限制</returns>
        public static bool ValidateIP(string LimitedIP)
        {
            string CurrentIP = GetClientIP();
            if (string.IsNullOrEmpty(LimitedIP))
                return true;
            LimitedIP.Replace(".", @"\.");
            LimitedIP.Replace("*", @"[^\.]{1,3}");
            Regex reg = new Regex(LimitedIP, RegexOptions.Compiled);
            Match match = reg.Match(CurrentIP);
            return !match.Success;
        }

        /// <summary>
        /// 取得用户客户端IP(穿过代理服务器取远程用户真实IP地址)
        /// </summary>
        public static string GetClientIP()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
        }
        #endregion

        #region 防止代碼注入

        /// <summary>
        /// 防止HTML代碼注入
        /// </summary>
        /// <param name="NoteContent"></param>
        /// <returns></returns>
        public static string ExchangeNote(string NoteContent)
        {
            string afterReContent = "";
            afterReContent = NoteContent.Replace("<", "&lt").Replace(">", "&gt");
            return afterReContent;
        }
        /// <summary>
        /// 防止SQL注入
        /// </summary>
        /// <param name="inputStr">輸入的sql語句</param>
        /// <returns>過濾後的語句</returns>
        public static string No_SqlHack(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr))
                return "";

            //要過濾掉的關鍵字集合
            string NoSqlHack_AllStr = "|;|and|chr(|exec|insert|select|delete|from|update|mid(|master.|";
            string SqlHackGet = inputStr;
            string[] AllStr = NoSqlHack_AllStr.Split('|');

            //分離關鍵字
            string[] GetStr = SqlHackGet.Split(' ');
            if (SqlHackGet != "")
            {
                for (int j = 0; j < GetStr.Length; j++)
                {
                    for (int i = 0; i < AllStr.Length; i++)
                    {
                        if (GetStr[j].ToLower() == AllStr[i].ToLower())
                        {
                            GetStr[j] = "";
                            break;
                        }
                    }
                }
                SqlHackGet = "";
                for (int i = 0; i < GetStr.Length; i++)
                {
                    SqlHackGet += GetStr[i].ToString() + " ";
                }
                return SqlHackGet.TrimEnd(' ').Replace("'", "_").Replace(",", "_");//.Replace("<", "&lt").Replace(">", "&gt");
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 过滤HTML 和SQL 
        /// </summary>
        /// <param name="str"></param>
        public static string NoSqlAndHtml(string str)
        {
            string s=string.Empty;
            if(!string.IsNullOrEmpty(str))
            {
                s=StringUtil.NoHTML(No_SqlHack(str));
            }
            return s;
        }
        #endregion

        #region MesageBox

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
        public static void ShowAlert(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>ymPrompt.alert('" + msg.ToString() + "',null,null,'系统提示');</script>");
        }
        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");

        }

        #endregion

        #region cookie

        /// <summary>
        /// 设置cookies
        /// </summary>
        /// <param name="mainName">主键</param>
        /// <param name="mainValue">值</param>
        /// <param name="days">天数</param>
        /// <returns></returns>
        public static bool SetCookies(string mainName, string mainValue, int days)
        {
            try
            {
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(mainName, mainValue);
                }
                else
                {
                    cookie.Value = mainValue;
                }
                cookie.Expires = DateTime.Now.AddDays(days);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取cookies
        /// .net 和JavaScript url加密不一样，解密一样
        /// </summary>
        /// <param name="mainName">主键</param>
        /// <returns></returns>
        public static string GetCookies(string mainName)
        {
            //HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
            //if (cookie != null)
            //{
            //    return HttpContext.Current.Server.UrlDecode(cookie.Value);
            //}
            //else
            //{
            //    return String.Empty;
            //}

            HttpCookieCollection collection = System.Web.HttpContext.Current.Request.Cookies;
            String r = "";
            foreach (String cookieKey in collection.AllKeys)
            {
                if (HttpContext.Current.Server.UrlDecode(cookieKey).Equals(mainName))
                {
                    r = System.Web.HttpContext.Current.Request.Cookies[cookieKey].Value;
                }
            }
            return r;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainName"></param>
        /// <returns></returns>
        public static string GetCookies2(string mainName)
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
            if (cookie != null)
            {
                return HttpContext.Current.Server.UrlDecode(cookie.Value);
            }
            else
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// 删除Cookies
        /// </summary>
        /// <param name="mainName"></param>
        public static bool DelCookies(string mainName)
        {
            try
            {
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region URL相关


        /// <summary>
        /// 获取url参数值
        /// </summary>
        /// <param name="key"></param>
        /// <returns>获取失败，返回""</returns>
        public static string GetRequestUrlStr(string key)
        {
            Object value = HttpContext.Current.Request.QueryString[key];
            if (null != value)
            {
                return value.ToString().Trim();
            }
            return String.Empty;
        }
        /// <summary>
        /// 获取url参数值,获取失败，返回0
        /// </summary>
        /// <param name="key"></param>
        /// <returns>获取失败，返回0</returns>
        public static int GetRequestUrlInt(string key)
        {
            int r;
            Int32.TryParse(HttpContext.Current.Request.QueryString[key], out r);
            return r;
        }

        /// <summary>
        /// 获取 完整url （协议名+域名+站点名+文件名+参数）
        /// <![CDATA[http://www.test.com/aaa/bbb.aspx?id=5&name=kelli]]>
        /// </summary>
        /// <returns> </returns>
        public static string GetUrl()
        {
            string url = HttpContext.Current.Request.Url.ToString();
            return url;
        }

        /// <summary>
        /// 获取 站点名+页面名+参数
        /// <![CDATA[url= /aaa/bbb.aspx?id=5&name=kelli]]>
        /// </summary>
        /// <returns></returns>
        public static string GetUrl1()
        {
            // string url=Request.Url.PathAndQuery;
            string url = HttpContext.Current.Request.RawUrl;
            return url;
        }

        /// <summary>
        /// 获取 站点名+页面名
        /// <![CDATA[url= aaa/bbb.aspx]]>
        /// </summary>
        /// <returns></returns>
        public static string GetUrl2()
        {
            // string url= HttpContext.Current.Request.Path;
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            return url;
        }


        /// <summary>
        /// 获取 域名
        /// <![CDATA[url= www.test.com]]>
        /// </summary>
        /// <returns></returns>
        public static string GetUrl3()
        {
            // string url= HttpContext.Current.Request.Path;
            string url = HttpContext.Current.Request.Url.Host;
            return url;
        }

        /// <summary>
        /// 获取 参数
        /// <![CDATA[url= ?id=5&name=kelli]]>
        /// </summary>
        /// <returns></returns>
        public static string GetUrl4()
        {
            // string url= HttpContext.Current.Request.Path;
            string url = HttpContext.Current.Request.Url.Query;
            return url;
        }
        /// <summary>
        /// 获取 文件名
        /// <![CDATA[bbb.aspx]]>
        /// </summary>
        /// <returns></returns>
        public static string GetUrl5()
        {
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            url = url.Substring(url.LastIndexOf('/') + 1);
            return url;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="curl"></param>
        /// <returns>
        /// 
        ///200 - 确定。客户端请求已成功。 
        ///201 - 已创建。 
        ///202 - 已接受。
        /// 
        ///400 - 错误的请求
        ///401 - 访问被拒绝
        ///403 - 禁止访问
        ///404 - 未找到
        ///405 - 用来访问本页面的 HTTP 谓词不被允许（方法不被允许） 
        ///406 - 客户端浏览器不接受所请求页面的 MIME 类型。 
        ///407 - 要求进行代理身份验证。 
        ///412 - 前提条件失败。 
        ///413 – 请求实体太大。 
        ///414 - 请求 URI 太长。 
        ///415 – 不支持的媒体类型。 
        ///416 – 所请求的范围无法满足。 
        ///417 – 执行失败。 
        ///423 – 锁定的错误
        /// 
        ///500 - 内部服务器错误。 
        ///501 - 页眉值指定了未实现的配置。 
        ///502 - Web 服务器用作网关或代理服务器时收到了无效响应。 
        ///503 - 服务不可用。这个错误代码为 IIS 6.0 所专用。 
        ///504 - 网关超时。 
        ///505 - HTTP 版本不受支持。
        /// </returns>
        public static int GetUrlError(string curl)
        {
            int num = 200;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(curl));
            ServicePointManager.Expect100Continue = false;
            try
            {
                ((HttpWebResponse)request.GetResponse()).Close();
            }
            catch (WebException exception)
            {
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    return num;
                }
                if (exception.Message.IndexOf("500 ") > 0)
                {
                    return 500;
                }
                if (exception.Message.IndexOf("401 ") > 0)
                {
                    return 401;
                }
                if (exception.Message.IndexOf("404") > 0)
                {
                    num = 404;
                }
            }
            return num;

        }
        #endregion


        #region 文件上传


        public readonly static string AllowExt = "jpe|jpeg|jpg|png|tif|tiff|bmp|gif|wbmp|swf|psd";
        /// 检测扩展名的有效性
        /// </summary>
        /// <param name="sExt">文件名扩展名</param>
        /// <returns>如果扩展名有效,返回true,否则返回false.</returns>
        public static bool CheckValidExt(string sExt)
        {
            bool flag = false;
            string[] aExt = AllowExt.Split('|');
            foreach (string filetype in aExt)
            {
                if (filetype.ToLower() == sExt.Replace(".", ""))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        ///<summary>
        /// 检测扩展名的有效性
        /// </summary>
        /// <param name="sExt">文件名扩展名</param>
        /// <param name="ext">自定义扩展名如：jpe|jpeg|jpg|png</param>
        /// <returns>如果扩展名有效,返回true,否则返回false.</returns>
        public static bool CheckValidExt(string sExt, string ext)
        {
            bool flag = false;
            string[] aExt = ext.Split('|');
            foreach (string filetype in aExt)
            {
                if (filetype.ToLower() == sExt.Replace(".", ""))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imagepath">图片路径</param>
        public static void imgDel(string imagepath)
        {
            if (System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);
            }
        }
        /// <summary>
        ///给上传的文件随机命名
        /// </summary>
        /// <param name="filename">文件名</param>
        public static string GetRandomFileName(string filename)
        {
            int i;
            string[] files = filename.Split('.');
            string exfilename = '.' + files.GetValue(files.Length - 1).ToString();
            char[] s = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            string num = "";
            Random r = new Random();
            for (i = 0; i <= 9; i++)
                num = num + s[r.Next(0, s.Length)].ToString();

            DateTime time = DateTime.Now;
            string name = time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + time.Hour.ToString().PadLeft(2, '0') + time.Minute.ToString().PadLeft(2, '0') + time.Second.ToString().PadLeft(2, '0') + num + exfilename;
            return name;
        }
        ///<summary>
        ///生成缩略图
        ///</summary>
        ///<param name="originalImagePath">源图路径（物理路径）</param>
        ///<param name="thumbnailPath">缩略图路径（物理路径）</param>
        ///<param name="width">缩略图宽度</param>
        ///<param name="height">缩略图高度</param>
        ///<param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }



        #endregion

        #region 生成html页面文件

        /// <summary>
        /// 生成HTML页面
        /// </summary>
        /// <param name="sHtml">Html文件内容</param>
        /// <param name="path">虚拟路径</param>
        public static void SetHtml(StringBuilder sHtml, string path)
        {
            StreamWriter swrite = null;
            try
            {
                swrite = new StreamWriter(HttpContext.Current.Server.MapPath(path), false, Encoding.Default);
                swrite.Write(sHtml.ToString());
                swrite.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                swrite.Close();
            }
        }

        /// <summary>
        /// 根据URL生成HTML页面
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="path">物理路径</param>
        public static void SetHtmlByURL(String url, String path, String fileName)
        {
            Encoding code = Encoding.GetEncoding("UTF-8");
            StreamReader sr = null;
            StreamWriter sw = null;
            string str = String.Empty;

            WebRequest temp = WebRequest.Create(url);
            WebResponse myTemp = temp.GetResponse();
            sr = new StreamReader(myTemp.GetResponseStream(), code);
            try
            {
                sr = new StreamReader(myTemp.GetResponseStream(), code);
                str = sr.ReadToEnd();
                Directory.CreateDirectory(path);
                sw = new StreamWriter(path + fileName, false, code);
                sw.Write(str);
                sw.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
                sw.Close();
            }
        }
        #endregion

        #region 数据类型转换
        /// <summary>
        /// 若字符串为null或Empty，则返回指定的defaultValue.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(string value, string defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 将字符串转化为数字(无符号整数) 若值不是数字返回defaultValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt(string key, int defaultValue)
        {
            int result = 0;
            bool b=Int32.TryParse(key, out result);
            return b ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串转化为数字(无符号整数) 若值不是数字返回0
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt(string key)
        {
            return GetInt(key, 0);
        }

        /// <summary>
        /// 将字符串转换为可空的日期类型，如果字符串不是有效的日期格式，则返回null
        /// </summary>
        /// <param name="s">进行转换的字符串</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeNullable(string s)
        {
            return GetDateTimeNullable(s, null);
        }
        /// <summary>
        /// 将字符串转换为可空的日期类型，如果字符串不是有效的日期格式，则返回defaultValue
        /// </summary>
        /// <param name="s">进行转换的字符串</param>
        /// <param name="defaultValue">要返回的默认值</param
        /// <returns></returns>
        public static DateTime? GetDateTimeNullable(string s, DateTime? defaultValue)
        {
            DateTime dt;
            bool b = DateTime.TryParse(s, out dt);
            return b ? (DateTime?)dt : defaultValue;
        }
        /// <summary>
        /// 转换时间 转换失败则为默认值 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string key, DateTime defaultValue)
        {
            DateTime dt;
            bool b = DateTime.TryParse(key, out dt);
            return b ? dt : defaultValue;
        }

        /// <summary>
        /// 将字符串转化为Int可空类型，若不是数字指定的defaultValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int? GetIntNull(string key, int? defaultValue)
        {
            int i;
            bool b = Int32.TryParse(key, out i);
            return b ? (int?)i : defaultValue;
        }
        /// <summary>
        /// 将字符串转化为Int可空类型，若不是数字返回null的Int?.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int? GetIntNull(string key)
        {
            return GetIntNull(key, null);
        }
        /// <summary>
        ///  将字符串转化为浮点数 若值不是浮点数返回defaultValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string key, decimal defaultValue)
        {
            decimal i;
            bool b = Decimal.TryParse(key, out i);
            return b ? i : defaultValue;
        }
        /// <summary>
        ///  将字符串转化为浮点数 若值不是浮点数返回0
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string key)
        {
            return GetDecimal(key, 0);
        }



        public static DateTime GetDateTime(string key)
        {
            return GetDateTime(key, DateTime.MinValue);
        }
        #endregion
    }
}