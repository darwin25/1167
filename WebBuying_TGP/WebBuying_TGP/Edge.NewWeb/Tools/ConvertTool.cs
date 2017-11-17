using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Edge.Web.Tools
{
    public static class ConvertTool
    {
        public static Nullable<T> ConverNullable<T>(string str) where T : struct
        {
            if (string.IsNullOrEmpty(str)) return null;
            try
            {
                return (T)Convert.ChangeType(str, typeof(T));
            }
            catch
            {
                return null;
            }
        }

        public static T ConverType<T>(string str) where T : struct
        {
            if (string.IsNullOrEmpty(str)) return default(T);

            try
            {
                return (T)Convert.ChangeType(str.Trim(), typeof(T));
            }
            catch
            {
                return default(T);
            }

        }

        public static int ToInt(string str)
        {
            int rtn = 0;
            int.TryParse(str, out rtn);
            return rtn;
        }

        public static long ToLong(string str)
        {
            long rtn = 0;
            long.TryParse(str, out rtn);
            return rtn;
        }

        public static decimal ToDecimal(string str)
        {
            decimal rtn = 0;
            return decimal.TryParse(str, out rtn) ? rtn : 0;

        }

        /// <summary>
        /// 转换时间格式，转换成功返回时间，否则返回DateTime.MinValue
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(string str)
        {
            DateTime rtn = DateTime.MinValue;
            if (DateTime.TryParse(str, out rtn) )
            {
                return rtn;
            } 
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换时间格式，转成yyyy-MM-dd的文本
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringDate(DateTime dt)
        {
            string str = "";
            try
            {
                if (dt == System.DateTime.MinValue)
                    return "";
                str = dt.ToString("yyyy-MM-dd");
            }
            catch
            { }
            return str;
        }

        /// <summary>
        /// 转换时间格式，转成yyyy-MM-dd hh:mm:ss的文本
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringDateTime(DateTime dt)
        {
            string str = "";
            try
            {
                if (dt == System.DateTime.MinValue)
                    return "";

                str = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch { }

            return str;
        }

        public static object ChangeType(Type type, string value)
        {
            if (type.FullName == "System.String") return value;



            else if (string.IsNullOrEmpty(value))
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch
                {
                    return null;
                }
            }
            return Convert.ChangeType(value, type);
        }

        public static string ToStringAmount(object obj)
        {
            string str = "";

            if (obj.GetType().FullName == "System.Decimal")
            {
                decimal decimalObj = (decimal)obj;
                str = decimalObj.ToString("N02");
            }
            else if (obj.GetType().FullName == "System.Double")
            {
                double doubleObj = (double)obj;
                str = doubleObj.ToString("N02");
            }

            return str;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, GetType(propInfo));
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }

                t.Rows.Add(row);
            }


            return ds;
        }

        private static Type GetType(PropertyInfo pi)
        {
            if (pi.PropertyType.Name == "Nullable`1")
            {
                return pi.PropertyType.GetProperty("Value").PropertyType;
            }

            return pi.PropertyType;
        }

        /// <summary>
        /// 合并两个相同的DataTable,返回合并后的结果
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static DataTable CombineTheSameDatatable(DataTable dt1, DataTable dt2)
        {
            if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
            {
                return new DataTable();
            }

            if (dt1.Rows.Count == 0)
            {
                return dt2;
            }
            if (dt2.Rows.Count == 0)
            {
                return dt1;
            }
            DataSet ds = new DataSet();

            ds.Tables.Add(dt1.Copy());

            ds.Merge(dt2.Copy());

            return ds.Tables[0];

        }

        /// <summary>
        /// 合并两个相同的DataTable,并去除主键重复，返回合并后的结果
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static DataTable CombineTheSameDatatable2(DataTable dt1, DataTable dt2, string primaryKey)
        {
            if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
            {
                return new DataTable();
            }

            if (dt1.Rows.Count == 0)
            {
                return dt2;
            }
            if (dt2.Rows.Count == 0)
            {
                return dt1;
            }
            DataSet ds = new DataSet();
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns[primaryKey] };
            ds.Tables.Add(dt1.Copy());

            ds.Merge(dt2.Copy());

            return ds.Tables[0];

        }

        ///<summary> 
        /// 将两个列不同的DataTable合并成一个新的DataTable 
        ///</summary> 
        ///<param name="dt1">源表</param> 
        ///<param name="dt2">需要合并的表</param> 
        ///<param name="primaryKey">需要排重列表（为空不排重）</param> 
        ///<param name="maxRows">合并后Table的最大行数</param> 
        ///<returns>合并后的datatable</returns> 
        public static DataTable MergeDataTable(DataTable dt1, DataTable dt2, string primaryKey)
        {
            //判断是否需要合并 
            if (dt1 == null && dt2 == null)
            {
                return null;
            }
            if (dt1 == null && dt2 != null)
            {
                return dt2.Copy();
            }
            else if (dt1 != null && dt2 == null)
            {
                return dt1.Copy();
            }
            //复制dt1的数据 
            DataTable dt = dt1.Copy();
            //补充dt2的结构（dt1中没有的列）到dt中 
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                string cName = dt2.Columns[i].ColumnName;
                if (!dt.Columns.Contains(cName))
                {
                    dt.Columns.Add(new DataColumn(cName));
                }
            }
            //复制dt2的数据 
            if (dt2.Rows.Count > 0)
            {
                Type t = dt2.Rows[0][primaryKey].GetType();
                bool isNeedFilter = string.IsNullOrEmpty(primaryKey) ? false : true;
                bool isNeedQuotes = t.Name == "String" ? true : false;
                int mergeTableNum = dt.Rows.Count;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    bool isNeedAdd = true;
                    //如果需要排重时，判断是否需要添加当前行 
                    if (isNeedFilter)
                    {
                        string primaryValue = dt2.Rows[i][primaryKey].ToString();
                        string fileter = primaryKey + "=" + primaryValue;
                        if (isNeedQuotes)
                        {
                            fileter = primaryKey + "='" + primaryValue + "'";
                        }
                        DataRow[] drs = dt.Select(fileter);
                        if (drs != null && drs.Length > 0)
                        {
                            isNeedAdd = false;
                        }
                    }
                    //添加数据 
                    if (isNeedAdd)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            string cName = dt.Columns[j].ColumnName;
                            if (dt2.Columns.Contains(cName))
                            {
                                //防止因同一字段不同类型赋值出错 
                                if (dt2.Rows[i][cName] != null && dt2.Rows[i][cName] != DBNull.Value && dt2.Rows[i][cName].ToString() != "")
                                {
                                    dr[cName] = dt2.Rows[i][cName];
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                        mergeTableNum++;
                    }
                }
            }
            return dt;
        }

        ///当sourceDataTable为空时合并失败
        /// <summary>
        /// 取两个DataTable的交集,删除重复数据
        /// </summary>
        /// <param name="sourceDataTable">源DataTable</param>
        /// <param name="targetDataTable">目标DataTable</param>
        /// <param name="primaryKey">两个表的主键</param>
        /// <returns>合并后的表</returns>
        public static DataTable MergeDataTable2(DataTable sourceDataTable, DataTable targetDataTable, string primaryKey)
        {
            if (sourceDataTable != null || targetDataTable != null || !sourceDataTable.Equals(targetDataTable))
            {
                sourceDataTable.PrimaryKey = new DataColumn[] { sourceDataTable.Columns[primaryKey] };
                DataTable dt = targetDataTable.Copy();
                foreach (DataRow tRow in dt.Rows)
                {
                    //拒绝自上次调用 System.Data.DataRow.AcceptChanges() 以来对该行进行的所有更改。
                    //因为行状态为DataRowState.Deleted时无法访问ItemArray的值
                    tRow.RejectChanges();
                    //在加载数据时Close通知、索引维护和约束。
                    sourceDataTable.BeginLoadData();
                    //查找和更新特定行。如果找不到任何匹配行，则使用给定值创建新行。
                    DataRow temp = sourceDataTable.LoadDataRow(tRow.ItemArray, true);
                    sourceDataTable.EndLoadData();
                    sourceDataTable.Rows.Remove(temp);
                }
            }
            sourceDataTable.AcceptChanges();
            return sourceDataTable;
        }

        #region GetPagedTable DataTable分页
        /// <summary>
        /// DataTable分页
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="PageIndex">页索引,注意：从1开始</param>
        /// <param name="PageSize">每页大小</param>
        /// <returns></returns>
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Clone();

            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }
        #endregion

    }
}
