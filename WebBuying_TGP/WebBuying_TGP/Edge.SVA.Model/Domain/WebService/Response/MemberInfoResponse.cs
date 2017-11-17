using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class MemberInfoResponse
    {
        private string _action;

        public string Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        private int _responseCode;

        public int ResponseCode
        {
            get
            {
                return _responseCode;
            }
            set
            {
                _responseCode = value;
            }
        }

        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        private int _recordCount;
        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }
        /// <summary>
        /// 卡号
        /// </summary>
        private string _cardNumber;
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        /// <summary>
        /// 卡余额
        /// </summary>
        private decimal _cardAmountBalance;
        public decimal CardAmountBalance
        {
            get { return _cardAmountBalance; }
            set { _cardAmountBalance = value; }
        }
        /// <summary>
        /// PWD失败重试计数
        /// </summary>
        private int _pWDFailRetryCount;
        public int PWDFailRetryCount
        {
            get { return _pWDFailRetryCount; }
            set { _pWDFailRetryCount = value; }
        }
        /// <summary>
        /// 卡点余额
        /// </summary>
        private decimal _cardPointBalance;
        public decimal CardPointBalance
        {
            get { return _cardPointBalance; }
            set { _cardPointBalance = value; }
        }
        /// <summary>
        /// 会员表主键
        /// </summary>
        private int _memberid;
        public int MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// 会员名称
        /// </summary>
        private string _MemberGivenName;
        public string MemberGivenName
        {
            get { return _MemberGivenName; }
            set { _MemberGivenName = value; }
        }
        /// <summary>
        /// 会员姓氏
        /// </summary>
        private string _MemberFamilyName;
        public string MemberFamilyName
        {
            get { return _MemberFamilyName; }
            set { _MemberFamilyName = value; }
        }        
        /// <summary>
        /// 会员数量
        /// </summary>
        private int _MemberCartCount;
        public int MemberCartCount
        {
            get { return _MemberCartCount; }
            set { _MemberCartCount = value; }
        }
        /// <summary>
        /// 会员昵称
        /// </summary>
        private string _memberNickName;
        public string MemberNickName
        {
            get { return _memberNickName; }
            set { _memberNickName = value; }
        }
        /// <summary>
        /// 保持优惠券计数
        /// </summary>
        private int _holdCouponCount;
        public int HoldCouponCount
        {
            get { return _holdCouponCount; }
            set { _holdCouponCount = value; }
        }
        /// <summary>
        /// 国家编号
        /// </summary>
        private string _countryCode;
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
        /// <summary>
        /// 会员使用语言
        /// </summary>
        private string _memberDefLanguage;
        public string MemberDefLanguage
        {
            get { return _memberDefLanguage; }
            set { _memberDefLanguage = value; }
        }
        /// <summary>
        /// 会员创建时间
        /// </summary>
        private DateTime _memberCreatedOn;
        public DateTime MemberCreatedOn
        {
            get { return _memberCreatedOn; }
            set { _memberCreatedOn = value; }
        }
        /// <summary>
        /// 会员手机号码
        /// </summary>
        private string _memberMobilePhone;
        public string MemberMobilePhone
        {
            get { return _memberMobilePhone; }
            set { _memberMobilePhone = value; }
        }
    }
}
