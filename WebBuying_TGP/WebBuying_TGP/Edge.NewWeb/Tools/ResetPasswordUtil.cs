using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Edge.SVA.Model.Domain.WebService.Response;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Edge.SVA.Model.Domain.WebService;
using Edge.SVA.Model.Domain.WebService.Request;

namespace Edge.Web.Tools
{
    public class ResetPasswordUtil
    {
        Tools.Logger logger = Tools.Logger.Instance;
        string key = "19A1708FCEFB1929";
        byte[] keyByte;
        
        public ResetPasswordUtil()
        {
            keyByte = HexStringToToHexByte(key);
        }
        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="useID">当前操作员的userid</param>
        /// <param name="memberRegisterMobileNum">会员的注册手机号</param>
        /// <returns>true，重设成功；false，重设失败。</returns>
        public bool ResetPassord(string useID, string memberRegisterMobileNum)
        {
            logger.WriteOperationLog("ResetPassord", useID + " " + memberRegisterMobileNum);
            bool rtn = false;
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                response = service.request(GetRequestStr(useID, memberRegisterMobileNum), key);
                
                MemberResetPasswordResponse mrpr = GetMemberResetPasswordResponse(response);
                if (mrpr != null)
                {
                    if (mrpr.ResponseCode.Equals(0))
                    {
                        rtn = true;
                    }
                    logger.WriteOperationLog("ResetPassord ResponseCode", mrpr.ResponseCode.ToString());
                    if (mrpr.ResponseCode.Equals(90286))
                    {
                        logger.WriteOperationLog("email not exists !", mrpr.ResponseCode.ToString());
                    }
                }
                else
                {
                    logger.WriteErrorLog("ResetPassord", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("ResetPassord", " error ", ex);
            }
            return rtn;
        }
        private string GetRequestStr(string useID, string memberRegisterMobileNum)
        {
            MemberResetPasswordRequest request = new MemberResetPasswordRequest();
            request.Action = "LostMemberPassword";
            request.UserID = useID;
            request.MemberRegistID = memberRegisterMobileNum;
            return Encode(JsonConvert.SerializeObject(request),key);
        }
        private MemberResetPasswordResponse GetMemberResetPasswordResponse(string response)
        {
            return JsonConvert.DeserializeObject<MemberResetPasswordResponse>(response);
        }
        private string Encode(string str, string key)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = CipherMode.ECB;
                provider.Key = keyByte;
                byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(str);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                stream.Close();
                return builder.ToString();
            }
            catch (Exception ex)
            {
                return "xxxx";
            }
        }
        private static byte[] HexStringToToHexByte(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                return new byte[] { };
            }
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 从SVA获取CardType信息
        /// </summary>
        /// <param name="lan">当前操作语言</param>
        /// <returns>卡类型信息</returns>
        public CardTypes[] GetCardTypeInfo(CardTypeInfoRequest request, string lan)
        {
            request.Action = "GetCardTypes";
            request.CardTypeID = 0;
            request.PageCurrent = "0";
            request.PageSize = "0";
            if (lan.ToLower() == "zh-cn") //confirm by michael he 2013-09-13
            {
                lan = "zh_CN";
            }
            else if (lan.ToLower() == "zh-hk")
            {
                lan = "zh_BigCN";
            }
            else
            {
                lan = "en_CA";
            }

            request.Language = lan;
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                string msg = JsonConvert.SerializeObject(request);
                logger.WriteOperationLog("GetCardTypes ", msg);
                //response = service.request(Encode(msg, key), key); //Removed By Robin 2015-10-15 暂时Close加密
                response = service.request(msg, key);
                logger.WriteOperationLog("GetCardTypes Response ", response);
                CardTypeInfoResponse responseObj = GetCardTypeInfoResponse(response);
                if (responseObj != null)
                {
                    logger.WriteOperationLog("GetCardTypes ResponseCode", responseObj.ResponseCode.ToString());
                    if (responseObj.ResponseCode.Equals(0))
                    {
                        return responseObj.CardTypes;
                    }
                }
                else
                {
                    logger.WriteErrorLog("GetCardTypes", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("GetCardTypes", " error ", ex);
            }
            return new CardTypes[0];
        }

        /// <summary>
        /// 从SVA获取CardGrade信息
        /// </summary>
        /// <param name="lan">当前操作语言</param>
        /// <returns>卡级别信息</returns>
        public CardGrades[] GetCardGradeInfo(CardGradeInfoRequest request, string lan)
        {
            request.Action = "GetCardGrades";
            request.CardTypeID = 0;
            request.PageCurrent = "0";
            request.PageSize = "0";
            if (lan.ToLower() == "zh-cn") //confirm by michael he 2013-09-13
            {
                lan = "zh_CN";
            }
            else if (lan.ToLower() == "zh-hk")
            {
                lan = "zh_BigCN";
            }
            else
            {
                lan = "en_CA";
            }

            request.Language = lan;
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                string msg = JsonConvert.SerializeObject(request);
                logger.WriteOperationLog("GetCardGrades ", msg);
                //response = service.request(Encode(msg, key), key); //Removed By Robin 2015-10-15 暂时Close加密
                response = service.request(msg, key); 
                logger.WriteOperationLog("GetCardGrades Response ", response);
                CardGradeInfoResponse responseObj = GetCardGradeInfoResponse(response);
                if (responseObj != null)
                {
                    logger.WriteOperationLog("GetCardGrades ResponseCode", responseObj.ResponseCode.ToString());
                    if (responseObj.ResponseCode.Equals(0))
                    {
                        return responseObj.CardGrades;
                    }
                }
                else
                {
                    logger.WriteErrorLog("GetCardGrades", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("GetCardGrades", " error ", ex);
            }
            return new CardGrades[0];
        }

      
        public MemberCard GetMemberCardInfo(MemberCardInfoRequest request, string cardNumber, string lan)
        {
            request.Action = "GetMemberCard";
            request.CardNumber = cardNumber;
            //request.PageCurrent = "0";
            //request.PageSize = "0";
            if (lan.ToLower() == "zh-cn")
            {
                lan = "zh_CN";
            }
            else if (lan.ToLower() == "zh-hk")
            {
                lan = "zh_BigCN";
            }
            else
            {
                lan = "en_CA";
            }

            request.Language = lan;
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                string msg = JsonConvert.SerializeObject(request);
                logger.WriteOperationLog("GetMemberCard ", msg);
                response = service.request(msg, key);
                logger.WriteOperationLog("GetMemberCard Response ", response);
                MemberCardInfoResponse responseObj = GetMemberCardInfoResponse(response);
                if (responseObj != null)
                {
                    logger.WriteOperationLog("GetMemberCard ResponseCode", responseObj.ResponseCode.ToString());
                    if (responseObj.ResponseCode.Equals(0))
                    {
                        return responseObj.MemberCard;
                    }
                }
                else
                {
                    logger.WriteErrorLog("GetMemberCard", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("GetMemberCard", " error ", ex);
            }
            return new MemberCard();
        }

        public MemberInfoResponse GetMemberInfo(MemberInfoRequest request, string LoginAccountNumber, int LoginAccountType, int NoPassword, string MemberPassword, int BrandID, int OSType, string DeviceID)
        {
            request.Action = "MemberLogin_New";
            request.LoginAccountNumber = LoginAccountNumber;
            //0 : MemberRegisterMobile；1：MemberEmail；2：MemberMobileNumber； 	
            request.LoginAccountType = LoginAccountType;
            request.NoPassword = NoPassword;
            request.MemberPassword = MemberPassword;
            request.BrandID = BrandID;
            request.OSType = OSType;
            request.DeviceID = DeviceID;
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                string msg = JsonConvert.SerializeObject(request);
                logger.WriteOperationLog("MemberLogin_New ", msg);
                response = service.request(msg, key);
                logger.WriteOperationLog("MemberLogin_New Response ", response);
                MemberInfoResponse responseObj = GetMemberInfoResponse(response);
                if (responseObj != null)
                {
                    logger.WriteOperationLog("MemberLogin_New ResponseCode", responseObj.ResponseCode.ToString());
                    if (responseObj.ResponseCode.Equals(0))
                    {
                        return responseObj;
                    }
                }
                else
                {
                    logger.WriteErrorLog("MemberLogin_New", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("MemberLogin_New", " error ", ex);
            }
            return new MemberInfoResponse();
        }


        public List<GetMemberTxn> GetMemberTxnList(GetMemberTxnListRequest request, string TxnNo)
        {
            request.Action = "GetMemberTxnList";
            request.TxnNo = TxnNo;
            request.MemberID = 0;
            request.CardNumber = "";
            request.Storecode = "";
            request.StartBusDate = null;
            request.EndBusDate = null;
            request.MinTotalAmount = 0;
            request.MaxTotalAmount = 0;
            request.SalesType = 0;
            request.TxnStatus = "";
            request.PageCurrent = "0";
            request.PageSize = "0";
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                string msg = JsonConvert.SerializeObject(request);
                logger.WriteOperationLog("GetMemberTxnList", msg);
                response = service.request(msg, key);
                logger.WriteOperationLog("GetMemberTxnList Response ", response);
                GetMemberTxnListResponse responseObj = GetMemberTxnListResponse(response);
                if (responseObj != null)
                {
                    logger.WriteOperationLog("GetMemberTxnList ResponseCode", responseObj.ResponseCode.ToString());
                    if (responseObj.ResponseCode.Equals(0))
                    {
                        return responseObj.List;
                    }
                }
                else
                {
                    logger.WriteErrorLog("GetMemberTxnList", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("GetMemberTxnList", " error ", ex);
            }
            return new List<GetMemberTxn>();
        }

        public List<GetSalesTByTxnNo> GetSalesTByTxnNo(GetSalesTByTxnNoRequest request, string TxnNo)
        {
            request.Action = "GetSalesTByTxnNo";
            request.TxnNo = TxnNo;
            try
            {
                SVAWebReference.SVAWebService service = new SVAWebReference.SVAWebService();
                string response = string.Empty;
                string msg = JsonConvert.SerializeObject(request);
                logger.WriteOperationLog("GetSalesTByTxnNo", msg);
                response = service.request(msg, key);
                logger.WriteOperationLog("GetSalesTByTxnNo Response ", response);
                GetSalesTByTxnNoResponse responseObj = GetSalesTByTxnNoResponse(response);
                if (responseObj != null)
                {
                    logger.WriteOperationLog("GetSalesTByTxnNo ResponseCode", responseObj.ResponseCode.ToString());
                    if (responseObj.ResponseCode.Equals(0))
                    {
                        return responseObj.List;
                    }
                }
                else
                {
                    logger.WriteErrorLog("GetSalesTByTxnNo", " return string is empty!");
                }
            }
            catch (System.Exception ex)
            {
                logger.WriteErrorLog("GetSalesTByTxnNo", " error ", ex);
            }
            return new List<GetSalesTByTxnNo>();
        }

        private CardTypeInfoResponse GetCardTypeInfoResponse(string response)
        {
            return JsonConvert.DeserializeObject<CardTypeInfoResponse>(response);
        }

        private CardGradeInfoResponse GetCardGradeInfoResponse(string response)
        {
            return JsonConvert.DeserializeObject<CardGradeInfoResponse>(response);
        }
        private GetMemberTxnListResponse GetMemberTxnListResponse(string response)
        {
            return JsonConvert.DeserializeObject<GetMemberTxnListResponse>(response);
        }
        private MemberCardInfoResponse GetMemberCardInfoResponse(string response)
        {
            return JsonConvert.DeserializeObject<MemberCardInfoResponse>(response);
        }
        private MemberInfoResponse GetMemberInfoResponse(string response)
        {
            return JsonConvert.DeserializeObject<MemberInfoResponse>(response);
        }

        private GetSalesTByTxnNoResponse GetSalesTByTxnNoResponse(string response)
        {
            return JsonConvert.DeserializeObject<GetSalesTByTxnNoResponse>(response);
        }
    }
}