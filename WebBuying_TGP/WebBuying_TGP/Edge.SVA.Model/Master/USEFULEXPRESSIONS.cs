using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 常用语表
    /// </summary>
    [Serializable]
    public partial class USEFULEXPRESSIONS
    {
        public USEFULEXPRESSIONS()
        { }
        #region Model
        private int _usefulexpressionsid;
        private string _phrasetitle1;
        private string _phrasetitle2;
        private string _phrasetitle3;
        private string _phrasecontent1;
        private string _phrasecontent2;
        private string _phrasecontent3;
        private int? _campaignid;
        private string _phrasepicfile;
        private string _code;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int USEFULEXPRESSIONSID
        {
            set { _usefulexpressionsid = value; }
            get { return _usefulexpressionsid; }
        }
        /// <summary>
        /// 标题1
        /// </summary>
        public string PhraseTitle1
        {
            set { _phrasetitle1 = value; }
            get { return _phrasetitle1; }
        }
        /// <summary>
        /// 标题2
        /// </summary>
        public string PhraseTitle2
        {
            set { _phrasetitle2 = value; }
            get { return _phrasetitle2; }
        }
        /// <summary>
        /// 标题3
        /// </summary>
        public string PhraseTitle3
        {
            set { _phrasetitle3 = value; }
            get { return _phrasetitle3; }
        }
        /// <summary>
        /// 内容1
        /// </summary>
        public string PhraseContent1
        {
            set { _phrasecontent1 = value; }
            get { return _phrasecontent1; }
        }
        /// <summary>
        /// 内容2
        /// </summary>
        public string PhraseContent2
        {
            set { _phrasecontent2 = value; }
            get { return _phrasecontent2; }
        }
        /// <summary>
        /// 内容3
        /// </summary>
        public string PhraseContent3
        {
            set { _phrasecontent3 = value; }
            get { return _phrasecontent3; }
        }
        /// <summary>
        /// 活动ID
        /// </summary>
        public int? CampaignID
        {
            set { _campaignid = value; }
            get { return _campaignid; }
        }
        /// <summary>
        /// 短语图片
        /// </summary>
        public string PhrasePicFile
        {
            set { _phrasepicfile = value; }
            get { return _phrasepicfile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        #endregion Model

    }
}