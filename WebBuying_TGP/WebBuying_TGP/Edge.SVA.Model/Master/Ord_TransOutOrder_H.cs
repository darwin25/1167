using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 卡订货单
    /// </summary>
    [Serializable]
    public partial class Ord_TransOutOrder_H
    {
        public Ord_TransOutOrder_H()
        { }
        #region Model
        private string _TransOutOrderNumber;
        private string _referenceno;
        private int? _fromstoreid;
        private string _fromcontactname;
        private string _fromcontactphone;
        private string _frommobile;
        private string _fromemail;
        private string _fromaddress;
        private int? _storeid;
        private string _storecontactname;
        private string _storecontactphone;
        private string _storecontactemail;
        private string _storemobile;
        private string _storeaddress;
        private string _remark;
        private DateTime? _createdbusdate;
        private DateTime? _approvebusdate;
        private string _approvalcode;
        private string _approvestatus;
        private DateTime? _approveon;
        private int? _approveby;
        private DateTime? _createdon = DateTime.Now;
        private int? _createdby;
        private DateTime? _updatedon = DateTime.Now;
        private int? _updatedby;

        /// <summary>
        /// 订单编号，主键
        /// </summary>
        public string TransOutOrderNumber
        {
            set { _TransOutOrderNumber = value; }
            get { return _TransOutOrderNumber; }
        }
        /// <summary>
        /// 参考编号
        /// </summary>
        public string ReferenceNo
        {
            set { _referenceno = value; }
            get { return _referenceno; }
        }
        /// <summary>
        /// 出货店铺主键
        /// </summary>
        public int? FromStoreID
        {
            set { _fromstoreid = value; }
            get { return _fromstoreid; }
        }
        /// <summary>
        /// 出货店铺联系人
        /// </summary>
        public string FromContactName
        {
            set { _fromcontactname = value; }
            get { return _fromcontactname; }
        }
        /// <summary>
        /// 出货店铺电话
        /// </summary>
        public string FromContactPhone
        {
            set { _fromcontactphone = value; }
            get { return _fromcontactphone; }
        }
        /// <summary>
        /// 出货店铺联系人手机
        /// </summary>
        public string FromMobile
        {
            set { _frommobile = value; }
            get { return _frommobile; }
        }
        /// <summary>
        /// 出货店铺邮箱
        /// </summary>
        public string FromEmail
        {
            set { _fromemail = value; }
            get { return _fromemail; }
        }
        /// <summary>
        /// 出货店铺地址
        /// </summary>
        public string FromAddress
        {
            set { _fromaddress = value; }
            get { return _fromaddress; }
        }
        /// <summary>
        /// 订货店铺主键
        /// </summary>
        public int? StoreID
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 出货店铺联系人
        /// </summary>
        public string StoreContactName
        {
            set { _storecontactname = value; }
            get { return _storecontactname; }
        }
        /// <summary>
        /// 送货地址
        /// </summary>
        public string StoreAddress
        {
            set { _storeaddress = value; }
            get { return _storeaddress; }
        }
        /// <summary>
        /// 送货邮箱
        /// </summary>
        public string StoreContactEmail
        {
            set { _storecontactemail = value; }
            get { return _storecontactemail; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string StoreMobile
        {
            set { _storemobile = value; }
            get { return _storemobile; }
        }
        /// <summary>
        /// 送货邮箱
        /// </summary>
        public string StoreContactPhone
        {
            set { _storecontactphone = value; }
            get { return _storecontactphone; }
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
        /// 单据创建时的busdate
        /// </summary>
        public DateTime? CreatedBusDate
        {
            set { _createdbusdate = value; }
            get { return _createdbusdate; }
        }
        /// <summary>
        /// 单据批核时的busdate
        /// </summary>
        public DateTime? ApproveBusDate
        {
            set { _approvebusdate = value; }
            get { return _approvebusdate; }
        }
        /// <summary>
        /// 批核时产生授权号，并通知前台
        /// </summary>
        public string ApprovalCode
        {
            set { _approvalcode = value; }
            get { return _approvalcode; }
        }
        /// <summary>
        /// 单据状态。状态： P：prepare。  A:Approve 。 V：Void
        /// </summary>
        public string ApproveStatus
        {
            set { _approvestatus = value; }
            get { return _approvestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ApproveOn
        {
            set { _approveon = value; }
            get { return _approveon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ApproveBy
        {
            set { _approveby = value; }
            get { return _approveby; }
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

