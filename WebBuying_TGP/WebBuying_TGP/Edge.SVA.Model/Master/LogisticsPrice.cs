using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model
{
    /// <summary>
    /// 物流价格设置表。 按省份，按供应商，设置报价
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    [Serializable]
    public partial class LogisticsPrice
    {
        public LogisticsPrice(){ }

        #region Model
        private int _keyid;
        private int _logisticsproviderid;
        private string _provincecode;
        private decimal? _startprice;
        private decimal? _startweight;
        private decimal? _overflowpriceperkg;
        /// <summary>
        /// 自增长主键
        /// </summary>
        public int KeyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        /// <summary>
        /// 物流供应商主键
        /// </summary>
        public int LogisticsProviderID
        {
            set { _logisticsproviderid = value; }
            get { return _logisticsproviderid; }
        }
        /// <summary>
        /// 省编码主键
        /// </summary>
        public string ProvinceCode
        {
            set { _provincecode = value; }
            get { return _provincecode; }
        }
        /// <summary>
        /// 起步价。 示例： 6元
        /// </summary>
        public decimal? StartPrice
        {
            set { _startprice = value; }
            get { return _startprice; }
        }
        /// <summary>
        /// 起步重量， 单位公斤。 示例： 10 公斤
        /// </summary>
        public decimal? StartWeight
        {
            set { _startweight = value; }
            get { return _startweight; }
        }
        /// <summary>
        /// 每公斤溢出价格。 示例：  1.5元 每公斤
        /// </summary>
        public decimal? OverflowPricePerKG
        {
            set { _overflowpriceperkg = value; }
            get { return _overflowpriceperkg; }
        }
        #endregion Model
    }
}
