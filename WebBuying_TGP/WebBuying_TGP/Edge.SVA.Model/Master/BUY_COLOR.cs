using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 颜色表
    /// </summary>
    [Serializable]
    public partial class BUY_COLOR
    {
        public BUY_COLOR()
        { }
        #region Model
        private int _colorid;
        private string _colorcode;
        private string _colorname1;
        private string _colorname2;
        private string _colorname3;
        private string _colorpicfile;
        private DateTime? _createdon = DateTime.Now;
        private int? _createdby;
        private DateTime? _updatedon = DateTime.Now;
        private int? _updatedby;
        private string _rGB;
        /// <summary>
        ///11 主键ID
        /// </summary>
        public int ColorID
        {
            set { _colorid = value; }
            get { return _colorid; }
        }
        /// <summary>
        ///11 RGB编号。 e.g. FFFFFF
        /// </summary>
        public string ColorCode
        {
            set { _colorcode = value; }
            get { return _colorcode; }
        }
        /// <summary>
        ///11 颜色名称1
        /// </summary>
        public string ColorName1
        {
            set { _colorname1 = value; }
            get { return _colorname1; }
        }
        /// <summary>
        ///11 颜色名称2
        /// </summary>
        public string ColorName2
        {
            set { _colorname2 = value; }
            get { return _colorname2; }
        }
        /// <summary>
        ///11 颜色名称3
        /// </summary>
        public string ColorName3
        {
            set { _colorname3 = value; }
            get { return _colorname3; }
        }
        /// <summary>
        ///11 颜色图片文件
        /// </summary>
        public string ColorPicFile
        {
            set { _colorpicfile = value; }
            get { return _colorpicfile; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public DateTime? CreatedOn
        {
            set { _createdon = value; }
            get { return _createdon; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public int? CreatedBy
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public DateTime? UpdatedOn
        {
            set { _updatedon = value; }
            get { return _updatedon; }
        }
        /// <summary>
        ///11 
        /// </summary>
        public int? UpdatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        public string RGB
        {
            get { return _rGB; }
            set { _rGB = value; }
        }
        #endregion Model

    }
}

