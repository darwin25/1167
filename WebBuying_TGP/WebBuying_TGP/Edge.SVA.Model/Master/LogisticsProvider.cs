using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model
{
    /// <summary>
	/// 物流供应商
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
	/// </summary>
	[Serializable]
	public partial class LogisticsProvider
    {
        public LogisticsProvider() { }
        #region Model
        private int _logisticsproviderid;
        private string _logisticsprovidercode;
        private string _providername1;
        private string _providername2;
        private string _providername3;
        private string _providercontacttel;
        private string _providercontact;
        private string _providercontactemail;
        private string _ordqueryaddr;
        private string _remark;
        private DateTime? _createdon;
        private int? _createdby;
        private DateTime? _updatedon;
        private int? _updatedby;
        /// <summary>
        /// 主键，自增长
        /// </summary>
        public int LogisticsProviderID
        {
            set { _logisticsproviderid = value; }
            get { return _logisticsproviderid; }
        }
        /// <summary>
        /// 物流编码
        /// </summary>
        public string LogisticsProviderCode
        {
            set { _logisticsprovidercode = value; }
            get { return _logisticsprovidercode; }
        }
        /// <summary>
        /// 物流名称1
        /// </summary>
        public string ProviderName1
        {
            set { _providername1 = value; }
            get { return _providername1; }
        }
        /// <summary>
        /// 物流名称2
        /// </summary>
        public string ProviderName2
        {
            set { _providername2 = value; }
            get { return _providername2; }
        }
        /// <summary>
        /// 物流名称3
        /// </summary>
        public string ProviderName3
        {
            set { _providername3 = value; }
            get { return _providername3; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ProviderContactTel
        {
            set { _providercontacttel = value; }
            get { return _providercontacttel; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ProviderContact
        {
            set { _providercontact = value; }
            get { return _providercontact; }
        }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string ProviderContactEmail
        {
            set { _providercontactemail = value; }
            get { return _providercontactemail; }
        }
        /// <summary>
        /// 订单查询地址
        /// </summary>
        public string OrdQueryAddr
        {
            set { _ordqueryaddr = value; }
            get { return _ordqueryaddr; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedOn
        {
            set { _createdon = value; }
            get { return _createdon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreatedBy
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedOn
        {
            set { _updatedon = value; }
            get { return _updatedon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpdatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        #endregion Model
    }
}
