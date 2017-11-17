using System;
namespace Edge.SVA.Model
{
    /// <summary>
    /// 货品图片
    /// </summary>
    [Serializable]
    public partial class BUY_PRODUCT_PIC
    {
        public BUY_PRODUCT_PIC()
        { }
        #region Model
        private int _keyid;
        private string _prodcode;
        private string _productthumbnailsfile;
        private string _productfullpicfile;
        private string _productpicnote1;
        private string _productpicnote2;
        private string _productpicnote3;
        private int? _isVideo;
        private int? _is360Pic;
        private int? _IsSizeCategory;
        /// <summary>
        /// 自增长主键
        /// </summary>
        public int KeyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        /// <summary>
        /// 货品主键
        /// </summary>
        public string ProdCode
        {
            set { _prodcode = value; }
            get { return _prodcode; }
        }
        /// <summary>
        /// 货品缩略图
        /// </summary>
        public string ProductThumbnailsFile
        {
            set { _productthumbnailsfile = value; }
            get { return _productthumbnailsfile; }
        }
        /// <summary>
        /// 货品完整图
        /// </summary>
        public string ProductFullPicFile
        {
            set { _productfullpicfile = value; }
            get { return _productfullpicfile; }
        }
        /// <summary>
        /// 货品图片备注1
        /// </summary>
        public string ProductPicNote1
        {
            set { _productpicnote1 = value; }
            get { return _productpicnote1; }
        }
        /// <summary>
        /// 货品图片备注2
        /// </summary>
        public string ProductPicNote2
        {
            set { _productpicnote2 = value; }
            get { return _productpicnote2; }
        }
        /// <summary>
        /// 货品图片备注3
        /// </summary>
        public string ProductPicNote3
        {
            set { _productpicnote3 = value; }
            get { return _productpicnote3; }
        }
        public int? IsVideo
        {
            get { return _isVideo; }
            set { _isVideo = value; }
        }
        public int? Is360Pic
        {
            get { return _is360Pic; }
            set { _is360Pic = value; }
        }
        public int? IsSizeCategory
        {
            get { return _IsSizeCategory; }
            set { _IsSizeCategory = value; }
        }
        #endregion Model

    }
}

