using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
     public class Member
    {
         public Member() { }

         #region Model
         private int _memberid;
         private string _memberregistermobile;
         private string _membermobilephone;
         private string _memberemail;
         private string _memberengfamilyname;
         private string _memberenggivenname;
         private string _memberchifamilyname;
         private string _memberchigivenname;
         private string _nickname;
         /// <summary>
         /// 会员表主键
         /// </summary>
         public int MemberID
         {
             set { _memberid = value; }
             get { return _memberid; }
         }
         /// <summary>
         /// 会员注册用手机号（加上国家代码的，例如0861392572219）
         /// </summary>
         public string MemberRegisterMobile
         {
             set { _memberregistermobile = value; }
             get { return _memberregistermobile; }
         }
         /// <summary>
         /// 会员手机号，不加国家代码（例如，1394592381）
         /// </summary>
         public string MemberMobilePhone
         {
             set { _membermobilephone = value; }
             get { return _membermobilephone; }
         }
         /// <summary>
         /// 会员邮箱
         /// </summary>
         public string MemberEmail
         {
             set { _memberemail = value; }
             get { return _memberemail; }
         }
         /// <summary>
         /// 会员英文名（姓）
         /// </summary>
         public string MemberEngFamilyName
         {
             set { _memberengfamilyname = value; }
             get { return _memberengfamilyname; }
         }
         /// <summary>
         /// 会员英文名（名）
         /// </summary>
         public string MemberEngGivenName
         {
             set { _memberenggivenname = value; }
             get { return _memberenggivenname; }
         }
         /// <summary>
         /// 会员中文名（姓）
         /// </summary>
         public string MemberChiFamilyName
         {
             set { _memberchifamilyname = value; }
             get { return _memberchifamilyname; }
         }
         /// <summary>
         /// 会员中文名（名）
         /// </summary>
         public string MemberChiGivenName
         {
             set { _memberchigivenname = value; }
             get { return _memberchigivenname; }
         }

         /// <summary>
         /// 昵称
         /// </summary>
         public string NickName
         {
             set { _nickname = value; }
             get { return _nickname; }
         }
         #endregion Model
    }
}
