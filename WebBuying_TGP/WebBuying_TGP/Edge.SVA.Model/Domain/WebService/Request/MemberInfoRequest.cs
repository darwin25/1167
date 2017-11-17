using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.SVA.Model.Domain.WebService.Request
{
    public class MemberInfoRequest : WebServiceResponseBase
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

        private int _memberID;

        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        private string _cardNumber;

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private string _conditionStr;

        public string ConditionStr
        {
            get { return _conditionStr; }
            set { _conditionStr = value; }
        }

        private string _pageCurrent;

        public string PageCurrent
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }

        private string _pageSize;

        public string PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private string _language;


        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        /// <summary>
        /// 会员登录号码
        /// </summary>
        private string _loginAccountNumber;
        public string LoginAccountNumber
        {
            get { return _loginAccountNumber; }
            set { _loginAccountNumber = value; }
        }
        /// <summary>
        /// 会员登录号码类型。 0：MemberRegisterMobile；1：MemberEmail；2：MemberMobileNumber；	
        /// </summary>
        private int _loginAccountType;
        public int LoginAccountType
        {
            get { return _loginAccountType; }
            set { _loginAccountType = value; }
        }
        /// <summary>
        /// 0：需要验证密码.  1: 不需要要验证密码。  默认为0
        /// </summary>
        private int _noPassword;
        public int NoPassword
        {
            get { return _noPassword; }
            set { _noPassword = value; }
        }
        /// <summary>
        /// 会员密码（MD5加密，密文长度32）  
        /// </summary>
        private string _memberPassword;
        public string MemberPassword
        {
            get { return _memberPassword; }
            set { _memberPassword = value; }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        private int _brandID;
        public int BrandID
        {
            get { return _brandID; }
            set { _brandID = value; }
        }
        /// <summary>
        /// 操作系统类型：  1： Apple的OS。 2：Google的 Android. 0 : 不指定
        /// </summary>
        private int _oSType;
        public int OSType
        {
            get { return _oSType; }
            set { _oSType = value; }
        }
        /// <summary>
        /// 和操作系统有关的设备ID
        /// </summary>
        private string _deviceID;
        public string DeviceID
        {
            get { return _deviceID; }
            set { _deviceID = value; }
        }
    }
}
